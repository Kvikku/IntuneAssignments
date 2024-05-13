﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static IntuneAssignments.Backend.GlobalVariables;
using static IntuneAssignments.Backend.FormUtilities;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.TokenProvider;
using IntuneAssignments.Backend;



namespace IntuneAssignments
{
    public partial class Settings : Form
    {

        private Application form1;

        


        public Settings(Application form1)
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
            //LoadData();
            
        }

        private JObject json;
        
        private void LoadData()
        {
            try
            {
                string filepath = appSettingsFile;
                string jsonstring = System.IO.File.ReadAllText(filepath);
                
                //MessageBox.Show(jsonstring);

                json = JObject.Parse(jsonstring);

                foreach (var tenant in json)
                {
                    cBTenant.Items.Add(tenant.Key);

                    WriteToLog("Found tenant: " + tenant.Key + " with tenant ID: " + tenant.Value["TenantId"] + " and client ID: " + tenant.Value["ClientId"] + " in the JSON file");
                }

                // Set first value in the combobox
                cBTenant.SelectedIndex = 0;

                var tenantName = cBTenant.SelectedItem.ToString();
                tBTenantName.Text = tenantName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

       

        private void cBTenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBTenant.SelectedIndex != -1)
            {
                string selectedTenant = cBTenant.SelectedItem.ToString();
                JObject tenantDetails = (JObject)json[selectedTenant];

                string tenantId = (string)tenantDetails["TenantId"];
                string clientId = (string)tenantDetails["ClientId"];

                tBTenantID.Text = tenantId;
                tBClientID.Text = clientId;
                tBTenantName.Text = selectedTenant;

                TokenProvider.tenantID = tenantId;
                TokenProvider.clientID = clientId;
                authority = $"https://login.microsoftonline.com/{tenantId}";

                WriteToLog("Switched to tenant " + selectedTenant + " with tenant ID: " + tenantId + " and client ID: " + clientId);

                // clear token

                accessToken = null;

                // Set token expiration time to 5 minutes ago to force a new token to be acquired
                tokenExpirationTime = DateTime.Now.AddMinutes(-5);

            }
        }


        private void Settings_Load(object sender, EventArgs e)
        {

            // These are no longer used, but I'm keeping them here for now in case I need them later
            lblClientSecret.Hide();
            tBClientSecret.Hide();

            LoadData();
            


            WriteToLog("Attempting to load authentication info from appsettings.json");



            // Retrieve data from appsettings.json and populate labels
            //string path = appSettingsFile; //@"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile(path)
            //    .Build();
            // Sets the variables to the values in the appsettings.json file
            //tenantID = configuration.GetSection("Entra:TenantId").Value;
            //clientID = configuration.GetSection("Entra:ClientId").Value;
            //clientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            //authority = $"https://login.microsoftonline.com/{tenantID}";
            //tBClientID.Text = clientID;
            //tBClientSecret.Text = clientSecret;
            //tBTenantID.Text = tenantID;
            //lblTenantIDString.Text = tenantID;
            //lblClientIDString.Text = clientID;
            //lblClientSecretString.Text = clientSecret;
        }

        private void saveSettingsNew()
        {

            WriteToLog("Saving settings to appsettings.json");

            // Save the new settings to appsettings.json

            string jsonString = File.ReadAllText(appSettingsFile);
            JObject json = JObject.Parse(jsonString);

            string tenantName = tBTenantName.Text;
            string tenantId = tBTenantID.Text;
            string clientId = tBClientID.Text;

            if(json.ContainsKey(tenantName))
            {
                json[tenantName]["TenantId"] = tenantId;
                json[tenantName]["ClientId"] = clientId;
            }
            else
            {
                WriteToLog("Tenant " + tenantName + " does not exist in the JSON file. Adding new tenant to the JSON file");

                json.Add(tenantName, new JObject
                {
                    { "TenantId", tenantId },
                    { "ClientId", clientId }
                });
            }

            File.WriteAllText(appSettingsFile, json.ToString(Formatting.Indented));




            // Update global variables so that the rest of the application can use the new settings

            TokenProvider.tenantID = tBTenantID.Text;
            TokenProvider.clientID = tBClientID.Text;
            //clientSecret = tBClientSecret.Text;
            TokenProvider.authority = $"https://login.microsoftonline.com/{TokenProvider.tenantID}";
        }

