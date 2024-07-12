using IntuneAssignments.Backend;
using Microsoft.Graph;
using Microsoft.Graph.Beta.DeviceAppManagement.IosLobAppProvisioningConfigurations.Item.Assign;
using Microsoft.Graph.Beta.DeviceManagement.Templates.Item.CreateInstance;

//using Microsoft.Graph.Auth;
using Microsoft.Graph.Beta.Models;
using Microsoft.Kiota.Abstractions;
using System.Reflection;
using static IntuneAssignments.Backend.FormUtilities;
using static IntuneAssignments.Backend.GlobalVariables;
using static IntuneAssignments.Backend.GraphServiceClientCreator;


namespace IntuneAssignments
{
    public partial class Policy : Form
    {

        private readonly Application _form1;
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

            // This method extracts the GroupID part and returns it


            int underscoreIndex = input.IndexOf('_');
            if (underscoreIndex >= 0 && underscoreIndex < input.Length - 1)
            {
                // check if it's all users or all devices


                return input.Substring(underscoreIndex + 1);
            }



            return string.Empty; // Return an empty string if "_" is not found or it's the last character


        }


        public async Task<List<Group>> LookUpGroup(string input)
        {

            // This method looks up a group based on the ID and returns the group name

            // First , check if the input is "All users" or "All devices" virtual group

            if (input == allUsersGroupID)
            {
                return new List<Group> { new Group { DisplayName = "All Users" } };
            }
            else if (input == allDevicesGroupID)
            {
                return new List<Group> { new Group { DisplayName = "All Devices" } };
            }
            else
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
        }

