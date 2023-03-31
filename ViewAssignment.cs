using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

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

        private void searchApp()
        {
            // Variables

            string searchquery = txtboxSearchApp.Text;


            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Clear the datagridview for older results

            form1.ClearDataGridView(dtgDisplayApp);


            // Authenticate to Graph

            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);



            // Make a call to Microsoft Graph
            var allApplications = client.DeviceAppManagement.MobileApps
                .Request()
                .Filter("contains(displayName, '" + searchquery + "')")
                .Select(u => new
                {
                    u.DisplayName,
                    u.Id
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

        private void listAllApps()
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Clear the datagridview for older results

            form1.ClearDataGridView(dtgDisplayApp);

            // Authenticate to Graph

            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);

            // Make a call to Microsoft Graph
            var allApplications = client.DeviceAppManagement.MobileApps
                .Request()
                .Select(u => new
                {
                    u.DisplayName,
                    u.Id
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

        async Task ListAllAssignedGroups()
        {

            // Take app ID from datagridview
            // This is the Application ID for which we query assignments
            var value = _form1.getAppIdFromDtg(dtgDisplayApp, 2);
            var appname = _form1.getAppIdFromDtg(dtgDisplayApp, 0);

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            UpdateLabel(lblAppID, value);
            UpdateLabel(lblAppName, appname);


            // Authenticate to Graph

            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);



            var allAssignments = client.DeviceAppManagement.MobileApps[value].Assignments
                .Request()
                .Select("id,intent")
                .GetAsync();

            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(allAssignments.Result);

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


                    var findGroupName = await client.Groups
                        .Request()
                        .Filter("ID eq '" + id + "'")
                        .Select(u => new
                        {
                            u.DisplayName,
                            u.Id
                        })
                        .GetAsync();

                    foreach (var group in findGroupName)
                    {
                        dtgGroupAssignment.Rows.Add(group.DisplayName, assignment.Intent, group.Id);
                    }


                }
            }


        }


        public async void deleteAppAssignment()
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph

            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);


            // Convert value og lblappid.text to mobile app ID
            var appID = lblAppID.Text;


            // Query graph for assignment ID for a given app
            var allAssignments = client.DeviceAppManagement.MobileApps[appID].Assignments
                .Request()
                .Select("id,intent")
                .GetAsync();

            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(allAssignments.Result);

            foreach (var assignment in assignmentsList)
            {
                //MessageBox.Show(assignment.Id + " " + assignment.Intent);

                await client.DeviceAppManagement.MobileApps[appID].Assignments[assignment.Id].Request().DeleteAsync();
            }




        }


        public async void deleteSelectedAppAssignment(DataGridView dataGridView)
        {
            

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph

            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);

            // Convert value og lblappid.text to mobile app ID
            var appID = lblAppID.Text;

            // Query graph for assignment ID for a given app
            var allAssignments = client.DeviceAppManagement.MobileApps[appID].Assignments
                .Request()
                .Select("id,intent")
                .GetAsync();

            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(allAssignments.Result);


            foreach (var assignment in assignmentsList) 
            {

                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                {
                    await client.DeviceAppManagement.MobileApps[appID].Assignments[assignment.Id].Request().DeleteAsync();
                }

            }





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
    }
}