        private void saveSettings()
        {

            WriteToLog("Saving settings to appsettings.json");

            // Save the new settings to appsettings.json

            string originalPath = appSettingsFile;

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(originalPath)
                .Build();

            var entraSettings = configuration.GetSection("Entra");

            entraSettings["TenantId"] = tBTenantID.Text;
            entraSettings["ClientId"] = tBClientID.Text;
            //entraSettings["ClientSecret"] = tBClientSecret.Text;

            // Update global variables so that the rest of the application can use the new settings



            TokenProvider.tenantID = tBTenantID.Text;
            TokenProvider.clientID = tBClientID.Text;
            //clientSecret = tBClientSecret.Text;
            TokenProvider.authority = $"https://login.microsoftonline.com/{TokenProvider.tenantID}";




            if (cBSaveSettings.Checked == true)
            {
                // User choose to save the settings to the appsettings file

                WriteToLog("User chose to save the settings to the appsettings file");

                // Save the new settings to the global variables

                WriteToLog("Saving the new settings to the global variables");


                // Create a JSON object to represent the configuration data
                var jsonConfig = new JObject();
                jsonConfig["Entra"] = new JObject
                {
                    { "TenantId", entraSettings["TenantId"] },
                    { "ClientId", entraSettings["ClientId"] },
                    //{ "ClientSecret", entraSettings["ClientSecret"] }
                };

                // Serialize the JSON object to a formatted string
                string updatedJson = jsonConfig.ToString(Formatting.Indented);

                // Write the updated JSON string back to the original file
                File.WriteAllText(originalPath, updatedJson);

            }
            else if (cBSaveSettings.Checked == false)
            {
                // Do nothing

                WriteToLog("User chose not to save the settings to the appsettings file");
            }
        }


        private void CheckConnection()
        {
            // Call check connection method in homepage form to verify that the new settings work

            HomePage homePage = System.Windows.Forms.Application.OpenForms["HomePage"] as HomePage;
            homePage?.checkConnectionStatus();
        }


        public static async Task AuthenticateToGraph()
        {

            // First check if there exist a token that is valid
            if ((CheckTokenLifetime(tokenExpirationTime)) == true)
            {

                // Token is still valid. No need to re-authenticate


            }
            else if ((CheckTokenLifetime(tokenExpirationTime)) == false)
            {

                // Token has expired. Must acquire new token.

                // Create a Graph client 
                var graphClient = CreateGraphServiceClient();

                // Get the signed-in user's profile
                var user = await graphClient.Me.GetAsync();

            }






            //MessageBox.Show(user.DisplayName);

        }


        private async void btnOK_Click(object sender, EventArgs e)
        {

            if (cBSaveSettings.Checked == true)
            {
                saveSettingsNew();
            }



            await AuthenticateToGraph();


            CheckConnection();



            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {

            WriteToLog("Opening the configuration folder");

            // Open file explorer
            System.Diagnostics.Process.Start("explorer.exe", appDataFolder);
        }





        public async Task checkAPIPermissions()
        {

            // Code to check if the app has the required API permissions
            // UNDER CONSTRUCTION

            await AuthenticateToGraph();

            // look up the permissions for the app


        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Attempt to authenticate to Graph API with the current settings

            WriteToLog("Attempting to authenticate to Graph API with the current settings");
            WriteToLog("NOTE - This method is currently not implemented");

            //checkAPIPermissions();

            MessageBox.Show("Feature not implemented yet         (╯°□°)╯︵ ┻━┻");



        }


    }
}
