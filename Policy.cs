using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;





// TO DO


// Method to check @odata.type contains certain key word (macOS, Windows, etc)
// Switch between main form and this form, keep location, reuse auth



namespace IntuneAssignments
{
    public partial class Policy : Form
    {

        private readonly Form1 _form1;


        public Policy(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void goHome()
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }


        ////////////////////////////////////////////////////////////////////////  METHODS  /////////////////////////////////////////////////////////////////////////////////////////////



        private void ListCompliancePolicies()
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);


            // Make a call to Microsoft Graph
            var allPolicies = client.DeviceManagement.DeviceCompliancePolicies
                .Request()
                .Select(u => new
                {
                    u.DisplayName,
                    u.Id
                })
                .Top(1000)
                .GetAsync();

            // Put result into a list for easy processing
            List<DeviceCompliancePolicy> deviceCompliancePolicies = new List<DeviceCompliancePolicy>();


            // Adds all the data from the graph query into the list
            deviceCompliancePolicies.AddRange(allPolicies.Result);


            // Loop through the list

            foreach (var policy in deviceCompliancePolicies)
            {

                dtgDisplayPolicy.Rows.Add(policy.DisplayName, "Compliance", policy.ODataType);

            }

        }

        private void ListConfigurationProfiles()
        {


            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);


            
            // Make a call to Microsoft Graph
            var allPolicies = client.DeviceManagement.DeviceConfigurations
                .Request()
                .Select(u => new
                {
                    u.DisplayName,
                    u.Id
                })
                .Top(1000)
                .GetAsync();

            // Put result into a list for easy processing
            List<DeviceConfiguration> deviceConfigurationProfiles = new List<DeviceConfiguration>();


            // Adds all the data from the graph query into the list
            deviceConfigurationProfiles.AddRange(allPolicies.Result);


            // Loop through the list

            foreach (var profile in deviceConfigurationProfiles)
            {

                dtgDisplayPolicy.Rows.Add(profile.DisplayName, "Device Configuration", profile.ODataType);

            }

        }

        //private void List




        ////////////////////////////////////////////////////////////////////////  BUTTONS  /////////////////////////////////////////////////////////////////////////////////////////////

        // Rename all buttons before use
        // No buttons should be name "button1, button2, etc"



        private void pbHome_Click(object sender, EventArgs e)
        {
            goHome();
        }

        private void btnListAllPolicy_Click(object sender, EventArgs e)
        {
            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Clear the datagridview for older results
            // Note - this should not be done in each method, because that would remove all other results
            form1.ClearDataGridView(dtgDisplayPolicy);




            ListCompliancePolicies();
            ListConfigurationProfiles();
        }
    }
}
