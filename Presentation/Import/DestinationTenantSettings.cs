using IntuneAssignments.Backend;
using IntuneAssignments.Backend.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using static IntuneAssignments.Backend.TokenProvider;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;
using static IntuneAssignments.Backend.Utilities.TenantSettings;

namespace IntuneAssignments.Presentation.Import
{
    public partial class DestinationTenantSettings : Form
    {
        private JObject json;
        public DestinationTenantSettings()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            InitializeComponent();
        }

        private void DestinationTenantSettings_Load(object sender, EventArgs e)
        {
            // Load the destination tenant settings
            createDestinationTenantSettingsFile();

            // Read the destination tenant settings file
            readDestinationTenantSettingsFile();
        }

        private void createDestinationTenantSettingsFile()
        {
            // Create a new file to store the destination tenant settings
            if (!File.Exists(destinationTenantSettingsFile))
            {
                using (StreamWriter sw = File.CreateText(destinationTenantSettingsFile))
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

        private void readDestinationTenantSettingsFile()
        {
            // Read the destination tenant settings file
            if (File.Exists(destinationTenantSettingsFile))
            {
                // Read the JSON file
                string json = File.ReadAllText(destinationTenantSettingsFile);
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
                MessageBox.Show("Destination tenant settings file not found.");
            }
        }

        private void pbDestinationTenant_Click(object sender, EventArgs e)
        {
            // Open the destination tenant settings form

            DestinationTenantSettings destinationTenantSettings = new DestinationTenantSettings();
            destinationTenantSettings.FormClosed += DestinationTenantSettings_FormClosed;
            destinationTenantSettings.ShowDialog();
        }

        private void DestinationTenantSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the parent form when the destination tenant settings form is closed
            this.Show();
        }

        private void btnCheckPermissions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet");
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Open the folder where the destination tenant settings file is stored
            System.Diagnostics.Process.Start("explorer.exe", appDataFolder);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            saveDestinationFile();

            // TODO - Authenticate

            await AuthenticateToDestinationTenant();

            //Import import = System.Windows.Forms.Application.OpenForms["Import"] as Import;
            //import.CheckConnection();

            this.Close();
        }

        private async Task AuthenticateToDestinationTenant()
        {
            // Authenticate to the destination tenant

            // Get the values from the text boxes and save them to the global variables
            destinationTenantID = tBTenantID.Text;
            destinationClientID = tBClientID.Text;

            WriteToLog("Destination Tenant ID: " + destinationTenantID);
            WriteToLog("Destination Client ID: " + destinationClientID);

            // Update destinationAuthority after changing destinationTenantID
            DestinationTenantGraphClient.destinationAuthority = $"https://login.microsoftonline.com/{destinationTenantID}";

            WriteToLog("Destination Authority: " + DestinationTenantGraphClient.destinationAuthority);

            // Create the GraphServiceClient object

            DestinationTenantGraphClient.destinationGraphServiceClient = await GetDestinationGraphClient();

            // test the connection
            try
            {
                var me = await DestinationTenantGraphClient.destinationGraphServiceClient.Me.GetAsync();
                WriteToLog("Connected to destination tenant as: " + me.UserPrincipalName);
                isDestinationTenantConnected = true;

            }
            catch (Exception ex)
            {
                WriteToLog("Error connecting to destination tenant: " + ex.Message);
                isDestinationTenantConnected = false;
            }
        }

        private void saveDestinationFile()
        {
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
            string filePath = destinationTenantSettingsFile;

            SaveSettings(tenantName, tenantID, clientID, filePath);
        }

        private void cBTenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBTenant.SelectedIndex != -1)
            {
                // Get the selected tenant name
                string selectedTenant = cBTenant.SelectedItem.ToString();

                // Read the JSON file
                string json = File.ReadAllText(destinationTenantSettingsFile);
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
            destinationClientID = tenantSettings.ClientID;
            destinationTenantID = tenantSettings.TenantID;

            // Log the selected tenant
            WriteToLog($"Selected tenant: {tenantName}, TenantID: {tenantSettings.TenantID}, ClientID: {tenantSettings.ClientID}");
        }
    }
}
