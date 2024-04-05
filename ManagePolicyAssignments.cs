using Microsoft.Graph.Beta.Models;
using System.Reflection;
using static IntuneAssignments.GlobalVariables;
using static IntuneAssignments.GraphServiceClientCreator;
using static IntuneAssignments.FormUtilities;
using Microsoft.Graph.Beta.Models.Networkaccess;

namespace IntuneAssignments
{
    public partial class ManagePolicyAssignments : Form
    {

        private readonly Form1 _form1;


        public ManagePolicyAssignments(Form1 form1)
        {
            // Load event

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            //_form1 = form1;

            // Hide the status panel and labels
            pnlStatus.Hide();
            lblPolicyID.Hide();
            lblPolicyType.Hide();
            lblPolicyName.Hide();

        }


        //protected override void OnLoad(EventArgs e)
        //{

        //    // Necessary to copy the location of Form1
        //    base.OnLoad(e);

        //    // Set the location of the form to the position of Form1
        //    if (_form1 != null)
        //    {
        //        Location = new Point(
        //            _form1.Location.X + (_form1.Width - Width) / 2,
        //            _form1.Location.Y + (_form1.Height - Height) / 2);
        //    }

        //    lblPolicyID.Text = "";
        //    lblPolicyName.Text = "";
        //    lblPolicyType.Text = "";

        //}


        private void viewPolicyAssignments()
        {

            // Fix this later so that it goes to the Policy form


            this.Hide();
            Policy policy = new Policy();
            policy.Show();



        }

        private void pbViewAssignments_Click(object sender, EventArgs e)
        {
            viewPolicyAssignments();
        }


        void ListAllADMXTemplates()
        {
            Policy policy = new Policy();

            policy.ListADMXTemplates(dtgDisplayPolicy);

        }


        void listAllCompliancePolicies()
        {
            Policy policy = new Policy();


            policy.ListCompliancePolicies(dtgDisplayPolicy);

        }

        void listAllSettingsCatalogPolicies()
        {
            Policy policy = new Policy();

            policy.ListSettingsCatalog(dtgDisplayPolicy);


        }

        void listAllDeviceConfigurationPolicies()
        {
            Policy policy = new Policy();

            policy.ListConfigurationProfiles(dtgDisplayPolicy);


        }

        public string getPolicyIdFromDtg(DataGridView datagridview, int columnIndex)
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





        async Task findPolicyAssignment()
        {
            Policy policy = new Policy();

            // view the labels
            lblPolicyID.Show();
            lblPolicyName.Show();
            lblPolicyType.Show();


            // Take app ID from datagridview
            // This is the Application ID for which we query assignments
            var policyPlatform = getPolicyIdFromDtg(dtgDisplayPolicy, 2);
            var appname = getPolicyIdFromDtg(dtgDisplayPolicy, 0);
            var appType = getPolicyIdFromDtg(dtgDisplayPolicy, 1);
            var policyID = getPolicyIdFromDtg(dtgDisplayPolicy, 3);


            // Load the MS Graph assembly for class lookup
            var assembly = Assembly.Load(graphAssembly);

            // Update labels
            lblPolicyID.Text = policyID;
            lblPolicyName.Text = appname;
            lblPolicyType.Text = appType;

            // Show status panel 
            pnlStatus.Show();
            rtbSummary.Show();
            lblNumberOfAssignmentsDeleted.Hide();
            lblDeleteStatusText.Hide();
            lblProgress.Hide();
            pBCalculate.Hide();
            btnClearSummary.Show();


            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();





            if (appType == "Compliance")
            {

                // Must check what platform the policy is for and create the correct object type

                // Look up the class name based on the odatatype property
                var policyClassName = policy.findCompliancePolicyType(policyPlatform);

                // Create the full class name
                var fullClassName = graphClassNamePrefix + policyClassName;

                // Create the class type
                var classType = assembly.GetType(fullClassName);


                if (classType == null)
                {
                    // troubleshoot if this happens
                    MessageBox.Show("Class type is null");
                }



                // Look up assignments and display in datagridview


                var result = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments.GetAsync();

                // Store result in list

                List<DeviceCompliancePolicyAssignment> assignmentList = new List<DeviceCompliancePolicyAssignment>();

                assignmentList.AddRange(result.Value);

                if (assignmentList.Count == 0)
                {
                    WriteToLog("No assignments found for " + appname);
                    rtbSummary.ForeColor = Color.Yellow;
                    rtbSummary.AppendText("No assignments found for " + appname + Environment.NewLine);
                    rtbSummary.ForeColor = Color.Salmon;

                }

                else if (assignmentList.Count > 0)
                {


                    // Clear the datagridview
                    dtgGroupAssignment.Rows.Clear();

                    foreach (var assignment in assignmentList)
                    {

                        // Need to parse the JSON data and grab target - GroupID field

                        var groupID = policy.ExtractGroupID(assignment.Id.ToString());

                        // Look up Azure AD groups based on ID

                        List<Group> groups = await policy.LookUpGroup(groupID);

                        foreach (var group in groups)
                        {

                            // Add the assigned group name and ID to the datagridview
                            dtgGroupAssignment.Rows.Add(group.DisplayName, group.Id);
                            WriteToLog("Group assignment for " + appname + " found : " + group.DisplayName + ". ID is : " + group.Id);
                        }
                    }
                }
            }

            if (appType == "Settings catalog")
            {
                // To be implemented
            }

            if (appType == "Device configuration")
            {
                // To be implemented
            }

            if (appType == "Administrative Templates")
            {
                // This method lists all ADMX templates (called groupPolicyConfigurations in Graph API) assignments

                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assignments.GetAsync();


                // Add the result to a list of assignments
                List<GroupPolicyConfigurationAssignment> assignmentsList = new List<GroupPolicyConfigurationAssignment>();
                assignmentsList.AddRange(result.Value);


                // Loop through the list and display each assignment

                if (assignmentsList.Count == 0)
                {
                    rtbSummary.ForeColor = Color.Yellow;
                    WriteToLog("No assignments found for " + appname);
                    rtbSummary.AppendText("No assignments found for " + appname + Environment.NewLine);
                    rtbSummary.ForeColor = Color.Salmon;
                }

                else if (assignmentsList.Count > 0)

                {
                    // Clear the datagridview
                    dtgGroupAssignment.Rows.Clear();

                    foreach (var assignment in assignmentsList)
                    {

                        // Need to parse the JSON data and grab target - GroupID field

                        //var groupID = policy.ExtractGroupID(assignment.Id.ToString());

                        // Look up Azure AD groups based on ID

                        //List<Group> groups = await policy.LookUpGroup(groupID);





                        // Get group ID from assignment ID
                        var groupID = GetGroupIDFromAssignmentID(assignment.Id.ToString());

                        // Get group name from group ID
                        var groupName = await FindGroupNameFromGroupID(groupID);
                        

                        // Add the assigned group name and ID to the datagridview
                        dtgGroupAssignment.Rows.Add(groupName, groupID);
                        WriteToLog("Group assignment for " + appname + " found : " + groupName + ". ID is : " + groupID);
                        
                        // No need to log to the rich text box
                        //rtbSummary.AppendText("Group assignment for " + appname + " found : " + groupName + ". ID is : " + groupID + Environment.NewLine);
                    }
                }
            }
        }

