using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Usb;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;
using static IntuneAssignments.Backend.SourceTenantGraphClient;
using static IntuneAssignments.Backend.DestinationTenantGraphClient;
using static IntuneAssignments.Backend.Intune_content_classes.SettingsCatalog;
using static IntuneAssignments.Backend.IntuneContentClasses.Groups;
using Microsoft.Graph.Beta.NetworkAccess.Reports.MicrosoftGraphNetworkaccessGetDiscoveredApplicationSegmentReportWithStartDateTimeWithEndDateTimeuserIdUserId;

namespace IntuneAssignments.Presentation.Import
{
    public partial class Import : Form
    {
        private const int ExpandedHeight = 200; // Adjust as needed
        private const int CollapsedHeight = 100; // Adjust as needed

        public Import()
        {
            InitializeComponent();

            // change the application icon and use the ico file in resources folder
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

        }



        private void Import_Load(object sender, EventArgs e)
        {
            pBarLoading.Hide();
            pBarGroupLoading.Hide();
            pnlGroups.Hide();
            CheckConnection();
        }


        public void CheckConnection()
        {
            // Check if the source and tenant settings are authenticated

            if (isSourceTenantConnected)
            {
                pbSourceConnectionCheck.Image = Properties.Resources.check;
            }
            else
            {
                pbSourceConnectionCheck.Image = Properties.Resources.cancel;
            }

            if (isDestinationTenantConnected)
            {
                pbDestinationChecker.Image = Properties.Resources.check;
            }
            else
            {
                pbDestinationChecker.Image = Properties.Resources.cancel;
            }
        }







        // Click events

        private async void pbSourceTenant_Click(object sender, EventArgs e)
        {
            // Open the source tenant settings form
            SourceTenantSettings sourceTenantSettings = new SourceTenantSettings();
            sourceTenantSettings.ShowDialog();
        }

        private void pbDestinationTenant_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.ShowDialog();

        }

        private void lblDestination_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.ShowDialog();

        }

        private void pBHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void lblSourceTenant_Click(object sender, EventArgs e)
        {
            // Open the source tenant settings form
            SourceTenantSettings sourceTenantSettings = new SourceTenantSettings();
            sourceTenantSettings.ShowDialog();
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }

        private void clbContentTypes_MouseEnter(object sender, EventArgs e)
        {
            clbContentTypes.Height = ExpandedHeight;
        }

        private void clbContentTypes_MouseLeave(object sender, EventArgs e)
        {
            clbContentTypes.Height = CollapsedHeight;
        }

        private async void btnListAll_Click(object sender, EventArgs e)
        {
            // Show the progress bar
            pBarLoading.Show();

            await AddAllSettingsCatalog();


            // Hide the progress bar
            pBarLoading.Hide();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // Show the progress bar
            pBarLoading.Show();


            await SearchAndAddSettingsCatalog();



            // Hide the progress bar
            pBarLoading.Hide();
        }

        private void btnImportContet_Click(object sender, EventArgs e)
        {
            var selectedPolicies = GetSettingsCatalogFromDTG(dtgImportContent);// Import the selected content

            MessageBox.Show(selectedPolicies.Count.ToString());
        }

        private void cBoxAssignments_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxAssignments.Checked)
            {
                pnlGroups.Show();
            }
            else
            {
                pnlGroups.Hide();
            }
        }

        private void tBoxGroupSearch_Click(object sender, EventArgs e)
        {
            tBoxGroupSearch.Text = "";
        }

        private async void btnGroupListAll_Click(object sender, EventArgs e)
        {
            pBarGroupLoading.Show();

            var groups = await GetAllGroups(destinationGraphServiceClient);

            AddGroupsToDTG(groups, dtgGroups);

            pBarGroupLoading.Hide();
        }

        private async void btnGroupSearch_Click(object sender, EventArgs e)
        {
            pBarGroupLoading.Show();
            var groups = await SearchForGroups(destinationGraphServiceClient, tBoxGroupSearch.Text.ToString());

            AddGroupsToDTG(groups, dtgGroups);
            pBarGroupLoading.Hide();
        }

        private void btnClearGroupDTG_Click(object sender, EventArgs e)
        {
            // Clear the groups datagridview
            ClearDataGridView(dtgGroups);
        }

        private void btnClearContentDTG_Click(object sender, EventArgs e)
        {
            // Clear the content datagridview
            ClearDataGridView(dtgImportContent);
        }



        // Methods for the import process //

        // Settings catalog

        private async Task SearchAndAddSettingsCatalog()
        {
            // Search for settings catalog policies
            var result = await SearchForSettingsCatalog(sourceGraphServiceClient, tbSearch.Text.ToString());
            AddSettingsCatalogToDTG(result, dtgImportContent);

        }

        private async Task AddAllSettingsCatalog()
        {
            // Add all settings catalog policies
            var result = await GetAllSettingsCatalogPolicies(sourceGraphServiceClient);
            AddSettingsCatalogToDTG(result, dtgImportContent);
        }

    }
}
