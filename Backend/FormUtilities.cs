using Microsoft.Graph.Beta.Models;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.GlobalVariables;

namespace IntuneAssignments.Backend
{
    public class FormUtilities
    {
        // This class will contain methods that are used by multiple forms to reduce code duplication and improve maintainability of the codebase as a whole.

        // All members must be static so that they can be called from other classes without instantiating an object of this class

        public static void ClearRichTextBox(RichTextBox richTextBox)
        {

            richTextBox.Clear();

        }

        public static void ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static void ClearCheckedListBox(CheckedListBox checkedListBox)
        {

            checkedListBox.Items.Clear();

        }

        public static void PurgeLogFileContent()
        {

            // This method will be used to purge the content of the log file

            File.WriteAllText(MainLogFile, string.Empty);

        }

        public static void WriteSystemSummaryToLog()
        {
            // This method will be used to write a summary of the system to the log file

            // Create a new instance of the StreamWriter class
            StreamWriter sw = new StreamWriter(primaryLogFile, true);

            // Write the data to the log file
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Beginning system summary");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The running system is {Environment.OSVersion} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The running system hostname is  {Environment.MachineName} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The running user is {Environment.UserName} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The executing assembly version is {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The executing assembly location is {System.Reflection.Assembly.GetExecutingAssembly().Location} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The executing assembly name is {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The .NET Runtime Version is {Environment.Version} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Finished system summary");


            // Close the StreamWriter instance
            sw.Close();
        }

        public static void WriteToLog(string data)
        {

            // This method will be used to log data to the main log file


            // Read the last ten lines from the log file
            List<string> lastTenLines = ReadLastLines(primaryLogFile, 5);

            // Check if any of the last ten lines are identical to the new data
            if (lastTenLines.Any(line => line.Contains(data)))
            {
                // If duplicate found, you may choose to handle it as needed
                //MessageBox.Show($"Duplicate entry: {data}");
                return; // Optionally, you can exit the method to avoid writing the duplicate
            }



            // Use the using statement to ensure proper disposal of StreamWriter
            using (StreamWriter sw = new StreamWriter(primaryLogFile, true))
            {
                // Write the data to the log file
                sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {data}");
            }
            // StreamWriter is automatically closed and disposed of when leaving the using block

        }



        public static List<string> ReadLastLines(string filePath, int lineCount)
        {
            List<string> lastLines = new List<string>();

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                // Read all lines from the file and keep the last N lines
                LinkedList<string> lines = new LinkedList<string>();
                while (!reader.EndOfStream)
                {
                    lines.AddLast(reader.ReadLine());
                    if (lines.Count > lineCount)
                    {
                        lines.RemoveFirst();
                    }
                }

                lastLines.AddRange(lines);
            }

