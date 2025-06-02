using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntuneAssignments.Backend;
using Newtonsoft.Json;

using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;
using static IntuneAssignments.Backend.Utilities.TenantSettings;
using static IntuneAssignments.Backend.TokenProvider;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.SourceTenantGraphClient;
using IntuneAssignments.Backend.Utilities;

namespace IntuneAssignments.Presentation.Import
{
    public partial class SourceTenantSettings : Form
    {
        public SourceTenantSettings()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            InitializeComponent();
        }

        private void SourceTenantSettings_Load(object sender, EventArgs e)
        {
            // Load the source tenant settings
            createSourceTenantSettingsFile();

            // Read the source tenant settings file
            readSourceTenantSettingsFile();
        }

        private void createSourceTenantSettingsFile()
        {
            // Create a new file to store the source tenant settings
            if (!File.Exists(sourceTenantSettingsFile))
            {
                using (StreamWriter sw = File.CreateText(sourceTenantSettingsFile))
                {
                    sw.WriteLine("{");
                    sw.WriteLine("  \"Lab 1\": {");
                    sw.WriteLine("    \"TenantID\": \"\",");
                    sw.WriteLine("    \"ClientID\": \"\"");
                    sw.WriteLine("  },");
                    sw.WriteLine("  \"Lab 2\": {");
                    sw.WriteLine("    \"TenantID\": \"\",");
                    sw.WriteLine("    \"ClientID\": \"\"");
                    sw.WriteLine("  }");
                    sw.WriteLine("}");
                }
            }
        }

        private void readSourceTenantSettingsFile()
        {
            // Read the source tenant settings file
            if (File.Exists(sourceTenantSettingsFile))
            {
                // Read the JSON file
                string json = File.ReadAllText(sourceTenantSettingsFile);
                var tenants = JsonConvert.DeserializeObject<Dictionary<string, TenantSettings>>(json);

                if (tenants != null && tenants.Count > 0)
                {
                    // Populate the combo box with tenant names
                    cBTenant.Items.Clear(); // Clear any existing items
                    foreach (var tenant in tenants)
                    {
                        cBTenant.Items.Add(tenant.Key);
                        WriteToLog($"Added tenant: {tenant.Key}");
                    }

                    // Select the first tenant by default
                    cBTenant.SelectedIndex = 0;

                    // Get the first tenant entry
                    var firstTenant = tenants.First();
                    string tenantName = firstTenant.Key;
                    TenantSettings tenantSettings = firstTenant.Value;

                    // Update tenant details
                    UpdateTenantDetails(tenantName, tenantSettings);
                }
                else
                {
                    MessageBox.Show("No tenants found in the settings file.");
                }
            }
            else
            {
                MessageBox.Show("Source tenant settings file not found.");
            }
        }

        private void pbSourceTenant_Click(object sender, EventArgs e)
        {
            // Open the source tenant settings form

            SourceTenantSettings sourceTenantSettings = new SourceTenantSettings();
            sourceTenantSettings.FormClosed += SourceTenantSettings_FormClosed;
            sourceTenantSettings.ShowDialog();
        }

        private void SourceTenantSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Import import = System.Windows.Forms.Application.OpenForms["Import"] as Import;
            import.CheckConnection();

            // Show the parent form when the source tenant settings form is closed
            this.Show();
        }

        private async Task AuthenticateToSourceTenant()
        {
            // Authenticate to the source tenant

            // Get the values from the text boxes and save them to the global variables
            SourceTenantGraphClient.sourceTenantID = tBTenantID.Text;
            SourceTenantGraphClient.sourceClientID = tBClientID.Text;

            WriteToLog("Source Tenant ID: " + sourceTenantID);
            WriteToLog("Source Client ID: " + sourceClientID);

            // Update sourceAuthority after changing sourceTenantID
            SourceTenantGraphClient.sourceAuthority = $"https://login.microsoftonline.com/{sourceTenantID}";

            WriteToLog("Source Authority: " + sourceAuthority);

            // Create the GraphServiceClient object
            SourceTenantGraphClient.sourceGraphServiceClient = await GetSourceGraphClient();

            // test the connection

            try
            {
                var me = await SourceTenantGraphClient.sourceGraphServiceClient.Me.GetAsync();
                WriteToLog("Connected to source tenant as: " + me.DisplayName);
                isSourceTenantConnected = true;
                sourceTenantName = await GetAzureTenantName(sourceGraphServiceClient);

                WriteToLog("Source Tenant Name: " + sourceTenantName);
            }
            catch (Exception ex)
            {
                WriteToLog("Error connecting to source tenant: " + ex.Message);
                isSourceTenantConnected = false;
            }
        }

        private void saveSourceFile()
        {
            // Is this now redundant? Delete later?
            
            // Get the values from the text boxes
            string tenantName = tBTenantName.Text;
            string tenantID = tBTenantID.Text;
            string clientID = tBClientID.Text;

            if (!CheckIfGUID(tenantID))
            {
                MessageBox.Show("Tenant ID is not a valid GUID");
                return;
            }

            if (!CheckIfGUID(clientID))
            {
                MessageBox.Show("Client ID is not a valid GUID");
                return;
            }

            // Define the file path for the JSON file
            string filePath = sourceTenantSettingsFile;

            SaveSettings(tenantName, tenantID, clientID, filePath);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Save settings to json file
            var tenantName = tBTenantName.Text;
            var tenantID = tBTenantID.Text;
            var clientID = tBClientID.Text;

            SaveTenantConfigurationToJson(tenantName, tenantID, clientID, sourceTenantSettingsFile);

            // Authenticate and log in to the source tenant

            await AuthenticateToSourceTenant();

            Import import = System.Windows.Forms.Application.OpenForms["Import"] as Import;
            import.CheckConnection();
            import.UpdateTenantDisplayNames();


            WriteToLog($"Source Tenant '{sourceTenantName}' authenticated successfully.");



            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Open the folder where the source tenant settings file is stored
            System.Diagnostics.Process.Start("explorer.exe", appDataFolder);
        }

        private void btnCheckPermissions_Click(object sender, EventArgs e)
        {
            // Check the permissions of the source tenant
            MessageBox.Show("Feature not implemented yet");
        }

        private void cBTenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBTenant.SelectedIndex != -1)
            {
                // Get the selected tenant name
                string selectedTenant = cBTenant.SelectedItem.ToString();

                // Read the JSON file
                string json = File.ReadAllText(sourceTenantSettingsFile);
                var tenants = JsonConvert.DeserializeObject<Dictionary<string, TenantSettings>>(json);

                // Update the UI with the selected tenant's details
                if (tenants.ContainsKey(selectedTenant))
                {
                    UpdateTenantDetails(selectedTenant, tenants[selectedTenant]);
                }
            }
        }

        private void UpdateTenantDetails(string tenantName, TenantSettings tenantSettings)
        {
            // Populate the textboxes
            tBTenantName.Text = tenantName;
            tBTenantID.Text = tenantSettings.TenantID;
            tBClientID.Text = tenantSettings.ClientID;

            // Save to global variables
            SourceTenantGraphClient.sourceClientID = tenantSettings.ClientID;
            SourceTenantGraphClient.sourceTenantID = tenantSettings.TenantID;

            // Log the selected tenant
            WriteToLog($"Selected tenant: {tenantName}, TenantID: {tenantSettings.TenantID}, ClientID: {tenantSettings.ClientID}");
        }
    }
}
