using IntuneAssignments.Backend.IntuneContentClasses;
using IntuneAssignments.Backend.Utilities;
using IntuneAssignments.Presentation.Import;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models.ODataErrors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.Backend.DestinationTenantGraphClient;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.Intune_content_classes.SettingsCatalog;
using static IntuneAssignments.Backend.IntuneContentClasses.ADMXtemplates;
using static IntuneAssignments.Backend.IntuneContentClasses.AppleBYODEnrollmentHandler;
using static IntuneAssignments.Backend.IntuneContentClasses.DeviceCompliance;
using static IntuneAssignments.Backend.IntuneContentClasses.DeviceConfiguration;
using static IntuneAssignments.Backend.IntuneContentClasses.FilterHandler;
using static IntuneAssignments.Backend.IntuneContentClasses.Filters;
using static IntuneAssignments.Backend.IntuneContentClasses.Groups;
using static IntuneAssignments.Backend.IntuneContentClasses.PowerShellScripts;
using static IntuneAssignments.Backend.IntuneContentClasses.ProactiveRemediations;
using static IntuneAssignments.Backend.IntuneContentClasses.ShellScriptmacOS;
using static IntuneAssignments.Backend.IntuneContentClasses.WindowsAutoPilotProfiles;
using static IntuneAssignments.Backend.IntuneContentClasses.WindowsFeatureUpdateProfileHandler;
using static IntuneAssignments.Backend.IntuneContentClasses.WindowsQualityUpdatePoliciesHandler;
using static IntuneAssignments.Backend.IntuneContentClasses.WindowsQualityUpdateProfileHandler;
using static IntuneAssignments.Backend.SourceTenantGraphClient;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Presentation.Bulk_operations
{
    public partial class Maintenance : Form
    {
        private const int ExpandedHeight = 200; // Adjust as needed
        private const int CollapsedHeight = 100; // Adjust as needed
        public Maintenance()
        {
            InitializeComponent();

            // change the application icon and use the ico file in resources folder
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            pBarLoading.Hide();
            CheckConnection();
            CheckForAuthentication.Start();
        }

        public void CheckConnection()
        {
            if (lastFormName == "Maintenance")
            {
                pbDestinationTenantCheck.Image = Properties.Resources.check;

            }
            else
            {
                pbDestinationTenantCheck.Image = Properties.Resources.cancel;
            }
        }

        private void CheckForAuthentication_Tick(object sender, EventArgs e)
        {

        }

        private void pBHome_Click(object sender, EventArgs e)
        {
            // Go back to the main menu
            this.Hide();
            HomePage mainMenu = new HomePage();
            mainMenu.ShowDialog();
        }

        private async void btnListAll_Click(object sender, EventArgs e)
        {
            // Show the progress bar
            pBarLoading.Show();

            ClearDataGridView(dtgDeleteContent);

            // Get the categories the user wants to search for
            List<string> categories = new();
            GetCheckedItemsFromCheckedListBox(clbContentTypes, categories);

            if (categories.Contains("Settings Catalog"))
            {
                var result = await GetAllSettingsCatalogPolicies(destinationGraphServiceClient);
                AddSettingsCatalogToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Device Compliance"))
            {
                var result = await GetAllDeviceCompliancePolicies(destinationGraphServiceClient);
                AddDeviceComplianceToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Device Configuration"))
            {
                var result = await GetAllDeviceConfigurations(destinationGraphServiceClient);
                AddDeviceConfigurationsToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Group Policy Configuration"))
            {
                // ADMX templates are not supported yet
            }
            if (categories.Contains("Proactive Remediations"))
            {
                var result = await GetAllProactiveRemediations(destinationGraphServiceClient);
                AddProactiveRemediationsToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("PowerShell script"))
            {
                var result = await GetAllPowerShellScripts(destinationGraphServiceClient);
                AddPowerShellScriptsToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Autopilot"))
            {
                var result = await GetAllWindowsAutoPilotProfiles(destinationGraphServiceClient);
                AddWindowsAutoPilotProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("macOS script"))
            {
                var result = await GetAllShellScriptmacOS(destinationGraphServiceClient);
                AddShellScriptmacOSToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Feature Update Profiles"))
            {
                var result = await GetAllWindowsFeatureUpdateProfiles(destinationGraphServiceClient);
                AddWindowsFeatureUpdateProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Quality Update Policies"))
            {
                var result = await GetAllWindowsQualityUpdatePolicies(destinationGraphServiceClient);
                AddWindowsQualityUpdatePoliciesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Expedite Policies"))
            {
                var result = await GetAllWindowsQualityUpdateProfiles(destinationGraphServiceClient);
                AddWindowsQualityUpdateProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Apple BYOD Enrollment Profiles"))
            {
                var result = await GetAllAppleBYODEnrollmentProfiles(destinationGraphServiceClient);
                AddAppleBYODEnrollmentProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Assignment Filters"))
            {
                var result = await FilterHandler.GetAllAssignmentFilters(destinationGraphServiceClient);
                AddAssignmentFiltersToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Groups"))
            {
                var result = await GetAllGroups(destinationGraphServiceClient);
                AddGroupsToDTG(result, dtgDeleteContent);
            }

            // Hide the progress bar
            pBarLoading.Hide();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var searchQuery = tbSearch.Text.Trim();

            // Show the progress bar
            pBarLoading.Show();

            ClearDataGridView(dtgDeleteContent);

            // Get the categories the user wants to search for
            List<string> categories = new();
            GetCheckedItemsFromCheckedListBox(clbContentTypes, categories);

            if (categories.Contains("Settings Catalog"))
            {
                var result = await SearchForSettingsCatalog(destinationGraphServiceClient, searchQuery);
                AddSettingsCatalogToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Device Compliance"))
            {
                var result = await SearchForDeviceCompliancePolicies(destinationGraphServiceClient, searchQuery);
                AddDeviceComplianceToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Device Configuration"))
            {
                var result = await SearchForDeviceConfigurations(destinationGraphServiceClient, searchQuery);
                AddDeviceConfigurationsToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Group Policy Configuration"))
            {
                // ADMX templates are not supported yet
            }
            if (categories.Contains("Proactive Remediations"))
            {
                var result = await SearchForProactiveRemediations(destinationGraphServiceClient, searchQuery);
                AddProactiveRemediationsToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("PowerShell script"))
            {
                var result = await SearchForPowerShellScripts(destinationGraphServiceClient, searchQuery);
                AddPowerShellScriptsToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Autopilot"))
            {
                var result = await SearchForWindowsAutoPilotProfiles(destinationGraphServiceClient, searchQuery);
                AddWindowsAutoPilotProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("macOS script"))
            {
                var result = await SearchForShellScriptmacOS(destinationGraphServiceClient, searchQuery);
                AddShellScriptmacOSToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Feature Update Profiles"))
            {
                var result = await SearchForWindowsFeatureUpdateProfiles(destinationGraphServiceClient, searchQuery);
                AddWindowsFeatureUpdateProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Quality Update Policies"))
            {
                var result = await SearchForWindowsQualityUpdatePolicies(destinationGraphServiceClient, searchQuery);
                AddWindowsQualityUpdatePoliciesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Windows Expedite Policies"))
            {
                var result = await SearchForWindowsQualityUpdateProfiles(destinationGraphServiceClient, searchQuery);
                AddWindowsQualityUpdateProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Apple BYOD Enrollment Profiles"))
            {
                var result = await SearchForAppleBYODEnrollmentProfiles(destinationGraphServiceClient, searchQuery);
                AddAppleBYODEnrollmentProfilesToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Assignment Filters"))
            {
                var result = await FilterHandler.SearchForAssignmentFilters(destinationGraphServiceClient, searchQuery);
                AddAssignmentFiltersToDTG(result, dtgDeleteContent);
            }
            if (categories.Contains("Groups"))
            {
                var result = await SearchForGroups(destinationGraphServiceClient, searchQuery);
                AddGroupsToDTG(result, dtgDeleteContent);
            }

            // Hide the progress bar
            pBarLoading.Hide();
        }

        private void pbDestinationTenant_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            lastFormName = "Maintenance";

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.ShowDialog();
        }

        private async void DeleteOrchestrator(DataGridView dtg)
        {
            // Get all the rows from the DataGridView

            // Loop through each row and check the content type (index 1)

            foreach (DataGridViewRow row in dtg.Rows)
            {
                // Get the content type from the second column (index 1)
                string contentType = row.Cells[1].Value.ToString();

                // Get the ID from the first column (index 3)
                string id = row.Cells[3].Value.ToString();

                // Get the name from the third column (index 0)
                string name = row.Cells[0].Value.ToString();

                // Call the appropriate delete method based on the content type
                if (contentType == "Settings Catalog")
                {
                    await DeleteSettingsCatalog(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Device Compliance")
                {
                    await DeleteDeviceCompliancePolicy(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Device Configuration")
                {
                    await DeleteDeviceConfigurationPolicy(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Group Policy Configuration")
                {
                    //DeleteADMXTemplate(destinationGraphServiceClient, id);
                }
                else if (contentType == "Proactive Remediations")
                {
                    await DeleteProactiveRemediationScript(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "PowerShell script")
                {
                    await DeletePowerShellScript(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Windows AutoPilot Profile")
                {
                    // Check if the profile has assignments
                    var assignments = await CheckIfAutoPilotProfileHasAssignments(destinationGraphServiceClient, id);

                    if (assignments)
                    {
                        // If it has assignments, delete them first and then delete the profile
                        WriteErrorToRTB(name + " has assignments, deleting them first...", rtbSummary, Color.Salmon);
                        await DeleteWindowsAutoPilotProfileAssignments(destinationGraphServiceClient, id);
                        WriteErrorToRTB(name + " assignments deleted successfully", rtbSummary, Color.Salmon);

                        await DeleteWindowsAutopilotProfile(destinationGraphServiceClient, id);
                        WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                    }
                    else
                    {
                        // If it doesn't have assignments, delete the profile directly
                        await DeleteWindowsAutopilotProfile(destinationGraphServiceClient, id);
                        WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                    }

                }
                else if (contentType == "macOS Shell Script")
                {
                    await DeleteMacosShellScript(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Windows Feature Update")
                {
                    await DeleteWindowsFeatureUpdateProfile(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Windows Quality Update")
                {
                    //await DeleteWindowsQualityUpdatePolicy(destinationGraphServiceClient, id);
                    //WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);

                    WriteErrorToRTB("Windows Quality Update is not supported yet. Work is in progress", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Windows Expedite Update")
                {
                    await DeleteWindowsQualityUpdateProfile(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Apple User Initiated Enrollment Profile")
                {
                    await DeleteAppleBYODEnrollmentProfile(destinationGraphServiceClient, id);
                    WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                }
                else if (contentType == "Assignment Filter")
                {
                    try
                    {
                        var result = await DeleteAssignmentFilter(destinationGraphServiceClient, id);

                        if (result)
                        {
                            WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                        }
                        else
                        {
                            WriteErrorToRTB(name + " could not be deleted. Check if the filter has assignment. Deleting a filter with assignment(s) is not supported", rtbSummary, Color.Salmon);
                            WriteToImportStatusFile(name + " could not be deleted. Check if the filter has assignment. Deleting a filter with assignment(s) is not supported");
                        }

                        //WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                    }
                    catch (ODataError error)
                    {
                        WriteErrorToRTB(name + " could not be deleted. Check if the filter has assignment. Deleting a filter with assignment(s) is not supported", rtbSummary, Color.Salmon);
                        WriteToImportStatusFile(name + " could not be deleted. Check if the filter has assignment. Deleting a filter with assignment(s) is not supported");
                    }
                    catch (Exception ex)
                    {
                        WriteErrorToRTB(name + " could not be deleted due to an unexpected error: " + ex.Message, rtbSummary, Color.Salmon);
                        WriteToImportStatusFile(name + " could not be deleted due to an unexpected error: " + ex.Message);
                    }
                }
                else if (contentType.Contains("group", StringComparison.OrdinalIgnoreCase))
                {
                    // Show a warning message box about the danger of deleting a group
                    var result = MessageBox.Show(
                        "Warning: Deleting a group is irreversible and cannot be recovered. Are you sure you want to proceed?",
                        "Delete Group Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2 // Default to "No"
                    );

                    if (result == DialogResult.Yes)
                    {
                        await DeleteSecurityGroup(destinationGraphServiceClient, id);
                        WriteErrorToRTB(name + " deleted successfully", rtbSummary, Color.Salmon);
                    }
                    else
                    {
                        WriteErrorToRTB(name + " deletion canceled by user", rtbSummary, Color.Salmon);
                    }
                }
            }
        }

        private void btnBulkDelete_Click(object sender, EventArgs e)
        {
            ClearAllDictionaries();

            int numberOfObjects = dtgDeleteContent.Rows.Count;

            // Check if there are any objects to delete
            if (numberOfObjects == 0)
            {
                MessageBox.Show("There are no objects to delete. Please search for objects first.", "No Objects Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numberOfObjects > 0)
            {
                // Ask the user if they are sure they want to delete all objects
                DialogResult dialogResult = MessageBox.Show($"There are currently {numberOfObjects} objects about to be deleted. Are you sure you want to delete all of them?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }


            DeleteOrchestrator(dtgDeleteContent);
        }

        private void btnClearContentDTG_Click(object sender, EventArgs e)
        {
            // Clear the content datagridview
            ClearDataGridView(dtgDeleteContent);
        }

        private void btnClearSelectedPoliciesFromDTG_Click(object sender, EventArgs e)
        {
            // Clear the selected groups datagridview
            ClearSelectedDataGridViewRow(dtgDeleteContent);
        }

        private void btnSelectAllCheckboxes_Click(object sender, EventArgs e)
        {
            // This method toggles the checkboxes in the DataGridView

            bool allChecked = FormUtilities.AreAllItemsInCLBChecked(clbContentTypes);

            for (int i = 0; i < clbContentTypes.Items.Count; i++)
            {
                clbContentTypes.SetItemChecked(i, !allChecked);
            }
        }
    }
}
