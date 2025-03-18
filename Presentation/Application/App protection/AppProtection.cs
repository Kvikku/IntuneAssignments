using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.Application;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.GraphServiceClientCreator;


namespace IntuneAssignments.Presentation.Application.App_protection
{
    public partial class AppProtection : Form
    {
        // Global variables
        private readonly IntuneAssignments.Application _application;
        public List<AndroidManagedAppProtection> SelectedAndroidManagedAppProtectionPolicies;
        public List<IosManagedAppProtection> SelectediOSManagedAppProtectionPolicies;
        public List<WindowsManagedAppProtection> SelectedWindowsManagedAppProtectionPolicies;
        public List<WindowsInformationProtection> SelectedMDMWindowsInformationProtectionPolicies;
        public List<Group> SelectedGroups;


        // Load and startup mechanics
        public AppProtection(IntuneAssignments.Application application)
        {
            InitializeComponent();
            _application = application;

        }

        protected override void OnLoad(EventArgs e)
        {
            // Necessary to copy the location of Form1
            base.OnLoad(e);

            // Set the location of the form to the position of Form1
            if (_application != null)
            {
                Location = new Point(
                    _application.Location.X + (_application.Width - Width) / 2,
                    _application.Location.Y + (_application.Height - Height) / 2);
            }

            // Set default value for app type combo box
            cBAppType.SelectedIndex = 0;

            // Set the progress bar to 0
            pBarDeployProgress.Value = 0;

            // initialize the lists
            SelectedAndroidManagedAppProtectionPolicies = new List<AndroidManagedAppProtection>();
            SelectediOSManagedAppProtectionPolicies = new List<IosManagedAppProtection>();
            SelectedWindowsManagedAppProtectionPolicies = new List<WindowsManagedAppProtection>();
            SelectedMDMWindowsInformationProtectionPolicies = new List<WindowsInformationProtection>();
            SelectedGroups = new List<Group>();

        }





        // Application logic

        private async Task ListAllAndroidApplicationProtectionPolicies(DataGridView dataGridView)
        {
            // Get all the Android app protection policies

            var result = await GetAllAndroidManagedAppProtectionPolicies();

            // Check if the result is empty
            if (result == null)
            {
                WriteToLog("No Android app protection policies found");
                rtbDeploymentSummary.SelectionColor = Color.Yellow;
                rtbDeploymentSummary.AppendText("No Android app protection policies found");
                rtbDeploymentSummary.ForeColor = rtbDeploymentSummary.ForeColor;

                return;
            }
            else
            {
                foreach (var policy in result)
                {
                    // Add the policy to the data grid view
                    dataGridView.Rows.Add(policy.DisplayName, "Android", policy.Id);
                }
            }
        }

        private async Task ListAlliOSAppProtectionPolicies(DataGridView dataGridView)
        {
            // Get all the iOS app protection policies

            var result = await GetAlliOSAppProtectionPolicies();

            // Check if the result is empty
            if (result == null)
            {
                WriteToLog("No iOS app protection policies found");
                rtbDeploymentSummary.SelectionColor = Color.Yellow;
                rtbDeploymentSummary.AppendText("No iOS app protection policies found");
                rtbDeploymentSummary.ForeColor = rtbDeploymentSummary.ForeColor;

                return;
            }
            else
            {
                foreach (var policy in result)
                {
                    // Add the policy to the data grid view
                    dataGridView.Rows.Add(policy.DisplayName, "iOS/iPadOS", policy.Id);
                }
            }
        }

        private async Task ListAllWindowsManagedAppProtection(DataGridView dataGridView)
        {
            // Get all the Windows app protection policies

            var result = await GetAllWindowsAppProtectionPolicies();

            // Check if the result is empty

            if (result == null)
            {
                WriteToLog("No Windows app protection policies found");
                rtbDeploymentSummary.SelectionColor = Color.Yellow;
                rtbDeploymentSummary.AppendText("No Windows app protection policies found");
                rtbDeploymentSummary.ForeColor = rtbDeploymentSummary.ForeColor;

                return;
            }
            else
            {
                foreach (var policy in result)
                {
                    // Add the policy to the data grid view
                    dataGridView.Rows.Add(policy.DisplayName, "Windows", policy.Id);
                }
            }
        }

        private async Task ListAllMdmWindowsInformationProtectionPolicy(DataGridView dataGridView)
        {
            // Get all the MDM Windows Information Protection policies

            var result = await GetAllMDMWindowsInformationProtectionPolicies();

            // Check if the result is empty

            if (result == null)
            {
                WriteToLog("No MDM Windows Information Protection policies found");
                rtbDeploymentSummary.SelectionColor = Color.Yellow;
                rtbDeploymentSummary.AppendText("No MDM Windows Information Protection policies found");
                rtbDeploymentSummary.ForeColor = rtbDeploymentSummary.ForeColor;

                return;
            }
            else
            {
                foreach (var policy in result)
                {
                    // Add the policy to the data grid view
                    dataGridView.Rows.Add(policy.DisplayName, "Windows", policy.Id);
                }
            }
        }

