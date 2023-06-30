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
using static IntuneAssignments.Form1;

namespace IntuneAssignments
{
    public partial class ViewAssignment : Form
    {

        private readonly Form1 _form1;

        public ViewAssignment(Form1 form1)
        {
            InitializeComponent();

            _form1 = form1;
        }

        protected override void OnLoad(EventArgs e)
        {
            // Necessary to copy the location of Form1
            base.OnLoad(e);

            // Set the location of the form to the position of Form1
            if (_form1 != null)
            {
                Location = new Point(
                    _form1.Location.X + (_form1.Width - Width) / 2,
                    _form1.Location.Y + (_form1.Height - Height) / 2);
            }

            // Removes dummy text in labels when launching the app
            UpdateLabel(lblAppID, "");
            UpdateLabel(lblAppName, "");

        }

        private void ViewAssignment_Load(object sender, EventArgs e)
        {

        }





        ////////////////////////////////////////// Classes ///////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////// Authentication ///////////////////////////////////////////////



        /////////////////////////////////////////// Configuration ////////////////////////////////////////////////////////////////////////



        private void goHome()
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        public async void searchApp()
        {
            // Variables

            string searchquery = txtboxSearchApp.Text;


            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Authenticate to Graph

            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            // Clear the datagridview for older results

            form1.ClearDataGridView(dtgDisplayApp);

            // Make a call to Microsoft Graph

            var result =  await graphClient.Result.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Search = searchquery;
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });


            // Put result into a list for easy processing
            List<MobileApp> searchResult = new List<MobileApp>();
            searchResult.AddRange(result.Value);

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
                    if (app.OdataType?.ToString() == null)
                    {
                        appOS = "Undefined";

                    }
                    else
                    {
                        appOS = app.OdataType?.ToString();
                    }


                    // Convert Odata.type string to human known platform
                    // NOTE - Additional checks are required to discover correct platform
                    var platform = "";

