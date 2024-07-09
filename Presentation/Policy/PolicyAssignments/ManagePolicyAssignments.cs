using Microsoft.Graph.Beta.Models;
using System.Reflection;
using static IntuneAssignments.Backend.GlobalVariables;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.FormUtilities;
using Microsoft.Graph.Beta.Models.Networkaccess;
using IntuneAssignments.Backend;
using System.Windows.Forms;
using Microsoft.Graph.Beta.DeviceManagement.Intents.Item.Assign;

namespace IntuneAssignments
{
    public partial class ManagePolicyAssignments : Form
    {

        private readonly Application _form1;


        public ManagePolicyAssignments(Application form1)
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

        async void ListAllSecurityBaselines()
        {
            // The new way of querying security baselines
            // Older methods above are still valid but this is the new way of querying security baselines
            // Older methods should be updated

            // Create the graph client
            var graphClient = CreateGraphServiceClient();

            var securityBaselines = await GetSecurityBaselines(graphClient);

            // check if there are any security baselines

            if (securityBaselines.Count == 0)
            {

                rtbSummary.AppendText("No security baselines found." + Environment.NewLine);
                return;
            }

            // Add the security baselines to the datagridview

            foreach (var baseline in securityBaselines)
            {


                // Lookup templateID and translate to template friendly name

                var templateID = baseline.TemplateId;
                var templateName = await GetTemplateDisplayNameFromTemplateID(templateID);
                var templatePlatform = await GetTemplatePlatformFromTemplateID(templateID);

                dtgDisplayPolicy.Rows.Add(baseline.DisplayName, templateName, templatePlatform, baseline.Id);
            }

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

            if (appType == "Settings Catalog")
            {
                // This code block lists all settings catalog assignments

                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.ConfigurationPolicies[policyID].Assignments.GetAsync();


                // Add the result to a list of assignments
                List<DeviceManagementConfigurationPolicyAssignment> assignmentsList = new List<DeviceManagementConfigurationPolicyAssignment>();
                assignmentsList.AddRange(result.Value);

                // Check if there are any assignments

                if (assignmentsList.Count == 0)
                {
                    WriteToLog("No assignments found for " + appname);
                    rtbSummary.AppendText("No assignments found for " + appname + Environment.NewLine);
                    return;
                }


                // Clear the datagridview
                dtgGroupAssignment.Rows.Clear();

                // Loop through the list and display each assignment

                foreach (var assignment in assignmentsList)
                {

                    // Get group ID from assignment ID
                    var groupID = GetGroupIDFromAssignmentID(assignment.Id.ToString());

                    // Get group name from group ID
                    var groupName = await FindGroupNameFromGroupID(groupID);


                    // Add the assigned group name and ID to the datagridview
                    dtgGroupAssignment.Rows.Add(groupName, groupID);
                    WriteToLog("Group assignment for " + appname + " found : " + groupName + ". ID is : " + groupID);

                }

            }

            if (appType == "Device Configuration")
            {
                // This code block lists all device configuration assignments

                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.DeviceConfigurations[policyID].Assignments.GetAsync();


                // Add the result to a list of assignments
                List<DeviceConfigurationAssignment> assignmentsList = new List<DeviceConfigurationAssignment>();
                assignmentsList.AddRange(result.Value);

                // Check if there are any assignments

                if (assignmentsList.Count == 0)
                {
                    WriteToLog("No assignments found for " + appname);
                    rtbSummary.AppendText("No assignments found for " + appname + Environment.NewLine);
                    return;
                }

                // Clear the datagridview
                dtgGroupAssignment.Rows.Clear();

                // Loop through the list and display each assignment

                foreach (var assignment in assignmentsList)
                {

                    // Get group ID from assignment ID
                    var groupID = GetGroupIDFromAssignmentID(assignment.Id.ToString());

                    // Get group name from group ID
                    var groupName = await FindGroupNameFromGroupID(groupID);

                    dtgGroupAssignment.Rows.Add(groupName, groupID);
                    WriteToLog("Group assignment for " + appname + " found : " + groupName + ". ID is : " + groupID);

                }
            }

            if (appType == "Administrative Templates")
            {
                // This code block lists all ADMX templates (called groupPolicyConfigurations in Graph API) assignments

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

            if (appType.StartsWith("MDM Security Baseline for Windows 10") || appType == "Microsoft Defender for Endpoint baseline" || appType == "Windows 365 Security Baseline" || appType == "BitLocker")
            {
                // Checks for assignments for security baselines for Windows 10 and later

                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.Intents[policyID].Assignments.GetAsync();

                // Add the result to a list of assignments
                List<DeviceManagementIntentAssignment> assignmentsList = new List<DeviceManagementIntentAssignment>();
                assignmentsList.AddRange(result.Value);

                // Check if there are any assignments

                if (assignmentsList.Count == 0)
                {
                    WriteToLog("No assignments found for " + appname);
                    rtbSummary.AppendText("No assignments found for " + appname + Environment.NewLine);
                    return;
                }

                // Clear the datagridview
                dtgGroupAssignment.Rows.Clear();

                // Loop through the list and display each assignment

                foreach (var assignment in assignmentsList)
                {

                    // Must cast the assignment target to the correct type in order to get the group ID
                    // This is because the target is a polymorphic type

                    // check if it is all users or all devices virtual groups

                    if (assignment.Target.GetType() == typeof(AllDevicesAssignmentTarget))
                    {
                        // Add the assigned group name and ID to the datagridview
                        dtgGroupAssignment.Rows.Add(allDevicesGroupName, allDevicesGroupID);
                        WriteToLog("Group assignment for " + appname + " found :" + allDevicesGroupName + ". ID is : " + allDevicesGroupID);

                        
                    }
                    else if (assignment.Target.GetType() == typeof(AllLicensedUsersAssignmentTarget))
                    {
                        // Add the assigned group name and ID to the datagridview
                        dtgGroupAssignment.Rows.Add(allUsersGroupName, allUsersGroupID);
                        WriteToLog("Group assignment for " + appname + " found :" + allUsersGroupName + ". ID is : " + allUsersGroupID);

                        
                    }
                    else
                    {
                        GroupAssignmentTarget groupAssignmentTarget = (GroupAssignmentTarget)assignment.Target;

                        groupAssignmentTarget.GroupId.ToString();

                        var groupID = groupAssignmentTarget.GroupId.ToString();
                        var groupName = await FindGroupNameFromGroupID(groupID);

                        dtgGroupAssignment.Rows.Add(groupName, groupID);
                        WriteToLog("Group assignment for " + appname + " found : " + groupName + ". ID is : " + groupID);
                    }

                    

                }
            }


        }

        public async Task DeleteAssignmentsFromSelectedPolicy()
        {
            // Deletes all assignments for the selected policies


            // show necessary controls

            pnlStatus.Show();
            rtbSummary.Show();
            lblNumberOfAssignmentsDeleted.Hide();
            lblDeleteStatusText.Hide();
            lblProgress.Hide();
            pBCalculate.Hide();
            btnClearSummary.Show();

            // Count number of selected rows (policies)
            var selectedRows = dtgDisplayPolicy.SelectedRows.Count;

            // If no rows are selected, show a message box
            if (selectedRows == 0)
            {
                MessageBox.Show("No rows are selected. Please select a row to delete.");
                return;
            }



            // If rows are selected, warn user before proceeding
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all assignments for the " + selectedRows + " selected policies?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                // Make assignment list for each selected policy and pass it to the delete method

                var listOfAssignments = new List<string>();

                var graphClient = CreateGraphServiceClient();

                foreach (DataGridViewRow assignment in dtgDisplayPolicy.SelectedRows)
                {

                    // clear the assignment list before adding new assignments
                    listOfAssignments.Clear();

                    var policyID = assignment.Cells[3].Value.ToString();
                    var policyType = assignment.Cells[1].Value.ToString();


                    // Check the policy to make the right API call

                    if (policyType == "Compliance")
                    {
                        WriteToLog("Deleting assignments for compliance policies are currently not implemented. Skipping...");
                        rtbSummary.ForeColor = Color.Yellow;
                        rtbSummary.AppendText("Deleting assignments for compliance policies are currently not implemented. Skipping..." + Environment.NewLine);
                        rtbSummary.ForeColor = Color.Salmon;


                        await DeletePolicyAssignment(listOfAssignments, policyType);
                    }

                    if (policyType == "Settings Catalog")
                    {
                        WriteToLog("Deleting assignments for settings catalog policies are currently not implemented. Skipping...");
                        rtbSummary.ForeColor = Color.Yellow;
                        rtbSummary.AppendText("Deleting assignments for settings catalog policies are currently not implemented. Skipping..." + Environment.NewLine);
                        rtbSummary.ForeColor = Color.Salmon;


                        await DeletePolicyAssignment(listOfAssignments, policyType);
                    }

                    if (policyType == "Device Configuration")
                    {
                        // Get all assigned groups for the selected policy

                        var result = await graphClient.DeviceManagement.DeviceConfigurations[policyID].Assignments.GetAsync();

                        // Check if there are any assignments

                        if (result.Value.Count == 0)
                        {
                            WriteToLog("No assignments found for " + assignment.Cells[0].Value.ToString());
                            rtbSummary.AppendText("No assignments found for " + assignment.Cells[0].Value.ToString() + Environment.NewLine);
                            return;
                        }

                        // Add the result to a list of assignments

                        foreach (var ID in result.Value)
                        {
                            // Add the assignment ID to the list
                            listOfAssignments.Add(ID.Id);
                        }

                        await DeletePolicyAssignment(listOfAssignments, policyType);
                    }

                    if (policyType == "Administrative Templates")
                    {
                        // Get all assigned groups for the selected policy

                        var result = await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assignments.GetAsync();

                        // Check if there are any assignments

                        if (result.Value.Count == 0)
                        {
                            WriteToLog("No assignments found for " + assignment.Cells[0].Value.ToString());
                            rtbSummary.AppendText("No assignments found for " + assignment.Cells[0].Value.ToString() + Environment.NewLine);
                            return;
                        }

                        // Add the result to a list of assignments

                        foreach (var ID in result.Value)
                        {
                            // Add the assignment ID to the list
                            listOfAssignments.Add(ID.Id);
                        }

                        await DeletePolicyAssignment(listOfAssignments, policyType);

                    }



                }

                // Clear the datagridview for older results
                //FormUtilities.ClearDataGridView(dtgGroupAssignment);

            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }
        }


