﻿using Microsoft.Graph;
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

// For assignment of policy - create two lists with app name and ID, and group name and ID

// GUI - hvis bare en rekke er valgt - vis assignments for appen
//



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


        private void FindCompliancePolicyAssignments(int rowIndex)
        {

            

            var profileName = dtgDisplayPolicy.Rows[rowIndex].Cells[0].Value.ToString();
            var profileType = dtgDisplayPolicy.Rows[rowIndex].Cells[1].Value.ToString();
            var profilePlatform = dtgDisplayPolicy.Rows[rowIndex].Cells[2].Value.ToString();
            var profileID = dtgDisplayPolicy.Rows[rowIndex].Cells[3].Value.ToString();


            // Troubleshoot only:
            //MessageBox.Show("Type is " + profileType);

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);

            if (profileType == "Compliance")
            {

                // Need to find all assignments by their unique ID's

                var assignments = client.DeviceManagement.DeviceCompliancePolicies[profileID].Assignments
                    .Request()
                    .Select("id")
                    .GetAsync();

                List <DeviceCompliancePolicyAssignment>  assignmentList = new List<DeviceCompliancePolicyAssignment>();

                assignmentList.AddRange(assignments.Result);



                if (assignmentList.Count == 0)
                {
                    // The list has zero members. Informing user and ending job
                    MessageBox.Show("No assignment found for " + profileName);
                }

                else if (assignmentList.Count >= 1) 
                {

                    // Make sure to account for the possiblity of there being multiple assignments

                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    foreach (var assignment in assignmentList)
                    {
                        MessageBox.Show(assignment.Id.ToString());
                    }
                    

                }



            }




            else if (profileType == "Device Configuration")
            {

            } 





            else if (profileType == "Settings catalog")
            {


            }
            
            else
            {
                MessageBox.Show("Unspecified error. Please troubleshoot");
            }



        }



        private void ListCompliancePolicies()
        {

            // Put result into a list for easy processing
            List<DeviceCompliancePolicy> deviceCompliancePolicies = new List<DeviceCompliancePolicy>();

            // Empty the list

            deviceCompliancePolicies.Clear();

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


            // Adds all the data from the graph query into the list
            deviceCompliancePolicies.AddRange(allPolicies.Result);


            // Loop through the list

            foreach (var policy in deviceCompliancePolicies)
            {

                dtgDisplayPolicy.Rows.Add(policy.DisplayName, "Compliance", policy.ODataType, policy.Id);

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

                dtgDisplayPolicy.Rows.Add(profile.DisplayName, "Device Configuration", profile.ODataType, profile.Id);

            }

        }

        private void ListSettingsCatalog()
        {


            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);



            // Make a call to Microsoft Graph
            var allPolicies = client.DeviceManagement.ConfigurationPolicies
                .Request()
                .Select(u => new
                {
                    u.Name,
                    u.Id,
                    u.Platforms
                })
                .Top(1000)
                .GetAsync();

            // Put result into a list for easy processing
            List<DeviceManagementConfigurationPolicy> configurationPolicies = new List<DeviceManagementConfigurationPolicy>();


            // Adds all the data from the graph query into the list
            configurationPolicies.AddRange(allPolicies.Result);


            // Loop through the list

            foreach (var policy in configurationPolicies)
            {

                dtgDisplayPolicy.Rows.Add(policy.Name, "Settings Catalog", policy.Platforms, policy.Id);

            }

        }

        private void ListAllGroups()
        {
            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            form1.ClearDataGridView(dtgDisplayPolicy);



            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);

            var groups = client.Groups
                .Request()
                .GetAsync();


            List<Group> listAllGroups = new List<Group>();
            listAllGroups.AddRange(groups.Result);

            foreach (var group in listAllGroups)
            {
                dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
            }
        }


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
            ListSettingsCatalog();
        }

        private void btnListAllGroups_Click(object sender, EventArgs e)
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Clear the datagridview for older results
            // Note - this should not be done in each method, because that would remove all other results
            form1.ClearDataGridView(dtgDisplayGroup);

            ListAllGroups();

        }

        private void dtgDisplayPolicy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string? type = "";


            // Pass the rowIndex to other method to allow processing
            FindCompliancePolicyAssignments(e.RowIndex);


            

            if (e.RowIndex >= 0)
            {
                type = dtgDisplayPolicy.Rows[e.RowIndex].Cells[1].Value.ToString();
                
                // Insert logic to choose which lookup method based on the value of the type variable
                // Index 3 contains the ID


                // Options:
                // Compliance
                // Device Configuration
                // Settings Catalog

            }


        }
    }
}