        private async Task ListAllAppProtectionPolicies()
        {
            await ListAlliOSAppProtectionPolicies(dtgDisplayAppProtectionPolicies);
            await ListAllAndroidApplicationProtectionPolicies(dtgDisplayAppProtectionPolicies);
            await ListAllWindowsManagedAppProtection(dtgDisplayAppProtectionPolicies);
            await ListAllMdmWindowsInformationProtectionPolicy(dtgDisplayAppProtectionPolicies);
        }

        private void PreparePolicyDeployment()
        {
            /* 
             * This method prepares the deployment of the selected app protection policy to the selected group
             * 
             * It also updated the rich text boxes with the selected app protection policies and groups
             * 
             * Finally it updates the global variables with the selected app protection policies and groups
             * 
             */



            // clear the rich text boxes
            ClearRichTextBox(rtbSelectedGroups);
            ClearRichTextBox(rtbSelectedPolicies);


            // Clear the selected app protection policies and groups lists if the are not empty
            if (SelectedAndroidManagedAppProtectionPolicies != null)
            {
                SelectedAndroidManagedAppProtectionPolicies.Clear();
            }

            if (SelectediOSManagedAppProtectionPolicies != null)
            {
                SelectediOSManagedAppProtectionPolicies.Clear();
            }

            if (SelectedWindowsManagedAppProtectionPolicies != null)
            {
                SelectedWindowsManagedAppProtectionPolicies.Clear();
            }

            if (SelectedMDMWindowsInformationProtectionPolicies != null)
            {
                SelectedMDMWindowsInformationProtectionPolicies.Clear();
            }

            // Copy the selected app protection policies and groups to the rich text boxes and lists


            foreach (DataGridViewRow row in dtgDisplayAppProtectionPolicies.SelectedRows)
            {
                rtbSelectedPolicies.AppendText(row.Cells[0].Value.ToString() + "\n");

                // Debug variables
                string platForm = row.Cells[1].Value.ToString();
                string policyId = row.Cells[2].Value.ToString();
                string displayName = row.Cells[0].Value.ToString();


                // Check the app type and add the selected app protection policy to the corresponding list
                if (row.Cells[1].Value.ToString() == "Android")
                {

                    SelectedAndroidManagedAppProtectionPolicies.Add(new AndroidManagedAppProtection
                    {
                        Id = row.Cells[2].Value.ToString(),
                        DisplayName = row.Cells[0].Value.ToString()
                    });
                }

                else if (row.Cells[1].Value.ToString() == "iOS/iPadOS")
                {
                    SelectediOSManagedAppProtectionPolicies.Add(new IosManagedAppProtection
                    {
                        Id = row.Cells[2].Value.ToString(),
                        DisplayName = row.Cells[0].Value.ToString()
                    });
                }

                else if (row.Cells[1].Value.ToString() == "Windows")
                {
                    SelectedWindowsManagedAppProtectionPolicies.Add(new WindowsManagedAppProtection
                    {
                        Id = row.Cells[2].Value.ToString(),
                        DisplayName = row.Cells[0].Value.ToString()
                    });
                }
            }

            foreach (DataGridViewRow row in dtgDisplayGroup.SelectedRows)
            {
                rtbSelectedGroups.AppendText(row.Cells[0].Value.ToString() + "\n");

                // Add the selected group to the selected groups list
                SelectedGroups.Add(new Group
                {
                    Id = row.Cells[3].Value.ToString(),
                    DisplayName = row.Cells[0].Value.ToString(),
                });
            }
        }

        private async Task AssignSelectedPolicies()
        {
            // Assign the selected app protection policies to the selected groups



            // Get the selected app protection policies and groups

            // Check if the selected app protection policies and groups are empty

            if (SelectedAndroidManagedAppProtectionPolicies.Count == 0 && SelectediOSManagedAppProtectionPolicies.Count == 0 && SelectedWindowsManagedAppProtectionPolicies.Count == 0 && SelectedMDMWindowsInformationProtectionPolicies.Count == 0)
            {
                WriteToLog("No app protection policies selected");
                rtbDeploymentSummary.SelectionColor = Color.Yellow;
                rtbDeploymentSummary.AppendText("No app protection policies selected \n");
                rtbDeploymentSummary.ForeColor = rtbDeploymentSummary.ForeColor;

                return;
            }

            if (dtgDisplayGroup.SelectedRows.Count == 0)
            {
                WriteToLog("No groups selected");
                rtbDeploymentSummary.SelectionColor = Color.Yellow;
                rtbDeploymentSummary.AppendText("No groups selected \n");
                rtbDeploymentSummary.ForeColor = rtbDeploymentSummary.ForeColor;

                return;
            }

            // check each list of selected app protection policies and assign them to the selected groups

            if (SelectedAndroidManagedAppProtectionPolicies.Count > 0)
            {
                foreach (var policy in SelectedAndroidManagedAppProtectionPolicies)
                {
                    foreach (var group in SelectedGroups)
                    {
                        // Assign the selected app protection policy to the selected group
                        await AssignAndroidManagedAppProtectionPolicy(policy.Id, group.Id);
                    }
                }
            }
        }

