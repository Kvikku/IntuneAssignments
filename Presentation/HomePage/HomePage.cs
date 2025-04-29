using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Beta.Models;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using IntuneAssignments.Backend;
using IntuneAssignments.Presentation.Import;
using IntuneAssignments.Presentation.Bulk_operations;

namespace IntuneAssignments
{
    public partial class HomePage : Form
    {



        private readonly Application _form1;

        public HomePage()
        {
            InitializeComponent();



            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void HomePage_Load(object sender, EventArgs e)
        {

            createConfigurationFolder();

            createAppSettingsFile();

            ShowWarningOnStatusLabels();

            await checkConnectionStatus();



            // For future use - to set the background color of the form
            //this.BackColor = Color.DarkViolet;



            // TEST ONLY- Purge the content of the log file - 
            // DELETE THIS LINE BEFORE RELEASE
            //PurgeLogFileContent();


            // Call methods to create configuration folder and files







            //loadAuthenticationInfo();


            // Remove this line before release
            //checkConnectionStatus();



        }


        // START UP CONFIGURATION //


        private void ShowWarningOnStatusLabels()
        {
            pBConnectionStatus.Image = Properties.Resources.cancel;

            //lblConnectionStatus.Text = "Not connected";
            lblTenantName.Text = "Not connected";
            lblAdditionalInfo.Text = "Please click the Cogwheel to authenticate";

        }

        private void createConfigurationFolder()
        {
            // Create a folder in ProgramData to store configuration files


            // Check if the folder in configurationFolder variable exists
            if (!System.IO.Directory.Exists(appDataFolder))
            {
                // If it does not exist, create it
                System.IO.Directory.CreateDirectory(appDataFolder);

                // Must also create log file here
                createPrimaryLogFile();

                WriteToLog("__");
                WriteToLog("__");
                WriteToLog("Launching application!");
                WriteToLog("The configuration folder is missing. It may have been deleted or this is the first time the app is launched on the system");
                WriteToLog("Configuration folder created.");
                WriteToLog("Configuration file created.");
                WriteSystemSummaryToLog();

            }
            else if (!System.IO.File.Exists(primaryLogFile))
            {
                // Create configuration files

                createPrimaryLogFile();


                WriteToLog("__");
                WriteToLog("__");
                WriteToLog("Launching application");
                WriteSystemSummaryToLog();
            }
            else
            {
                // All files exist
                WriteToLog("__");
                WriteToLog("__");
                WriteToLog("Launching application");
                WriteSystemSummaryToLog();
            }



        }

        private void createPrimaryLogFile()
        {
            if (!System.IO.File.Exists(primaryLogFile))
            {
                using (FileStream fs = File.Create(primaryLogFile))
                {
                    // Do nothing


                    // Release the file

                }


            }
            else
            {
                WriteToLog("The log file already exists. No need to create");
            }


            // release the file
        }

        private async void createAppSettingsFile()
        {
            if (!System.IO.File.Exists(appSettingsFile))
            {

                // copy file from the appsettings.json file in the project to the configuration folder
                string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json");
                string destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "IntuneAssignments");
                string destinationFilePath = Path.Combine(destinationDirectory, "AppSettings.json");
                File.Copy(sourceFile, appSettingsFile, false);  // The 'true' argument allows overwriting if the file already exists




            }
            else
            {
                WriteToLog("The configuration file already exists. No need to create");
            }


        }

        private void createConfigurationFiles()
        {
            // TO BE DELETED
            // Create configuration files in the configuration folder

            using (FileStream fs = File.Create(appSettingsFile))
            {
                // Do nothing
            }


            // check if the configuration file already exists
            if (!System.IO.File.Exists(AppSettingsFile))
            {
                string AppSettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json");
                string destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "IntuneAssignments");
                string destinationFilePath = Path.Combine(destinationDirectory, "AppSettings.json");
                File.Copy(AppSettingsFile, destinationFilePath, false);  // The 'true' argument allows overwriting if the file already exists

                WriteToLog("The configuration file is missing. It may have been deleted or it is the first time the app is running on the system");
                WriteToLog("Creating the configuration file");
                WriteToLog("Configuration file created");


            }
            else
            {
                WriteToLog("The configuration file already exist. No need to create");
            }




