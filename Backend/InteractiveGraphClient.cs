using Microsoft.Graph.Beta;
using Microsoft.Identity.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using static IntuneAssignments.Backend.FormUtilities;

namespace IntuneAssignments.Backend
{


    public class GraphServiceClientCreator
    {
        public static GraphServiceClient CreateGraphServiceClient()
        {

            Console.WriteLine("Creating graph object");
            var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider());
            return new GraphServiceClient(authenticationProvider);

        }

    }

    public class TokenProvider : IAccessTokenProvider
    {

        public static bool CheckTokenLifetime(DateTimeOffset tokenExpiryTime)
        {

            // This method will be used to check the lifetime of the token

            // If the token is still valid, return true
            if (tokenExpiryTime > DateTimeOffset.UtcNow)
            {
                WriteToLog("Token is still valid. Using existing token");
                return true;
            }
            else
            {
                WriteToLog("Token is expired. Must acquire new token");
                return false;
            }

        }

        // This class will be used to provide the access token to the GraphServiceClient object interactively, with authentication done in the browser

        public static string clientID { get; set; }
        public static string tenantID { get; set; }

        public static string authority = $"https://login.microsoftonline.com/{tenantID}";

        public static string redirectUri = "http://localhost";  // Use a valid redirect URI

        public static GraphServiceClient? graphClient;

        public static string? accessToken;

        public static DateTimeOffset tokenExpirationTime;

        public static string[] newScope = new string[] { "https://graph.microsoft.com/.default" };

        public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
            CancellationToken cancellationToken = default)
        {
            var token = "";


            // check if the token is still valid
            if (tokenExpirationTime > DateTimeOffset.UtcNow)
            {
                WriteToLog("Token is still valid. Using existing token");

                return accessToken;
            }
            else
            {

                WriteToLog("Token is expired. Must acquire new token");





                var app = PublicClientApplicationBuilder
                   .Create(clientID)
                   .WithAuthority(new Uri(authority))
                   .WithRedirectUri(redirectUri)
                   .Build();

                var accounts = await app.GetAccountsAsync();



                AuthenticationResult result;
                try
                {
                    result = await app.AcquireTokenSilent(newScope, accounts.FirstOrDefault())
                        .ExecuteAsync();
                }
                catch (MsalUiRequiredException)
                {

                    try
                    {
                        result = await app.AcquireTokenInteractive(newScope)
                        .WithPrompt(Prompt.SelectAccount)
                        //.WithUseEmbeddedWebView(true)
                        //.WithEmbeddedWebViewOptions(new EmbeddedWebViewOptions() { Title = "Sign in to your account" })
                        .ExecuteAsync();
                    }
                    catch (Microsoft.Identity.Client.MsalServiceException me)
                    {
                        MessageBox.Show(me.Message);
                        throw;
                    }

                    
                }

                token = result.AccessToken;
                accessToken = result.AccessToken;

                tokenExpirationTime = result.ExpiresOn;


                return token;
            }
        }

        public AllowedHostsValidator AllowedHostsValidator { get; }
    }

}
