using Microsoft.Graph.Beta.Models;
using System.Reflection;
using static IntuneAssignments.GlobalVariables;
using static IntuneAssignments.GraphServiceClientCreator;

namespace IntuneAssignments
{
    public partial class ManagePolicyAssignments : Form
    {

        private readonly Form1 _form1;


        public ManagePolicyAssignments(Form1 form1)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            //_form1 = form1;
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



            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();





            if (appType == "Compliance")
            {

                // Must check what platform the policy is for and create the correct object type

                // Look up the class name based on the odatatype property
                var policyClassName = policy.findCompliancePolicyType(policyPlatform);

                // Create the full class name
                var fullClassName = _form1.graphClassNamePrefix + policyClassName;

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

                    MessageBox.Show("No assigments for this policy");


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


                        }
                    }





                }




            }

            if (appType == "Settings catalog")
            {





            }

            if (appType == "Device configuration")
            {





            }


        }


        public async void deletePolicyAssignment()
        {

            // Awaiting support ticket on github before proceeding with this



            // Deletes all assignments for the selected policy


            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();


            // Convert value og lblappid.text to mobile app ID
            var policyID = lblPolicyID.Text;
            var policyType = lblPolicyType.Text;






            if (policyType == "Compliance")
            {

                // Query graph for assignment ID for a given policy

                var result = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments.GetAsync();


                // Add the result to a list of assignments
                List<DeviceCompliancePolicyAssignment> assignmentsList = new List<DeviceCompliancePolicyAssignment>();
                assignmentsList.AddRange(result.Value);


                // Loop through the list and delete each assignment

                foreach (var assignment in assignmentsList)
                {
                    //MessageBox.Show(assignment.Id + " " + assignment.Intent);

                    await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments[assignment.Id].DeleteAsync();
                }


            }






        }




        private void btnListAllPolices_Click(object sender, EventArgs e)
        {
            listAllCompliancePolicies();
            listAllSettingsCatalogPolicies();
            listAllDeviceConfigurationPolicies();
        }




        private void dtgDisplayPolicy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            findPolicyAssignment();
        }

        private void btnDeleteAllAssignments_Click(object sender, EventArgs e)
        {
            // Show message box with warning, and if statement based on what the user clicks

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all assignments for this policy?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                // If user clicks yes, delete all assignments
                deletePolicyAssignment();

                // Clear the datagridview for older results
                FormUtilities.ClearDataGridView(dtgGroupAssignment);

                // Refresh datagridview
                findPolicyAssignment();
            }
            else if (dialogResult == DialogResult.No)
            {
                // If user clicks no, do nothing
            }
        }

        private void btnSearchPolicy_Click(object sender, EventArgs e)
        {

        }
    }
}