            // does nothing if the file already exists

            if (!System.IO.File.Exists(MainLogFile))
            {
                // Must implement logging here



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

            /*
             * 02.02.2024
             * This method has been replaced and is no longer in use
             * This method is kept for reference and will be deleted in the future
             */



            // Reads the appsettings.json file and stores the information in variables

            WriteToLog("Loading authentication info from appsettings.json file");

            string path = Application.AppSettingsFile; //@"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();


            // Sets the variables to the values in the appsettings.json file

            // Note - this is using the old msauth method.  
            MSGraphAuthenticator.ZtenantID = configuration.GetSection("Entra:TenantId").Value;
            MSGraphAuthenticator.ZclientID = configuration.GetSection("Entra:ClientId").Value;
            MSGraphAuthenticator.ZclientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            MSGraphAuthenticator.Zauthority = $"https://login.microsoftonline.com/{Application.tenantID}";


            // Testing only
            // MessageBox.Show(tenantID + "\n" + clientID + "\n" + clientSecret + "\n" + authority); 
        }

        public async Task checkConnectionStatus()
        {

            // Checks if the authentication info in appsettings.json file grants access to Microsoft Graph

            try
            {
                WriteToLog("Checking connection status");


                // Create a graph service client object
                var graphClient = CreateGraphServiceClient();

                // Make a call to Microsoft Graph
                var tenantInfo = await graphClient.Organization.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                });

                var user = await graphClient.Me.GetAsync();



                // Put result in a list for processing
                List<Organization> organizations = new List<Organization>();
                organizations.AddRange(tenantInfo.Value);



                // If the call is successful, display the tenant name and the connection status
                pBConnectionStatus.Image = Properties.Resources.check;
                lblConnectionStatus.Text = "Connected to Azure tenant: ";
                lblTenantName.Text = organizations[0].DisplayName;
                lblAdditionalInfo.Text = user.UserPrincipalName;

                WriteToLog("Successfully connected to Azure tenant: " + organizations[0].DisplayName + " as " + user.UserPrincipalName);

                //MessageBox.Show("You are connected to" + "\n" + organizations[0].DisplayName + "\n" + organizations[0].Id);

            }
            catch (Exception ex)
            {
                //Do nothing

                //MessageBox.Show(ex.Message);
                pBConnectionStatus.Image = Properties.Resources.cancel;
                lblTenantName.Text = "Not connected";
                lblAdditionalInfo.Show();
                lblAdditionalInfo.Text = "Please click the Cogwheel to authenticate";

                WriteToLog("Error connecting to the Azure tenant. Please troubleshoot and double check the authentication info in the appsettings.json file");
            }


        }


        // BUTTONS //

        private void pbGoToApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application form1 = new Application();
            form1.Show();

            WriteToLog("Opening the application page");


        }

        private void pbGoToPolicy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Policy policy = new Policy();
            policy.Show();

            WriteToLog("Opening the policy page");



        }

        private void GoToAbout_Click(object sender, EventArgs e)
        {

            WriteToLog("Opening the about page");
            About about = new About();
            about.ShowDialog(this);




        }

        private void GoToSettings_Click(object sender, EventArgs e)
        {

            try
            {
                WriteToLog("Opening the settings page");
                Settings settings = new Settings();
                settings.ShowDialog();
            }
            catch (Exception me)
            {
                //MessageBox.Show(me.Message);
                throw;
            }



        }

        private void pbWhatsNew_Click(object sender, EventArgs e)
        {
            WriteToLog("Opening the what's new page");
            WhatsNew whatsNew = new WhatsNew();
            whatsNew.ShowDialog();
        }

        private void pBImportExport_Click(object sender, EventArgs e)
        {
            // Open the import page
            WriteToLog("Opening the import/export page");
            this.Hide();
            Import import = new Import();
            import.Show();
        }

        private void pbGoToMaintenance_Click(object sender, EventArgs e)
        {
            // Open the maintenance page
            WriteToLog("Opening the maintenance page");
            this.Hide();
            Maintenance maintenance = new Maintenance();
            maintenance.Show();
        }
    }
}
