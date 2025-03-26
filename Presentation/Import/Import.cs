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
using Microsoft.Graph.Beta.Security.ThreatIntelligence.WhoisRecords.Item;

namespace IntuneAssignments.Presentation.Import
{
    public partial class Import : Form
    {
        private const int ExpandedHeight = 200; // Adjust as needed
        private const int CollapsedHeight = 100; // Adjust as needed
        private bool assignments = false;

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
            pBarImportStatus.Hide();
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

            await AddAllSettingsCatalogToDTG();


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

        private async void btnImportContet_Click(object sender, EventArgs e)
        {
            // Show the progress bar
            pBarImportStatus.Show();

            // Create a new file to store the import status
            CreateImportStatusFile();

            // Check for assignments

            if (cBoxAssignments.Checked)
            {
                assignments = true;
                WriteToImportStatusFile("Assignments: True");
            }
            else
            {
                assignments = false;
            }


            // Settings catalog section
            await SettingsCatalogOrchestrator();

            // Hide the progress bar
            pBarImportStatus.Hide();
        }

        private void CreateImportStatusFile()
        {
            // Create a new file to store the import status
            if (!System.IO.File.Exists(importStatusFile))
            {
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(importStatusFile))
                {
                    sw.WriteLine("Import Status File");
                    sw.WriteLine("==================");
                    sw.WriteLine($"Timestamp: {DateTime.Now}");
                    sw.WriteLine("Status: Started");
                    sw.WriteLine($"User: {Environment.UserName}");
                    sw.WriteLine($"Source Tenant ID: {sourceTenantID}");
                    sw.WriteLine($"Source Client ID: {sourceClientID}");
                    sw.WriteLine($"Destination Tenant ID: {destinationTenantID}");
                    sw.WriteLine($"Destination Client ID: {destinationClientID}");
                    sw.WriteLine("Import process initiated.");
                }
            }
        }

        private void cBoxAssignments_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxAssignments.Checked)
            {
                pnlGroups.Show();
                assignments = true;
            }
            else
            {
                pnlGroups.Hide();
                assignments = false;
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

        private List<string> GetAllGroupIDsFromDTG(DataGridView dtg)
        {
            // Get all the group IDs from the datagridview
            List<string> groupIDs = new List<string>();
            foreach (DataGridViewRow row in dtg.Rows)
            {
                groupIDs.Add(row.Cells[3].Value.ToString());
            }
            // Return the group IDs
            return groupIDs;
        }



        // Methods for the import process //

        // Settings catalog

        private async Task SettingsCatalogOrchestrator()
        {
            // Orchestrates the settings catalog import process

            // Clear the dictionary
            settingsCatalogNameAndID.Clear();

            // Populate the settings catalog dictionary
            foreach (DataGridViewRow row in dtgImportContent.Rows)
            {
                if (row.Cells[1].Value == "Settings Catalog")
                {
                    AddItemsToDictionary(settingsCatalogNameAndID, row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                }
            }

            // Import the settings catalog
            await ImportSettingsCatalog();
        }

        private async Task SearchAndAddSettingsCatalog()
        {
            // Search for settings catalog policies
            var result = await SearchForSettingsCatalog(sourceGraphServiceClient, tbSearch.Text.ToString());
            AddSettingsCatalogToDTG(result, dtgImportContent);

        }

        private async Task AddAllSettingsCatalogToDTG()
        {
            // Add all settings catalog policies to the datagridview
            var result = await GetAllSettingsCatalogPolicies(sourceGraphServiceClient);
            AddSettingsCatalogToDTG(result, dtgImportContent);
        }

        private async Task ImportSettingsCatalog()
        {
            // Import the selected settings catalog policies

            // Get the selected policies
            var policies = GetSettingsCatalogFromDTG(dtgImportContent);

            // Get the selected groups
            var groupIDs = GetAllGroupIDsFromDTG(dtgGroups);

            // Import the policies

            await ImportMultipleSettingsCatalog(sourceGraphServiceClient, destinationGraphServiceClient, dtgImportContent, policies, rtbDeploymentSummary, assignments, groupIDs);
        }

        private void btnClearSelectedFromGroupDTG_Click(object sender, EventArgs e)
        {
            // Clear the selected groups datagridview
            ClearSelectedDataGridViewRow(dtgGroups);
        }
    }
}
