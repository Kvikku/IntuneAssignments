using IntuneAssignments.Presentation.Import;
using Microsoft.Graph.Beta;
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
            CheckConnection();
        }

        public void CheckConnection()
        {
            if (isDestinationTenantConnected)
            {
                pbDestinationTenantCheck.Image = Properties.Resources.check;
            }
            else
            {
                pbDestinationTenantCheck.Image = Properties.Resources.cancel;
            }
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
                //await AddAllDeviceComplianceToDTG();
            }
            if (categories.Contains("Device Configuration"))
            {
                //await AddAllDeviceConfigurationToDTG();
            }
            if (categories.Contains("Group Policy Configuration"))
            {
                //await AddAllADMXTemplateToDTG();
                // Note - ADMX templates are not supported yet, and they might never be supported because Microsoft is pushing Settings Catalog
            }
            if (categories.Contains("Proactive Remediations"))
            {
                //await AddAllProactiveRemediationsToDTG();
            }
            if (categories.Contains("PowerShell script"))
            {
                //await AddAllPowerShellScripts();
            }
            if (categories.Contains("Windows Autopilot"))
            {
                //await AddAllWindowsAutopilotProfilesToDTG();
            }
            if (categories.Contains("macOS script"))
            {
                //await AddAllMacOSShellScriptsToDTG();
            }
            if (categories.Contains("Windows Feature Update Profiles"))
            {
                //await AddAllWindowsFeatureUpdateProfilesToDTG();
            }
            if (categories.Contains("Windows Quality Update Policies"))
            {
                // await AddAllWindowsQualityUpdatePoliciesToDTG();
            }
            if (categories.Contains("Windows Expedite Policies"))
            {
                //await AddAllWindowsQualityUpdateProfilesToDTG();
            }
            if (categories.Contains("Apple BYOD Enrollment Profiles"))
            {
                //await AddAllAppleBYODEnrollmentProfilesToDTG();
            }
            if (categories.Contains("Assignment Filters"))
            {
                //await AddAllAssignmentFiltersToDTG();
            }
            if (categories.Contains("Groups"))
            {
                //await AddAllGroupsToDTG();
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

            }
            if (categories.Contains("Device Configuration"))
            {

            }
            if (categories.Contains("Group Policy Configuration"))
            {
                //await SearchAndAddADMXTemplate();
                // Note - ADMX templates are not supported yet, and they might never be supported because Microsoft is pushing Settings Catalog
            }
            if (categories.Contains("Proactive Remediations"))
            {

            }
            if (categories.Contains("PowerShell script"))
            {

            }
            if (categories.Contains("Windows Autopilot"))
            {

            }
            if (categories.Contains("macOS script"))
            {

            }
            if (categories.Contains("Windows Feature Update Profiles"))
            {

            }
            if (categories.Contains("Windows Quality Update Policies"))
            {

            }
            if (categories.Contains("Windows Expedite Policies"))
            {

            }
            if (categories.Contains("Apple BYOD Enrollment Profiles"))
            {

            }
            if (categories.Contains("Assignment Filters"))
            {

            }
            if (categories.Contains("Groups"))
            {

            }




            // Hide the progress bar
            pBarLoading.Hide();
        }

        private void pbDestinationTenant_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.ShowDialog();
        }
    }
}