        public async Task AssignAndroidManagedAppProtectionPolicy(string policy, string id)
        {
            // Create a graph service client
            var graphServiceClient = CreateGraphServiceClient();


            // Create a group assignment target

            var groupAssignmentTarget = new GroupAssignmentTarget
            {
                OdataType = "#microsoft.graph.groupAssignmentTarget",
                DeviceAndAppManagementAssignmentFilterId = null,
                DeviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.None,
                GroupId = id

            };

            // Create a new Android managed app protection assignment

            var requestBody = new TargetedManagedAppPolicyAssignment
            {
                Id = id,//+ "_incl"
                Source = DeviceAndAppManagementAssignmentSource.Direct,
                SourceId = "00000000-0000-0000-0000-000000000000",
                Target = groupAssignmentTarget
            };

            var requestBody1 = new TargetedManagedAppPolicyAssignment
            {
                OdataType = "#microsoft.graph.targetedManagedAppPolicyAssignment",
                Target = new ConfigurationManagerCollectionAssignmentTarget
                {
                    OdataType = "microsoft.graph.configurationManagerCollectionAssignmentTarget",
                    CollectionId = "1e0d5d14-3275-43ad-a8e6-a4e9bb04f77d",
                },
            };



            // TODO - This is not working yet

            try
            {
                //var result = await graphServiceClient.DeviceAppManagement.AndroidManagedAppProtections[policy].Assignments[requestBody.Id].PatchAsync(requestBody);

                //var result = await graphServiceClient.DeviceAppManagement.ManagedAppPolicies[policy].PatchAsync(requestBody1);
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                MessageBox.Show(me.Message);
                throw;
            }




        }



        // Navigation mechanics
        private void goHome()
        {
            this.Hide();
            IntuneAssignments.Application application = new IntuneAssignments.Application();
            application.Show();
        }






        // Event handlers for the navigation buttons
        private void pbHome_Click(object sender, EventArgs e)
        {
            goHome();
        }

        private async void btnListAllPolicies_Click(object sender, EventArgs e)
        {
            // Clear the data grid view
            dtgDisplayAppProtectionPolicies.Rows.Clear();


            // Check the selected app type and list the corresponding app protection policies

            if (cBAppType.SelectedIndex == 0)
            {
                // List all the app protection policies
                await ListAllAppProtectionPolicies();
            }

            else if (cBAppType.SelectedIndex == 1)
            {
                // List all the iOS app protection policies
                await ListAlliOSAppProtectionPolicies(dtgDisplayAppProtectionPolicies);
            }

            else if (cBAppType.SelectedIndex == 2)
            {
                // List all the Android app protection policies
                await ListAllAndroidApplicationProtectionPolicies(dtgDisplayAppProtectionPolicies);
            }

            else if (cBAppType.SelectedIndex == 3)
            {
                // List all the Windows app protection policies
                await ListAllWindowsManagedAppProtection(dtgDisplayAppProtectionPolicies);
                await ListAllMdmWindowsInformationProtectionPolicy(dtgDisplayAppProtectionPolicies);
            }
        }


        private async void btnListAllGroups_Click(object sender, EventArgs e)
        {
            await ListAllGroupsV2(dtgDisplayGroup);
        }

        private void btnPrepareDeployment_Click(object sender, EventArgs e)
        {
            PreparePolicyDeployment();
        }

        private void btnResetDeployment_Click(object sender, EventArgs e)
        {
            /* Clear the selected app protection policies and groups */
            ClearRichTextBox(rtbSelectedGroups);
            ClearRichTextBox(rtbSelectedPolicies);
            pBarDeployProgress.Value = 0;
        }

        private async void btnDeployPolicyAssignment_Click(object sender, EventArgs e)
        {
            // Deploy the selected app protection policies to the selected groups

            // Reset the progress bar
            pBarDeployProgress.Value = 0;

            //await AssignSelectedPolicies();

            MessageBox.Show("Feature not implemented yet");

            //await AssignAndroidManagedAppProtectionPolicy("T_ca665e42-ed6f-40ea-ae4a-2ea2278f6be5", "315107e1-9ebe-47a1-8485-360591334584");
        }

        private void AppProtection_Load(object sender, EventArgs e)
        {

        }

        private void btnDeployDescription_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet");
        }
    }
}
