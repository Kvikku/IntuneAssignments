using Microsoft.Graph.Beta;
using Microsoft.Identity.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IntuneAssignments.FormUtilities;

namespace IntuneAssignments
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


        
        
        public bool CheckTokenLifetime(DateTimeOffset tokenExpiryTime)
        {

            // This method will be used to check the lifetime of the token

            // If the token is still valid, return true
            if (tokenExpiryTime > DateTimeOffset.UtcNow)
            {
                return true;
            }
            else
            {
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
            if (tokenExpirationTime > DateTimeOffset.UtcNow.AddMinutes(5))
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
                    result = await app.AcquireTokenInteractive(newScope)
                        .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                        .ExecuteAsync();
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