        public async Task deleteSelectedPolicyAssignment()
        {
            // Deletes the selected policy assignment for the selected policy

            

            // Does not work for certain security baseline types. See other methods for those

            // Check if any rows are selected

            if (dtgGroupAssignment.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows are selected. Please select a row to delete.");
                return;
            }

            var listOfAssignments = new List<string>();
            var policyType = lblPolicyType.Text;
            var policyID = lblPolicyID.Text;


            // Check if the policy type is the intent type
            // The intent type works differently than other policy types, hence the need for a separate way of deleting assignments

            if (policyType.StartsWith("MDM Security Baseline for Windows 10") || policyType == "Microsoft Defender for Endpoint baseline" || policyType == "Windows 365 Security Baseline" || policyType == "BitLocker")
            {
                /*
                 * The way it works is that you do a POST with the group ID's you want to keep assigned to the policy, and the rest will be deleted
                 */

                var groupIDs = new List<string>();

                foreach (DataGridViewRow row in dtgGroupAssignment.SelectedRows)
                {
                    if (row.Selected)
                    {
                        // Get the group ID of the group you want to delete

                        var groupID = row.Cells[1].Value.ToString();

                        groupIDs.Add(groupID);
                    }


                }

                try
                {
                    // Call the method to delete the assignments
                    await DeleteSecurityBaselineAssignments(groupIDs, policyID);

                    foreach (var group in groupIDs)
                    {
                        rtbSummary.AppendText("Assignment deleted for " + lblPolicyName.Text + " for group " + group + Environment.NewLine);
                        rtbSummary.AppendText(Environment.NewLine);
                    }

                }
                catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
                {
                    rtbSummary.AppendText("Error deleting assignment for " + lblPolicyName.Text + " for group " + me.Message + Environment.NewLine);
                }
                return;
            }





                // For all other policy types
                // Create the assignment ID for each row selected from the policy ID and group ID and store it in a variable

                foreach (DataGridViewRow selectedRow in dtgGroupAssignment.SelectedRows)
                {
                    // Add the assignment ID to the list
                    var groupID = selectedRow.Cells[1].Value.ToString();
                    
                    var assignmentID = policyID + "_" + groupID;
                    listOfAssignments.Add(assignmentID);
                }
            await DeletePolicyAssignment(listOfAssignments, policyType);
        }





