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
using static IntuneAssignments.GlobalVariables;
using static IntuneAssignments.FormUtilities;
using static IntuneAssignments.TokenProvider;
using static IntuneAssignments.GraphServiceClientCreator;
using Microsoft.IdentityModel.Logging;
using Microsoft.Graph.Beta;

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

            ShowWarningOnStatusLabels();



            // TEST ONLY- Purge the content of the log file - 
            // DELETE THIS LINE BEFORE RELEASE
            //PurgeLogFileContent();


            // Call methods to create configuration folder and files
            createConfigurationFolder();




            createConfigurationFiles();

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
            lblAdditionalInfo.Text = "Please click the cogwheel to view and manage the authentication info";

        }

        private void createConfigurationFolder()
        {
            // Create a folder in ProgramData to store configuration files


            // Check if the folder in configurationFolder variable exists
            if (!System.IO.Directory.Exists(configurationFolder))
            {
                // If it does not exist, create it
                System.IO.Directory.CreateDirectory(configurationFolder);
                WriteToLog("");
                WriteToLog("");
                WriteToLog("Launching application!");
                WriteToLog("The configuration folder is missing. It may have been deleted or it is the first time the app is running on the system");
                WriteToLog("Creating the configuration folder");
                WriteToLog("Configuration folder created");

            }
            else
            {
                WriteToLog("");
                WriteToLog("");
                WriteToLog("Launching application");
                WriteSystemSummaryToLog();


                WriteToLog("The configuration folder already exist. No need to create");
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





            // Reads the appsettings.json file and stores the information in variables

            WriteToLog("Loading authentication info from appsettings.json file");

            string path = Form1.AppSettingsFile; //@"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();


            // Sets the variables to the values in the appsettings.json file

            MSGraphAuthenticator.tenantID = configuration.GetSection("Entra:TenantId").Value;
            MSGraphAuthenticator.clientID = configuration.GetSection("Entra:ClientId").Value;
            MSGraphAuthenticator.clientSecret = configuration.GetSection("Entra:ClientSecret").Value;
            MSGraphAuthenticator.authority = $"https://login.microsoftonline.com/{Form1.tenantID}";


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
                lblAdditionalInfo.Text = "Please click the cogwheel to view and manage the authentication info";

                WriteToLog("Error connecting to the Azure tenant. Please troubleshoot and double check the authentication info in the appsettings.json file");
            }


        }


        // BUTTONS //

        private void pbGoToApplication_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
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

            WriteToLog("Opening the settings page");
            Settings settings = new Settings();
            settings.ShowDialog();


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await FormUtilities.getAllEntraGroups();
        }

        private async void button2_Click(object sender, EventArgs e)
 
        {


            /*
             * CONTINUE
             * 
             * group member count. use getGroupMembersFromGroup method to count and return the number of members in a group
             * 
             * 
             * 
             */



            List<User> userList = new List<User>();

            List<Device> deviceList = new List<Device>();

            var groupMembers = await getGroupMembersFromGroup("7ecf909c-50d1-4537-827b-cc055fde8b80");


            MessageBox.Show(groupMembers.Count.ToString());


            foreach (var member in groupMembers)
            {

                if (member.OdataType == "#microsoft.graph.user")
                {
                    
                    // Add to users list
                    userList.Add((User)member);

                }
                else if (member.OdataType == "#microsoft.graph.device")
                {
                    // Add to devices list
                    deviceList.Add((Device)member);
                }
                else
                {
                    // Unknown object
                    MessageBox.Show("Unknown object type");
                }



            }


            foreach (var user in userList)
            {
                MessageBox.Show(user.DisplayName + " " + user.UserPrincipalName);
            }

            foreach (var device in deviceList)
            {
                MessageBox.Show(device.DisplayName + " " + device.Model + " " + device.Platform);

            }


        }
    }
}
