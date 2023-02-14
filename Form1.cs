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
// Fix try catch and check for if the session is authentictated properly. handle errors
// Select multiple apps, add assignments

// Multiple assignments:
// Panel with radio buttons? drop down menus?




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

        int col = -1;
        int row = -1;
        string clientID = "f67679c6-4a23-42d8-84c6-bb3f9cf1f1c0";
        string tenantID = "18456af8-4036-4e1c-b888-43e04c49046a";
        string clientSecret = "";
        string[] scopes = new string[] { "DeviceManagementApps.ReadWrite.All", "DeviceManagementServiceConfig.Read.All", "DeviceManagementConfiguration.Read.All",
        "Directory.Read.All"};
        string GraphEndpoint = "https://graph.microsoft.com/v1.0";
        string accessToken = "";


        private void Form1_Load(object sender, EventArgs e)
        {




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


            }
            catch (Exception errorMsg)
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

        public async void updateTenantInfo()
        {
            // Create a graph service client object
            var graphClient = GetGraphClient();


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

        }

        private void ClearDataGridView(DataGridView dataGridView)
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
            var graphClient = GetGraphClient();

            // Make a call to Microsoft Graph
            var allApplications = graphClient.DeviceAppManagement.MobileApps
                .Request()
                .Select(u => new
                {
                    u.DisplayName,
                })
                .Top(1000)
                .GetAsync();

            // Put result into a list for easy processing
            List<MobileApp> listAllApplications = new List<MobileApp>();
            listAllApplications.AddRange(allApplications.Result);

            // Loop through the list
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
        public void ListAllGroups()
        {
            ClearDataGridView(dtgDisplayGroup);
            ClearCheckedListBox(clbGroupAssignment);

            // Create a graph service client object
            var graphClient = GetGraphClient();

            var groups =  graphClient.Groups
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
            var graphClient = GetGraphClient();


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

            foreach ( var group in groups)
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
            var graphClient = GetGraphClient();

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
            
        }

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
    }
    }
