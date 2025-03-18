﻿using IntuneAssignments.Backend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.Backend.FormUtilities;
using static IntuneAssignments.Backend.GlobalVariables;
using static IntuneAssignments.Backend.TenantSettings;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.TokenProvider;
using static IntuneAssignments.Backend.DestinationClientCreator;

namespace IntuneAssignments.Presentation.Import
{
    public partial class DestinationTenantSettings : Form
    {
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
                    sw.WriteLine("  \"TenantName\": \"\",");
                    sw.WriteLine("  \"TenantID\": \"\",");
                    sw.WriteLine("  \"ClientID\": \"\"");
                    sw.WriteLine("}");
                }
            }
        }

        private void readDestinationTenantSettingsFile()
        {
            // Read the destination tenant settings file
            if (File.Exists(destinationTenantSettingsFile))
            {
                // Read the JSON file and populate the textboxes
                string json = File.ReadAllText(destinationTenantSettingsFile);
                var destinationTenantSettings = JsonConvert.DeserializeObject<TenantSettings>(json);

                // Access the properties through the destinationTenantSettings object
                string tenantName = destinationTenantSettings.TenantName;
                string tenantID = destinationTenantSettings.TenantID;
                string clientID = destinationTenantSettings.ClientID;

                // Populate the textboxes
                tBTenantName.Text = tenantName;
                tBTenantID.Text = tenantID;
                tBClientID.Text = clientID;

                // save to global variables
                destinationClientID = clientID;
                destinationTenantID = tenantID;
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

            await testAuth();
        }

        private async Task testAuth()
        {
            destinationTenantID = tBTenantID.Text;

            // Update destinationAuthority after changing destinationTenantID
            TokenProvider.destinationAuthority = $"https://login.microsoftonline.com/{destinationTenantID}";

            var test = await GetDestinationGraphClient();

            var result = await test.DeviceManagement.ManagedDevices.GetAsync();
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

        
    }
}
