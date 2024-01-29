using System;
using System.Net;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using Microsoft.Graph.Core;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Azure.Identity;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Principal;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using Windows.Foundation.Metadata;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using static IntuneAssignments.Form1;
using System.Reflection;
using static IntuneAssignments.FormUtilities;
using static IntuneAssignments.GlobalVariables;
using static IntuneAssignments.GraphServiceClientCreator;





// TO DO


// Method to check @odata.type contains certain key word (macOS, Windows, etc)

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
        private ManagePolicyAssignments managePolicyAssignments;

        private void Policy_Load(object sender, EventArgs e)
        {
            cbPolicyType.Text = "All types";
            pnlAssignedTo.Visible = false;
        }

        //public Policy(Form1 form1)
        //{
        //    InitializeComponent();
        //    _form1 = form1;

        //    lblAssignmentPreview.Hide();

        //    pnlAssignedTo.Hide();

        //}

        public Policy()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Makes the form not resizable and the parent form not clickable
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form over its parent

            InitializeComponent();
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    // Necessary to copy the location of Form1
        //    base.OnLoad(e);

        //    // Set the location of the form to the position of Form1
        //    if (_form1 != null)
        //    {
        //        Location = new Point(
        //            _form1.Location.X + (_form1.Width - Width) / 2,
        //            _form1.Location.Y + (_form1.Height - Height) / 2);
        //    }



        //}


        //public Policy(ManagePolicyAssignments managePolicyAssignments)
        //{
        //    this.managePolicyAssignments = managePolicyAssignments;
        //}

        private void goHome()
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void viewManageAssignments()
        {

            this.Hide();
            ManagePolicyAssignments managePolicyAssignments = new ManagePolicyAssignments(_form1);
            managePolicyAssignments.Show();

        }

        ////////////////////////////////////////////////////////////////////////  METHODS  /////////////////////////////////////////////////////////////////////////////////////////////

        public string ExtractGroupID(string input)
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

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();


            // Create a list to store the groups in
            List<Group> Groups = new List<Group>();



            // Make a call to Microsoft Graph
            var result = await graphClient.Groups.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayname" };
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });



            // add the result to the list
            Groups.AddRange(result.Value);


            // Find the group name based on the ID (because graph doesn't allow to search for the ID directly)
            var groupName = Groups.Find(x => x.Id == input);

            // Convert the group name to a string and return it
            if (groupName != null)
            {
                return new List<Group> { groupName };
            }

            else
            {
                return new List<Group>();
            }


        }



        private async void FindPolicyAssignments(int rowIndex)
        {



            var profileName = dtgDisplayPolicy.Rows[rowIndex].Cells[0].Value.ToString();
            var profileType = dtgDisplayPolicy.Rows[rowIndex].Cells[1].Value.ToString();
            var profilePlatform = dtgDisplayPolicy.Rows[rowIndex].Cells[2].Value.ToString();
            var profileID = dtgDisplayPolicy.Rows[rowIndex].Cells[3].Value.ToString();


            // Troubleshoot only:
            // MessageBox.Show("Type is " + profileType);

            var graphClient = CreateGraphServiceClient();

            if (profileType != "")
            {

                // Need to find all assignments by their unique ID's





                var result = await graphClient.DeviceManagement.DeviceCompliancePolicies[profileID].Assignments.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
                });

                // This ID is profile id followed by group ID
                // UUID_UUID

                List<DeviceCompliancePolicyAssignment> assignmentList = new List<DeviceCompliancePolicyAssignment>();

                assignmentList.AddRange(result.Value);



                if (assignmentList.Count == 0)
                {
                    // The list has zero members. Informing user and ending job
                    //MessageBox.Show("No assignment found for " + profileName);

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "";
                    rtbDeploymentSummary.SelectionColor = Color.Yellow;
                    rtbAssignmentPreview.AppendText(profileName + " does not have any assignments" + "\n");
                }

                else if (assignmentList.Count >= 1)
                {

                    // Make sure to account for the possiblity of there being multiple assignments

                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "is assigned to:"; ;


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

            // use method from FormUtilities.cs class


            ClearRichTextBox(rtbSelectedPolicies);
            ClearRichTextBox(rtbSelectedGroups);




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




        public string findPolicyPlatform(string odatatype)
        {
            // IMPORTANT!

            // This was intended to be used to find the platform of a policy, however it is not used in the current version of the app
            // The reason was that it is easier to find a substring in the odatatype property than to use this method
            // Keeping it here for future reference


            // Translates odatatype property to human readable platform name for display in datagridview
            // Must be updated if new platforms are added to Intune or the odatatype changes

            string[] Windows = { "#microsoft.graph.windows10CompliancePolicy", "Windows10" };
            string[] iOS = { "#microsoft.graph.iosCompliancePolicy" };
            string[] Android = { "#microsoft.graph.androidDeviceOwnerCompliancePolicy", "#microsoft.graph.androidWorkProfileCompliancePolicy", "#microsoft.graph.androidDeviceOwnerGeneralDeviceConfiguration" };
            string[] macOS = { "#microsoft.graph.macOSCompliancePolicy", };


            return "test";
        }



        public string findSettingsCatalogPolicyType(string odatatype)
        {
            /* 
                IMPORTANT!

                This code is no longer needed, because settings catalog objects does not need to know the class name of the policy type, nor does it need to know the platform (Windows, iOS, etc...)
                Keeping it here for future reference
            







                This method converts the odatatype property to the actual class name of the app and returns it
                There are 4 different types of settings catalog in Intune, and each one has a different class name
                
                The class name is needed to dynamically create a requestBody when updating the description of a policy
                

                var requestBody = new DeviceManagementConfigurationPolicy


                Platforms = DeviceManagementConfigurationPlatforms.Windows10
                Platforms = DeviceManagementConfigurationPlatforms.IOS
                Platforms = DeviceManagementConfigurationPlatforms.MacOS


            */


            var test = new DeviceManagementConfigurationPolicy
            {
                Platforms = DeviceManagementConfigurationPlatforms.Android
            };

            switch (odatatype)
            {
                case ("Windows10"):

                    return "Windows";

                case ("IOS"):

                    return "iOS";

                case ("MacOS"):

                    return "MacOS";

                default:
                    // Code for other cases or handle unexpected values
                    return "Error looking up policy type";
            }


        }
        public string findCompliancePolicyType(string odatatype)
        {
            /* 
                This method converts the odatatype property to the actual class name of the app and returns it
                There are 5 different types of compliance policies in Intune, and each one has a different class name
                
                The class name is needed to dynamically create a requestBody when updating the description of a policy


            */


            switch (odatatype)
            {
                case "#microsoft.graph.androidDeviceOwnerCompliancePolicy":
                    // Code for androidDeviceOwnerCompliancePolicy
                    return "AndroidDeviceOwnerCompliancePolicy";


                case "#microsoft.graph.iosCompliancePolicy":
                    // Code for iosCompliancePolicy
                    return "IosCompliancePolicy";

                case "#microsoft.graph.windows10CompliancePolicy":
                    // Code for windows10CompliancePolicy
                    return "Windows10CompliancePolicy";


                case "#microsoft.graph.androidWorkProfileCompliancePolicy":
                    // Code for androidWorkProfileCompliancePolicy

                    return "AndroidWorkProfileCompliancePolicy";


                case "#microsoft.graph.macOSCompliancePolicy":
                    // Code for macOSCompliancePolicy
                    return "MacOSCompliancePolicy";


                default:
                    // Code for other cases or handle unexpected values
                    return "Error looking up policy type";

            }
        }


        async Task UpdatePolicyDescription()
        {

            // This method updates the description of a policy
            // The existing description is overwritten with the text in txtboxAppDescription

            // Configure the progress bar to show progress

            // Set progress bar to 0
            pBarDeployProgress.Value = 0;




            // Create an instance of form1
            Form1 form1 = new Form1();



            // Load the MS Graph assembly for class lookup
            var assembly = Assembly.Load(form1.graphAssembly);

            try
            {

                // Authenticate to Graph
                var graphClient = CreateGraphServiceClient();



                // Check if text box is empty
                if (string.IsNullOrEmpty(txtboxDescription.Text))
                {
                    // No text entered. No changes will be made. This is intentional
                    return;
                }



                else
                {


                    if (dtgDisplayPolicy.SelectedRows.Count > 0)
                    {





                        // Loop through each selected row in the datagridview

                        foreach (DataGridViewRow row in dtgDisplayPolicy.SelectedRows)
                        {

                            // Set the max (finished state) value to the number of apps in the checked list box
                            pBarDeployProgress.Maximum = dtgDisplayPolicy.SelectedRows.Count;



                            // Extract the policy ID from the datagridview

                            string policyID = row.Cells[3].Value.ToString();
                            string policyName = row.Cells[0].Value.ToString();
                            string policyType = row.Cells[1].Value.ToString();
                            string policyPlatform = row.Cells[2].Value.ToString();




                            /*
                             These next blocks of code will handle each policy type separately
                             For each policy type there is a different object type that must be created and used to update the policy
                             This code could probably be optimized by using a switch statement instead of if statements
                            */





                            // COMPLIANCE POLICY //

                            if (policyType == "Compliance")
                            {

                                // Must check what platform the policy is for and create the correct object type

                                // Look up the class name based on the odatatype property
                                var policyClassName = findCompliancePolicyType(policyPlatform);

                                // Create the full class name
                                var fullClassName = form1.graphClassNamePrefix + policyClassName;

                                // Create the class type
                                var classType = assembly.GetType(fullClassName);


                                if (classType == null)
                                {
                                    // troubleshoot if this happens
                                    MessageBox.Show("Class type is null");
                                }


                                // Create a new request body based on the app class name
                                var requestBody = Activator.CreateInstance(classType);


                                // Set the description property to the text in the textbox
                                SetProperty(requestBody, "Description", txtboxDescription.Text);


                                // Update the description
                                var result = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].PatchAsync((DeviceCompliancePolicy)requestBody);

                                // write to the textbox
                                rtbDeploymentSummary.SelectionColor = Color.Green;
                                rtbDeploymentSummary.AppendText("Description for " + policyName + " has been updated" + Environment.NewLine);

                            }



                            // SETTINGS CATALOG POLICY

                            if (policyType == "Settings Catalog")
                            {


                                // Create a new settings catalog object
                                var requestBody = new DeviceManagementConfigurationPolicy
                                {
                                    Description = txtboxDescription.Text
                                };

                                // Update the description
                                var result = await graphClient.DeviceManagement.ConfigurationPolicies[policyID].PatchAsync(requestBody);

                                // write to the textbox
                                rtbDeploymentSummary.SelectionColor = Color.Green;
                                rtbDeploymentSummary.AppendText("Description for " + policyName + " has been updated" + Environment.NewLine);
                            }




                            /*
                               Next step is to continue with the other policy types
                               
                               Device configuration has a lot of different odatatypes
                           
                                
                                

                            https://graph.microsoft.com/beta/deviceManagement/groupPolicyConfigurations // ADMX template

                            */


                            // DEVICE CONFIGURATION POLICY
                            // Consider not support device configuration policies for now


                            if (policyType == "Device Configuration")
                            {
                                // Not implemented yet

                                // Create a new device configuration object



                                // Write to the textbox in yellow color to indicate that this is not supported yet
                                rtbDeploymentSummary.SelectionColor = Color.Yellow;


                                rtbDeploymentSummary.AppendText("Administrative templates are not supported yet. No changes have been made to " + policyName + Environment.NewLine);

                            }


                            // Update the progress bar
                            pBarDeployProgress.Value++;

                        }
                    }
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }


        static void SetProperty(object obj, string propertyName, object value)
        {
            // Set the value of a property in an object


            var property = obj.GetType().GetProperty(propertyName);
            if (property != null)
            {
                property.SetValue(obj, value);
            }
            else
            {
                Console.WriteLine($"Property {propertyName} not found in {obj.GetType().Name}");
            }
        }

        async Task AssignSettingsCatalog(string policyID, string groupID)
        {
            // Description

            // This methods assigns a settings catalog to one or more groups

            // The policy ID and group ID are passed as parameters to this method and used to create the assignment



            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            // Create a group assignment target object
            var groupAssignmentTarget = new GroupAssignmentTarget
            {
                GroupId = groupID
                //DeviceAndAppManagementAssignmentFilterId = policyID

            };



            // Create a configuration policy assignment object
            var deviceConfigurationAssignmentTarget = new DeviceConfigurationAssignment
            {

                Target = groupAssignmentTarget

            };


            // Create an array to store all group IDs
            // Add the new group ID to the array, which is passed into this method as a parameter
            // Existing group IDs are added to this array later in the code
            string[] groupIDs = { groupID };


            // Create a list to temporarily store existing group IDs for further processing
            List<DeviceManagementConfigurationPolicyAssignment> groupIDList = new List<DeviceManagementConfigurationPolicyAssignment>();



            // All existing assignments must be retrieved and added to the array in order to prevent them from being overwritten

            // Find all existing assignments by their group ID
            var existingAssignments = await graphClient.DeviceManagement.ConfigurationPolicies[policyID]
                .Assignments
                .GetAsync();


            // Check if there are any existing assignments

            if (existingAssignments.Value.Count >= 1)
            {
                // Add existing assignments to a list for further processing
                foreach (var assignment in existingAssignments.Value)
                {
                    groupIDList.Add(assignment);
                }
            }


            // Loop through each existing assignment, extract the group ID and add that to the array of group ID's
            // This is to ensure that existing assignments are not overwritten and deleted by PostAsync() later in the code


            foreach (var group in groupIDList)
            {

                // Extract the group ID from the ID property (which consists of the policy ID and the group ID joined by a "_" sign)
                int underscoreIndex = group.Id.IndexOf("_");

                if (underscoreIndex >= 0 && underscoreIndex < group.Id.Length - 1)
                {
                    string extractedText = group.Id.Substring(underscoreIndex + 1);


                    // Add each existing assignment to the array of assignments to ensure that they are not overwritten and deleted
                    Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    groupIDs[groupIDs.Length - 1] = extractedText;



                }

            }

            // Create an empty list to store the assignments
            List<DeviceManagementConfigurationPolicyAssignment> assignments = new List<DeviceManagementConfigurationPolicyAssignment>();


            // Loop through each group ID and create an assignment object for each one

            foreach (var group in groupIDs)
            {
                var assignment = new DeviceManagementConfigurationPolicyAssignment
                {
                    OdataType = "#microsoft.graph.deviceManagementConfigurationPolicyAssignment",
                    Id = group,
                    Target = new GroupAssignmentTarget
                    {
                        OdataType = "#microsoft.graph.groupAssignmentTarget",
                        DeviceAndAppManagementAssignmentFilterId = null,
                        DeviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.Include,
                        GroupId = group,
                    },
                    Source = DeviceAndAppManagementAssignmentSource.Direct,
                    SourceId = group,

                };
                // add each assignment to the list of assignments
                assignments.Add(assignment);

            }


            // Create a request body object and add all assignment object to it
            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.ConfigurationPolicies.Item.Assign.AssignPostRequestBody
            {
                Assignments = assignments
            };




            // Create a new assignment
            try
            {

                var result = await graphClient.DeviceManagement.ConfigurationPolicies[policyID].Assign.PostAsync(requestBody);


            }
            catch (ServiceException ex)
            {

                MessageBox.Show(ex.Message);
                throw;
            }


        }

        async Task AssignCompliancePolcy(string policyID, string groupID)
        {
            // This methods assigns a compliance policy to one or more groups

            // the policy ID and group ID are passed as parameters to this method and used to create the assignment 



            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();



            // Create a group assignment target object
            var groupAssignmentTarget = new GroupAssignmentTarget
            {
                GroupId = groupID
                //DeviceAndAppManagementAssignmentFilterId = policyID

            };


            // Create a device configuration assignment object
            var deviceComplianceAssignmentTarget = new DeviceCompliancePolicyAssignment
            {

                Target = groupAssignmentTarget

            };


            // Create an array to store all group IDs
            // Add the new group ID to the array, which is passed into this method as a parameter
            // Existing group IDs are added to this array later in the code
            string[] groupIDs = { groupID };


            // create a list for temporarily storing existing group IDs for further processing
            List<DeviceCompliancePolicyAssignment> groupIDList = new List<DeviceCompliancePolicyAssignment>();


            // Find all existing assignments by their group ID
            var existingAssignments = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID]
                .Assignments
                .GetAsync();


            // check if there are any existing assignments

            if (existingAssignments.Value.Count >= 1)
            {
                // Add existing assignments to a list for further processing
                foreach (var assignment in existingAssignments.Value)
                {
                    groupIDList.Add(assignment);
                }
            }





            // Loop through each existing assignment, extract the group ID and add that to the array of group ID's
            // This is to ensure that existing assignments are not overwritten and deleted by PostAsync() later in the code
            foreach (var group in groupIDList)
            {

                // Extract the group ID from the ID property (which consists of the policy ID and the group ID joined by a "_" sign)
                int underscoreIndex = group.Id.IndexOf("_");

                if (underscoreIndex >= 0 && underscoreIndex < group.Id.Length - 1)
                {
                    string extractedText = group.Id.Substring(underscoreIndex + 1);

                    // Add each existing assignment to the array of assignments

                    Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    groupIDs[groupIDs.Length - 1] = extractedText;


                }
            }




            // The array now consists of all existing group ID's + the new group ID passed to this method as a parameter


            // Begin deployment of the policy to the groups


            // Create an empty list to store the assignments
            List<DeviceCompliancePolicyAssignment> assignments = new List<DeviceCompliancePolicyAssignment>();



            // Loop through the groupIDs array and add each ID to the request body
            // It is important that all group ID's are added and assigned at the same time,
            // otherwise each request will delete all previous and only the last request will be added

            foreach (var ID in groupIDs)
            {
                var assignment = new DeviceCompliancePolicyAssignment
                {
                    OdataType = "#microsoft.graph.deviceCompliancePolicyAssignment",
                    Id = ID,
                    Target = new DeviceAndAppManagementAssignmentTarget
                    {
                        OdataType = "#microsoft.graph.groupAssignmentTarget",
                        AdditionalData = new Dictionary<string, object>
                        {
                            { "groupId", ID }
                        },
                    }
                };

                assignments.Add(assignment);
            }

            // create a request body object and add all assignment objects to it
            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceCompliancePolicies.Item.Assign.AssignPostRequestBody
            {
                Assignments = assignments
            };



            // Create a new assignment

            try
            {

                var result = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assign.PostAsync(requestBody);


            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }








        }

        async Task AssignDeviceConfiguration(string policyID, string groupID)
        {
            // This methods assigns a device configuration policy to one or more groups

            // the policy ID and group ID are passed as parameters to this method and used to create the assignment 

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();


            // create a group assignment target object
            var target = new GroupAssignmentTarget
            {

                GroupId = groupID
            };

            // create a device configuration assignment object
            var deviceConfigAssignment = new DeviceConfigurationAssignment
            {

                Target = target,

            };

            // Create an array to store all group IDs
            // Add the new group ID to the array, which is passed into this method as a parameter
            // Existing group IDs are added to this array later in the code
            string[] groupIDs = { groupID };


            // create a list for temporarily storing existing group IDs for further processing
            List<DeviceConfigurationAssignment> groupIDlist = new List<DeviceConfigurationAssignment>();

            // All existing assignments must be retrieved and added to the array in order to prevent them from being overwritten

            // Find all existing assignments by their group ID
            var existingAssignments = await graphClient.DeviceManagement.DeviceConfigurations[policyID]
                .Assignments
                .GetAsync();

            // Check if there are any existing assignments

            if (existingAssignments.Value.Count >= 1)
            {
                // Add existing assignments to a list for further processing
                foreach (var assignment in existingAssignments.Value)
                {
                    groupIDlist.Add(assignment);
                }
            }


            // Loop through each existing assignment, extract the group ID and add that to the array of group ID's
            // This is to ensure that existing assignments are not overwritten and deleted by PostAsync() later in the code

            foreach (var group in groupIDlist)
            {

                // Extract the group ID from the ID property (which consists of the policy ID and the group ID joined by a "_" sign)
                int underscoreIndex = group.Id.IndexOf("_");

                if (underscoreIndex >= 0 && underscoreIndex < group.Id.Length - 1)
                {
                    string extractedText = group.Id.Substring(underscoreIndex + 1);


                    // Add each existing assignment to the array of assignments to ensure that they are not overwritten and deleted
                    Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    groupIDs[groupIDs.Length - 1] = extractedText;



                }

            }


            // create an empty list to store the assignments
            List<DeviceConfigurationAssignment> assignments = new List<DeviceConfigurationAssignment>();

            // Loop through each group ID and create an assignment object for each one

            foreach (var group in groupIDs)
            {

                var assignment = new DeviceConfigurationAssignment
                {

                    //OdataType = "#microsoft.graph.deviceManagementConfigurationPolicyAssignment",
                    Id = policyID + "_" + group,
                    Intent = DeviceConfigAssignmentIntent.Apply,
                    //Source = DeviceAndAppManagementAssignmentSource.Direct,
                    //SourceId = group,
                    Target = new GroupAssignmentTarget
                    {
                        OdataType = "microsoft.graph.groupAssignmentTarget",
                        //DeviceAndAppManagementAssignmentFilterId = null,
                        //DeviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.None,
                        GroupId = group

                    },

                };

                // Add each assignment object to the list of assignments
                assignments.Add(assignment);

            }

            // Create a request body object and add all assignment objects to it
            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceConfigurations.Item.Assign.AssignPostRequestBody
            {
                Assignments = assignments
            };


            // create a new assignment
            try
            {

                var result = await graphClient.DeviceManagement.DeviceConfigurations[policyID].Assign.PostAsync(requestBody);


            }
            catch (ServiceException ex)
            {
                Console.WriteLine(ex.Message);
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


            // Sets the scope of the progress bar to the number of selected policies * number of selected groups

            int numberOfPolicies = SelectedPolicies.Count();
            int numberOfGroups = SelectedGroups.Count();
            int progressBarMaxValue = numberOfPolicies * numberOfGroups;
            pBarDeployProgress.Maximum = progressBarMaxValue;


            // Store default color for rich textbox
            var defaultColor = rtbDeploymentSummary.ForeColor;

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();




            // Iterate over the keys in the dictionary and retrieve the policy ID from graph
            // for each selected cell in dtgdisplaypolicy --> assign to each selected cell in dtgdisplaygroup


            try
            {

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


                            // Assignments needs to be separated into different foreach loops

                            // Assignments for Compliance Policies
                            if (type == "Compliance")
                            {

                                // Loop through each selected group and assign the policy to each group
                                foreach (var group in SelectedGroups)
                                {

                                    string groupName = group.Key;
                                    string groupID = group.Value;


                                    // Assignment for Compliance Policies
                                    await AssignCompliancePolcy(policyID, groupID);


                                    // Log status to the textbox
                                    rtbDeploymentSummary.ForeColor = Color.Green;
                                    rtbDeploymentSummary.AppendText(policy + " has been assigned to " + group.Key + Environment.NewLine);
                                    pBarDeployProgress.Value++;
                                    rtbDeploymentSummary.ForeColor = defaultColor;

                                }
                            }

                            // Assignments for Settings Catalog
                            if (type == "Settings Catalog")
                            {

                                // Loop through each selected group and assign the policy to each group
                                foreach (var group in SelectedGroups)
                                {

                                    string groupName = group.Key;
                                    string groupID = group.Value;


                                    // Assignment for Settings Catalog
                                    await AssignSettingsCatalog(policyID, groupID);


                                    // Log status to the textbox
                                    rtbDeploymentSummary.ForeColor = Color.Green;
                                    rtbDeploymentSummary.AppendText(policy + " has been assigned to " + group.Key + Environment.NewLine);
                                    pBarDeployProgress.Value++;
                                    rtbDeploymentSummary.ForeColor = defaultColor;
                                }
                            }

                            // Assignments for Device Configuration Policies
                            if (type == "Device Configuration")
                            {

                                // Loop through each selected group and assign the policy to each group
                                foreach (var group in SelectedGroups)
                                {

                                    string groupName = group.Key;
                                    string groupID = group.Value;


                                    // Assignment for Device Configuration Policies
                                    await AssignDeviceConfiguration(policyID, groupID);


                                    // Log status to the textbox
                                    rtbDeploymentSummary.ForeColor = Color.Green;
                                    rtbDeploymentSummary.AppendText(policy + " has been assigned to " + group.Key + Environment.NewLine);
                                    pBarDeployProgress.Value++;
                                    rtbDeploymentSummary.ForeColor = defaultColor;
                                }
                            }
                        }
                    }
                }
            }
            catch (ServiceException ex)
            {
                // Log error to the textbox
                rtbDeploymentSummary.SelectionColor = Color.Red;
                rtbDeploymentSummary.AppendText("An error occured when deploying policies. The error message is :" + Environment.NewLine);
                rtbDeploymentSummary.AppendText(ex.Message + Environment.NewLine);
                rtbDeploymentSummary.SelectionColor = rtbDeploymentSummary.ForeColor;
                throw;
            }






        }

        public async void ListCompliancePolicies(DataGridView dataGridView)
        {

            // This method lists all compliance policies in the tenant and displays them in a datagridview

            // Put result into a list for easy processing
            List<DeviceCompliancePolicy> deviceCompliancePolicies = new List<DeviceCompliancePolicy>();


            // Empty the list
            deviceCompliancePolicies.Clear();


            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();


            // Make a call to Microsoft Graph
            var result = await graphClient.DeviceManagement.DeviceCompliancePolicies.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });


            // Adds all the data from the graph query into the list
            deviceCompliancePolicies.AddRange(result.Value);


            // Loop through the list

            foreach (var policy in deviceCompliancePolicies)
            {

                dataGridView.Rows.Add(policy.DisplayName, "Compliance", policy.OdataType, policy.Id);

            }

        }

        public async void ListConfigurationProfiles(DataGridView dataGridView)
        {

            // This method lists all configuration profiles in the tenant and displays them in a datagridview

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();



            var result = await graphClient.DeviceManagement.DeviceConfigurations.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });

            // Put result into a list for easy processing
            List<DeviceConfiguration> deviceConfigurationProfiles = new List<DeviceConfiguration>();


            // Adds all the data from the graph query into the list
            deviceConfigurationProfiles.AddRange(result.Value);


            // Loop through the list

            foreach (var profile in deviceConfigurationProfiles)
            {

                dataGridView.Rows.Add(profile.DisplayName, "Device Configuration", profile.OdataType, profile.Id);

            }

        }

        public async void ListSettingsCatalog(DataGridView dataGridView)
        {
            // This method lists all settings catalog in the tenant and displays them in a datagridview

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            var target = new DeviceManagementConfigurationPolicy
            {

            };


            var result = await graphClient.DeviceManagement.ConfigurationPolicies.GetAsync();
            ;

            // Put result into a list for easy processing
            List<DeviceManagementConfigurationPolicy> configurationPolicies = new List<DeviceManagementConfigurationPolicy>();


            // Adds all the data from the graph query into the list
            configurationPolicies.AddRange(result.Value);


            // Loop through the list

            foreach (var policy in configurationPolicies)
            {

                dataGridView.Rows.Add(policy.Name, "Settings Catalog", policy.Platforms, policy.Id);

            }

        }

        public async void ListAllGroups()
        {
            // This method lists all groups in the tenant and displays them in a datagridview

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            var result = await graphClient.Groups
                .GetAsync();


            List<Group> listAllGroups = new List<Group>();

            listAllGroups.AddRange(result.Value);

            foreach (var group in listAllGroups)
            {
                dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
            }


            // Add All users and all devices virtual groups and IDs to the datagridview

            dtgDisplayGroup.Rows.Add("All Users", form1.allUsersGroupID);
            dtgDisplayGroup.Rows.Add("All Devices", form1.allDevicesGroupID);

        }




        public async void SearchForGroup()
        {

            // This method searches for a group based on the search term entered in the textbox

            var searchquery = txtboxSearchGroup.Text;

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();



            /*
             * Make a call to Microsoft Graph
             * 
             * Note - this could be optimized by searching or filtering 
             * in the query instead of retrieving all policies and 
             * then filtering in the code
             * 
             * As of 13.12.2023 search is not supported
             */


            var result = await graphClient.Groups
                .GetAsync();


            List<Group> listAllGroups = new List<Group>();

            listAllGroups.AddRange(result.Value);

            // add all users and all devices virtual groups to the result
            // this is to ensure that they are included in the search results

            Group AllUsers = new Group
            {
                DisplayName = allUsersGroupName,
                Id = allUsersGroupID
            };

            Group AllDevices = new Group
            {
                DisplayName = allDevicesGroupName,
                Id = allDevicesGroupID
            };


            listAllGroups.Add(AllUsers);
            listAllGroups.Add(AllDevices);

            // Use LINQ to query the result

            var filteredGroups = listAllGroups
                 .Where(group => group.DisplayName.Contains(searchquery, StringComparison.OrdinalIgnoreCase))
                 .ToList();

            // Display message if no results were found
            if (filteredGroups.Count == 0)
            {
                MessageBox.Show("No groups were found containing the word " + searchquery);
            }
            else
            {
                // Display the result in the datagridview

                foreach (var group in filteredGroups)
                {
                    dtgDisplayGroup.Rows.Add(group.DisplayName, group.Id);
                }
            }



        }
        public void HelpGuide()
        {

            // make a message box with yes and no button

            DialogResult result = MessageBox.Show("Do you want a quick tour?", "Quick tour", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {

                // Hides all panels to begin the help guide

                pnlAssignedTo.Visible = false;
                pnlSearchGroup.Visible = false;
                pnlSearchPolicy.Visible = false;
                pnlSummary.Visible = false;
                cbLookUpAssignment.Visible = false;

                // sleep for 2 seconds
                Thread.Sleep(2000);


                MessageBox.Show("Here you can do bulk group assignments for policies");

                pnlSearchPolicy.Visible = true;
                MessageBox.Show("Firstly you need to find and select all policies you want for deployment");

                pnlSearchGroup.Visible = true;
                MessageBox.Show("Then you need to find and select all groups you want to deploy the policies to");


                pnlSummary.Visible = true;
                cbLookUpAssignment.Visible = true;
                MessageBox.Show("Finally you can review the summary and click deploy to deploy the policies to the selected groups");











            }

            else if (result == DialogResult.No)

            {

                // User clicked no, so do nothing

            }


            else

            {
                MessageBox.Show("An error has occured when trying to display the help guide.");
            }

        }


        public async void SearchForSettingsCatalogPolicy()
        {

            // This method searches for a settings catalog policy based on the search term entered in the textbox

            var searchquery = txtboxSearchPolicy.Text;

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            /*
             * Make a call to Microsoft Graph
             * 
             * Note - this could be optimized by searching or filtering 
             * in the query instead of retrieving all policies and 
             * then filtering in the code
             * 
             * As of 12.12.2023 search is not supported
             */

            var result = await graphClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "name", "platforms" };
            });

            // Put result into a list for easy processing
            List<DeviceManagementConfigurationPolicy> settingsCatalogPolicies = new List<DeviceManagementConfigurationPolicy>();

            // Adds all the data from the graph query into the list
            settingsCatalogPolicies.AddRange(result.Value);

            // Use LINQ to filter the list based on the search query

            var filteredPolicies = settingsCatalogPolicies
                 .Where(policy => policy.Name.Contains(searchquery, StringComparison.OrdinalIgnoreCase))
                 .ToList();


            // Display message if no results were found
            if (filteredPolicies.Count == 0)
            {
                MessageBox.Show("No Settings catalog policies were found containing the word " + searchquery);
            }
            else
            {
                // Display the result in the datagridview
                foreach (var policy in filteredPolicies)
                {
                    dtgDisplayPolicy.Rows.Add(policy.Name, "Settings catalog", policy.Platforms, policy.Id);
                }
            }

        }

        public async void SearchForCompliancePolicy()
        {

            // This method searches for a compliance policy based on the search term entered in the textbox

            var searchquery = txtboxSearchPolicy.Text;


            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();



            /*
             * Make a call to Microsoft Graph
             * 
             * Note - this could be optimized by searching or filtering 
             * in the query instead of retrieving all policies and 
             * then filtering in the code
             * 
             * As of 12.12.2023 search is not supported
             */

            var result = await graphClient.DeviceManagement.DeviceCompliancePolicies.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
            });



            // Put result into a list for easy processing
            List<DeviceCompliancePolicy> deviceCompliancePolicies = new List<DeviceCompliancePolicy>();

            // Adds all the data from the graph query into the list
            deviceCompliancePolicies.AddRange(result.Value);


            // Use LINQ to filter the list based on the search query

            var filteredPolicies = deviceCompliancePolicies
                 .Where(policy => policy.DisplayName.Contains(searchquery, StringComparison.OrdinalIgnoreCase))
                 .ToList();

            // Display message if no results were found
            if (filteredPolicies.Count == 0)
            {
                MessageBox.Show("No Compliance policies were found containing the word " + searchquery);
            }
            else
            {
                // Display the result in the datagridview
                foreach (var policy in filteredPolicies)
                {
                    dtgDisplayPolicy.Rows.Add(policy.DisplayName, "Compliance", policy.OdataType, policy.Id);
                }
            }



        }

        public async void SearchForDeviceConfigurationPolicy()
        {

            // This method searches for a device configuration policy (Administrative templates) based on the search term entered in the textbox

            var searchquery = txtboxSearchPolicy.Text;

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();



            /*
             * Make a call to Microsoft Graph
             * 
             * Note - this could be optimized by searching or filtering 
             * in the query instead of retrieving all policies and 
             * then filtering in the code
             * 
             * As of 12.12.2023 search is not supported
             */

            var result = await graphClient.DeviceManagement.DeviceConfigurations.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
                    requestConfiguration.Headers.Add("ConsistencyLevel", "Eventual");
                });

            // Put result into a list for easy processing
            List<DeviceConfiguration> deviceConfigurationProfiles = new List<DeviceConfiguration>();

            // Adds all the data from the graph query into the list
            deviceConfigurationProfiles.AddRange(result.Value);


            // Use LINQ to filter the list based on the search query

            var filteredPolicies = deviceConfigurationProfiles
                 .Where(policy => policy.DisplayName.Contains(searchquery, StringComparison.OrdinalIgnoreCase))
                 .ToList();

            // Display message if no results were found

            if (filteredPolicies.Count == 0)
            {
                MessageBox.Show("No Device Configuration policies were found containing the word " + searchquery);
            }
            else
            {
                // Display the result in the datagridview
                foreach (var policy in filteredPolicies)
                {
                    dtgDisplayPolicy.Rows.Add(policy.DisplayName, "Device Configuration", policy.OdataType, policy.Id);
                }
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
            FormUtilities.ClearDataGridView(dtgDisplayPolicy);


            if (cbPolicyType.Text == "All types")
            {
                ListCompliancePolicies(dtgDisplayPolicy);
                ListConfigurationProfiles(dtgDisplayPolicy);
                ListSettingsCatalog(dtgDisplayPolicy);
            }

            else if (cbPolicyType.Text == "Compliance policy")
            {
                ListCompliancePolicies(dtgDisplayPolicy);
            }

            else if (cbPolicyType.Text == "Administrative templates")
            {
                ListConfigurationProfiles(dtgDisplayPolicy);
            }
            else if (cbPolicyType.Text == "Settings catalog")
            {
                ListSettingsCatalog(dtgDisplayPolicy);
            }


        }

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            // Clear the datagridview for older results
            ClearDataGridView(dtgDisplayGroup);

            SearchForGroup();


        }

        private void btnListAllGroups_Click(object sender, EventArgs e)
        {

            // Create an object of form1 to use it's methods   
            Form1 form1 = new Form1();


            // Clear the datagridview for older results
            // Note - this should not be done in each method, because that would remove all other results
            FormUtilities.ClearDataGridView(dtgDisplayGroup);

            ListAllGroups();

        }

        private void dtgDisplayPolicy_CellClick(object sender, DataGridViewCellEventArgs e)
        {







            if (cbLookUpAssignment.Checked == true)
            {
                pnlAssignedTo.Visible = true;

                if (e.RowIndex == 0)
                {
                    //MessageBox.Show("test");
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
            FormUtilities.ClearRichTextBox(rtbSelectedGroups);
            FormUtilities.ClearRichTextBox(rtbSelectedPolicies);
            pBarDeployProgress.Value = 0;
        }

        private void btnDeployPolicyAssignment_Click(object sender, EventArgs e)
        {
            AssignSelectedPolicies();
        }

        private void pbHelpGuide_Click(object sender, EventArgs e)
        {
            HelpGuide();
        }

        private void btnDeployDescription_Click(object sender, EventArgs e)
        {
            UpdatePolicyDescription();
        }

        private void dtgDisplayPolicy_SelectionChanged(object sender, EventArgs e)
        {
            // This is needed to allow the user to select multiple rows in the datagridview

            // Select the entire selected rows
            foreach (DataGridViewCell cell in dtgDisplayPolicy.SelectedCells)
            {
                dtgDisplayPolicy.Rows[cell.RowIndex].Selected = true;
            }

            // Now, you can access the data of the selected rows if needed
            foreach (DataGridViewRow selectedRow in dtgDisplayPolicy.SelectedRows)
            {
                // ...
            }

        }

        private void pbViewAssignments_Click(object sender, EventArgs e)
        {
            viewManageAssignments();
        }

        private void btnSearchPolicy_Click(object sender, EventArgs e)
        {
            // Check what type of policy is selected in the combobox
            // Then call the appropriate method to search for that policy type

            ClearDataGridView(dtgDisplayPolicy);


            if (cbPolicyType.Text == "All types")
            {

            }

            else if (cbPolicyType.Text == "Compliance policy")
            {
                SearchForCompliancePolicy();
            }

            else if (cbPolicyType.Text == "Administrative templates")
            {
                SearchForDeviceConfigurationPolicy();
            }

            else if (cbPolicyType.Text == "Settings catalog")
            {
                SearchForSettingsCatalogPolicy();
            }



        }

        private void txtboxSearchPolicy_Click(object sender, EventArgs e)
        {
            txtboxSearchPolicy.Clear();
        }

        private void txtboxSearchGroup_Click(object sender, EventArgs e)
        {
            txtboxSearchGroup.Clear();
        }
    }
}
