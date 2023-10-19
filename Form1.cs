using System;
using System.Net;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using Microsoft.Graph.Core;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Azure.Identity;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Principal;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using Windows.Foundation.Metadata;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.TenantRelationships.ManagedTenants.ManagementActionTenantDeploymentStatuses.MicrosoftGraphManagedTenantsChangeDeploymentStatus;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.DataFormats;

//TO DO


///// Nice to haves /////

// Handle errors when deploying to already assigned groups (Currently this is not a issue, because existing assignments is not deleted. consider if it is necessary to notify of existing assignments)
// Handle All Users and All Devices virtual groups
// Delete policy assignments
// Warning prompts
// Confirmations
// append or replace description
// Warning when deploying large amount of groups and/or apps - could take up to 1 minutes before it shows up in the portal
// VPP apps - modify query
// Logging to log file
// Assignment options (End User Notifications, Availability, Deadline)
// Different needs for each app type (VPP, Win32, MGP, etc)



// Create list for 1.1 release

// Check if API permissions are OK and overkill
// Logging to log file


// Create list for 1.0 release:

// OK - Test on different tenants
// OK - Need to create a guide for users to create an app registration and give it the correct permissions
// OK - Need to store authentication information in a file
// OK - Need to ask user if he wants to save the information
// OK - Need to have indicator of if tenant connection is OK
// Finish github instructions








namespace IntuneAssignments
{
    public partial class Form1 : Form
    {



        // Global variables //
        public event EventHandler pbCheckConnectionClickSimulated;
        bool sideBarExpandTimer = false;
        int col = -1;
        int row = -1;
        public static string clientID { get; set; }
        public static string tenantID { get; set; }
        public static string clientSecret { get; set; }
        public static string authority { get; set; }

        public static string[] scopes = new[] { "DeviceManagementApps.ReadWrite.All", "DeviceManagementServiceConfig.Read.All", "DeviceManagementConfiguration.Read.All",
        "Directory.Read.All", "DeviceManagementConfiguration.ReadWrite.All" };
        string GraphEndpoint = "https://graph.microsoft.com/v1.0";
        public static string[] newScopes = new string[]
        {
            "https://graph.microsoft.com/.default"
        };
        string accessToken = "";
        public static string configurationFolder = @"C:\ProgramData\IntuneAssignments";
        public static string AppSettingsFile = @"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";
        public static string GraphAccessToken { get; set; }
        public static Point Form1Location { get; set; }
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer buttonGrowTimer;
        private int sizeIncrement = 10;
        private int growthDuration = 1000;
        private int timerCount = 1;
        private Size OriginalLoginButtonSize = Size.Empty;


        //public MSGraphAuthenticator graphAuthenticator { get; set; }


        public Form1()
        {

            // change the application icon and use the ico file in resources folder


            InitializeComponent();
            txtboxSearchApp.KeyDown += TxtboxSearchApp_KeyDown;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // Hides the login panel during application launch
            //HidePanel(panelTenantInfo);
            //HidePanel(menuPanel);
            //delayLoginAnimation();

            // Hides default text on labels

            // add data to dtgdisplayapp

            createConfigurationFolder();
            createConfigurationFiles();


            lblSignedInUser.Text = "You are not signed in!";
            lblTenantID.Text = "";
            lblConnectionStatus.Text = "";
            lblTenantName.Text = "";



            tstbtn001.Hide();

            //pnlIntent.Hide();
            //pnlSearchApp.Hide();
            //pnlSearchGroup.Hide();
            //panelSummary.Hide();

            cBAppType.Text = "All platforms";

            // Remove this to authenticate as a user
            panelTenantInfo.Hide();

            // This code is not necessary as long as client credential provider is used as the authentication method

            //// Creates a timer to have the animation trigger after 3 seconds
            //animationTimer = new System.Windows.Forms.Timer();
            //animationTimer.Interval = 3000;
            //animationTimer.Tick += Timer_Tick;
            //animationTimer.Start();


            //// Creates a timer to animate the login button

            //buttonGrowTimer = new System.Windows.Forms.Timer();
            //buttonGrowTimer.Interval = 16;
            //buttonGrowTimer.Tick += ButtonTimer_Tick;


            // Load authentication settings from appsettings.json file
            loadAuthenticationInfo();

            checkConnectionStatus();
        }




        private void showPolicyAssignment()
        {

            // Switches to policy assignment form, and keeps the location of this form

            Form1Location = Location;

            this.Hide();
            Policy policy = new Policy(this);
            policy.Show();


        }