        public async Task deleteSelectedPolicyAssignment()
        {
            // Deletes the selected policy assignment for the selected policy

            // Create the assignment ID for each row selected from the policy ID and group ID and store it in a variable

            // Check if any rows are selected

            if (dtgGroupAssignment.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows are selected. Please select a row to delete.");
                return;
            }

            var listOfAssignments = new List<string>();
            // make a list of selected rows

            foreach (DataGridViewRow selectedRow in dtgGroupAssignment.SelectedRows)
            {
                // Add the assignment ID to the list
                var groupID = selectedRow.Cells[1].Value.ToString();
                var policyID = lblPolicyID.Text;
                var assignmentID = policyID + "_" + groupID;
                listOfAssignments.Add(assignmentID);
            }

            await DeletePolicyAssignment(listOfAssignments);

        }

        public async Task deleteAllPolicyAssignments()
        {
            // Deletes all policy assignments for the selected policy

        }


        public async Task DeletePolicyAssignment(List<string> assignmentList)
        {


            /* Test method to delete a given assignments for a given policy
             */


            // reset the progress bar from any previous operations
            pBCalculate.Value = 0;

            // Declare variables
            int numberOfAssignmentsDeleted = 0;

            // Store the policy type
            var policyType = lblPolicyType.Text;


            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();


            // Count number of assignments to calculate size of progress bar
            pBCalculate.Maximum = assignmentList.Count;


            // Enable UI features to show progress
            lblProgress.Show();
            lblDeleteStatusText.Show();
            lblNumberOfAssignmentsDeleted.Text = 0.ToString();
            lblNumberOfAssignmentsDeleted.Show();
            pBCalculate.Show();


            // Check the policy type and delete the assignment

            foreach (var policy in assignmentList)
            {
                // Split the policy ID and group ID
                var policyID = policy.Split("_")[0];
                var groupID = policy.Split("_")[1];
                var assignmentID = policyID + "_" + groupID;

                if (policyType == "Compliance")
                {
                    // Note - this currently does not work, even though the documenation says it should
                    MessageBox.Show("Deleting compliance policy assignments is currently bugged, due to an error in the Graph API. I will implement the feature as soon as the error is fixed");
                    return;
                    // Delete the assignment
                    await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments[assignmentID].DeleteAsync();
                    WriteToLog("Assignment deleted for " + lblPolicyName.Text + " for group " + groupID);
                    rtbSummary.AppendText("Assignment deleted for " + lblPolicyName.Text + " for group " + groupID + Environment.NewLine);
                    pBCalculate.Value++;
                    lblNumberOfAssignmentsDeleted.Text = 1.ToString();
                }

                if (policyType == "Settings catalog")
                {
                    // To be implemented
                }

                if (policyType == "Device configuration")
                {
                    // To be implemented
                }

                if (policyType == "Administrative Templates")
                {
                    // Delete the assignment
                    await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assignments[assignmentID].DeleteAsync();
                    WriteToLog("Assignment for group " + groupID + " has been deleted.");
                    rtbSummary.AppendText("Assignment for group " + groupID + " has been deleted." + Environment.NewLine);
                    pBCalculate.Value++;
                    numberOfAssignmentsDeleted++;
                    lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString();
                }
            }

            
        }

