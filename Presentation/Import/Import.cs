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
using static IntuneAssignments.Backend.IntuneContentClasses.DeviceConfiguration;
using static IntuneAssignments.Backend.Intune_content_classes.SettingsCatalog;
using static IntuneAssignments.Backend.IntuneContentClasses.DeviceCompliance;
using static IntuneAssignments.Backend.IntuneContentClasses.ADMXtemplates;
using static IntuneAssignments.Backend.IntuneContentClasses.Groups;
using static IntuneAssignments.Backend.IntuneContentClasses.Filters;
using static IntuneAssignments.Backend.IntuneContentClasses.ProactiveRemediations;
using Microsoft.Graph.Beta.NetworkAccess.Reports.MicrosoftGraphNetworkaccessGetDiscoveredApplicationSegmentReportWithStartDateTimeWithEndDateTimeuserIdUserId;
using Microsoft.Graph.Beta.Security.ThreatIntelligence.WhoisRecords.Item;
using Windows.Graphics.Printing.PrintSupport;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using IntuneAssignments.Backend.IntuneContentClasses;


namespace IntuneAssignments.Presentation.Import
{
    public partial class Import : Form
    {
        private const int ExpandedHeight = 200; // Adjust as needed
        private const int CollapsedHeight = 100; // Adjust as needed
        private bool assignments = false;
        private bool filter = false;
        private bool settingsCatalog = false;
        private bool deviceCompliance = false;

        public Import()
        {
            InitializeComponent();

            // change the application icon and use the ico file in resources folder
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

        }



