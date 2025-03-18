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
                    sw.WriteLine("  \"TenantName\": \"\",");
                    sw.WriteLine("  \"TenantID\": \"\",");
                    sw.WriteLine("  \"ClientID\": \"\"");
                    sw.WriteLine("}");
                }
            }
        }

        private void readSourceTenantSettingsFile()
        {
            // Read the source tenant settings file
            if (File.Exists(sourceTenantSettingsFile))
            {
                // Read the JSON file and populate the textboxes
                string json = File.ReadAllText(sourceTenantSettingsFile);
                var sourceTenantSettings = JsonConvert.DeserializeObject<TenantSettings>(json);

                // Access the properties through the sourceTenantSettings object
                string tenantName = sourceTenantSettings.TenantName;
                string tenantID = sourceTenantSettings.TenantID;
                string clientID = sourceTenantSettings.ClientID;

                // Populate the textboxes
                tBTenantName.Text = tenantName;
                tBTenantID.Text = tenantID;
                tBClientID.Text = clientID;

                // save to global variables
                TokenProvider.tenantID = tenantID;
                TokenProvider.clientID = clientID;
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
            }
            catch (Exception ex)
            {
                WriteToLog("Error connecting to source tenant: " + ex.Message);
                isSourceTenantConnected = false;
            }
        }

        private void saveSourceFile()
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
            string filePath = sourceTenantSettingsFile;

            SaveSettings(tenantName, tenantID, clientID, filePath);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            saveSourceFile();

            // TODO - Authenticate

            await AuthenticateToSourceTenant();

            Import import = System.Windows.Forms.Application.OpenForms["Import"] as Import;
            import.CheckConnection();

            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Open the folder where the source tenant settings file is stored
            System.Diagnostics.Process.Start("explorer.exe", sourceTenantSettingsFile);
        }

        private void btnCheckPermissions_Click(object sender, EventArgs e)
        {
            // Check the permissions of the source tenant
            MessageBox.Show("Feature not implemented yet");
        }
    }
}