                    switch (appOS)
                    {
                        case "#microsoft.graph.win32LobApp" or "#microsoft.graph.officeSuiteApp" or "#microsoft.graph.microsoftStoreForBusinessApp" or "#microsoft.graph.winGetApp":
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

        public async void listAllApps()
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Clear the datagridview for older results

            form1.ClearDataGridView(dtgDisplayApp);


            // Create the list

            var listAllApplications = new List<MobileApp>();


            // Authenticate to Graph

            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();



            // Make a call to Microsoft Graph

            var result = await graphClient.Result.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });



            // Put result into a list for easy processing


            listAllApplications.AddRange(result.Value);


            // Loop through the list
            foreach (var app in listAllApplications)
            {


                // Check OS platform for each app
                var appOS = "";
                if (app.OdataType?.ToString() == null)
                {
                    appOS = "Undefined";

                }
                else
                {
                    appOS = app.OdataType?.ToString();
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

        async Task ListAllAssignedGroups()
        {

            // Take app ID from datagridview
            // This is the Application ID for which we query assignments
            var value = _form1.getAppIdFromDtg(dtgDisplayApp, 2);
            var appname = _form1.getAppIdFromDtg(dtgDisplayApp, 0);

            
            UpdateLabel(lblAppID, value);
            UpdateLabel(lblAppName, appname);


            // Authenticate to Graph

            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();


            var result = await graphClient.Result.DeviceAppManagement.MobileApps[value].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });

            

            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(result.Value);

            if (assignmentsList.Count == 0)
            {
                // The list has zero members. Informing user
                MessageBox.Show("No assignments found");
            }

            else if (assignmentsList.Count >= 1)
            // The list has members - proceeding
            {

                foreach (var assignment in assignmentsList)
                {
                    // Testing only
                    //MessageBox.Show(assignment.Id + " " + assignment.Intent);

                    var id = assignment.Id.Substring(0, assignment.Id.Length - 4);

                    var resultList = new List<Group>();

                    var findGroupName = await graphClient.Result.Groups[id].GetAsync((requestConfiguration) =>
                    {
                        requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
                    });

                    resultList.Add(findGroupName);


                    foreach (var group in resultList)
                    {
                        dtgGroupAssignment.Rows.Add(group.DisplayName, assignment.Intent, group.Id);
                    }


                }
            }


        }


        public async void deleteAppAssignment()
        {


            // Authenticate to Graph

            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();


            // Convert value og lblappid.text to mobile app ID
            var appID = lblAppID.Text;

            // Query graph for assignment ID for a given app
            var result = await graphClient.Result.DeviceAppManagement.MobileApps["{mobileApp-id}"].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "intent" };
            });


            // Add the result to a list of assignments
            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(result.Value);


            // Loop through the list and delete each assignment

            foreach (var assignment in assignmentsList)
            {
                //MessageBox.Show(assignment.Id + " " + assignment.Intent);

                await graphClient.Result.DeviceAppManagement.MobileApps[appID].Assignments[assignment.Id].DeleteAsync();
            }




        }


        public async void deleteSelectedAppAssignment(DataGridView dataGridView)
        {


            // Authenticate to Graph

            var graphClient = MSGraphAuthenticator.GetAuthenticatedGraphClient();

            // Convert value og lblappid.text to mobile app ID
            var appID = lblAppID.Text;

            var result = await graphClient.Result.DeviceAppManagement.MobileApps[appID].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "intent" };
            });


            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(result.Value);

            // match group ID with assignment ID

            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {

                int rowIndex = cell.RowIndex;
                int columnIndex = 2; // Index of the third column (zero-based index)

                if (dataGridView.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    // Retrieve the value of the third column in order to match it with assignment ID
                    string? groupID = dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                    // Find assignment ID for a given group ID
                    var assignmentID = assignmentsList.FirstOrDefault(x => x.Id.Contains(groupID));

                    // Delete assignment

                    await graphClient.Result.DeviceAppManagement.MobileApps[appID].Assignments[assignmentID.Id].DeleteAsync();

                    
                }


            }

            

            // Clear the datagridview for older results
            _form1.ClearDataGridView(dtgGroupAssignment);

            // Refresh datagridview
            ListAllAssignedGroups();



        }


        // Method to update label with a given text
        public void UpdateLabel(System.Windows.Forms.Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new MethodInvoker(delegate { label.Text = text; }));
            }
            else
            {
                label.Text = text;
            }
        }

        /////////////////////////////////////////// Key presses ////////////////////////////////////////////////////////////////////////







        /////////////////////////////////////////// BUTTONS ////////////////////////////////////////////////////////////////////////



        private void btnSearchApp_Click(object sender, EventArgs e)
        {

        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            goHome();
        }

        private void btnSearchApp_Click_1(object sender, EventArgs e)
        {
            searchApp();
        }

        private void btnAllGroups_Click(object sender, EventArgs e)
        {
            listAllApps();
        }

        private void dtgDisplayApp_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // Clear the datagridview for older results
            _form1.ClearDataGridView(dtgGroupAssignment);




            ListAllAssignedGroups();

        }




        private void pbClearDtgDisplayApp_Click(object sender, EventArgs e)
        {
            // Clear the datagridview for older results

            _form1.ClearDataGridView(dtgDisplayApp);
        }

        private void pbpbClearDtgGroupAssignment_Click(object sender, EventArgs e)
        {
            // Clear the datagridview for older results
            _form1.ClearDataGridView(dtgGroupAssignment);
        }

        private void tstbtn1_Click(object sender, EventArgs e)
        {

            // Show message box with warning, and if statement based on what the user clicks

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all assignments for this app?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                // If user clicks yes, delete all assignments
                deleteAppAssignment();
            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }


        }

        private void btnDeleteSelectedAssignment_Click(object sender, EventArgs e)
        {
            deleteSelectedAppAssignment(dtgGroupAssignment);
        }


    }
}
