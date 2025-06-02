using Microsoft.Graph.Beta;
using Microsoft.Identity.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static IntuneAssignments.Backend.Utilities.FormUtilities;

namespace IntuneAssignments.Backend
{
    public class DestinationTenantGraphClient
    {
        public static string destinationAuthority = $"https://login.microsoftonline.com/{destinationTenantID}";
        public static string destinationClientID { get; set; }
        public static string destinationTenantID { get; set; }

        public static string redirectUri = "http://localhost";  // Use a valid redirect URI

        public static string[] destinationScope = new string[] { "https://graph.microsoft.com/.default" };

        public static GraphServiceClient destinationGraphServiceClient;

        public static string? destinationAccessToken;
        public static DateTimeOffset destinationTokenExpirationTime;

        public static GraphServiceClient CreateGraphServiceClient()
        {
            Console.WriteLine("Creating graph object");
            var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new DestinationTokenProvider());
            return new GraphServiceClient(authenticationProvider);
        }

        public static async Task<GraphServiceClient> GetDestinationGraphClient()
        {
            try
            {
                var app = PublicClientApplicationBuilder
                    .Create(destinationClientID)
                    .WithAuthority(new Uri(destinationAuthority))
                    .WithRedirectUri(redirectUri)
                    .Build();

                var accounts = await app.GetAccountsAsync();
                AuthenticationResult result;

                if (!accounts.Any())
                {
                    result = await app.AcquireTokenInteractive(destinationScope)
                        .WithPrompt(Prompt.SelectAccount)
                        .WithExtraScopesToConsent(destinationScope) // Add this line to consent to all scopes
                        .ExecuteAsync();
                }
                else
                {
                    try
                    {
                        result = await app.AcquireTokenSilent(destinationScope, accounts.FirstOrDefault())
                            .ExecuteAsync();
                    }
                    catch (MsalUiRequiredException)
                    {
                        result = await app.AcquireTokenInteractive(destinationScope)
                            .WithPrompt(Prompt.SelectAccount)
                            .WithExtraScopesToConsent(destinationScope) // Add this line to consent to all scopes
                            .ExecuteAsync();
                    }
                }

                destinationAccessToken = result.AccessToken;
                destinationTokenExpirationTime = result.ExpiresOn;

                var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new DestinationTokenProvider());
                return new GraphServiceClient(authenticationProvider);
            }
            catch (Exception ex)
            {
                WriteToLog($"Error acquiring token: {ex.Message}");
                throw;
            }
        }

        public class DestinationTokenProvider : IAccessTokenProvider
        {
            public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
                CancellationToken cancellationToken = default)
            {
                var token = "";

                // check if the token is still valid
                if (destinationTokenExpirationTime > DateTimeOffset.UtcNow)
                {
                    WriteToLog("Token is still valid. Using existing token");
                    return destinationAccessToken;
                }
                else
                {
                    WriteToLog("Token is expired. Must acquire new token");

                    var app = PublicClientApplicationBuilder
                       .Create(destinationClientID)
                       .WithAuthority(new Uri(destinationAuthority))
                       .WithRedirectUri(redirectUri)
                       .Build();

                    var accounts = await app.GetAccountsAsync();

                    AuthenticationResult result;
                    try
                    {
                        result = await app.AcquireTokenSilent(destinationScope, accounts.FirstOrDefault())
                            .ExecuteAsync();
                    }
                    catch (MsalUiRequiredException)
                    {
                        try
                        {
                            result = await app.AcquireTokenInteractive(destinationScope)
                            .WithPrompt(Prompt.SelectAccount)
                            .ExecuteAsync();
                        }
                        catch (Microsoft.Identity.Client.MsalServiceException me)
                        {
                            MessageBox.Show(me.Message);
                            throw;
                        }
                    }

                    token = result.AccessToken;
                    destinationAccessToken = result.AccessToken;
                    destinationTokenExpirationTime = result.ExpiresOn;

                    return token;
                }
            }

            public AllowedHostsValidator AllowedHostsValidator { get; }
        }
    }
}
