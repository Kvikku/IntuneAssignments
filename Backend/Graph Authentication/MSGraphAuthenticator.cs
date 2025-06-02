using Microsoft.Graph.Beta;

namespace IntuneAssignments.Backend
{

    // 15.04.2024 - Remove Nuget package Azure.Identity because it is deprecated
    // 22.01.2024 - can this now be deleted? check back later.
    // 14.03.2024 - Keeping this in case the need for client secret returns
    // Added a Z character in front of variables to prevent conflicts with other variables



    public class MSGraphAuthenticator
    {

        public static string ZclientID { get; set; }
        public static string ZtenantID { get; set; }
        public static string ZclientSecret { get; set; }
        public static string Zauthority { get; set; }

        public static string[] znewScopes = new string[]
       {
            "https://graph.microsoft.com/.default"
       };

        // Test if this works

        //public static async Task<GraphServiceClient> ZGetAuthenticatedGraphClient()
        //{
        //    try
        //    {
        //        ClientSecretCredential clientSecretCredential = new ClientSecretCredential(ZtenantID, ZclientID, ZclientSecret);
        //        GraphServiceClient graphclient = new GraphServiceClient(clientSecretCredential, znewScopes);



        //        return graphclient;

        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        throw;
        //    }

        //}



    }
}
