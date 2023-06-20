using Microsoft.Graph;
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
using Windows.Media.Protection.PlayReady;
using static System.Windows.Forms.DataFormats;





// TO DO


// Method to check @odata.type contains certain key word (macOS, Windows, etc)
// Switch between main form and this form, keep location, reuse auth

// For assignment of policy - create two lists with app name and ID, and group name and ID

// GUI - hvis bare en rekke er valgt - vis assignments for appen
// GUI - Menu item to choose if it should query for assignment on click or not

// Error handling:
// Check if user has selected multiple cells on the same row
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

            lblAssignmentPreview.Hide();

        }

        private void goHome()
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }


        ////////////////////////////////////////////////////////////////////////  METHODS  /////////////////////////////////////////////////////////////////////////////////////////////

        private string ExtractGroupID(string input)
        {
            // Group ID for assignments is returned as the following format from Graph

            // PolicyID_GroupID

            // This methode extracts the GroupID part and returns it


            int underscoreIndex = input.IndexOf('_');
            if (underscoreIndex >= 0 && underscoreIndex < input.Length - 1)
            {
                return input.Substring(underscoreIndex + 1);
            }

            return string.Empty; // Return an empty string if "_" is not found or it's the last character


        }


        public async Task<List<Group>> LookUpGroup(string input)
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);


            List<Group> groups = new List<Group>();

            try

            {
                var groupSearch = await client.Groups
            .Request()
            .Filter($"id eq '{input}'")
            .GetAsync();



                while (groupSearch.CurrentPage != null)
                {
                    foreach (var group in groupSearch.CurrentPage)
                    {
                        groups.Add(group);
                    }

                    if (groupSearch.NextPageRequest == null)
                    {
                        break;
                    }

                    groupSearch = await groupSearch.NextPageRequest.GetAsync();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            return groups;
        }


        private async void FindPolicyAssignments(int rowIndex)
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

            if (profileType != "")
            {

                // Need to find all assignments by their unique ID's



                var assignments = client.DeviceManagement.DeviceCompliancePolicies[profileID].Assignments
                    .Request()
                    .Select("id")
                    .GetAsync();

                // This ID is profile id followed by group ID
                // UUID_UUID

                List<DeviceCompliancePolicyAssignment> assignmentList = new List<DeviceCompliancePolicyAssignment>();

                assignmentList.AddRange(assignments.Result);



                if (assignmentList.Count == 0)
                {
                    // The list has zero members. Informing user and ending job
                    //MessageBox.Show("No assignment found for " + profileName);

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName + " does not have any assignments";
                }

                else if (assignmentList.Count >= 1)
                {

                    // Make sure to account for the possiblity of there being multiple assignments

                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName + " is assigned to:";


                    foreach (var assignment in assignmentList)
                    {
                        // Testing only
                        // MessageBox.Show(assignment.Id.ToString());


                        // Need to parse the JSON data and grab target - GroupID field

                        var groupID = ExtractGroupID(assignment.Id.ToString());

                        // Look up Azure AD groups based on ID

                        List<Group> groups = await LookUpGroup(groupID);

                        foreach (var group in groups)
                        {

                            //MessageBox.Show("This app is currently assigned to " + group.DisplayName);

                            rtbAssignmentPreview.AppendText(group.DisplayName + "\n");
                        }






                    }


                }



            }

            else
            {
                MessageBox.Show("Unspecified error. Please troubleshoot");
            }



        }


        private Dictionary<string, List<string>> GetSelectedPolicies(DataGridView dataGridView)
        {

            // Method to store the selected policies from a data grid view in a dictionary for further processing

            Dictionary<string, List<string>> values = new Dictionary<string, List<string>>();

            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                if (!cell.OwningRow.IsNewRow)
                {
                    string key = cell.OwningRow.Cells[0].Value?.ToString() ?? string.Empty;
                    string value1 = cell.OwningRow.Cells[1].Value?.ToString() ?? string.Empty;
                    string value2 = cell.OwningRow.Cells[2].Value?.ToString() ?? string.Empty;
                    string value3 = cell.OwningRow.Cells[3].Value?.ToString() ?? string.Empty;
                    // Add cell for ID!

                    if (!values.ContainsKey(key))
                    {
                        values[key] = new List<string>();
                    }

                    values[key].Add(value1);
                    values[key].Add(value2);
                    values[key].Add(value3);
                }
            }

            return values;
        }


        private Dictionary<string, string> GetSelectedGroups(DataGridView dataGridView)
        {

            // Method to store the selected groups from a data grid view in a dictionary for further processing

            Dictionary<string, string> values = new Dictionary<string, string>();

            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                if (cell.RowIndex >= 0 && cell.ColumnIndex >= 0)
                {
                    string key = dataGridView.Rows[cell.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                    string value = dataGridView.Rows[cell.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;

                    values[key] = value;
                }
            }

            return values;
        }


        public void PreparePolicyDeployment()
        {

            // This method prepares the policy deployment by populating the rich text box with the policies and groups that the user has selected


            // Clears old content in the textbox

            _form1.ClearRichTextBox(rtbSelectedPolicies);
            _form1.ClearRichTextBox(rtbSelectedGroups);



            // Gather the values from the selected policies and selected groups

            Dictionary<string, List<string>> SelectedPolicies = GetSelectedPolicies(dtgDisplayPolicy);
            Dictionary<string, string> SelectedGroups = GetSelectedGroups(dtgDisplayGroup);


            // Loop through all policies and add to the rich text box to give an overview prior to assignment:

            foreach (string policy in SelectedPolicies.Keys)
            {

                rtbSelectedPolicies.AppendText(policy.ToString() + "\n");

            }


            // Groups:

            foreach (string group in SelectedGroups.Keys)
            {

                rtbSelectedGroups.AppendText(group.ToString() + "\n");

            }
        }


        async Task AssignCompliancePolcy(string policyID, string groupID)
        {
            // Method to assign a compliance policy to one group

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);




            var target = new GroupAssignmentTarget
            {
                GroupId = groupID
                //DeviceAndAppManagementAssignmentFilterId = policyID

            };


            var assignment = new DeviceConfigurationAssignment
            {

                Target = target

            };





            try
            {


                await client.DeviceManagement
                    .DeviceConfigurations[policyID]
                    .Assignments
                    .Request()
                    .AddAsync(assignment);


            }
            catch (Exception)
            {

                throw;
            }



        }


        async Task AssignSelectedPolicies()
        {


            // Gather the values from the selected policies and selected groups



            Dictionary<string, List<string>> SelectedPolicies = GetSelectedPolicies(dtgDisplayPolicy);
            Dictionary<string, string> SelectedGroups = GetSelectedGroups(dtgDisplayGroup);


            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);


            // Iterate over the keys in the dictionary and retrieve the policy ID from graph
            // for each selected cell in dtgdisplaypolicy --> assign to each selected cell in dtgdisplaygroup

            foreach (string policy in SelectedPolicies.Keys)
            {

                if (SelectedPolicies.TryGetValue(policy, out List<string> dataList))
                {

                    if (dataList.Count >= 3)
                    {

                        // Type is the profile type (Compliance, Device Configuration, Settings Catalog)
                        string type = dataList[0];
                        //MessageBox.Show(ID);



                        // ID is the policy ID in Graph
                        string policyID = dataList[2];
                        //MessageBox.Show(type);



                        // Begin assignment

                        foreach (var group in SelectedGroups)
                        {

                            string groupName = group.Key;
                            string groupID = group.Value;

                            // Use these for deployment

                            await AssignCompliancePolcy(policyID, groupID);


                        }



                    }

                }


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

            if (cbLookUpAssignment.Checked == true)
            {


                if (e.RowIndex == 0)
                {
                    MessageBox.Show("test");
                }

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    //string? type = "";

                    //type = dtgDisplayPolicy.Rows[e.RowIndex].Cells[1].Value.ToString();

                    rtbAssignmentPreview.Clear();



                    // Pass the rowIndex to other method to allow processing
                    FindPolicyAssignments(e.RowIndex);
                }
            }

            else
            {

            }



        }

        private void btnPrepareDeployment_Click(object sender, EventArgs e)
        {
            PreparePolicyDeployment();
        }

        private void btnResetDeployment_Click(object sender, EventArgs e)
        {
            _form1.ClearRichTextBox(rtbSelectedGroups);
            _form1.ClearRichTextBox(rtbSelectedPolicies);
        }

        private void btnDeployPolicyAssignment_Click(object sender, EventArgs e)
        {
            AssignSelectedPolicies();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph
            GraphServiceClient client = new Form1().NewGetGraphClient(Form1.GraphAccessToken);

            var groupID = "107b865f-4732-430e-abf3-41737fd2697b";

            var policyID = "44812917-7720-47cf-9f5f-809d67764817";

            var target = new GroupAssignmentTarget
            {

               GroupId = groupID


            };

            
            // This only works for Device Configuration (not compliance or settings catalog)
            var deviceConfigAssignment = new DeviceConfigurationAssignment
            {
                
                Target = target,

            };

            client.DeviceManagement
                    .DeviceConfigurations[policyID]
                    .Assignments
                    .Request()
                    .AddAsync(deviceConfigAssignment);







            // Under development:

            var settingsCatalogConfig = new DeviceManagementConfigurationPolicyAssignment
            {
                
                Target = target,

            };


            client.DeviceManagement
                    .ConfigurationPolicies[policyID]
                    .Assignments
                    .Request()
                    .AddAsync(settingsCatalogConfig);










            //// PostASync overwrites existing deployments

            //var assignment = new DeviceConfigurationGroupAssignment
            //{
            //    TargetGroupId = groupID
            //};


            //client.DeviceManagement
            //        .DeviceConfigurations[policyID]
            //        .Assign(new List<DeviceConfigurationGroupAssignment> { assignment } )
            //        .Request()
            //        .PostAsync();
        }




    }
}