        private void showViewAssignment()
        {
            // Switches to View Assignment form, and keeps the location of this form

            Form1Location = Location;
            this.Hide();
            ViewAssignment viewAssignment = new ViewAssignment(this);
            viewAssignment.Show();

        }

        ////////////////////////////////////////// Classes ///////////////////////////////////////////////////////////////////

        public class MobileAppInfo
        {
            public string Id { get; set; }
            public string DisplayName { get; set; }
        }

        public class GroupInfo
        {
            public string Id { get; set; }
            public string DisplayName { get; set; }
        }

        public class EntraConfiguration
        {
            // IS THIS REQUIRED?

            public string TenantId { get; set; }
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }

        }



        // Methods //

        ////////////////////////////////////////////// Authentication ///////////////////////////////////////////////



        public async Task authMSAL()
        {

            // THIS CODE IS NOT NECESSARY WHEN CLIENT CREDENTIAL PROVIDER IS THE AUTHENTICATION METHOD IN USE

            // Authenticates with a user log in, and saves the access token in a variable for future use
            // Other methodes requires this access token to be created, so this should be the first thing the user does
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

                GraphAccessToken = accessToken;

            }
            catch (Exception errorMsg)
            {

                MessageBox.Show(errorMsg.Message);
            }
        }




        //public GraphServiceClient NewGetGraphClient(string SharedAccessToken)
        //{
        //    try
        //    {
        //        return new GraphServiceClient(
        //        new DelegateAuthenticationProvider(
        //            (requestMessage) =>
        //            {
        //                requestMessage.Headers.Authorization =
        //                    new AuthenticationHeaderValue("bearer", SharedAccessToken);

        //                return Task.FromResult(0);
        //            }));
        //    }
        //    catch (Exception errorMsg)
        //    {
        //        MessageBox.Show(errorMsg.Message);

        //        throw;
        //    }
        //}



        public class MSGraphAuthenticator
        {

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




        /// ////////////////////////////////////// Configuration /////////////////////////////////////////////////////

        private async Task checkConnectionStatus()
        {

            // Checks if the authentication info in appsettings.json file grants access to Microsoft Graph

            try
            {

                // Create a graph service client object
                var graphClient = await MSGraphAuthenticator.GetAuthenticatedGraphClient();

                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Organization.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                });

                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo.Value);

                // display tenant name in message box



                // THIS DOESNT WORK YET
                pBConnectionStatus.Image = Properties.Resources.check;
                lblConnectionStatus.Text = "Connected to: ";
                lblTenantName.Text = organizations[0].DisplayName;

                //MessageBox.Show("You are connected to" + "\n" + organizations[0].DisplayName + "\n" + organizations[0].Id);

            }
            catch (Exception ex)
            {
                //Do nothing

                //MessageBox.Show(ex.Message);
                pBConnectionStatus.Image = Properties.Resources.cancel;
                lblConnectionStatus.Text = "Not connected";
            }


        }

        private void loadAuthenticationInfo()
        {

            // Reads the appsettings.json file and stores the information in variables

            string path = Form1.AppSettingsFile; //@"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();


            // Sets the variables to the values in the appsettings.json file

            Form1.tenantID = configuration.GetSection("Entra:TenantId").Value;
            Form1.clientID = configuration.GetSection("Entra:ClientId").Value;
            Form1.clientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            Form1.authority = $"https://login.microsoftonline.com/{Form1.tenantID}";


            // Testing only
            // MessageBox.Show(tenantID + "\n" + clientID + "\n" + clientSecret + "\n" + authority); 
        }


        public void SimulatePictureBoxClick()
        {
            checkConnectionStatus();
        }

        private void createConfigurationFolder()
        {
            // Create a folder in ProgramData to store configuration files


            // Check if the folder in configurationFolder variable exists
            if (!System.IO.Directory.Exists(configurationFolder))
            {
                // If it does not exist, create it
                System.IO.Directory.CreateDirectory(configurationFolder);

            }
        }

        private void createConfigurationFiles()
        {
            // Create configuration files in the configuration folder

            // check if the configuration file already exists
            if (!System.IO.File.Exists(AppSettingsFile))
            {
                string AppSettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json");
                string destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "IntuneAssignments");
                string destinationFilePath = Path.Combine(destinationDirectory, "AppSettings.json");
                File.Copy(AppSettingsFile, destinationFilePath, false);  // The 'true' argument allows overwriting if the file already exists
            }

            // does nothing if the file already exists
        }


        private void checkConfigurationSettings()
        {

            // Checks if configuration settings are present in the configuration file


            IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(AppSettingsFile)
                .Build();


            // Sets the variables to the values in the appsettings.json file
            tenantID = configuration.GetSection("Entra:TenantId").Value;
            clientID = configuration.GetSection("Entra:ClientId").Value;
            clientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            authority = $"https://login.microsoftonline.com/{tenantID}";

            if (string.IsNullOrEmpty(tenantID) || string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(clientSecret))
            {


                // open file explorer if user clicks yes. If user clicks no, do nothing
                DialogResult dialogResult = MessageBox.Show("Some authentication info appears to be missing. Please check the information in the AppSettings.json file. Do you want to open the containing folder?", "Open configuration folder", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Open file explorer
                    System.Diagnostics.Process.Start("explorer.exe", configurationFolder);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            else
            {

                // Do nothing


            }

        }


        private void startButtonAnimation()
        {
            // Calculate the number of iterations based on growth duration and interval

            int iterations = growthDuration / 500;


            // Create a timer with an interval of 16 milliseconds

            buttonGrowTimer = new System.Windows.Forms.Timer();
            buttonGrowTimer.Interval = 16;
            buttonGrowTimer.Tick += ButtonTimer_Tick;

            buttonGrowTimer.Start();

            // Start the timer


        }

        private void ButtonTimer_Tick(object sender, EventArgs eventArgs)
        {
            // Increase the button's size
            SignIn.Size = new Size(SignIn.Width + sizeIncrement, SignIn.Height + sizeIncrement);

            // Calculate the total growth duration
            int totalDuration = (buttonGrowTimer.Interval * timerCount);

            if (totalDuration >= growthDuration)
            {
                buttonGrowTimer.Stop();

                buttonGrowTimer.Tick -= ButtonTimer_Tick;
                buttonGrowTimer.Tick += buttonShrinkTimer_Tick;
                buttonGrowTimer.Start();
            }

            timerCount++;
        }

        private void buttonShrinkTimer_Tick(object sender, EventArgs E)
        {

            SignIn.Size = new Size(SignIn.Width - sizeIncrement, SignIn.Height - sizeIncrement);

            // Check if the button has reached its original size
            if (SignIn.Width <= 126 || SignIn.Height <= 41)
            {
                // Stop the timer
                buttonGrowTimer.Stop();

                // Enable the button
                buttonGrowTimer.Enabled = true;
            }
        }

        private void delayLoginAnimation()
        {
            // Opens the sidebar 
            sideBarTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer to prevent further ticks
            animationTimer.Stop();

            // Call your method here
            delayLoginAnimation();
        }

        public async void updateTenantInfoWithoutUser()
        {

            try
            {

                // Create a graph service client object
                var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();



                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Result.Organization.GetAsync((requestConfiguration) =>
                {
                    //requestConfiguration.QueryParameters.Select = new string[] { "id" };
                });


                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo.Value);


                // Loop through the list
                // NOTE - this could be improved. There is room for error if the query returns more than 1 result
                foreach (var org in organizations)
                {
                    lblTenantID.Text = "Tenant ID: " + org.Id;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error authenticating to Microsoft Graph. Please try again");
                //MessageBox.Show(ex.Message);
                {

                }

            }

        }

        public async void updateTenantInfo()
        {

            try
            {

                // Create a graph service client object
                var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();


                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Result.Organization.GetAsync((requestConfiguration) =>
                {
                    //requestConfiguration.QueryParameters.Select = new string[] { "id" };
                });




                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo.Value);

                // Loop through the list
                // NOTE - this could be improved. There is room for error if the query returns more than 1 result
                foreach (var org in organizations)
                {
                    lblSignedInUser.Text = "Tenant: " + org.DisplayName;
                    lblTenantID.Text = "Tenant ID: " + org.Id;
                }


                // THIS NEEDS FIXING

                // Make a call to Microsoft Graph to find logged in users display name
                //var result = await graphClient.Result.Me.GetAsync((requestConfiguration) =>
                //{
                //  requestConfiguration.QueryParameters.Select = new string[] { "displayName" };
                //});


                //lblSignedInUser.Text = result.DisplayName.ToString();
                //lblSignedInUser.Show();


                sideBarTimer.Start();


                pnlIntent.Show();
                pnlSearchApp.Show();
                pnlSearchGroup.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error authenticating to Microsoft Graph. Please try again");
                //MessageBox.Show(ex.Message);
            }









        }

        public void ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public void ClearCheckedListBox(CheckedListBox checkedListBox)
        {

            checkedListBox.Items.Clear();

        }


        public void ClearRichTextBox(RichTextBox richTextBox)
        {

            richTextBox.Clear();

        }


        public async void ListAllApps()
        {

            ClearDataGridView(dtgDisplayApp);
            ClearCheckedListBox(clbAppAssignments);

            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            var selectedPlatform = cBAppType.Text;



            // Make a call to Microsoft Graph
            var allApplications = await graphClient.Result.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "displayName", "id" };
            });

            // Put result into a list for easy processing
            List<MobileApp> listAllApplications = new List<MobileApp>();
            listAllApplications.AddRange(allApplications.Value);






            // Check cBAppType.text. List only items with corresponding platform

            if (cBAppType.Text == "Android")
            {
                foreach (var result in listAllApplications)
                {
                    // Need to translate odatatype to actual platform name
                    var platForm = FindAppPlatform(result.OdataType.ToString());

                    if (platForm == "Android")
                    {
                        dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                    }
                }



            }

            if (cBAppType.Text == "iOS")
            {
                foreach (var result in listAllApplications)
                {
                    // Need to translate odatatype to actual platform name
                    var platForm = FindAppPlatform(result.OdataType.ToString());

                    if (platForm == "iOS")
                    {
                        dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                    }
                }

            }

            if (cBAppType.Text == "Windows")
            {
                foreach (var result in listAllApplications)
                {
                    // Need to translate odatatype to actual platform name
                    var platForm = FindAppPlatform(result.OdataType.ToString());

                    if (platForm == "Windows")
                    {
                        dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                    }
                }


            }

            if (cBAppType.Text == "macOS")
            {
                foreach (var result in listAllApplications)
                {
                    // Need to translate odatatype to actual platform name
                    var platForm = FindAppPlatform(result.OdataType.ToString());

                    if (platForm == "macOS")
                    {
                        dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                    }
                }

            }

            if (cBAppType.Text == "All platforms")
            {

                // Searching for all types of apps

                foreach (var result in listAllApplications)
                {


                    // Need to translate odatatype to actual platform name
                    var platForm = FindAppPlatform(result.OdataType.ToString());

                    dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                }


            }

        }


        public string FindAppPlatform(string odatatype)
        {

            // Translates odatatype property to human readable platform name for display in datagridview

            string[] Windows = { "#microsoft.graph.win32LobApp", "#microsoft.graph.officeSuiteApp", "#microsoft.graph.microsoftStoreForBusinessApp", "#microsoft.graph.winGetApp" };
            string[] Android = { "#microsoft.graph.managedAndroidStoreApp", "androidStoreApp" };
            string[] iOS = { "#microsoft.graph.managedIOSStoreApp", "iosStoreApp", "#microsoft.graph.iosVppApp" };
            string[] macoS = { "#microsoft.graph.macOSOfficeSuiteApp", "macOSMicrosoftEdgeApp" };

            // search for odatatype in arrays and returns the platform name
            if (Windows.Contains(odatatype))
            {
                return "Windows";
            }
            else if (Android.Contains(odatatype))
            {
                return "Android";
            }
            else if (iOS.Contains(odatatype))
            {
                return "iOS";
            }
            else if (macoS.Contains(odatatype))
            {
                return "macOS";
            }
            else
            {
                return "Unknown app type";
            }
        }



        public async void ListAllGroups()
        {
            ClearDataGridView(dtgDisplayGroup);
            ClearCheckedListBox(clbGroupAssignment);

            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            var groups = await graphClient.Result.Groups
                .GetAsync();


            List<Group> listAllGroups = new List<Group>();
            listAllGroups.AddRange(groups.Value);

            foreach (var group in listAllGroups)
            {
                dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
            }
        }
        public async void SearchForGroup()
        {
            ClearDataGridView(dtgDisplayGroup);
            ClearCheckedListBox(clbGroupAssignment);

            string searchQuery = txtboxSearchGroup.Text;


            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();


            // Construct group query


            // Make a call to Microsoft Graph
            var allGroups = await graphClient.Result.Groups.GetAsync((requestConfiguration) =>
            {

                // This cannot be this easy, lol 

                requestConfiguration.QueryParameters.Search = "\"displayName:" + searchQuery + "\"";
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });


            // Make a list of all returned groups from the search
            List<Group> groups = new List<Group>();
            groups.AddRange(allGroups.Value);

            foreach (var group in groups)
            {
                dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
                //clbGroupAssignment.Items.Add(group.DisplayName);
            }
        }
        public async void SearchForApp()
        {
            ClearCheckedListBox(clbAppAssignments);
            ClearDataGridView(dtgDisplayApp);

            string searchquery = txtboxSearchApp.Text;


            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            // Make a call to Microsoft Graph
            var allApplications = await graphClient.Result.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Search = searchquery;
            });


            // Put result into a list for easy processing
            List<MobileApp> searchResult = new List<MobileApp>();
            searchResult.AddRange(allApplications.Value);

            int numberOfAppsFound = searchResult.Count;

            if (numberOfAppsFound == 0)

            {

                MessageBox.Show("No applications found containing " + searchquery);

            }

            else if (numberOfAppsFound > 0)

            {

                // Check cBAppType.text. List only items with corresponding platform

                if (cBAppType.Text == "Android")
                {
                    foreach (var result in searchResult)
                    {
                        // Need to translate odatatype to actual platform name
                        var platForm = FindAppPlatform(result.OdataType.ToString());

                        if (platForm == "Android")
                        {
                            dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                        }
                    }



                }

                if (cBAppType.Text == "iOS")
                {
                    foreach (var result in searchResult)
                    {
                        // Need to translate odatatype to actual platform name
                        var platForm = FindAppPlatform(result.OdataType.ToString());

                        if (platForm == "iOS")
                        {
                            dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                        }
                    }

                }

                if (cBAppType.Text == "Windows")
                {
                    foreach (var result in searchResult)
                    {
                        // Need to translate odatatype to actual platform name
                        var platForm = FindAppPlatform(result.OdataType.ToString());

                        if (platForm == "Windows")
                        {
                            dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                        }
                    }


                }

                if (cBAppType.Text == "macOS")
                {
                    foreach (var result in searchResult)
                    {
                        // Need to translate odatatype to actual platform name
                        var platForm = FindAppPlatform(result.OdataType.ToString());

                        if (platForm == "macOS")
                        {
                            dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                        }
                    }

                }

                if (cBAppType.Text == "All types (BETA)")
                {

                    // Searching for all types of apps

                    foreach (var result in searchResult)
                    {


                        // Need to translate odatatype to actual platform name
                        var platForm = FindAppPlatform(result.OdataType.ToString());

                        dtgDisplayApp.Rows.Add(result.DisplayName, platForm);
                    }


                }





            }

        }
        public void HidePanel(Panel panel)
        {

            if (panel.Visible == true)
            {
                panel.Visible = false;


            }
            else if (panel.Visible == false)
            {
                panel.Visible = true;
            }


        }

        public void SummarizeAssignments()
        {

            foreach (object apps in clbAppAssignments.Items)
            {
                rtbSummarizeApps.AppendText(apps.ToString() + "\n");
            }

            foreach (object groups in clbGroupAssignment.Items)
            {
                rtbSummarizeGroups.AppendText(groups.ToString() + "\n");
            }

            if (rbtnAvailable.Checked)
            {
                rtbSummarizeIntent.Clear();
                rtbSummarizeIntent.AppendText(rbtnAvailable.Text);

            }

            else if (rbtnRequired.Checked)
            {
                rtbSummarizeIntent.Clear();
                rtbSummarizeIntent.AppendText(rbtnRequired.Text);

            }
            else if (rbtnUninstall.Checked)
            {
                rtbSummarizeIntent.Clear();
                rtbSummarizeIntent.AppendText(rbtnUninstall.Text);
            }
            else
            {
                MessageBox.Show("Please select an intent for the deployment");
            }
        }

        public void ClearSummary()
        {
            foreach (Control control in panelSummary.Controls)

            {
                if (!(control is System.Windows.Forms.Label) && !(control is Button))
                {

                    control.Text = string.Empty;

                }
            }
            progressBar1.Value = 0;
        }



        async Task AddAppAssignment()
        {
            // Reset the progress bar
            progressBar1.Value = 0;

            // Flow
            // Foreach app in checkedlistbox app - > add assignment from checkedlistbox group with checkedlistbox intent

            // Info needed:

            // App ID
            // Group ID
            // Intent

            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            // Sets the scope of the progress bar

            // 

            int numberOfApps = clbAppAssignments.Items.Count;
            int numberOfGroups = clbGroupAssignment.Items.Count;

            int progressBarMaxValue = numberOfApps * numberOfGroups;

            progressBar1.Maximum = progressBarMaxValue;



            InstallIntent intent;
            if (!Enum.TryParse(rtbSummarizeIntent.Text, out intent))
            {
                throw new ArgumentException("Invalid InstallIntent value.");
            }


            var mobileApps = await GetAllMobileAppsAsync();
            var Groups = await SearchAndGetAllGroupsAsync();


            // Loop through all apps in the checked listbox
            foreach (var app in clbAppAssignments.Items)
            {
                var mobileAppID = GetAppIdByName(mobileApps, app.ToString());

                // This is the app ID for each app in the checked list box
                // Use this for assignment purposes


                // Testing only:
                // MessageBox.Show(mobileAppID.ToString());

                // Loop through all groups in the checked listbox
                foreach (var group in clbGroupAssignment.Items)
                {
                    var groupID = GetGroupIdByName(Groups, group.ToString());
                    // This is the app ID for each group in the checked list box
                    // Use this for assignment purposes


                    // Testing only:
                    // MessageBox.Show(groupID.ToString());


                    var target = new GroupAssignmentTarget
                    {
                        GroupId = groupID,
                    };

                    var newAssignment = new MobileAppAssignment();
                    {
                        newAssignment.Target = target;
                        newAssignment.Intent = intent;

                    }

                    try
                    {
                        //await graphClient.DeviceAppManagement
                        //    .MobileApps[mobileAppID]
                        //    .Assignments
                        //    .Request()
                        //    .AddAsync(newAssignment);





                        // This might delete existing assignments

                        await graphClient.Result.DeviceAppManagement.MobileApps[mobileAppID]
                            .Assignments
                            .PostAsync(newAssignment);

                        rtbDeploymentSummary.AppendText("Adding group " + group + " to " + app + " as " + intent + "\n");
                        rtbDeploymentSummary.AppendText("\n");

                        progressBar1.Value++;

                    }
                    catch (Exception ex)
                    {
                        //Troubleshoot only
                        //MessageBox.Show($"Error adding assignment for {app.ToString()} and {group.ToString()}: {ex.Message}");

                        // variables for error message
                        string errorMessage = ex.Message;
                        string desiredMessage = "";

                        // Extract the desired message from the error
                        int start = errorMessage.IndexOf("\"Message\": \"");
                        int end = errorMessage.IndexOf(", for AppId:");

                        if (start >= 0 && end >= 0)
                        {
                            desiredMessage = errorMessage.Substring(start + 13, end - start - 13);
                        }



                        rtbDeploymentSummary.SelectionColor = Color.Red;
                        rtbDeploymentSummary.AppendText("Error when adding " + app.ToString() + " to " + group.ToString() + " as " + intent + "\n");
                        rtbDeploymentSummary.AppendText($"Error message: " + desiredMessage);
                        rtbDeploymentSummary.SelectionColor = rtbDeploymentSummary.ForeColor;

                    }




                }




            }


        }


        public void HelpGuide()
        {



            // make a message box with yes and no button

            DialogResult result = MessageBox.Show("Do you want a quick tour?", "Quick tour", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                // User wants help. Begin help guide

                // First check if user is signed in to a tenant
                if (lblTenantID.Text == "")
                {
                    MessageBox.Show("You are not signed in to a tenant. Please sign in to a tenant first, and then launch help guide.", "Please sign in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }



                // Begin with hiding certain panels
                panelSummary.Visible = false;
                pnlIntent.Visible = false;
                pnlSearchGroup.Visible = false;




                ListAllApps();
                // mute the sound that plays when a user clicks the button here

                MessageBox.Show("First you find and double click each application you want to assign.", "Find applications", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);


                pnlSearchGroup.Visible = true;
                ListAllGroups();
                MessageBox.Show("Now find and double click each group you want to assign applications to.", "Find groups", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);



                pnlIntent.Visible = true;
                MessageBox.Show("Then select the intent for the deployment.", "Select intent", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);



                panelSummary.Visible = true;
                MessageBox.Show("Finally you click Prepare deployment, double check the summary and click Deploy or Reset.", "Check summary", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);





            }
            else if (result == DialogResult.No)
            {
                // User did not want help. Do nothing
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }

        }


        public async Task<List<MobileAppInfo>> GetAllMobileAppsAsync()
        {

            // Retrieves all mobile apps with ID and display name, and saves them in a list for further use and processing

            // Create the list
            var mobileApps = new List<MobileApp>();


            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();



            // Query for all mobile apps
            var result = await graphClient.Result.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });


            // add the results to the list
            mobileApps.AddRange(result.Value);


            var mobileAppInfos = mobileApps.Select(app => new MobileAppInfo
            {
                Id = app.Id,
                DisplayName = app.DisplayName
            }).ToList();

            return mobileAppInfos;




        }

        public async Task<List<GroupInfo>> SearchAndGetAllGroupsAsync()
        {
            // Retrieves all Azure AD groups with ID and display name, and saves them in a list for further use and processing

            // Create the list
            var Groups = new List<Group>();


            // Create a graph service client object
            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();



            // Query for all mobile apps
            var result = await graphClient.Result.Groups.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });


            // add the results to the list
            Groups.AddRange(result.Value);


            var groupInfo = Groups.Select(app => new GroupInfo
            {
                Id = app.Id,
                DisplayName = app.DisplayName
            }).ToList();

            return groupInfo;

        }

        public string GetAppIdByName(List<MobileAppInfo> mobileApps, string appName)
        {

            // Searches through the list of app and retrieves the ID

            var mobileApp = mobileApps.FirstOrDefault(x => x.DisplayName.Equals(appName, StringComparison.OrdinalIgnoreCase));
            if (mobileApp == null)
            {
                throw new Exception($"Mobile app '{appName}' not found.");
            }

            return mobileApp.Id;
        }

        public string GetGroupIdByName(List<GroupInfo> groups, string groupName)
        {
            // Searches through the list of groups and retrieves the ID
            var group = groups.FirstOrDefault(x => x.DisplayName.Equals(groupName, StringComparison.OrdinalIgnoreCase));
            if (group == null)
            {
                throw new Exception($"Group '{groupName}' not found.");
            }

            return group.Id;
        }

        public string getAppIdFromDtg(DataGridView datagridview, int columnIndex)
        {
            // Retrieve the value of the column specified by index

            if (datagridview.SelectedCells.Count > 0 && datagridview.SelectedCells[0].RowIndex != -1)
            {
                // Get the value of the specified cell in the clicked row
                var value = datagridview.Rows[datagridview.SelectedCells[0].RowIndex].Cells[columnIndex].Value;

                // Return the value as a string
                return value?.ToString(); // Use null-conditional operator to avoid null reference exception
            }
            else
            {
                // No cell is selected, return null or empty string as appropriate
                return null; // or return string.Empty;
            }

        }

        public void showDeploymentSummary()
        {
            panelSummary.Show();
            System.Threading.Thread.Sleep(1000);
            btnSummarize_Click(null, null);
        }


        // method that clicks the button btnSummarize





        /////////////////////////////////////////// Key presses ////////////////////////////////////////////////////////////////////////
        private void TxtboxSearchApp_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // prevent the "ding" sound
                e.SuppressKeyPress = true; // suppress the key stroke that caused the "ding" sound
                btnSearchApp.PerformClick();
            }
        }


        private void myDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dtgDisplayApp.ContextMenuStrip = dtgDisplayAppRightClick;
                dtgDisplayAppRightClick.Show(dtgDisplayApp, e.Location);
            }

        }


        //////////////////////////////////////////// TIMERS /////////////////////////////////////////////////////////////////////



        private void sideBarTimer_Tick(object sender, EventArgs e)
        {



            if (sideBarExpandTimer)
            {
                // if menubar is expanded -> Minimize
                menuPanel.Width -= 10;


                if (menuPanel.Width == menuPanel.MinimumSize.Width)
                {
                    sideBarExpandTimer = false;
                    sideBarTimer.Stop();
                }
            }

            else
            {
                menuPanel.Width += 10;
                if (menuPanel.Width == menuPanel.MaximumSize.Width)
                {
                    sideBarExpandTimer = true;
                    sideBarTimer.Stop();
                }
            }
        }






        /////////////////////////////////////////// BUTTONS ////////////////////////////////////////////////////////////////////////



        private async void button2_Click(object sender, EventArgs e)
        {
            // Authenticates to MS Graph
            // Requires user to log in with admin account and password
            // Generates an access token which is used when making API calls

            // TODO 
            // Rename button click event to reflect updated name of the button

            await authMSAL();

            updateTenantInfo();




        }

        // met



        private void btnSearchApp_Click(object sender, EventArgs e)
        {
            SearchForApp();
        }

        private void btnAllGroups_Click(object sender, EventArgs e)
        {
            ListAllApps();
        }

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            SearchForGroup();



        }

        private void btnListAllGroups_Click(object sender, EventArgs e)
        {
            ListAllGroups();
        }

        private void dtgDisplayApp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row was clicked
            {
                var value = dtgDisplayApp.Rows[e.RowIndex].Cells[0].Value; // Get the value of the leftmost cell
                if (value != null)
                {
                    clbAppAssignments.Items.Add(value); // Add the value to the CheckedListBox
                }
            }
        }

        private void clbGroupAssignment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = clbGroupAssignment.IndexFromPoint(e.Location);
                if (index >= 0 && clbGroupAssignment.GetItemChecked(index))
                {
                    clbGroupAssignment.SelectedIndex = index;
                    clbGroupAssignment.ContextMenuStrip.Show(clbGroupAssignment, e.Location);


                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = clbGroupAssignment.Items.Count - 1; i >= 0; i--)
            {
                if (clbGroupAssignment.GetItemChecked(i))
                {
                    clbGroupAssignment.Items.RemoveAt(i);
                }
            }

        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clbGroupAssignment.Items.Clear();
        }

        private void clbAppAssignments_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                int index = clbAppAssignments.IndexFromPoint(e.Location);
                if (index >= 0 && clbAppAssignments.GetItemChecked(index))
                {
                    clbAppAssignments.SelectedIndex = index;
                    clbAppAssignments.ContextMenuStrip.Show(clbGroupAssignment, e.Location);


                }
            }

        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = clbAppAssignments.Items.Count - 1; i >= 0; i--)
            {
                if (clbAppAssignments.GetItemChecked(i))
                {
                    clbAppAssignments.Items.RemoveAt(i);
                }
            }

        }

        private void removeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clbAppAssignments.Items.Clear();
        }

        private void dtgDisplayGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Check if a valid row was clicked
            {
                var value = dtgDisplayGroup.Rows[e.RowIndex].Cells[0].Value; // Get the value of the leftmost cell
                if (value != null)
                {
                    clbGroupAssignment.Items.Add(value); // Add the value to the CheckedListBox
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //HidePanel(panelTenantInfo);
            //HidePanel(menuPanel);

            //sideBarTimer.Start();

        }

        private void btnSummarize_Click(object sender, EventArgs e)
        {
            SummarizeAssignments();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearSummary();
        }

        private void btnDeployAssignments_Click(object sender, EventArgs e)
        {
            int numberOfApps = rtbSummarizeApps.Lines.Count();
            int numberOfGroups = rtbSummarizeGroups.Lines.Count();
            int numberOfAssignments = numberOfApps * numberOfGroups;


            if (numberOfAssignments > 9)
            {

                DialogResult result = MessageBox.Show("You are attempting to make 10 or more assignments. Are you sure?", "Large assignment detected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    AddAppAssignment();
                }
                else
                {
                    // user clicked no. Do nothing
                }
            }


        }

        private void pbView_Click(object sender, EventArgs e)
        {

            showViewAssignment();

        }

        private void txtboxSearchApp_Click(object sender, EventArgs e)
        {
            txtboxSearchApp.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            showPolicyAssignment();
        }

        private void rbtnAvailable_Click(object sender, EventArgs e)
        {
            // Click event for Available radio button
            // Shows the deployment summary of the apps page

            showDeploymentSummary();
        }

        private void rbtnRequired_Click(object sender, EventArgs e)
        {
            // Click event for Required radio button
            // Shows the deployment summary of the apps page

            showDeploymentSummary();
        }

        private void rbtnUninstall_Click(object sender, EventArgs e)
        {
            // Click event for Uninstall radio button
            // Shows the deployment summary of the apps page

            showDeploymentSummary();
        }

        private void btnSearchApp_Click_1(object sender, EventArgs e)
        {

            if (cBAppType.Text == "")


            {
                MessageBox.Show("Please select application type in the drop down menu");
            }

            else if (cBAppType.Text == "All types (BETA)")

            {
                SearchForApp();
            }
            else
            {
                SearchForApp();
            }
        }

        private void txtboxSearchGroup_Click(object sender, EventArgs e)
        {
            txtboxSearchGroup.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            updateTenantInfoWithoutUser();
            HelpGuide();
        }

        private void pbInfo_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }

        private void tstbtn001_Click(object sender, EventArgs e)
        {

            //ye old faithful test button

        }

        public async Task TEST()
        {

            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            // Make a call to Microsoft Graph
            var tenantInfo = await graphClient.Result.Organization.GetAsync((requestConfiguration) =>
            {
                //requestConfiguration.QueryParameters.Select = new string[] { "id" };
            });




            // Put result in a list for processing
            List<Organization> organizations = new List<Organization>();
            organizations.AddRange(tenantInfo.Value);

            // Loop through the list
            // NOTE - this could be improved. There is room for error if the query returns more than 1 result
            foreach (var org in organizations)
            {
                MessageBox.Show(org.DisplayName);
            }
        }


        private void pBSettings_Click(object sender, EventArgs e)
        {

            Settings settings = new Settings();
            settings.ShowDialog();



        }

        private void pbCheckConnection_Click(object sender, EventArgs e)
        {

            checkConfigurationSettings();
            checkConnectionStatus();
        }
    }
}