        private async void FindPolicyAssignment(int rowIndex)
        {
            // New method to find all assignments for a policy based on the unique ID of the policy

            var profileName = dtgDisplayPolicy.Rows[rowIndex].Cells[0].Value.ToString();
            var profileType = dtgDisplayPolicy.Rows[rowIndex].Cells[1].Value.ToString();
            var profilePlatform = dtgDisplayPolicy.Rows[rowIndex].Cells[2].Value.ToString();
            var profileID = dtgDisplayPolicy.Rows[rowIndex].Cells[3].Value.ToString();

            if (profileType == "Compliance")
            {
                // If it's a compliance policy

                var result = await GetCompliancePolicyAssignments(profileID);

                if (result.Count == 0)
                {
                    // The list has zero members. Informing user and ending job
                    //MessageBox.Show("No assignment found for " + profileName);

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "";
                    rtbDeploymentSummary.SelectionColor = Color.Yellow;
                    rtbAssignmentPreview.AppendText(profileName + " does not have any assignments" + "\n");
                }

                else if (result.Count >= 1)
                {
                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "is assigned to:"; ;

                    foreach (var assignment in result)
                    {
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

            else if (profileType == "Device Configuration")
            {
                // If it's a device configuration policy

                var result = await GetDeviceConfigurationAssignments(profileID);

                if (result.Count == 0)
                {
                    // The list has zero members. Informing user and ending job

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "";
                    rtbDeploymentSummary.SelectionColor = Color.Yellow;
                    rtbAssignmentPreview.AppendText(profileName + " does not have any assignments" + "\n");
                }

                else if (result.Count >= 1)
                {
                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "is assigned to:"; ;

                    foreach (var assignment in result)
                    {

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

            else if (profileType == "Administrative Templates")
            {
                // If it's an administrative template policy (Called Group Policy Configuration in Graph API)

                var result = await GetADMXTemplateAssignments(profileID);

                if (result.Count == 0)
                {
                    // The list has zero members. Informing user and ending job

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "";
                    rtbDeploymentSummary.SelectionColor = Color.Yellow;
                    rtbAssignmentPreview.AppendText(profileName + " does not have any assignments" + "\n");
                }

                else if (result.Count >= 1)
                {
                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "is assigned to:"; ;

                    foreach (var assignment in result)
                    {

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

            else if (profileType == "Settings Catalog")
            {
                // If it's a settings catalog policy

                var result = await GetSettingsCatalogAssignments(profileID);

                if (result.Count == 0)
                {
                    // The list has zero members. Informing user and ending job

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "";
                    rtbDeploymentSummary.SelectionColor = Color.Yellow;
                    rtbAssignmentPreview.AppendText(profileName + " does not have any assignments" + "\n");
                }

                else if (result.Count >= 1)
                {
                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "is assigned to:";

                    foreach (var assignment in result)
                    {

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

            else if (profileType.Contains("Baseline") || profileType.Contains("baseline"))
            {
                // If it's a security baseline policy

                var result = await GetSecurityBaselineAssignments(profileID);

                if (result.Count == 0)
                {
                    // The list has zero members. Informing user and ending job

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "";
                    rtbDeploymentSummary.SelectionColor = Color.Yellow;
                    rtbAssignmentPreview.AppendText(profileName + " does not have any assignments" + "\n");
                }

                else if (result.Count >= 1)
                {
                    // The list has at least one member. Proceeding with job

                    // Loop through each assignment ID and find group name

                    lblAssignmentPreview.Show();
                    lblAssignmentPreview.Text = profileName;
                    lblAssignedTo.Text = "is assigned to:";

                    foreach (var assignment in result)
                    {
                        GroupAssignmentTarget groupAssignmentTarget = (GroupAssignmentTarget)assignment.Target;

                        var groupID = groupAssignmentTarget.GroupId;

                        // Look up Azure AD groups based on ID

                        List<Group> groups = await LookUpGroup(groupID);
                        foreach (var group in groups)
                        {
                            rtbAssignmentPreview.AppendText(group.DisplayName + "\n");
                        }
                    }
                }
            }

            else
            {
                //something unexpected happened
                rtbDeploymentSummary.SelectionColor = Color.Red;
                rtbDeploymentSummary.AppendText("An error occurred. Please troubleshoot" + "\n");
                rtbDeploymentSummary.SelectionColor = ForeColor;
                WriteToLog("An error occurred when looking up assignments for policy " + profileName + ". Please troubleshoot");
            }
        }

        private async void FindPolicyAssignments(int rowIndex)
        {
            // TODO - phase out this method and use FindPolicyAssignment instead
            // Method that finds all assignments for a policy based on the unique ID of the policy

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
                    string value = dataGridView.Rows[cell.RowIndex].Cells[3].Value?.ToString() ?? string.Empty;

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
            Application form1 = new Application();

            // Load the MS Graph assembly for class lookup
            var assembly = Assembly.Load(form1.graphAssembly);

            var description = txtboxDescription.Text;


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

                                WriteToLog("Description for " + policyName + " has been updated with the following description: " + description.ToString());

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

                                WriteToLog("Description for " + policyName + " has been updated with the following description: " + description.ToString());

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
                            // Consider not supporting device configuration policies for now

                            if (policyType == "Device Configuration")
                            {
                                // Not implemented yet

                                // Create a new device configuration object

                                WriteToLog("Device configuration policies are not supported yet. No changes have been made to " + policyName);

                                // Write to the textbox in yellow color to indicate that this is not supported yet
                                rtbDeploymentSummary.SelectionColor = Color.Yellow;


                                rtbDeploymentSummary.AppendText("Administrative templates are not supported yet. No changes have been made to " + policyName + Environment.NewLine);

                            }

                            if (policyType.Contains("Baseline") || policyType.Contains("baseline"))
                            {
                                var requestBody = new DeviceManagementIntent
                                {
                                    Description = txtboxDescription.Text
                                };

                                // Update the description
                                var result = await graphClient.DeviceManagement.Intents[policyID].PatchAsync(requestBody);

                                WriteToLog("Description for " + policyName + " has been updated with the following description: " + description.ToString());

                                // write to the textbox
                                rtbDeploymentSummary.SelectionColor = Color.Green;
                                rtbDeploymentSummary.AppendText("Description for " + policyName + " has been updated" + Environment.NewLine);

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



        async Task AssignSecurityBaseline(string policyID, string groupID)
        {
            // This methods assigns a security baseline to one or more groups

            // Important - this flow is incomplete. Must add check if the assignment already exists, because that will break




            // The policy ID and group ID are passed as parameters to this method and used to create the assignment

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            // Create a group assignment target object
            var groupAssignmentTarget = new GroupAssignmentTarget
            {
                GroupId = groupID
                //DeviceAndAppManagementAssignmentFilterId = policyID

            };

            // Create a security baseline assignment object
            var deviceSecurityBaselineAssignmentTarget = new DeviceManagementIntentAssignment
            {

                Target = groupAssignmentTarget

            };

            // Create an array to store all group IDs
            // Add the new group ID to the array, which is passed into this method as a parameter
            // Existing group IDs are added to this array later in the code
            string[] groupIDs = { groupID };



            // Find all existing assignments by their group ID
            var existingAssignments = await graphClient.DeviceManagement.Intents[policyID].Assignments.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "target" };
            });


            // Create an empty list to store the assignments
            List<DeviceManagementIntentAssignment> assignments = new List<DeviceManagementIntentAssignment>();

            // Check if there are any existing assignments



            if (existingAssignments.Value.Count >= 1)
            {
                // Add existing assignments to the list for further processing
                foreach (var assignment in existingAssignments.Value)
                {
                    // check if the assignment is already in the list
                    // if it is, don't add it again

                    GroupAssignmentTarget target = (GroupAssignmentTarget)assignment.Target;


                    if (target.GroupId != groupAssignmentTarget.GroupId)
                    {
                        assignments.Add(assignment);
                    }
                }
            }


            // Loop through each group ID and create an assignment object for each one
            foreach (var group in groupIDs)
            {
                var newAssignment = new DeviceManagementIntentAssignment
                {
                    OdataType = "#microsoft.graph.deviceManagementIntentAssignment",
                    Id = group,
                    Target = new GroupAssignmentTarget
                    {
                        OdataType = "#microsoft.graph.groupAssignmentTarget",
                        GroupId = group,
                    },
                };

                // check if the assignment is already in the list
                // if it is, don't add it again
                if (!assignments.Contains(newAssignment))
                {
                    // Add each assignment to the list of assignments
                    assignments.Add(newAssignment);
                }

            }


            // find duplicates and remove them


            // Create a request body object and add all assignment objects to it
            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.Intents.Item.Assign.AssignPostRequestBody
            {
                Assignments = assignments
            };


            // Create a new assignment
            try
            {
                await graphClient.DeviceManagement.Intents[policyID].Assign.PostAsync(requestBody);
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }
        async Task AssignADMXTemplate(string policyID, string groupID)
        {
            // This methods assigns an administrative template to one or more groups

            // The policy ID and group ID are passed as parameters to this method and used to create the assignment

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            // Create a group assignment target object
            var groupAssignmentTarget = new GroupAssignmentTarget
            {
                GroupId = groupID
                //DeviceAndAppManagementAssignmentFilterId = policyID

            };

            // Create an administrative template assignment object

            var deviceADMXGroupAssignmentTarget = new GroupPolicyConfigurationAssignment
            {

                Target = groupAssignmentTarget,

            };

            // Create an array to store all group IDs
            // Add the new group ID to the array, which is passed into this method as a parameter
            // Existing group IDs are added to this array later in the code
            string[] groupIDs = { groupID };

            // create a list for temporarily storing existing group IDs for further processing

            List<GroupPolicyConfigurationAssignment> groupIDList = new List<GroupPolicyConfigurationAssignment>();

            // Find all existing assignments by their group ID
            var existingAssignments = await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID]
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
                int underscoreIndex = group.Id.IndexOf('_');

                if (underscoreIndex >= 0 && underscoreIndex < group.Id.Length - 1)
                {
                    string extractedText = group.Id.Substring(underscoreIndex + 1);

                    // check if the assignment is already in the list
                    // if it is, don't add it again
                    if (!groupIDs.Contains(extractedText))
                    {
                        Array.Resize(ref groupIDs, groupIDs.Length + 1);
                        groupIDs[groupIDs.Length - 1] = extractedText;
                    }

                    //Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    //groupIDs[groupIDs.Length - 1] = extractedText;
                }
            }

            // Create an empty list to store the assignments
            List<GroupPolicyConfigurationAssignment> assignments = new List<GroupPolicyConfigurationAssignment>();

            // Loop through each group ID and create an assignment object for each one

            foreach (var group in groupIDs)
            {
                var assignment = new GroupPolicyConfigurationAssignment
                {
                    OdataType = "#microsoft.graph.groupPolicyConfigurationAssignment",
                    Id = group,
                    Target = new GroupAssignmentTarget
                    {
                        OdataType = "microsoft.graph.groupAssignmentTarget",
                        GroupId = group
                    }
                };



                // Add each assignment object to the list of assignments
                assignments.Add(assignment);
            }


            // Create a request body object and add all assignment objects to it
            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.GroupPolicyConfigurations.Item.Assign.AssignPostRequestBody
            {
                Assignments = assignments
            };

            // Create a new assignment


            try
            {
                var result = await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assign.PostAsync(requestBody);
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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

                    // check if the assignment is already in the list
                    // if it is, don't add it again
                    if (!groupIDs.Contains(extractedText))
                    {
                        Array.Resize(ref groupIDs, groupIDs.Length + 1);
                        groupIDs[groupIDs.Length - 1] = extractedText;
                    }


                    // Add each existing assignment to the array of assignments to ensure that they are not overwritten and deleted
                    //Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    //groupIDs[groupIDs.Length - 1] = extractedText;
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


                    // check if the assignment is already in the list
                    // if it is, don't add it again
                    if (!groupIDs.Contains(extractedText))
                    {
                        Array.Resize(ref groupIDs, groupIDs.Length + 1);
                        groupIDs[groupIDs.Length - 1] = extractedText;
                    }

                    // Add each existing assignment to the array of assignments

                    //Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    //groupIDs[groupIDs.Length - 1] = extractedText;
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

                    // check if the assignment is already in the list
                    // if it is, don't add it again
                    if (!groupIDs.Contains(extractedText))
                    {
                        Array.Resize(ref groupIDs, groupIDs.Length + 1);
                        groupIDs[groupIDs.Length - 1] = extractedText;
                    }

                    // Add each existing assignment to the array of assignments to ensure that they are not overwritten and deleted
                    //Array.Resize(ref groupIDs, groupIDs.Length + 1);
                    //groupIDs[groupIDs.Length - 1] = extractedText;



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

            WriteToLog("Preparing to assign policies to groups");

            // Gather the values from the selected policies and selected groups



            Dictionary<string, List<string>> SelectedPolicies = GetSelectedPolicies(dtgDisplayPolicy);
            Dictionary<string, string> SelectedGroups = GetSelectedGroups(dtgDisplayGroup);


            // Create an object of form1 to use it's methods   
            Application form1 = new Application();


            // Sets the scope of the progress bar to the number of selected policies * number of selected groups

            int numberOfPolicies = SelectedPolicies.Count();
            int numberOfGroups = SelectedGroups.Count();
            int progressBarMaxValue = numberOfPolicies * numberOfGroups;
            pBarDeployProgress.Maximum = progressBarMaxValue;

            WriteToLog("A total of " + numberOfPolicies + " policies will be assigned to " + numberOfGroups + " groups.");

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


                                    // Log status to the logfile
                                    WriteToLog(policy + " has been assigned to " + group.Key);

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

                                    // Log status to the logfile
                                    WriteToLog(policy + " has been assigned to " + group.Key);

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

                                    // Log status to the logfile
                                    WriteToLog(policy + " has been assigned to " + group.Key);

                                    // Log status to the textbox
                                    rtbDeploymentSummary.ForeColor = Color.Green;
                                    rtbDeploymentSummary.AppendText(policy + " has been assigned to " + group.Key + Environment.NewLine);
                                    pBarDeployProgress.Value++;
                                    rtbDeploymentSummary.ForeColor = defaultColor;
                                }
                            }

                            // Assignments for Administrative Templates
                            if (type == "Administrative Templates")
                            {

                                // Loop through each selected group and assign the policy to each group
                                foreach (var group in SelectedGroups)
                                {

                                    string groupName = group.Key;
                                    string groupID = group.Value;

                                    // Assignment for Administrative Templates
                                    await AssignADMXTemplate(policyID, groupID);

                                    // Log status to the logfile
                                    WriteToLog(policy + " has been assigned to " + group.Key);

                                    // Log status to the textbox
                                    rtbDeploymentSummary.ForeColor = Color.Green;
                                    rtbDeploymentSummary.AppendText(policy + " has been assigned to " + group.Key + Environment.NewLine);
                                    pBarDeployProgress.Value++;
                                    rtbDeploymentSummary.ForeColor = defaultColor;

                                }
                            }

                            // Assignments for Security Baselines
                            if (type.Contains("Baseline") || type.Contains("baseline"))
                            {
                                // Loop through each selected group and assign the policy to each group
                                foreach (var group in SelectedGroups)
                                {

                                    string groupName = group.Key;
                                    string groupID = group.Value;

                                    // Assignment for Security Baselines
                                    await AssignSecurityBaseline(policyID, groupID);

                                    // Log status to the logfile
                                    WriteToLog(policy + " has been assigned to " + group.Key);

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

                // Log status to the logfile
                WriteToLog("An error occurred during deployment. The error message is: ");
                WriteToLog(ex.Message);

                // Log error to the textbox
                rtbDeploymentSummary.SelectionColor = Color.Red;
                rtbDeploymentSummary.AppendText("An error occured when deploying policies. The error message is :" + Environment.NewLine);
                rtbDeploymentSummary.AppendText(ex.Message + Environment.NewLine);
                rtbDeploymentSummary.SelectionColor = rtbDeploymentSummary.ForeColor;
                pBarDeployProgress.Value++;
                //throw;
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
            Application form1 = new Application();

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

        public async void ListADMXTemplates(DataGridView dataGridView)
        {
            // This method lists all ADMX templates (called groupPolicyConfigurations in Graph API) in the tenant and displays them in a datagridview

            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            // Make a call to Microsoft Graph
            var result = await graphClient.DeviceManagement.GroupPolicyConfigurations.GetAsync();

            // Put result into a list for easy processing
            List<GroupPolicyConfiguration> groupPolicyConfigurations = new List<GroupPolicyConfiguration>();

            groupPolicyConfigurations.AddRange(result.Value);
            foreach (var policy in groupPolicyConfigurations)
            {
                dataGridView.Rows.Add(policy.DisplayName, "Administrative Templates", "Windows", policy.Id);
            }
        }

        public async void ListSecurityBaselines(DataGridView dataGridView)
        {
            /* 
             * This method lists all security baselines in the tenant and displays them in a datagridview
             * 
             * Note - Security baselines in this context is:
             * - Windows 10 security baselines
             * - Microsoft Defender for Endpoint security baselines
             * - Windows 365 security baselines
             * 
             * M365 and Edge are not included in this method because their backend is the Settings Catalog framework
            */


            // Authenticate to Graph

            var graphClient = CreateGraphServiceClient();

            // Make a call to Microsoft Graph

            var result = await graphClient.DeviceManagement.Intents.GetAsync();

            // Put result into a list for easy processing

            List<DeviceManagementIntent> securityBaselines = new List<DeviceManagementIntent>();

            securityBaselines.AddRange(result.Value);

            foreach (var intent in securityBaselines)
            {
                // Lookup templateID and translate to template friendly name

                var templateID = intent.TemplateId;
                var templateName = await GetTemplateDisplayNameFromTemplateID(templateID);
                var templatePlatform = await GetTemplatePlatformFromTemplateID(templateID);

                dataGridView.Rows.Add(intent.DisplayName, templateName, templatePlatform, intent.Id);
            }
        }

        public async void ListAllGroups()
        {
            /*
             * 02.02.2024
             * This method has been replace by SearchForGroupV2 in FormUtilities.cs
             * The new method is more efficient and is shared across the entire application
             * This method is kept for reference and will be deleted in the future
             */

            // This method lists all groups in the tenant and displays them in a datagridview



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

            dtgDisplayGroup.Rows.Add("All Users", allUsersGroupID);
            dtgDisplayGroup.Rows.Add("All Devices", allDevicesGroupID);

        }

        public async void SearchForGroup()
        {

            /*
             * 02.02.2024
             * This method has been replace by SearchForGroupV2 in FormUtilities.cs
             * The new method is more efficient and is shared across the entire application
             * This method is kept for reference and will be deleted in the future
             */

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

            /*
             * 
             * Method that lists policies based on the selected policy 
             * 
             */

            WriteToLog("User clicked the List All Policies button");

            // Clear the datagridview for older results
            FormUtilities.ClearDataGridView(dtgDisplayPolicy);


            if (cbPolicyType.Text == "All types")
            {

                WriteToLog("User selected All types in the policy type combobox. Listing all policies");

                ListCompliancePolicies(dtgDisplayPolicy);
                ListConfigurationProfiles(dtgDisplayPolicy);
                ListSettingsCatalog(dtgDisplayPolicy);
                ListADMXTemplates(dtgDisplayPolicy);
                ListSecurityBaselines(dtgDisplayPolicy);
            }

            else if (cbPolicyType.Text == "Compliance policy")
            {
                WriteToLog("User selected Compliance policy in the policy type combobox. Listing only compliance policies");

                ListCompliancePolicies(dtgDisplayPolicy);
            }

            else if (cbPolicyType.Text == "Administrative templates")
            {
                WriteToLog("User selected Administrative templates in the policy type combobox. Listing only device configuration policies");

                ListADMXTemplates(dtgDisplayPolicy);
                ListConfigurationProfiles(dtgDisplayPolicy);
            }
            else if (cbPolicyType.Text == "Settings catalog")
            {
                WriteToLog("User selected Settings catalog in the policy type combobox. Listing only settings catalog policies");

                ListSettingsCatalog(dtgDisplayPolicy);
            }
            else if (cbPolicyType.Text == "Security baseline")
            {
                WriteToLog("User selected Security Baselines in the policy type combobox. Listing only security baselines");

                ListSecurityBaselines(dtgDisplayPolicy);
            }


        }

        private async void btnSearchGroup_Click(object sender, EventArgs e)
        {

            /*
             * Method that searches for groups based on the search term entered in the textbox
             * 
             */
            var searchquery = txtboxSearchGroup.Text;

            WriteToLog("User clicked the Search Group button and is searching for " + searchquery);

            // Clear the datagridview for older results
            ClearDataGridView(dtgDisplayGroup);



            if (string.IsNullOrWhiteSpace(searchquery) || searchquery == "" || searchquery == "Enter search here")
            {
                WriteToLog("User entered an invalid search query. The search query was " + searchquery);
                MessageBox.Show("Invalid search query. Please try again");

            }
            else
            {
                await Task.Run(() => SearchForGroupV2(searchquery, dtgDisplayGroup));
            }



            //SearchForGroup();


        }

        private async void btnListAllGroups_Click(object sender, EventArgs e)
        {
            /*
             * Method that lists all groups in the tenant
             * 
             * 
             */

            // Clear the datagridview for older results

            FormUtilities.ClearDataGridView(dtgDisplayGroup);


            WriteToLog("User clicked the List All Groups button");

            await Task.Run(() => ListAllGroupsV2(dtgDisplayGroup));

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
                    FindPolicyAssignment(e.RowIndex);
                }
            }

            else
            {

            }

        }

        private void btnPrepareDeployment_Click(object sender, EventArgs e)
        {
            /*
             * This method prepares the deployment of policies to groups
             * 
             */

            WriteToLog("User clicked the Prepare Deployment button");

            PreparePolicyDeployment();
        }

        private void btnResetDeployment_Click(object sender, EventArgs e)
        {
            /*
             * This method resets the deployment of policies to groups by
             * clearing the selected groups and policies and 
             * resetting the progress bar
             */

            WriteToLog("User clicked the Reset Deployment button");

            FormUtilities.ClearRichTextBox(rtbSelectedGroups);
            FormUtilities.ClearRichTextBox(rtbSelectedPolicies);
            pBarDeployProgress.Value = 0;
        }

        private async void btnDeployPolicyAssignment_Click(object sender, EventArgs e)
        {
            WriteToLog("User clicked the Deploy button");
            pBarDeployProgress.Value = 0;
            await AssignSelectedPolicies();
        }

        private void pbHelpGuide_Click(object sender, EventArgs e)
        {
            HelpGuide();
        }

        private void btnDeployDescription_Click(object sender, EventArgs e)
        {
            WriteToLog("User clicked the Deploy Description button");

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
            /*
             *
             * Method that searches for policies based on the selected policy type
             * Check what type of policy is selected in the combobox
             * Then call the appropriate method to search for that policy type
             * 
             */

            WriteToLog("User clicked the Search Policy button");


            ClearDataGridView(dtgDisplayPolicy);


            if (cbPolicyType.Text == "All types")
            {
                WriteToLog("User selected All types in the policy type combobox. Searching for all policies");
                SearchForCompliancePolicy();
                SearchForDeviceConfigurationPolicy();
                SearchForSettingsCatalogPolicy();

            }

            else if (cbPolicyType.Text == "Compliance policy")
            {
                WriteToLog("User selected Compliance policy in the policy type combobox. Searching for compliance policies");

                SearchForCompliancePolicy();
            }

            else if (cbPolicyType.Text == "Administrative templates")
            {
                WriteToLog("User selected Administrative templates in the policy type combobox. Searching for device configuration policies");

                SearchForDeviceConfigurationPolicy();
            }

            else if (cbPolicyType.Text == "Settings catalog")
            {
                WriteToLog("User selected Settings catalog in the policy type combobox. Searching for settings catalog policies");

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

        private void txtboxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ResetProgressBar_Click(object sender, EventArgs e)
        {
            pBarDeployProgress.Value = 0;
            rtbDeploymentSummary.Clear();
        }

        private void copyCellContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dtgDisplayPolicy.CurrentCell.RowIndex;
            int columnindex = dtgDisplayPolicy.CurrentCell.ColumnIndex;
            CopyDataGridViewCellContent(rowindex, columnindex, dtgDisplayPolicy);
        }

        private void copyCellContentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int rowindex = dtgDisplayGroup.CurrentCell.RowIndex;
            int columnindex = dtgDisplayGroup.CurrentCell.ColumnIndex;
            CopyDataGridViewCellContent(rowindex, columnindex, dtgDisplayGroup);
        }
    }
}
