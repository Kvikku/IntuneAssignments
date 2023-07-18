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
using Microsoft.Graph.Beta.Models.WindowsUpdates;
using Tavis.UriTemplates;

//TO DO

///// UI ///////////////////

// Flat theme
// Animations


///// Framework ////////////

// Everything as simple methods

///// Core functionality /////

// Fix try catch and check for if the session is authentictated properly. handle errors
// Handle All Users and All Devices virtual groups
// Handle errors when deploying to already assigned groups
// Display list of each error for each assignment
// Display welcome tour on first launch
// Checkbox to skip
// VPP apps - modify query
// Windows - Winget apps?
// Logging to log file


/// FINISHED ///

// OK - List all assignments with intent for an application
// OK - Add one or more assignments with intent for an application
// OK - Delete one or more assignments for an application
// OK - Select multiple apps, add assignments
// OK - Sidebar slides back after MS auth
// OK - Search box default text disappear when clicked
// OK - Display list of each error for each assignment
// OK - Pop up box for assignment for policies
// OK - Deployment of settings catalog, compliance and device config
// OK - On application launch - Prompt user to log in
// OK - Progress bar
// OK - Search fields
// OK - Deployment of settings catalog, compliance and device config



// Assignment options (End User Notifications, Availability, Deadline)
// Different needs for each app type (VPP, Win32, MGP, etc)
// Drop down menu to select each type?
// Multiple assignments:
// Panel with radio buttons? drop down menus?





///// Nice to haves /////

//
// Warning prompts
// Confirmations
// Reload DTG's after changes
// Login form
// Tool tips
// append or replace description


// last action:



// Continue on applicaiton form



// Continue on policy form
// - Warning when deploying large amount of groups and/or apps - could take up to 1 minutes before it shows up in the portal
// - Progress bar
// Create list for 1.0 release







namespace IntuneAssignments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtboxSearchApp.KeyDown += TxtboxSearchApp_KeyDown;
        }




        // Global variables //

        bool sideBarExpandTimer = false;
        int col = -1;
        int row = -1;
        public static string clientID = "f67679c6-4a23-42d8-84c6-bb3f9cf1f1c0";
        public static string tenantID = "18456af8-4036-4e1c-b888-43e04c49046a";
        public static string clientSecret = "mvt8Q~T_JKJ0PlCr69d1bfQlyBJcZXjekFJ_Ab-g";
        public static string[] scopes = new[] { "DeviceManagementApps.ReadWrite.All", "DeviceManagementServiceConfig.Read.All", "DeviceManagementConfiguration.Read.All",
        "Directory.Read.All", "DeviceManagementConfiguration.ReadWrite.All" };
        string GraphEndpoint = "https://graph.microsoft.com/v1.0";
        public static string[] newScopes = new string[]
        {
            "https://graph.microsoft.com/.default"
        };
        string accessToken = "";
        public static string GraphAccessToken { get; set; }
        public static Point Form1Location { get; set; }
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer buttonGrowTimer;
        private int sizeIncrement = 10;
        private int growthDuration = 1000;
        private int timerCount = 1;
        private Size OriginalLoginButtonSize = Size.Empty;



        public void Form1_Load(object sender, EventArgs e)
        {
            // Hides the login panel during application launch
            //HidePanel(panelTenantInfo);
            //HidePanel(menuPanel);
            //delayLoginAnimation();

            // Hides default text on labels

            // add data to dtgdisplayapp
            dtgDisplayApp.Rows.Add("test", "test", "test");
            dtgDisplayApp.Rows.Add("test", "test", "test");
            dtgDisplayApp.Rows.Add("test", "test", "test");
            dtgDisplayApp.Rows.Add("test", "test", "test");
            dtgDisplayApp.Rows.Add("test", "test", "test");
            dtgDisplayApp.Rows.Add("test", "test", "test");

            lblSignedInUser.Text = "";
            lblTenantID.Text = "";

            pnlIntent.Hide();
            pnlSearchApp.Hide();
            pnlSearchGroup.Hide();
            panelSummary.Hide();


            // Creates a timer to have the animation trigger after 3 seconds
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 3000;
            animationTimer.Tick += Timer_Tick;
            animationTimer.Start();


            // Creates a timer to animate the login button

            buttonGrowTimer = new System.Windows.Forms.Timer();
            buttonGrowTimer.Interval = 16;
            buttonGrowTimer.Tick += ButtonTimer_Tick;

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

        // Methods //

        ////////////////////////////////////////////// Authentication ///////////////////////////////////////////////



        public async Task authMSAL()
        {

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
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }

        }

        /// ////////////////////////////////////// Configuration ///////////////////////////////////////////////////

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

        public async void updateTenantInfo()
        {


            try
            {


                // Create a graph service client object
                var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();




                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Result.Organization.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id" };
                });




                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo.Value);

                // Loop through the list
                // NOTE - this could be improved. There is room for error if the query returns more than 1 result
                foreach (var org in organizations)
                {
                    tenantID = org.Id;
                    lblTenantID.Text = "Tenant ID: " + tenantID;
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
                pBPointToLoginButton.Hide();

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

            if (cBAppType.Text == "All types (BETA)")
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
            System.Threading.Thread.Sleep(2000);
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

            if (cBAppType.Text == "")


            {
                MessageBox.Show("Please select application type in the drop down menu");
            }

            else if (cBAppType.Text == "All types (BETA)")

            {
                ListAllApps();
                //MessageBox.Show("Feature not implemented");
            }
            else
            {
                ListAllApps();
            }


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

            sideBarTimer.Start();

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
            AddAppAssignment();
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
    }
}