            return lastLines;
        }




        public static async Task<int> countGroupMembers(string groupID)
        {
            // Method to count the number of members in a group



            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            var groupMemberCount = await graphClient.Groups[groupID].Members.Count.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
            });




            var groupMemberCountInt = Convert.ToInt32(groupMemberCount);



            return groupMemberCountInt;
        }


        public static async Task SearchForGroupV2(string groupName, DataGridView dataGridView)
        {

            // This method will be used to search for a group in the tenant and display the results in a datagridview


            // Authenticate to Graph
            var graphClient = CreateGraphServiceClient();

            // Look up the group by display name
            var result = await graphClient.Groups.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Search = "\"displayName:" + groupName + "\"";
                requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
            });


            if (result.Value.Capacity == 0)
            {
                // No groups found
                WriteToLog("No groups found with the name " + groupName);
                MessageBox.Show("No groups found with the name " + groupName);

            }

            else if (result.Value.Count != null)
            {

                // Create a new list to store the groups in
                List<Group> groups = new List<Group>();

                // Add the groups to the list
                groups.AddRange(result.Value);

                // Add the groups to the datagridview
                foreach (var group in groups)
                {
                    // Get the number of members in the group
                    var memberCount = await Task.Run(async () => countGroupMembers(group.Id).Result.ToString());

                    // Get the group type
                    var groupType = FormUtilities.groupType(group);


                    dataGridView.Invoke(new Action(() => dataGridView.Rows.Add(group.DisplayName, memberCount, groupType, group.Id)));
                    WriteToLog("Adding group " + group.DisplayName + " to view");
                }

            }
            else
            {
                // Some error occured
                WriteToLog("An error occured while searching for group " + groupName);
                WriteToLog("Please troubleshoot");
            }




        }

        public static string groupType(Group group)
        {
            // Method to determine what group type the group is
            // Static, dynamic user or dynamic device

            string groupType = "Unknown";


            if (group.MembershipRule == null)
            {
                groupType = "Static";
                return groupType;

            }

            else if (group.MembershipRule.StartsWith("(user."))

            {
                groupType = "Dynamic User";
                return groupType;
            }

            else if (group.MembershipRule.StartsWith("(device."))

            {
                groupType = "Dynamic Device";
                return groupType;
            }
            else
            {
                return groupType;
            }


        }

        public static async Task ListAllGroupsV2(DataGridView dataGridView)
        {



            // This method lists all groups in the tenant and displays them in a datagridview

            // Authenticate to Graph
            var allGroups = await getAllEntraGroups();


            foreach (var group in allGroups)
            {
                // Get the number of members in the group
                var memberCount = await Task.Run(async () => countGroupMembers(group.Id).Result.ToString());

                // Get the group type
                var groupType = FormUtilities.groupType(group);

                if (memberCount != null)
                {

                    // Add the groups to the datagridview with all information available
                    dataGridView.Invoke(new Action(() => dataGridView.Rows.Add(group.DisplayName, memberCount, groupType, group.Id)));



                    WriteToLog("Adding group " + group.DisplayName + " to view");

                }
                else if (memberCount == null)
                {


                }
                // Sjekk siste fra chatGPT - 
            }


            // Add All users and all devices virtual groups and IDs to the datagridview

            dataGridView.Invoke(new Action(() =>
            {
                dataGridView.Rows.Add("All Users", "N/A", "N/A", allUsersGroupID);
                WriteToLog("Adding group " + allUsersGroupName + " to view");

                dataGridView.Rows.Add("All Devices", "N/A", "N/A", allDevicesGroupID);
                WriteToLog("Adding group " + allDevicesGroupName + " to view");
            }));






        }

        // Method to check memberShipRule property of a group and determine if the group is dynamic or static



        public static async Task<List<Group>> getAllEntraGroups()
        {

            WriteToLog("Attempting to list all Entra groups");

            /*
             * Method to look up groups in Entra ID
             * 
             * TO DO
             * 
             * Replace other methods that look up groups in the Entra ID with this method
             * 
             */


            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();


            // Look up all groups in Entra ID and retrieve only the id, memberShipRule and displayName properties of the groups 

            var result = await graphClient.Groups.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
                // requestConfiguration.QueryParameters.Select = new string[] { "id", "memberShipRule", "displayName", "members" };
            });





            // Create a new list to store the groups in
            List<Group> entraGroups = new List<Group>();


            // Add the groups to the list
            entraGroups.AddRange(result.Value);

            return entraGroups;

        }


        public static async Task<List<DirectoryObject>> getGroupMembersFromGroup(string groupID)
        {

            // Method to look up group membership in the Entra ID



            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Look up all members of the group
            var result = await graphClient.Groups[groupID].Members.GetAsync();

            // Create list

            List<DirectoryObject> groupMembers = new List<DirectoryObject>();

            // Add to list

            groupMembers.AddRange(result.Value);

            // check odata type foreach member

            return groupMembers;

        }


        // Method to process list of group members and sort into users and devices


        public static void sortGroupMembers(DirectoryObject groupMember)
        {

            // Create lists to store users and devices in








        }




        // may need to delete this later:

        public static async Task<List<Device>> getEntraGroupMembership(string groupID)
        {
            // Method to look up group membership in the Entra ID

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();


            // Look up all members of the group and retrieve only the id, displayName
            // Use OData casts to specify the type of the object to be returned
            // https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/dev/docs/upgrade-to-v5.md#support-for-odata-casts-in-request-builders


            var result = await graphClient.Groups[groupID].Members.GraphDevice.GetAsync(); //OData cast to GraphDevice



            // create a new list to store the group members in

            List<Device> groupMembers = new List<Device>();

            // Add the group members to the list

            groupMembers.AddRange(result.Value);

            foreach (var member in groupMembers)
            {
                MessageBox.Show(member.DisplayName);
            }

            return groupMembers;

        }


        public static async Task<string> FindGroupNameFromGroupID(string groupID)
        {
            // Method to look up the group name from the group ID
            // Must pass in the group ID

            if (groupID == allUsersGroupID)
            {
                return allUsersGroupName;
            }

            else if (groupID == allDevicesGroupID)
            {
                return allDevicesGroupName;
            }

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            try
            {
                // Look up the group by the ID
                var group = await graphClient.Groups[groupID].GetAsync();

                // check if the group is null
                if (group == null)
                {
                    WriteToLog("No group found with ID" + groupID);
                    return "Group not found";
                }

                else
                {
                    string groupName = group.DisplayName;

                    return groupName;
                }


            }
            catch (Exception ex)
            {
                WriteToLog("An error occured while looking up group name from group ID. The error message is: ");
                WriteToLog(ex.Message);

                return "ERROR LOOKING UP GROUP NAME FROM GROUP ID";
                throw;
            }


        }

        public static async Task<string> FindGroupNameFromAppAssignmentID(string applicationID, string assignmentID)
        {
            // Method to look up the group name from the application assignment ID
            // Must pass in application ID and assignment ID

            // Create a new instance of the GraphServiceClient class

            var graphClient = CreateGraphServiceClient();

            // Check if the ID is All Users og All Devices

            if (assignmentID.StartsWith("acacac"))
            {
                WriteToLog("Group name is All Users (virtual group)");
                return allUsersGroupName;
            }

            else if (assignmentID.StartsWith("adadad"))
            {
                WriteToLog("Group name is All Devices (virtual group)");
                return allDevicesGroupName;
            }

            else
            {
                // Convert the assignment ID to the group ID
                var id = assignmentID.Substring(0, assignmentID.Length - 4);


                // Look up the group by the ID

                string groupName = await FindGroupNameFromGroupID(id);

                if (groupName == "ERROR LOOKING UP GROUP NAME FROM GROUP ID")
                {

                    return "ERROR LOOKING UP GROUP NAME FROM GROUP ID";
                }

                WriteToLog("Group name is " + groupName);

                return groupName;
            }
        }

        public static string GetGroupIDFromAssignmentID(string assignmentID)
        {
            /* Method to get the group ID from the an assignment ID

            The assignment ID consists of the ID of the policy or application followed by an underscore and the ID of the group

            Example: 12345678_ababab

            Where 12345678 is the ID of the policy or application and ababab is the ID of the group
             
            It is often useful to extract the group ID from the assignment ID and look up the group by the ID to get the group name

            */



            if (assignmentID.Contains(allUsersGroupID))
            {
                WriteToLog("Group name is All Users (virtual group)");
                return allUsersGroupID;
            }

            else if (assignmentID.Contains(allDevicesGroupID))
            {
                WriteToLog("Group name is All Devices (virtual group)");
                return allDevicesGroupID;
            }

            else
            {

                int underscoreIndex = assignmentID.IndexOf('_');
                if (underscoreIndex != -1 && underscoreIndex < assignmentID.Length - 1)
                {
                    return assignmentID.Substring(underscoreIndex + 1);
                }
                else
                {
                    return "ERROR GETTING GROUP ID FROM ASSIGNMENT ID";
                }
            }

        }

        public static async Task<string> GetTemplatePlatformFromTemplateID(string templateID)
        {
            // Method to get the template platform from the template ID

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Look up the template by the ID
            var template = await graphClient.DeviceManagement.Templates[templateID].GetAsync();

            // Check if the template is null
            if (template == null)
            {
                WriteToLog("No security baseline template found with ID " + templateID);
                return "";
            }

            else
            {
                string templatePlatform = template.PlatformType.ToString();

                return templatePlatform;
            }
        }

        public static async Task<string> GetTemplateDisplayNameFromTemplateID(string templateID)
        {
            // Method to get the template display name from the template ID

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Look up the template by the ID
            var template = await graphClient.DeviceManagement.Templates[templateID].GetAsync();

            // Check if the template is null
            if (template == null)
            {
                WriteToLog("No security baseline template found with ID " + templateID);
                return "";
            }

            else
            {
                string templateDisplayName = template.DisplayName;

                return templateDisplayName;
            }
        }

        public static async Task<List<DeviceCompliancePolicyAssignment>> GetCompliancePolicyAssignments(string policyID)
        {
            // Method to get all assignments for a compliance policy

            // Create a new instance of the GraphServiceClient class

            var graphClient = CreateGraphServiceClient();

            // Look up the policy by the ID

            var policy = await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assignments.GetAsync();

            // Create a list to store the policy assignments in

            List<DeviceCompliancePolicyAssignment> policyAssignments = new List<DeviceCompliancePolicyAssignment>();

            // Add to list

            policyAssignments.AddRange(policy.Value);

            // Return the list
            return policyAssignments;

        }

        public static async Task<List<DeviceConfigurationAssignment>> GetDeviceConfigurationAssignments(string policyID)
        {
            // Method to get all assignments for a device configuration policy

            // Create a new instance of the GraphServiceClient class

            var graphClient = CreateGraphServiceClient();

            // Look up the policy by the ID

            var policy = await graphClient.DeviceManagement.DeviceConfigurations[policyID].Assignments.GetAsync();

            // Create a list to store the policy assignments in

            List<DeviceConfigurationAssignment> policyAssignments = new List<DeviceConfigurationAssignment>();

            // Add to list

            policyAssignments.AddRange(policy.Value);

            // Return the list

            return policyAssignments;
        }

        public static async Task<List<GroupPolicyConfigurationAssignment>> GetADMXTemplateAssignments(string policyID)
        {
            // Method to get all assignments for an ADMX template (called Group Policy Configuration in the Graph API)

            // Create a new instance of the GraphServiceClient class

            var graphClient = CreateGraphServiceClient();

            // Look up the policy by the ID

            var policy = await graphClient.DeviceManagement.GroupPolicyConfigurations[policyID].Assignments.GetAsync();

            // Create a list to store the policy assignments in

            List<GroupPolicyConfigurationAssignment> policyAssignments = new List<GroupPolicyConfigurationAssignment>();

            // Add to list

            policyAssignments.AddRange(policy.Value);

            // Return the list

            return policyAssignments;
        }

        public static async Task<List<DeviceManagementConfigurationPolicyAssignment>> GetSettingsCatalogAssignments(string policyID)
        {
            // Method to get all assignments for a settings catalog policy

            // Create a new instance of the GraphServiceClient class

            var graphClient = CreateGraphServiceClient();

            // Look up the policy by the ID

            var policy = await graphClient.DeviceManagement.ConfigurationPolicies[policyID].Assignments.GetAsync();

            // Create a list to store the policy assignments in

            List<DeviceManagementConfigurationPolicyAssignment> policyAssignments = new List<DeviceManagementConfigurationPolicyAssignment>();

            // Add to list

            policyAssignments.AddRange(policy.Value);

            // Return the list

            return policyAssignments;
        }

        public static async Task<List<DeviceManagementIntentAssignment>> GetSecurityBaselineAssignments(string policyID)
        {
            // Method to get all assignments for a security baseline policy
            var graphClient = CreateGraphServiceClient();

            // Look up the policy by the ID

            var policy = await graphClient.DeviceManagement.Intents[policyID].Assignments.GetAsync();

            // Create a list to store the policy assignments in

            List<DeviceManagementIntentAssignment> policyAssignments = new List<DeviceManagementIntentAssignment>();


            // Add to list

            policyAssignments.AddRange(policy.Value);

            return policyAssignments;
        }

        public void CheckIfGUID(string input)
        {
            // Method to check if a string is a valid GUID

            if (Guid.TryParse(input, out Guid result))
            {
                WriteToLog("The string is a valid GUID");
            }
            else
            {
                WriteToLog("The string is not a valid GUID");
            }
        }
    }
}
