using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IntuneAssignments.MSGraphAuthenticator;
using static IntuneAssignments.GlobalVariables;
using static IntuneAssignments.FormUtilities;
using Microsoft.IdentityModel.Logging;

namespace IntuneAssignments
{
    public partial class HomePage : Form
    {
        


        private readonly Form1 _form1;

        public HomePage()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            WriteToLog("HomePage loaded");
            
            
            // Hide this label until it is needed
            lblAdditionalInfo.Hide();


            // Call methods to create configuration folder and files
            createConfigurationFolder();
            createConfigurationFiles();

            loadAuthenticationInfo();
            checkConnectionStatus();


            // Continue migrating startup code from form1.cs to here.
        }


        // START UP CONFIGURATION //


        private void createConfigurationFolder()
        {
            // Create a folder in ProgramData to store configuration files


            // Check if the folder in configurationFolder variable exists
            if (!System.IO.Directory.Exists(configurationFolder))
            {
                // If it does not exist, create it
                System.IO.Directory.CreateDirectory(configurationFolder);

            }
        }

        private void createConfigurationFiles()
        {
            // Create configuration files in the configuration folder

            // check if the configuration file already exists
            if (!System.IO.File.Exists(AppSettingsFile))
            {
                string AppSettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json");
                string destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "IntuneAssignments");
                string destinationFilePath = Path.Combine(destinationDirectory, "AppSettings.json");
                File.Copy(AppSettingsFile, destinationFilePath, false);  // The 'true' argument allows overwriting if the file already exists
            }

            // does nothing if the file already exists

            if (!System.IO.File.Exists(MainLogFile))
            {

                // Create the file
                System.IO.File.Create(MainLogFile);

                // Write to the file
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(MainLogFile, true))
                {
                    file.WriteLine("Log file created: " + DateTime.Now);
                }

            }
        }


        private void loadAuthenticationInfo()
        {

            // Reads the appsettings.json file and stores the information in variables

            string path = Form1.AppSettingsFile; //@"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();


            // Sets the variables to the values in the appsettings.json file

            tenantID = configuration.GetSection("Entra:TenantId").Value;
            clientID = configuration.GetSection("Entra:ClientId").Value;
            clientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            authority = $"https://login.microsoftonline.com/{Form1.tenantID}";


            // Testing only
            // MessageBox.Show(tenantID + "\n" + clientID + "\n" + clientSecret + "\n" + authority); 
        }

        public async Task checkConnectionStatus()
        {

            // Checks if the authentication info in appsettings.json file grants access to Microsoft Graph

            try
            {

                // Create a graph service client object
                var graphClient = await GetAuthenticatedGraphClient();

                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Organization.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                });

                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo.Value);

                // display tenant name in message box



                // THIS DOESNT WORK YET
                pBConnectionStatus.Image = Properties.Resources.check;
                lblConnectionStatus.Text = "Connected to Azure tenant: ";
                lblTenantName.Text = organizations[0].DisplayName;
                lblAdditionalInfo.Hide();

                //MessageBox.Show("You are connected to" + "\n" + organizations[0].DisplayName + "\n" + organizations[0].Id);

            }
            catch (Exception ex)
            {
                //Do nothing

                //MessageBox.Show(ex.Message);
                pBConnectionStatus.Image = Properties.Resources.cancel;
                lblTenantName.Text = "Not connected";
                lblAdditionalInfo.Show();
                lblAdditionalInfo.Text = "Please click the cogwheel to view and manage the authentication info";
            }


        }


        // BUTTONS //

        private void pbGoToApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();




        }

        private void pbGoToPolicy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Policy policy = new Policy();
            policy.Show();





        }

        private void GoToAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);




        }

        private void GoToSettings_Click(object sender, EventArgs e)
        {
            
            
            Settings settings = new Settings();
            settings.ShowDialog();


        }


    }
}
