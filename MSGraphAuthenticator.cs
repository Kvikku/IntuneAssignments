using Azure.Identity;
using Microsoft.Graph.Beta.Models.ManagedTenants;
using Microsoft.Graph.Beta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuneAssignments
{

    /*
     * 
     * 
     * Used by pretty much all forms to create a graph service client object
     * 
     *
     */

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
