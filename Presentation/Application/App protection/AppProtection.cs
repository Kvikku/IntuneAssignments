using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.Application;
using static IntuneAssignments.Backend.FormUtilities;


namespace IntuneAssignments.Presentation.Application.App_protection
{
    public partial class AppProtection : Form
    {
        // Global variables
        private readonly IntuneAssignments.Application _application;


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
            // This method prepares the deployment of the selected app protection policy to the selected group


            // clear the rich text boxes
            ClearRichTextBox(rtbSelectedGroups);
            ClearRichTextBox(rtbSelectedPolicies);

            //

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

        }
    }
}
