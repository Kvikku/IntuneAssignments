using Azure.Identity;
using Microsoft.Graph.Beta;

namespace IntuneAssignments
{

    // 22.01.2024 - can this now be deleted? check back later.



    public  class MSGraphAuthenticator
    {
        
        public static string clientID { get; set; }
        public static string tenantID { get; set; }
        public static string clientSecret { get; set; }
        public static string authority { get; set; }

        public static string[] newScopes = new string[]
       {
            "https://graph.microsoft.com/.default"
       };

        // Test if this works

        public static async Task<GraphServiceClient> GetAuthenticatedGraphClient()
        {
            try
            {
                ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantID, clientID, clientSecret);
                GraphServiceClient graphclient = new GraphServiceClient(clientSecretCredential, newScopes);



                return graphclient;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw;
            }

        }



    }
}
