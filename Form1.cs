using System;
using System.Net;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Azure.Identity;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Principal;
using System.Threading.Tasks;

//TO DO

///// UI ///////////////////

// Flat theme
// Animations


///// Framework ////////////

// Everything as simple methods

///// Functionality /////

// List all assignments with intent for an application
// Add one or more assignments with intent for an application
// Delete one or more assignments for an application



namespace IntuneAssignments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Global variables //

        string clientID = "f67679c6-4a23-42d8-84c6-bb3f9cf1f1c0";
        string tenantID = "18456af8-4036-4e1c-b888-43e04c49046a";
        string clientSecret = "";
        string[] scopes = new string[] { "Calendars.Read", "Calendars.ReadWrite" };
        string GraphEndpoint = "https://graph.microsoft.com/v1.0";
        string accessToken = "";

        private void Form1_Load(object sender, EventArgs e)
        {

            
            

        }




        // Methods //

        ////////////////////////////////////////////// Authentication ///////////////////////////////////////////////


        /// With client secret ///////////////////////////////////////////////////////////////////////////////////////
        private async Task AuthenticateToGraph()
        {
            // NOT CURRENTLY IN USE //

            InteractiveBrowserCredential interactiveBrowserCredential = new InteractiveBrowserCredential();
            var graphClient = new GraphServiceClient(interactiveBrowserCredential);

            InteractiveBrowserCredentialOptions options = new InteractiveBrowserCredentialOptions();

            try
            {
                // Make a call to Microsoft Graph to confirm that authentication was successful
                var me = await graphClient.Me
                    .Request()
                    .GetAsync();

                var tenantInfo = await graphClient.Organization
                    .Request()
                    .Select("ID")
                    .GetAsync();
                
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo);

                foreach (var org in organizations)
                {
                    
                    tenantID= org.Id;
                    lblTenantID.Text = "Tenant ID: " + tenantID;
                }

                lblSignedInUser.Text = "Signed in as " + me.DisplayName;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error authenticating: " + ex.Message);
            }
        }

        // With username and password ///////////////////////////////////////////////////////////////////////////////
        public async Task authMSAL()
        {
            
            // Authenticates with a user log in, and saves the access token in a variable for future use
            try
            {
                var app = PublicClientApplicationBuilder.Create(clientID)
                           .WithAuthority(AzureCloudInstance.AzurePublic, tenantID)
                           .Build();

                var result = await app.AcquireTokenInteractive(scopes)
                                       .WithUseEmbeddedWebView(true)
                                       .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                                       .ExecuteAsync();

                accessToken = result.AccessToken;

                
            }
            catch (Exception errorMsg )
            {

                MessageBox.Show(errorMsg.Message);
            }
        }


        public GraphServiceClient GetGraphClient()
        {

            // Creates a reusable graph service client object
            // Requires authentication to already be done

            try
            {
                return new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", accessToken);

                        return Task.FromResult(0);
                    }));
            }
            catch (Exception errorMsg)
            {
                MessageBox.Show(errorMsg.Message);

                throw;
            }

            
            
            
        }


        private async void testBtn_Click(object sender, EventArgs e)
        {
            var graphClient = GetGraphClient();

            var users = await graphClient.Me
                .Request()
                .GetAsync();

            MessageBox.Show(users.DisplayName);

        }



        //TODO
        // Fix try catch and check for if the session is authentictated properly. handle errors

        

        public async void updateTenantInfo()
        {
            // Make a call to Microsoft Graph
            var graphClient = GetGraphClient();

            

            var tenantInfo = await graphClient.Organization
                    .Request()
                    .Select("ID")
                    .GetAsync();

            List<Organization> organizations = new List<Organization>();
            organizations.AddRange(tenantInfo);

            foreach (var org in organizations)
            {

                tenantID = org.Id;
                lblTenantID.Text = "Tenant ID: " + tenantID;
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // TODO 
            // Rename button click event to reflect updated name of the button
            
            await authMSAL();

            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Use the result to create a GraphServiceClient
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", accessToken);

                        return Task.FromResult(0);
                    }));
        }


    }
    }
