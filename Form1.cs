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
using Windows.ApplicationModel.VoiceCommands;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using Windows.Foundation.Metadata;

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

// OK - List all assignments with intent for an application
// OK - Add one or more assignments with intent for an application
// OK - Delete one or more assignments for an application
// OK - Select multiple apps, add assignments
// OK - Sidebar slides back after MS auth
// OK - Search box default text disappear when clicked
// OK - Display list of each error for each assignment



// Assignment options (End User Notifications, Availability, Deadline)
// Different needs for each app type (VPP, Win32, MGP, etc)
// Drop down menu to select each type?
// Multiple assignments:
// Panel with radio buttons? drop down menus?
// On application launch - Prompt user to log in
// Progress bar



///// Nice to haves /////

// Warning prompts
// Confirmations
// Reload DTG's after changes
// Login form



// last action:

// change GUI
// Idea to change intent to drop down menu and place within deployment pane. remove radio buttons
// Idea to change DTG UI to more sleek design
// Button animation






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
        string clientID = "f67679c6-4a23-42d8-84c6-bb3f9cf1f1c0";
        string tenantID = "18456af8-4036-4e1c-b888-43e04c49046a";
        string clientSecret = "";
        string[] scopes = new string[] { "DeviceManagementApps.ReadWrite.All", "DeviceManagementServiceConfig.Read.All", "DeviceManagementConfiguration.Read.All",
        "Directory.Read.All"};
        string GraphEndpoint = "https://graph.microsoft.com/v1.0";
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

            lblSignedInUser.Text = "";
            lblTenantID.Text = "";


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

        private void showViewAssignment()
        {
            // Switches to View Assignment-form, and keeps the location of this form

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

                    tenantID = org.Id;
                    lblTenantID.Text = "Tenant ID: " + tenantID;
                }

                lblSignedInUser.Text = "Signed in as " + me.DisplayName;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error authenticating: " + ex.Message);
            }
        }

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

        // Deprecated
        public GraphServiceClient GetGraphClient()
        {
            // Deprecated

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


        public GraphServiceClient NewGetGraphClient(string SharedAccessToken)
        {
            try
            {
                return new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", SharedAccessToken);

                        return Task.FromResult(0);
                    }));
            }
            catch (Exception errorMsg)
            {
                MessageBox.Show(errorMsg.Message);

                throw;
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
                var graphClient = NewGetGraphClient(GraphAccessToken);


                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Organization
                        .Request()
                        .Select("ID")
                        .GetAsync();

                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo);

                // Loop through the list
                // NOTE - this could be improved. There is room for error if the query returns more than 1 result
                foreach (var org in organizations)
                {
                    tenantID = org.Id;
                    lblTenantID.Text = "Tenant ID: " + tenantID;
                }

                var users = await graphClient.Me
                    .Request()
                    .GetAsync();

                lblSignedInUser.Text = users.DisplayName;

                sideBarTimer.Start();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error authenticating to Microsoft Graph. Please try again");
                //MessageBox.Show(ex.Message);
            }









        }

        public void ClearDataGridView(DataGridView dataGridView)
        {
            // Clear all the rows in the DataGridView control
            while (dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows.RemoveAt(0);
            }
        }

        private void ClearCheckedListBox(CheckedListBox checkedListBox)
        {

            checkedListBox.Items.Clear();

        }


        public void ListAllApps()
        {

            ClearDataGridView(dtgDisplayApp);
            ClearCheckedListBox(clbAppAssignments);

            // Create a graph service client object
            var graphClient = NewGetGraphClient(GraphAccessToken);

            var selectedPlatform = cBAppType.Text;



            // Make a call to Microsoft Graph
            var allApplications = graphClient.DeviceAppManagement.MobileApps
                .Request()
                .Select(u => new
                {
                    u.DisplayName,
                    u.Id,
                })
                .Top(1000)
                .GetAsync();

            // Put result into a list for easy processing
            List<MobileApp> listAllApplications = new List<MobileApp>();
            listAllApplications.AddRange(allApplications.Result);

            // Loop through the list
            // This foreach is no longer in use:
            foreach (var app in listAllApplications)
            {


                // Check OS platform for each app
                var appOS = "";
                if (app.ODataType?.ToString() == null)
                {
                    appOS = "Undefined";

                }
                else
                {
                    appOS = app.ODataType?.ToString();
                }



                // Convert Odata.type string to human known platform
                // NOTE - Additional checks are required to discover correct platform
                var platform = "";

                switch (appOS)
                {
                    case "#microsoft.graph.win32LobApp" or "#microsoft.graph.officeSuiteApp" or "#microsoft.graph.microsoftStoreForBusinessApp":
                        platform = "Windows";
                        break;

                    case "#microsoft.graph.managedIOSStoreApp" or "#microsoft.graph.iosVppApp":
                        platform = "iOS";
                        break;

                    case "#microsoft.graph.androidManagedStoreApp":
                        platform = "Android";
                        break;

                    case "#microsoft.graph.macOSOfficeSuiteApp":
                        platform = "macOS";
                        break;

                    default:
                        platform = "Undefined or unknown";
                        break;

                }

                // Display all
                // Finally add displayname and platform for each app into the datagridview
                //dtgDisplayApp.Rows.Add(app.DisplayName, platform, app.Id);




            }


            // Check cBAppType.text. List only items with corresponding platform

            if (cBAppType.Text == "Android")
            {
                List<MobileApp> matchingAndroid = listAllApplications
                    .Where(item => item.ODataType != null && item.ODataType.Contains("Android"))
                    .ToList();

                // Display in DTG
                foreach (var result in matchingAndroid)
                {
                    dtgDisplayApp.Rows.Add(result.DisplayName, "Android app", result);

                    // Test and troubleshoot only
                    // MessageBox.Show(result.DisplayName.ToString());
                }

            }

            if (cBAppType.Text == "iOS")
            {

                List<MobileApp> matchingiOS = listAllApplications
                    .Where(item => item.ODataType != null && item.ODataType.Contains("IOS"))
                    .ToList();

                // Note
                // for VPP app - query for #microsoft.graph.iosVppApp
                // for store app - query for #microsoft.graph.managedIOSStoreApp


                // Display in DTG
                foreach (var result in matchingiOS)
                {
                    dtgDisplayApp.Rows.Add(result.DisplayName, "iOS app", result);

                    // Test and troubleshoot only
                    // MessageBox.Show(result.DisplayName.ToString());
                }
            }

            if (cBAppType.Text == "Windows")
            {

                List<MobileApp> matchingWindows = listAllApplications
                    .Where(item => item.ODataType != null && (item.ODataType.Contains("win32") || item.ODataType.Contains("windowsMicrosoftEdge") || item.ODataType.Contains("microsoftStoreForBusiness")))
                    .ToList();

                // microsoftStoreForBusiness
                // Win32LobApp
                // windowsMicrosoftEdgeApp
                // Winget?


                // Display in DTG
                foreach (var result in matchingWindows)
                {
                    dtgDisplayApp.Rows.Add(result.DisplayName, "Windows app", result);

                    // Test and troubleshoot only
                    // MessageBox.Show(result.DisplayName.ToString());
                }

            }

            if (cBAppType.Text == "macOS")
            {

                List<MobileApp> matchingmacOS = listAllApplications
                   .Where(item => item.ODataType != null && (item.ODataType.Contains("macOSOfficeSuiteApp") || item.ODataType.Contains("macOSMicrosoftEdgeApp") || item.DisplayName.Contains("Microsoft Defender for Endpoint (macOS)")))
                   .ToList();

                // Defender for Endpoint app - no odata.type


                // Display in DTG
                foreach (var result in matchingmacOS)
                {
                    dtgDisplayApp.Rows.Add(result.DisplayName, "macOS app", result);

                    // Test and troubleshoot only
                    // MessageBox.Show(result.DisplayName.ToString());
                }


            }

            if (cBAppType.Text == "All types (BETA)")
            {

                MessageBox.Show("Feature not implemented yet");
            }

        }
        public void ListAllGroups()
        {
            ClearDataGridView(dtgDisplayGroup);
            ClearCheckedListBox(clbGroupAssignment);

            // Create a graph service client object
            var graphClient = NewGetGraphClient(GraphAccessToken);

            var groups = graphClient.Groups
                .Request()
                .GetAsync();


            List<Group> listAllGroups = new List<Group>();
            listAllGroups.AddRange(groups.Result);

            foreach (var group in listAllGroups)
            {
                dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
            }
        }
        public void SearchForGroup()
        {
            ClearDataGridView(dtgDisplayGroup);
            ClearCheckedListBox(clbGroupAssignment);

            string searchQuery = txtboxSearchGroup.Text;


            // Create a graph service client object
            var graphClient = NewGetGraphClient(GraphAccessToken);


            // Construct group query
            var queryOptions = new List<QueryOption>()
                {
                    new QueryOption("$search", "\"displayName:" + searchQuery + "\"")
                };


            // Make a call to Microsoft Graph
            var allGroups = graphClient.Groups
                .Request(queryOptions)
                .Header("consistencylevel", "eventual")
                .Select(u => new
                {
                    u.DisplayName,
                    u.Id,
                    u.GroupTypes,
                    u.Description,
                    u.SecurityEnabled

                })
                .Top(100)
                .GetAsync();

            // Make a list of all returned groups from the search
            List<Group> groups = new List<Group>();
            groups.AddRange(allGroups.Result);

            foreach (var group in groups)
            {
                dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
                //clbGroupAssignment.Items.Add(group.DisplayName);
            }
        }
        public void SearchForApp()
        {
            ClearCheckedListBox(clbAppAssignments);
            ClearDataGridView(dtgDisplayApp);

            string searchquery = txtboxSearchApp.Text;


            // Create a graph service client object
            var graphClient = NewGetGraphClient(GraphAccessToken);

            // Make a call to Microsoft Graph
            var allApplications = graphClient.DeviceAppManagement.MobileApps
                .Request()
                .Filter("contains(displayName, '" + searchquery + "')")
                .Select(u => new
                {
                    u.DisplayName,
                })
                .Top(1000)
                .GetAsync();

            // Put result into a list for easy processing
            List<MobileApp> searchResult = new List<MobileApp>();
            searchResult.AddRange(allApplications.Result);

            int numberOfAppsFound = searchResult.Count;

            if (numberOfAppsFound == 0)

            {

                MessageBox.Show("No applications found with containing " + searchquery);

            }

            else if (numberOfAppsFound >= 1)

            {

                // Loop through the list
                foreach (var app in searchResult)
                {


                    // Check OS platform for each app
                    var appOS = "";
                    if (app.ODataType?.ToString() == null)
                    {
                        appOS = "Undefined";

                    }
                    else
                    {
                        appOS = app.ODataType?.ToString();
                    }


                    // Convert Odata.type string to human known platform
                    // NOTE - Additional checks are required to discover correct platform
                    var platform = "";

                    switch (appOS)
                    {
                        case "#microsoft.graph.win32LobApp" or "#microsoft.graph.officeSuiteApp" or "#microsoft.graph.microsoftStoreForBusinessApp":
                            platform = "Windows";
                            break;

                        case "#microsoft.graph.managedIOSStoreApp":
                            platform = "iOS";
                            break;

                        case "#microsoft.graph.androidManagedStoreApp":
                            platform = "Android";
                            break;

                        case "#microsoft.graph.macOSOfficeSuiteApp":
                            platform = "macOS";
                            break;

                        default:
                            platform = "Undefined or unknown";
                            break;

                    }

                    // Finally add displayname and platform for each app into the datagridview
                    dtgDisplayApp.Rows.Add(app.DisplayName, platform, app.Id);


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
                if (!(control is Label) && !(control is Button))
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
            var graphClient = NewGetGraphClient(GraphAccessToken);

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
                        await graphClient.DeviceAppManagement
                            .MobileApps[mobileAppID]
                            .Assignments
                            .Request()
                            .AddAsync(newAssignment);

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

            // Retrieves all mobile apps and saves them in a list for further use and processing


            var mobileApps = new List<MobileAppInfo>();

            var graphServiceClient = NewGetGraphClient(GraphAccessToken);

            var mobileAppPage = await graphServiceClient.DeviceAppManagement.MobileApps.Request().GetAsync();

            do
            {
                foreach (var mobileApp in mobileAppPage)
                {
                    var mobileAppInfo = new MobileAppInfo
                    {
                        Id = mobileApp.Id,
                        DisplayName = mobileApp.DisplayName
                    };
                    mobileApps.Add(mobileAppInfo);
                }

                if (mobileAppPage.NextPageRequest != null)
                {
                    mobileAppPage = await mobileAppPage.NextPageRequest.GetAsync();
                }
                else
                {
                    mobileAppPage = null;
                }
            } while (mobileAppPage != null);

            return mobileApps;
        }

        public async Task<List<GroupInfo>> SearchAndGetAllGroupsAsync(string query = null)
        {

            var groups = new List<GroupInfo>();
            var graphServiceClient = NewGetGraphClient(GraphAccessToken);
            var groupPage = await graphServiceClient.Groups.Request().Filter(query).GetAsync();

            do
            {
                foreach (var group in groupPage)
                {
                    var groupInfo = new GroupInfo
                    {
                        Id = group.Id,
                        DisplayName = group.DisplayName
                    };
                    groups.Add(groupInfo);
                }

                if (groupPage.NextPageRequest != null)
                {
                    groupPage = await groupPage.NextPageRequest.GetAsync();
                }
                else
                {
                    groupPage = null;
                }
            } while (groupPage != null);

            return groups;
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


        private async void testBtn_Click(object sender, EventArgs e)
        {


            buttonGrowTimer.Start();

        }

        private void btnSearchApp_Click(object sender, EventArgs e)
        {
            SearchForApp();
        }

        private void btnAllGroups_Click(object sender, EventArgs e)
        {

            if (cBAppType.Text == "")


            {
                MessageBox.Show("Please select application type");
            }

            else if (cBAppType.Text == "All types (BETA)")

            {
                MessageBox.Show("Feature not implemented");
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
    }
}