        public async Task deleteAllPolicyAssignments()
        {
            // Deletes all policy assignments for the selected policy


            // check if there are any rows in the datagridview

            if (dtgGroupAssignment.Rows.Count == 0)
            {
                MessageBox.Show("There are no assignments for the selected app.");
                return;
            }


            // make a list of all rows

            var listOfAssignments = new List<string>();
            var policyType = lblPolicyType.Text;


            // Loop through all rows in the datagridview and add the assignment ID to the list

            foreach (DataGridViewRow row in dtgGroupAssignment.Rows)
            {
                // Add the assignment ID to the list
                var groupID = row.Cells[1].Value.ToString();
                var policyID = lblPolicyID.Text;
                var assignmentID = policyID + "_" + groupID;
                listOfAssignments.Add(assignmentID);
            }

            // Call the delete method
            await DeletePolicyAssignment(listOfAssignments, policyType);

        }

        
        public async Task DeletePolicyAssignment(List<string> assignmentList, string policyType)
        {
            /* 
             *  Method to delete a given assignments for a given policy
             */

            // reset the progress bar from any previous operations
            pBCalculate.Value = 0;

            // Declare variables
            int numberOfAssignmentsDeleted = 0;

            // Store the policy type
            //var policyType = lblPolicyType.Text;


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
                    WriteToLog("Deleting assignments for compliance policies are currently not implemented. Skipping...");
                    rtbSummary.ForeColor = Color.Yellow;
                    rtbSummary.AppendText("Deleting assignments for compliance policies are currently not implemented. Skipping..." + Environment.NewLine);
                    rtbSummary.ForeColor = Color.Salmon;
                    return;


                    // Delete the assignment
                    await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments[assignmentID].DeleteAsync();
                    WriteToLog("Assignment deleted for " + lblPolicyName.Text + " for group " + groupID);
                    rtbSummary.AppendText("Assignment deleted for " + lblPolicyName.Text + " for group " + groupID + Environment.NewLine);
                    pBCalculate.Value++;
                    lblNumberOfAssignmentsDeleted.Text = 1.ToString();
                }