        public async Task deletePolicyAssignment(string PolicyID)
        {
            // This method is no longer in use

            // Deletes the selected policy assignment for the selected policy



            lblProgress.Show();
            lblDeleteStatusText.Show();
            lblNumberOfAssignmentsDeleted.Text = 0.ToString();
            lblNumberOfAssignmentsDeleted.Show();
            pBCalculate.Show();

            // Declare variables

            int numberOfPolicies;
            int numberOfAssignmentsDeleted = 0;

            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();


            // Convert value og lblappid.text to mobile app ID
            var policyID = PolicyID;
            var policyType = lblPolicyType.Text;



            if (policyType == "Compliance")
            {

                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments.GetAsync();


                // Add the result to a list of assignments
                List<DeviceCompliancePolicyAssignment> assignmentsList = new List<DeviceCompliancePolicyAssignment>();
                assignmentsList.AddRange(result.Value);

                numberOfPolicies = assignmentsList.Count;
                pBCalculate.Maximum = numberOfPolicies;

                // Loop through the list and delete each assignment

                foreach (var assignment in assignmentsList)
                {
                    var groupID = GetGroupIDFromAssignmentID(assignment.Id.ToString());
                    var groupName = await FindGroupNameFromGroupID(groupID);


                    await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments[assignment.Id].DeleteAsync();
                    WriteToLog("Assignment deleted for " + lblPolicyName.Text + " for group " + groupName);
                    rtbSummary.AppendText("Assignment deleted for " + lblPolicyName.Text + " for group " + groupName + Environment.NewLine);
                    pBCalculate.Value++;
                    numberOfAssignmentsDeleted++;
                    lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString(); 
                }
            }

            if (policyType == "Settings catalog")
            {
                // To be implemented
            }

            if (policyType == "Device configuration")
            {
                // To be implemented
            }

            if (policyType == "Administrative Templates")
            {
                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assignments.GetAsync();


                // Add the result to a list of assignments
                List<GroupPolicyConfigurationAssignment> assignmentsList = new List<GroupPolicyConfigurationAssignment>();
                assignmentsList.AddRange(result.Value);

                numberOfPolicies = assignmentsList.Count;
                pBCalculate.Maximum = numberOfPolicies;

                // Loop through the list and delete each assignment

                foreach (var assignment in assignmentsList)
                {
                    var groupID = GetGroupIDFromAssignmentID(assignment.Id.ToString());
                    var groupName = await FindGroupNameFromGroupID(groupID);

                    await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assignments[assignment.Id].DeleteAsync();

                    WriteToLog("Assignment for group " + groupName + " has been deleted.");
                    rtbSummary.AppendText("Assignment for group " + groupName + " has been deleted." + Environment.NewLine);
                    pBCalculate.Value++;
                    numberOfAssignmentsDeleted++;
                    lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString();
                }
            }
        }


        private void btnListAllPolices_Click(object sender, EventArgs e)
        {
            listAllCompliancePolicies();
            listAllSettingsCatalogPolicies();
            listAllDeviceConfigurationPolicies();
            ListAllADMXTemplates();
        }




        private void dtgDisplayPolicy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearDataGridView(dtgGroupAssignment);
            ClearRichTextBox(rtbSummary);
            findPolicyAssignment();
        }

        private async void btnDeleteAllAssignments_Click(object sender, EventArgs e)
        {
            // Show message box with warning, and if statement based on what the user clicks

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all assignments for this policy?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                // If user clicks yes, delete all assignments
                await deleteAllPolicyAssignments();

                // Clear the datagridview for older results
                FormUtilities.ClearDataGridView(dtgGroupAssignment);

                // Refresh datagridview
                //findPolicyAssignment();
            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }
        }

        private void btnSearchPolicy_Click(object sender, EventArgs e)
        {

        }

        private async void btnDeleteSelectedAssignment_Click(object sender, EventArgs e)
        {
            await deleteSelectedPolicyAssignment();
        }

        private void ManagePolicyAssignments_Load(object sender, EventArgs e)
        {

        }

        private void btnClearSummary_Click(object sender, EventArgs e)
        {
            ClearRichTextBox(rtbSummary);
        }
    }
}
