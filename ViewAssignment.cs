using Microsoft.Graph.Beta.Models;
using static IntuneAssignments.GraphServiceClientCreator;
using static IntuneAssignments.FormUtilities;
using static IntuneAssignments.GlobalVariables;
using System.Windows.Forms;
using System.Threading.Tasks.Dataflow;

namespace IntuneAssignments
{
    public partial class ViewAssignment : Form
    {

        private readonly Application _form1;
        public int numberOfAssignmentsDeleted = 0;

        public ViewAssignment(Application form1)
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
            UpdateLabel(lblNumberOfAssignmentsDeleted, "");
            lblDeleteStatusText.Hide();
            lblProgress.Hide();
            pbCalculate.Hide();

        }




        ////////////////////////////////////////// Classes ///////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////// Authentication ///////////////////////////////////////////////



        /////////////////////////////////////////// Configuration ////////////////////////////////////////////////////////////////////////



        private void goHome()
        {
            this.Hide();
            Application form1 = new Application();
            form1.Show();
        }

        public async void searchApp()
        {
            // Variables

            string searchquery = txtboxSearchApp.Text;


            // Create an object of form1 to use it's methods   
            Application form1 = new Application();


            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();

            // Clear the datagridview for older results

            FormUtilities.ClearDataGridView(dtgDisplayApp);

            // Make a call to Microsoft Graph

            var result = await graphClient.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
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
            Application form1 = new Application();


            // Clear the datagridview for older results

            FormUtilities.ClearDataGridView(dtgDisplayApp);


            // Create the list

            var listAllApplications = new List<MobileApp>();


            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();



            // Make a call to Microsoft Graph

            var result = await graphClient.DeviceAppManagement.MobileApps.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });


            foreach (var app in result.Value)
            {
                // remove app protection app objects from the list

                if (!(app.OdataType.Contains("#microsoft.graph.managedAndroidStoreApp") || app.OdataType.Contains("#microsoft.graph.managedIOSStoreApp")))
                {
                    listAllApplications.Add(app);
                }
            }






            //listAllApplications.AddRange(result.Value);




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
                    case "#microsoft.graph.win32LobApp" or "#microsoft.graph.officeSuiteApp" or "#microsoft.graph.microsoftStoreForBusinessApp" or "#microsoft.graph.winGetApp" or "#microsoft.graph.windowsWebApp":
                        platform = "Windows";
                        break;

                    case "#microsoft.graph.managedIOSStoreApp" or "#microsoft.graph.iosVppApp":
                        platform = "iOS";
                        break;

                    case "#microsoft.graph.androidManagedStoreApp" or "#microsoft.graph.androidManagedStoreApp":
                        platform = "Android";
                        break;

                    case "#microsoft.graph.macOSOfficeSuiteApp" or "#microsoft.graph.macOSMicrosoftDefenderApp" or "#microsoft.graph.macOSMicrosoftEdgeApp" or "#microsoft.graph.macOSWebClip":
                        platform = "macOS";
                        break;

                    case "#microsoft.graph.webApp":
                        platform = "Web link";
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

            var graphClient = CreateGraphServiceClient();


            var result = await graphClient.DeviceAppManagement.MobileApps[value].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });



            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(result.Value);

            if (assignmentsList.Count == 0)
            {
                // The list has zero members. Informing user
                MessageBox.Show("No assignments found");
                WriteToLog("No assignments found for application " + appname + " with ID " + value);
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

                    // check if the ID is for All Users or All Devices virtual groups
                    if (id.StartsWith("acacac"))
                    {
                        WriteToLog("Group name is All Users (virtual group)");
                        dtgGroupAssignment.Rows.Add("All Users (virtual group)", assignment.Intent, allUsersGroupID);
                    }

                    else if (id.StartsWith("adadad"))
                    {
                        WriteToLog("Group name is All Devices (virtual group)");
                        dtgGroupAssignment.Rows.Add("All Devices (virtual group)", assignment.Intent, allDevicesGroupID);

                    }
                    else
                    {
                        try
                        {
                            var findGroupName = await graphClient.Groups[id].GetAsync((requestConfiguration) =>
                            {
                                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
                            });

                            resultList.Add(findGroupName);


                            foreach (var group in resultList)
                            {
                                dtgGroupAssignment.Rows.Add(group.DisplayName, assignment.Intent, group.Id);
                            }

                        }
                        catch (Exception ex)
                        {
                            WriteToLog("An error occurred when trying to look up the group name with group ID " + id);
                            WriteToLog("The error message is: " + ex.Message);
                            WriteToLog("This is usually because the group has been deleted from Entra, but the assignment for the group still exists in Intune");

                            rtbSummary.AppendText("An error occurred when trying to look up the group name with group ID " + id);
                            rtbSummary.AppendText("\n");
                            rtbSummary.AppendText("The error message is: " + ex.Message);
                            rtbSummary.AppendText("\n");
                            rtbSummary.AppendText("This is usually because the group has been deleted from Entra, but the assignment for the group still exists in Intune");
                            rtbSummary.AppendText("\n");

                        }
                    }






                }
            }


        }


        public async void deleteAppAssignment()
        {

            // show label

            lblDeleteStatusText.Show();
            lblNumberOfAssignmentsDeleted.Text = 0.ToString();
            numberOfAssignmentsDeleted = 0;
            pbCalculate.Show();
            lblProgress.Show();


            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();


            // Convert value og lblappid.text to mobile app ID
            var appID = lblAppID.Text;

            // Query graph for assignment ID for a given app
            var result = await graphClient.DeviceAppManagement.MobileApps[appID].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "intent" };
            });


            // Add the result to a list of assignments
            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(result.Value);

            int numberOfAssignments = assignmentsList.Count;
            pbCalculate.Maximum = numberOfAssignments;

            // Loop through the list and delete each assignment

            foreach (var assignment in assignmentsList)
            {
                //MessageBox.Show(assignment.Id + " " + assignment.Intent);

                var id = assignment.Id;

                // Find group id from assignment id

                var groupID = id.Substring(0, id.Length - 4);

                // Find group name from group ID

                var groupName = await FindGroupNameFromAppAssignmentID(appID, id);

                // Delete assignment

                await graphClient.DeviceAppManagement.MobileApps[appID].Assignments[assignment.Id].DeleteAsync();

                WriteToLog("Assignment for group " + groupName + " has been deleted");
                rtbSummary.AppendText("Assignment for group " + groupName + " has been deleted");
                rtbSummary.AppendText("\n");

                // Update the label with the number of assignments deleted
                numberOfAssignmentsDeleted++;
                pbCalculate.Value++;
                lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString();

            }

            // Clear the datagridview for older results
            FormUtilities.ClearDataGridView(dtgGroupAssignment);




        }


        public async void deleteSelectedAppAssignment(DataGridView dataGridView)
        {
            // show label

            lblDeleteStatusText.Show();
            lblNumberOfAssignmentsDeleted.Text = 0.ToString();
            numberOfAssignmentsDeleted = 0;

            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();

            // Convert value og lblappid.text to mobile app ID
            var appID = lblAppID.Text;

            var result = await graphClient.DeviceAppManagement.MobileApps[appID].Assignments.GetAsync((requestConfiguration) =>
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


                    // Find group name from group ID
                    var groupName = await FindGroupNameFromAppAssignmentID(appID, assignmentID.Id);

                    // Delete assignment

                    await graphClient.DeviceAppManagement.MobileApps[appID].Assignments[assignmentID.Id].DeleteAsync();



                    rtbSummary.AppendText("Assignment for group " + groupName + " has been deleted");
                    rtbSummary.AppendText("\n");

                    // Update the label with the number of assignments deleted
                    numberOfAssignmentsDeleted++;
                    lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString();

                }


            }



            // Clear the datagridview for older results
            FormUtilities.ClearDataGridView(dtgGroupAssignment);

            // Refresh datagridview
            await ListAllAssignedGroups();



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


        public async Task DeleteAppAssignment(string appID)
        {

            /*
             * This method will delete all assignments for a given app
             * Pass the app ID as a parameter
             */

            WriteToLog("Attempting to delete all assignments for app with ID " + appID);

            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();


            // Query graph for assignment ID for the given app
            var result = await graphClient.DeviceAppManagement.MobileApps[appID].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "intent" };
            });

            // check if the result is null
            if (result.Value == null)
            {
                WriteToLog("No assignments found for app with ID " + appID);
                return;
            }




            // Add the result to a list of assignments

            List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
            assignmentsList.AddRange(result.Value);

            // count how many assignments are found
            int numberOfAssignments = assignmentsList.Count;

            // log the number of assignments found
            WriteToLog("Number of assignments found for app with ID " + appID + " is " + numberOfAssignments);


            foreach (var assignment in assignmentsList)
            {

                try
                {
                    // Get the assignment group name

                    var groupName = FindGroupNameFromAppAssignmentID(appID, assignment.Id);

                    WriteToLog("Group ID for the assignment is " + assignment.Id);
                    WriteToLog("Attempting to delete the assignment");

                    // Delete the assignment
                    await graphClient.DeviceAppManagement.MobileApps[appID].Assignments[assignment.Id].DeleteAsync();

                    WriteToLog("Assignment with ID " + assignment.Id + " has been deleted");
                    WriteToLog(" ");
                }
                catch (Exception)
                {
                    WriteToLog("An error occurred when trying to delete the assignment with ID " + assignment.Id);
                    throw;
                }


            }

        }


        public async Task<string> CountNumberOfAssignmentsToBeDeleted()
        {
            int numberOfApps = 0;
            int numberOfAssignments = 0;



            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            // store all app IDs in a list
            List<string> appIDs = new List<string>();

            // IDs are at index 2 in the datagridview
            foreach (DataGridViewRow selectedRow in dtgDisplayApp.SelectedRows)
            {
                // Make sure the row is not a new row (if your DataGridView allows adding new rows)
                if (!selectedRow.IsNewRow)
                {
                    appIDs.Add(selectedRow.Cells[2].Value.ToString());

                    // count the number of apps
                    numberOfApps++;
                }
            }



            // count the number of assignments for each app
            foreach (var appID in appIDs)
            {
                // Query graph for assignment ID for a given app
                var result = await graphClient.DeviceAppManagement.MobileApps[appID].Assignments.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id", };
                });

                // Add the result to a list of assignments
                List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
                assignmentsList.AddRange(result.Value);

                // count how many assignments are found
                numberOfAssignments += assignmentsList.Count;
            }

            //MessageBox.Show("Number of apps selected for deleting assignments is " + numberOfApps);
            //MessageBox.Show("Number of assignments found for all selected apps is " + numberOfAssignments);

            return "The number of applications are " + numberOfApps + " and the number of assignments are " + numberOfAssignments;
        }

        public async Task deleteSelectedAppAssignments()
        {
            /*
             * This method will delete all assignments for all selected apps in the datagridview dtgDisplayApp
             */

            // Store default color for rich textbox
            var defaultColor = rtbSummary.ForeColor;


            // Warn user before proceeding
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete ALL assignments for ALL selected apps?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // show necessary controls

            pbCalculate.Show();
            lblProgress.Show();
            lblDeleteStatusText.Show();
            lblNumberOfAssignmentsDeleted.Text = 0.ToString();
            numberOfAssignmentsDeleted = 0;





            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();

            // store all app IDs in a list
            List<string> appIDs = new List<string>();

            // IDs are at index 2 in the datagridview
            foreach (DataGridViewRow selectedRow in dtgDisplayApp.SelectedRows)
            {
                // Make sure the row is not a new row (if your DataGridView allows adding new rows)
                if (!selectedRow.IsNewRow)
                {
                    appIDs.Add(selectedRow.Cells[2].Value.ToString());
                }
            }

            int numberOfApps = appIDs.Count;
            WriteToLog("Number of apps selected for deleting assignments is " + numberOfApps);
            rtbSummary.AppendText("Number of apps selected for deleting assignments is " + numberOfApps);
            rtbSummary.AppendText("\n");

            // Set the progress bar maximum value
            pbCalculate.Maximum = numberOfApps;


            // Process the list and delete all assignments for each app

            foreach (var appID in appIDs)
            {

                // find the app name
                var appName = dtgDisplayApp.SelectedRows[0].Cells[0].Value.ToString();

                WriteToLog("Begin deleting assignments for app " + appName + " with app id " + appID);
                rtbSummary.AppendText("Begin deleting assignments for app " + appName + " with app id " + appID);
                rtbSummary.AppendText("\n");


                // Query graph for assignment ID for a given app
                var result = await graphClient.DeviceAppManagement.MobileApps[appID].Assignments.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id", "intent" };
                });

                // Add the result to a list of assignments
                List<MobileAppAssignment> assignmentsList = new List<MobileAppAssignment>();
                assignmentsList.AddRange(result.Value);

                // check if the result is null
                if (result.Value.Count == 0)
                {
                    WriteToLog("No assignments found for app " + appName);
                    rtbSummary.AppendText("No assignments found for app + " + appName);
                    rtbSummary.AppendText("\n");

                }
                else
                {
                    // count how many assignments are found
                    int numberOfAssignments = assignmentsList.Count;

                    WriteToLog("Number of assignments found for app" + appName + " is " + numberOfAssignments);
                    rtbSummary.AppendText("Number of assignments found for app" + appName + " is " + numberOfAssignments);
                    rtbSummary.AppendText("\n");

                    // Loop through the list and delete each assignment

                    foreach (var assignment in assignmentsList)
                    {
                        // find the group name
                        var groupName = await FindGroupNameFromAppAssignmentID(appID, assignment.Id);

                        if (groupName == "ERROR LOOKING UP GROUP NAME FROM GROUP ID")
                        {
                            WriteToLog("Group ID + " + assignment.Id + " does not exist in Entra. This is most likely because the group has been deleted. Skipping");
                            rtbSummary.ForeColor = Color.Yellow;
                            rtbSummary.AppendText("Group ID + " + assignment.Id + " does not exist in Entra. This is most likely because the group has been deleted. Skipping");
                            rtbSummary.AppendText("\n");
                            rtbSummary.ForeColor = defaultColor;
                        }
                        else
                        {
                            // Delete assignment
                            await graphClient.DeviceAppManagement.MobileApps[appID].Assignments[assignment.Id].DeleteAsync();

                            WriteToLog("Assignment for group " + groupName + " has been deleted");
                            rtbSummary.AppendText("Assignment for group " + groupName + " has been deleted");
                            rtbSummary.AppendText("\n");

                            // Update the label with the number of assignments deleted
                            numberOfAssignmentsDeleted++;
                            lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString();
                        }


                    }
                }
                // Update the progress bar
                pbCalculate.Value++;
            }



        }

        public void HelpGuide()
        {

            DialogResult result = MessageBox.Show("Do you want a quick tour?", "Quick tour", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {

                pnlSearchApp.Visible = false;
                pnllViewAssignments.Visible = false;

                MessageBox.Show("Here you can view and delete assignments");

                pnlSearchApp.Visible = true;
                MessageBox.Show("Firstly you find and select the application you want to view assignments for");

                pnllViewAssignments.Visible = true;
                MessageBox.Show("Then you can view and delete assignments");


            }

            else if (result == DialogResult.No)

            {

                // User clicked no, so do nothing

            }


            else

            {
                MessageBox.Show("An error has occured when trying to display the help guide.");
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
            ClearRichTextBox(rtbSummary);
            pbCalculate.Value = 0;
            listAllApps();
        }

        private async void dtgDisplayApp_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // Clear the datagridview for older results
            FormUtilities.ClearDataGridView(dtgGroupAssignment);




            await ListAllAssignedGroups();

        }




        private void pbClearDtgDisplayApp_Click(object sender, EventArgs e)
        {
            // Clear the datagridview for older results

            FormUtilities.ClearDataGridView(dtgDisplayApp);
        }

        private void pbpbClearDtgGroupAssignment_Click(object sender, EventArgs e)
        {
            // Clear the datagridview for older results
            FormUtilities.ClearDataGridView(dtgGroupAssignment);
        }

        private async void tstbtn1_Click(object sender, EventArgs e)
        {

            // Show message box with warning, and if statement based on what the user clicks

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all assignments for this app?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                // If user clicks yes, delete all assignments
                deleteAppAssignment();

                // Clear the datagridview for older results
                FormUtilities.ClearDataGridView(dtgGroupAssignment);

            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }


        }

        private void btnDeleteSelectedAssignment_Click(object sender, EventArgs e)
        {
            // Show message box with warning, and if statement based on what the user clicks

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected assignments for this app?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                // If user clicks yes, delete all assignments
                deleteSelectedAppAssignment(dtgGroupAssignment);
            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }


        }

        private void pbHelpGuide_Click(object sender, EventArgs e)
        {
            HelpGuide();
        }



        private void dtgDisplayApp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is not the header cell
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Clear the previous selection
                dtgDisplayApp.ClearSelection();

                // Select the entire row
                dtgDisplayApp.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnClearSummary_Click(object sender, EventArgs e)
        {
            ClearRichTextBox(rtbSummary);
        }

        private async void btnDeleteAssignmentForSelectedApps_Click(object sender, EventArgs e)
        {
            // show necessary controls
            lblProgress.Show();
            lblProgress.Text = "Processing the number of apps and assignments to be deleted...";
            pbCalculate.Show();
            pbCalculate.Style = ProgressBarStyle.Marquee;

            // Show number of apps and assignments to be deleted
            var status = await CountNumberOfAssignmentsToBeDeleted();


            MessageBox.Show(status);

            // hide necessary controls
            lblProgress.Hide();
            pbCalculate.Hide();
            pbCalculate.Style = ProgressBarStyle.Blocks;


            // Show message box with warning, and if statement based on what the user clicks

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete ALL assignments for ALL selected apps?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                // If user clicks yes, delete all assignments
                await deleteSelectedAppAssignments();
            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }


        }


    }
}