                if (policyType == "Settings Catalog")
                {

                    WriteToLog("Deleting assignments for settings catalog policies are currently not implemented. Skipping...");

                    rtbSummary.ForeColor = Color.Yellow;
                    rtbSummary.AppendText("Deleting assignments for settings catalog policies are currently not implemented. Skipping..." + Environment.NewLine);
                    rtbSummary.ForeColor = Color.Salmon;
                    return;



                    // Delete the assignment
                    await graphClient.DeviceManagement.ConfigurationPolicies[policyID].Assignments[assignmentID].DeleteAsync();

                }

                if (policyType == "Device Configuration")
                {
                    // Delete the assignment
                    await graphClient.DeviceManagement.DeviceConfigurations[policyID].Assignments[assignmentID].DeleteAsync();
                    WriteToLog("Assignment for group " + groupID + " has been deleted.");
                    rtbSummary.AppendText("Assignment for group " + groupID + " has been deleted." + Environment.NewLine);
                    pBCalculate.Value++;
                    numberOfAssignmentsDeleted++;
                    lblNumberOfAssignmentsDeleted.Text = numberOfAssignmentsDeleted.ToString();
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

                if (policyType.StartsWith("MDM Security Baseline for Windows 10") || policyType == "Microsoft Defender for Endpoint baseline" || policyType == "Windows 365 Security Baseline" || policyType == "BitLocker")
                {
                    // Delete all assignments for the security baseline

                    // new post request body
                    var requestBody = new AssignPostRequestBody
                    {

                        Assignments = new List<DeviceManagementIntentAssignment>()
                    };

                    // Delete - POST request with the group ID's you want to keep assigned to the policy
                    await graphClient.DeviceManagement.Intents[policyID].Assign.PostAsync(requestBody);

                    // TODO - all users and all devices

                }
            }
        }


        private void btnListAllPolices_Click(object sender, EventArgs e)
        {
            listAllCompliancePolicies();
            listAllSettingsCatalogPolicies();
            listAllDeviceConfigurationPolicies();
            ListAllADMXTemplates();
            ListAllSecurityBaselines();
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
            await findPolicyAssignment();
        }

        private void ManagePolicyAssignments_Load(object sender, EventArgs e)
        {

        }

        private void btnClearSummary_Click(object sender, EventArgs e)
        {
            ClearRichTextBox(rtbSummary);
        }

        private async void btnDeleteAssignmentForSelectedPolicies_Click(object sender, EventArgs e)
        {
            await DeleteAssignmentsFromSelectedPolicy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListAllSecurityBaselines();
        }
    }
}
