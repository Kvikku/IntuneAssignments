using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;

namespace IntuneAssignments
{
    public partial class Settings : Form
    {

        private Form1 form1;



        public Settings(Form1 form1)
        {

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent



            this.form1 = form1;

            InitializeComponent();

        }

        public Settings()
        {

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            InitializeComponent();

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // Retrieve data from appsettings.json and populate labels

            string path = Form1.AppSettingsFile; //@"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(path)
                .Build();



            // Sets the variables to the values in the appsettings.json file
            Form1.tenantID = configuration.GetSection("Entra:TenantId").Value;
            Form1.clientID = configuration.GetSection("Entra:ClientId").Value;
            Form1.clientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            Form1.authority = $"https://login.microsoftonline.com/{Form1.tenantID}";



            tBClientID.Text = Form1.clientID;
            tBClientSecret.Text = Form1.clientSecret;
            tBTenantID.Text = Form1.tenantID;


            //lblTenantIDString.Text = tenantID;
            //lblClientIDString.Text = clientID;
            //lblClientSecretString.Text = clientSecret;

            
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

            // THIS DOES NOT WORK YET

            // Save the new settings to appsettings.json

            string path = Form1.AppSettingsFile;

            IConfigurationRoot configuration = new ConfigurationBuilder()
            //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(path)
                .Build();

            var entraSettings = configuration.GetSection("Entra");

            entraSettings["TenantId"] = tBTenantID.Text;
            entraSettings["ClientId"] = tBClientID.Text;
            entraSettings["ClientSecret"] = tBClientSecret.Text;

            

            File.WriteAllText("appsettings.json", configuration.GetDebugView());

            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Open file explorer
            System.Diagnostics.Process.Start("explorer.exe", @"C:\ProgramData\IntuneAssignments");
            this.Close();
        }


        public async Task<GraphServiceClient> testAuth()

        {

            try
            {
                var scopes = new[] { "https://graph.microsoft.com/.default" };

                var options = new ClientSecretCredentialOptions
                {
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
                };


                var credential = new ClientSecretCredential(Form1.tenantID, Form1.clientID, Form1.clientSecret, options);

                var graphClient = new GraphServiceClient(credential, scopes);

                return graphClient;
            }
            catch (Exception)
            {
                MessageBox.Show(Text = "Authentication failed. Please check your settings and try again.", "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }






        }


        public async Task checkAPIPermissions()
        {

            // Code to check if the app has the required API permissions
            // UNDER CONSTRUCTION



            var graphClient = await testAuth();


            try
            {
                var result = await graphClient.Applications.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = "appId eq 'f67679c6-4a23-42d8-84c6-bb3f9cf1f1c0'";

                });

                var appRoles = result.Value;

                if (appRoles != null)
                {
                    foreach (var appRole in appRoles)
                    {
                        Console.WriteLine($"App Role: {appRole.DisplayName}, Description: {appRole.Description}");
                    }
                }
                else
                {
                    Console.WriteLine("No app roles found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Attempt to authenticate to Graph API with the current settings


            //checkAPIPermissions();

            MessageBox.Show("Feature not implemented yet         (╯°□°)╯︵ ┻━┻");



        }
    }
}