        private void Import_Load(object sender, EventArgs e)
        {
            //pnlImportControls.Hide();
            pnlStatusOutput.Hide();
            //pnlImportContent.Hide();
            cbAddFilter.Hide();
            pnlAddFilter.Hide();
            pBarLoading.Hide();
            pBarGroupLoading.Hide();
            pBarImportStatus.Hide();
            pnlGroups.Hide();
            CheckConnection();

            CheckForAuthentication.Start();

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

        private void CheckForAuthentication_Tick(object sender, EventArgs e)
        {
            CheckIfSourceAndDestinationIsAuthenticated();
        }

        public bool CheckIfSourceAndDestinationIsAuthenticated()
        {
            // Check if the source and destination tenants are authenticated
            if (isSourceTenantConnected && isDestinationTenantConnected)
            {
                CheckForAuthentication.Stop();
                pnlImportControls.Show();
                pnlImportContent.Show();
                return true;
            }
            else
            {
                return false;
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

            ClearDataGridView(dtgImportContent);


            // Get the categories the user wants to search for
            List<string> categories = new();
            GetCheckedItemsFromCheckedListBox(clbContentTypes, categories);

            if (categories.Contains("Settings Catalog"))
            {
                await AddAllSettingsCatalogToDTG();
            }
            if (categories.Contains("Device Compliance"))
            {
                await AddAllDeviceComplianceToDTG();
            }
            if (categories.Contains("Device Configuration"))
            {
                await AddAllDeviceConfigurationToDTG();
            }
            if (categories.Contains("Group Policy Configuration"))
            {
                //await AddAllADMXTemplateToDTG();
                // Note - ADMX templates are not supported yet, and they might never be supported because Microsoft is pushing Settings Catalog
            }
            if (categories.Contains("Proactive Remediations"))
            {
                await AddAllProactiveRemediationsToDTG();
            }


            // Hide the progress bar
            pBarLoading.Hide();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // Show the progress bar
            pBarLoading.Show();

            ClearDataGridView(dtgImportContent);

            // Get the categories the user wants to search for
            List<string> categories = new();
            GetCheckedItemsFromCheckedListBox(clbContentTypes, categories);

            if (categories.Contains("Settings Catalog"))
            {
                await SearchAndAddSettingsCatalog();
            }
            if (categories.Contains("Device Compliance"))
            {
                await SearchAndAddDeviceCompliance();
            }
            if (categories.Contains("Device Configuration"))
            {
                await SearchAndAddDeviceConfiguration();
            }
            if (categories.Contains("Group Policy Configuration"))
            {
                //await SearchAndAddADMXTemplate();
                // Note - ADMX templates are not supported yet, and they might never be supported because Microsoft is pushing Settings Catalog
            }
            if (categories.Contains("Proactive Remediations"))
            {
                await SearchAndAddProactiveRemediations();
            }




            // Hide the progress bar
            pBarLoading.Hide();
        }

        private async void btnImportContet_Click(object sender, EventArgs e)
        {
            // Check if no radio button are selected
            if (pnlAddFilter.Visible && !rbFilterInclude.Checked && !rbFilterExclude.Checked)
            {
                MessageBox.Show("Please select a filter type");
                return;
            }

            // Check what type of content is selected


            // Show the progress bar
            pBarImportStatus.Show();

            // Show the panel for output
            pnlStatusOutput.Show();

            // Create a new file to store the import status
            CreateImportStatusFile();

            // Check for assignments

            if (cBoxAssignments.Checked)
            {
                assignments = true;
                WriteToImportStatusFile("Assignments: True");

                // Get the selected group names from the dtg (first column)
                List<string> groupNames = new List<string>();
                foreach (DataGridViewRow row in dtgGroups.Rows)
                {
                    groupNames.Add(row.Cells[0].Value.ToString());
                }

                WriteToImportStatusFile("The following groups will be added as the assignment");
                foreach (var group in groupNames)
                {
                    WriteToImportStatusFile(group);
                }
                WriteToImportStatusFile("=====================================");

            }
            else
            {
                assignments = false;
                WriteToImportStatusFile("Assignments: False");
            }

            if (cbAddFilter.Checked)
            {
                filter = true;
                WriteToImportStatusFile("Filter: True");
                WriteToImportStatusFile($"Selected Filter: {dtgFilters.SelectedRows[0].Cells[0].Value.ToString()}");
                WriteToImportStatusFile($"Selected Filter Rule: {dtgFilters.SelectedRows[0].Cells[1].Value.ToString()}");
                WriteToImportStatusFile($"Selected Filter ID: {dtgFilters.SelectedRows[0].Cells[3].Value.ToString()}");

                SelectedFilterName = dtgFilters.SelectedRows[0].Cells[0].Value.ToString();
                SelectedFilterID = dtgFilters.SelectedRows[0].Cells[3].Value.ToString();

                // get the filter type
                if (rbFilterInclude.Checked == true)
                {
                    deviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.Include;
                }
                if (rbFilterExclude.Checked == true)
                {
                    deviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.Exclude;
                }
            }
            else
            {
                filter = false;
                WriteToImportStatusFile("Filter: False");
            }

            // Get all selected content from the column
            List<string> contentTypes = new();
            foreach (DataGridViewRow row in dtgImportContent.Rows)
            {
                // only add if unique
                if (contentTypes.Contains(row.Cells[1].Value.ToString()))
                {
                    continue;
                }
                contentTypes.Add(row.Cells[1].Value.ToString());
            }

            // Write to the import status file
            WriteToImportStatusFile("The following content types will be imported:");
            foreach (var content in contentTypes)
            {
                WriteToImportStatusFile(content);
            }
            WriteToImportStatusFile("=====================================");

            if (contentTypes.Contains("Settings Catalog"))
            {
                // Settings catalog section
                await SettingsCatalogOrchestrator();
            }
            if (contentTypes.Contains("Device Compliance"))
            {
                // Device compliance section
                await DeviceComplianceOrchestrator();
            }
            if (contentTypes.Contains("Device Configuration"))
            {
                // Device configuration section
                await DeviceConfigurationOrchestrator();
            }
            if (contentTypes.Contains("Group Policy Configuration"))
            {
                // ADMX template section
                //await ADMXTemplateOrchestrator();

                // Note - ADMX templates are not supported yet, and they might never be supported because Microsoft is pushing Settings Catalog
            }
            if (contentTypes.Contains("Proactive Remediations"))
            {
                // Proactive remediations section
                await ProactiveRemediationsOrchestrator();
            }





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
                cbAddFilter.Show();
            }
            else
            {
                pnlGroups.Hide();
                assignments = false;
                cbAddFilter.Hide();
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

            await ImportMultipleSettingsCatalog(sourceGraphServiceClient, destinationGraphServiceClient, dtgImportContent, policies, rtbDeploymentSummary, assignments, filter, groupIDs);
        }


        // Device compliance

        private async Task DeviceComplianceOrchestrator()
        {
            // Orchestrates the settings catalog import process

            // Clear the dictionary
            deviceComplianceNameAndID.Clear();

            // Populate the settings catalog dictionary
            foreach (DataGridViewRow row in dtgImportContent.Rows)
            {
                if (row.Cells[1].Value == "Device Compliance")
                {
                    AddItemsToDictionary(deviceComplianceNameAndID, row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                }
            }

            // Import the settings catalog
            await ImportDeviceCompliance();
        }

        private async Task SearchAndAddDeviceCompliance()
        {
            // Search for device compliance policies
            var result = await SearchForDeviceCompliancePolicies(sourceGraphServiceClient, tbSearch.Text.ToString());
            AddDeviceComplianceToDTG(result, dtgImportContent);
        }

        private async Task AddAllDeviceComplianceToDTG()
        {
            // Add all device compliance policies to the datagridview
            var result = await GetAllDeviceCompliancePolicies(sourceGraphServiceClient);
            AddDeviceComplianceToDTG(result, dtgImportContent);
        }

        private async Task ImportDeviceCompliance()
        {
            // Import the selected settings catalog policies

            // Get the selected policies
            var policies = GetDeviceComplianceFromDTG(dtgImportContent);

            // Get the selected groups
            var groupIDs = GetAllGroupIDsFromDTG(dtgGroups);

            // Import the policies

            await ImportMultipleDeviceCompliancePolicies(sourceGraphServiceClient, destinationGraphServiceClient, dtgImportContent, policies, rtbDeploymentSummary, assignments, filter, groupIDs);
        }

        // Device configuration

        private async Task DeviceConfigurationOrchestrator()
        {
            // Orchestrates the settings catalog import process
            // Clear the dictionary
            deviceComplianceNameAndID.Clear();
            // Populate the settings catalog dictionary
            foreach (DataGridViewRow row in dtgImportContent.Rows)
            {
                if (row.Cells[1].Value == "Device Configuration")
                {
                    AddItemsToDictionary(deviceConfigurationNameAndID, row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                }
            }
            // Import the settings catalog
            await ImportDeviceConfiguration();
        }

        private async Task SearchAndAddDeviceConfiguration()
        {
            // Search for device configuration policies
            var result = await SearchForDeviceConfigurations(sourceGraphServiceClient, tbSearch.Text.ToString());
            AddDeviceConfigurationsToDTG(result, dtgImportContent);
        }

        private async Task AddAllDeviceConfigurationToDTG()
        {
            // Add all device configuration policies to the datagridview
            var result = await GetAllDeviceConfigurations(sourceGraphServiceClient);
            AddDeviceConfigurationsToDTG(result, dtgImportContent);
        }

        private async Task ImportDeviceConfiguration()
        {
            // Import the selected settings catalog policies
            // Get the selected policies
            var policies = GetDeviceConfigurationsFromDTG(dtgImportContent);
            // Get the selected groups
            var groupIDs = GetAllGroupIDsFromDTG(dtgGroups);
            // Import the policies
            await ImportMultipleDeviceConfigurations(sourceGraphServiceClient, destinationGraphServiceClient, dtgImportContent, policies, rtbDeploymentSummary, assignments, filter, groupIDs);
        }


        // ADMX template (Group policy configurations)

        private async Task ADMXTemplateOrchestrator()
        {
            // Orchestrates the admx templates  import process
            // Clear the dictionary
            ADMXtemplateNameAndID.Clear();
            // Populate the settings catalog dictionary
            foreach (DataGridViewRow row in dtgImportContent.Rows)
            {
                if (row.Cells[1].Value == "Group Policy Configuration")
                {
                    AddItemsToDictionary(ADMXtemplateNameAndID, row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                }
            }
            // Import the settings catalog
            await ImportADMXTemplate();
        }



        private async Task SearchAndAddADMXTemplate()
        {
            // Search for admx templates 
            var result = await SearchForGroupPolicyConfigurations(sourceGraphServiceClient, tbSearch.Text.ToString());
            AddGroupPolicyConfigurationsToDTG(result, dtgImportContent);
        }

        private async Task AddAllADMXTemplateToDTG()
        {
            // Add all ADMXtemplateNameAndID policies to the datagridview
            var result = await GetAllGroupPolicyConfigurations(sourceGraphServiceClient);
            AddGroupPolicyConfigurationsToDTG(result, dtgImportContent);
        }

        private async Task ImportADMXTemplate()
        {
            // Import the selected ADMXtemplateNameAndID policies
            // Get the selected policies
            var policies = GetGroupPolicyConfigurationsFromDTG(dtgImportContent);
            // Get the selected groups
            var groupIDs = GetAllGroupIDsFromDTG(dtgGroups);
            // Import the policies
            await ImportMultipleGroupPolicyConfigurations(sourceGraphServiceClient, destinationGraphServiceClient, dtgImportContent, policies, rtbDeploymentSummary, assignments, filter, groupIDs);
        }


        // Proactive remediations (Device health scripts)

        private async Task ProactiveRemediationsOrchestrator()
        {
            // Orchestrates the proactive remediations import process
            // Clear the dictionary
            proactiveRemediationNameAndID.Clear();
            // Populate the settings catalog dictionary
            foreach (DataGridViewRow row in dtgImportContent.Rows)
            {
                if (row.Cells[1].Value == "Proactive Remediations")
                {
                    AddItemsToDictionary(proactiveRemediationNameAndID, row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                }
            }
            // Import the settings catalog
            await ImportProactiveRemediations();
        }

        private async Task SearchAndAddProactiveRemediations()
        {
            // Search for proactive remediations
            var result = await SearchForProactiveRemediations(sourceGraphServiceClient, tbSearch.Text.ToString());
            AddProactiveRemediationsToDTG(result, dtgImportContent);
        }

        private async Task AddAllProactiveRemediationsToDTG()
        {
            // Add all proactive remediations to the datagridview
            var result = await GetAllProactiveRemediations(sourceGraphServiceClient);
            AddProactiveRemediationsToDTG(result, dtgImportContent);
        }

        private async Task ImportProactiveRemediations()
        {
            // Import the selected proactive remediations
            // Get the selected policies
            var policies = GetProactiveRemediationsFromDTG(dtgImportContent);
            // Get the selected groups
            var groupIDs = GetAllGroupIDsFromDTG(dtgGroups);
            // Import the policies
            await ImportMultipleProactiveRemediations(sourceGraphServiceClient, destinationGraphServiceClient, dtgImportContent, policies, rtbDeploymentSummary, assignments, filter, groupIDs);
        }



        // Other methods //
        private void btnClearSelectedFromGroupDTG_Click(object sender, EventArgs e)
        {
            // Clear the selected groups datagridview
            ClearSelectedDataGridViewRow(dtgGroups);
        }

        private void rbFilterInclude_Click(object sender, EventArgs e)
        {
            // Set the filter to include
            rbFilterExclude.Checked = false;
        }

        private void rbFilterExclude_Click(object sender, EventArgs e)
        {
            rbFilterInclude.Checked = false;
        }

        private async Task AddFiltersToDTG(GraphServiceClient graphServiceClient, DataGridView dtg)
        {
            // Add filters to the datagridview
            // Get the filters
            var filters = await GetAllAssignmentFilters(graphServiceClient);

            // Add the filters to the datagridview
            foreach (var filter in filters)
            {
                dtg.Rows.Add(filter.DisplayName, filter.Rule, filter.Platform, filter.Id);
            }
        }


        private async void cbAddFilter_CheckedChanged(object sender, EventArgs e)
        {
            // Show or hide the filter options
            if (cbAddFilter.Checked)
            {
                pnlAddFilter.Visible = true;
                filter = true;
                pnlAddFilter.Show();
                filter = true;
                ClearDataGridView(dtgFilters);
                await AddFiltersToDTG(destinationGraphServiceClient, dtgFilters);
            }
            else
            {
                filter = false;
                pnlAddFilter.Hide();
                filter = false;
            }
        }

        private void btnClearSelectedPoliciesFromDTG_Click(object sender, EventArgs e)
        {
            // Clear the selected groups datagridview
            ClearSelectedDataGridViewRow(dtgImportContent);
        }

        private void pBarLoading_Click(object sender, EventArgs e)
        {

        }
    }
}
