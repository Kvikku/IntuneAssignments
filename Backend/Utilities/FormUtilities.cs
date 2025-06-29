﻿using IntuneAssignments.Presentation.Import;
using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.DeviceManagement.ConfigurationPolicies.Item.Assign;
using Microsoft.Graph.Beta.DeviceManagement.DeviceCompliancePolicies.Item.Assign;
using Microsoft.Graph.Beta.DeviceManagement.Intents.Item.Assign;
using Microsoft.Graph.Beta.Models;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Windows.ApplicationModel.Activation;
using static IntuneAssignments.Backend.GraphServiceClientCreator;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Backend.Utilities
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

        public static void ClearSelectedDataGridViewRow(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(row.Index);
            }
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

        public static void CopyDataGridViewCellContent(int rowIndex, int columnIndex, DataGridView dataGridView)
        {
            // Check if the rowIndex and columnIndex are within the valid range
            if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count &&
                columnIndex >= 0 && columnIndex < dataGridView.Columns.Count)
            {
                // Get the value of the specified cell
                object cellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Copy the cell value to the clipboard
                    Clipboard.SetText(cellValue.ToString());
                }
            }
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

        public enum LogType
        {
            Info,
            Warning,
            Error
        }

        public static void WriteToImportStatusFile(string data, LogType logType = LogType.Info)
        {
            try
            {
                // Use the using statement to ensure proper disposal of StreamWriter
                using (StreamWriter sw = new StreamWriter(importStatusFile, true))
                {
                    // Write the data to the import status file with log type
                    sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logType}] - {data}");
                }
                // StreamWriter is automatically closed and disposed of when leaving the using block
            }
            catch (IOException ex)
            {
                // Handle the exception
                MessageBox.Show($"An error occurred while writing to the import status file: {ex.Message}");
            }
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

            try
            {
                // Use the using statement to ensure proper disposal of StreamWriter
                using (StreamWriter sw = new StreamWriter(primaryLogFile, true))
                {
                    // Write the data to the log file
                    sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {data}");
                }
                // StreamWriter is automatically closed and disposed of when leaving the using block
            }
            catch (IOException ex)
            {
                // Handle the exception
                MessageBox.Show($"An error occurred while writing to the log file: {ex.Message}");
            }
        }

        public static void HandleException(Exception ex, string contextMessage, bool showMessageBox = true)
        {
            string logMessage = $"{contextMessage}: {ex.Message}";
            WriteToLog(logMessage);

            if (showMessageBox)
            {
                MessageBox.Show(logMessage);
            }
        }


        public static void WriteErrorToRTB(string errorMessage, RichTextBox rtb, Color? color = null)
        {
            // This method will be used to write an error message to the rich text box with a default color of red,
            // but allows specifying another color when calling the method.

            Color textColor = color ?? Color.Red; // Use the specified color or default to red
            rtb.SelectionColor = textColor;
            rtb.AppendText($"{errorMessage}\n");
            rtb.SelectionColor = rtb.ForeColor; // Reset to default color
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



            // This method lists all groups in the tenant and displays them in a DataGrid view

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
                    // no members in group. Do nothing.
                }
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
                requestConfiguration.QueryParameters.Count = true;
                requestConfiguration.QueryParameters.Filter = "not(groupTypes/any(g:g eq 'Unified'))";
                requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
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

        public static string GetGroupIDFromIntentPolicyAssignment(string ID)
        {
            /* Method to get the group ID from the assignment object ID
             * 
             * 
             */



            return "";
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

        public static bool CheckIfGUID(string input)
        {
            // Method to check if a string is a valid GUID

            if (Guid.TryParse(input, out Guid result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static async Task<List<IosManagedAppProtection>> GetAlliOSAppProtectionPolicies()
        {
            // Method to get the iOS managed app protection policy

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            var result = await graphClient.DeviceAppManagement.IosManagedAppProtections.GetAsync((RequestConfiguration) =>
            {
                RequestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });

            // Create a list to store the iOS app protection policies in

            List<IosManagedAppProtection> iOSAppProtectionPolicies = new List<IosManagedAppProtection>();

            // Add to list
            iOSAppProtectionPolicies.AddRange(result.Value);

            // Return the list
            return iOSAppProtectionPolicies;

        }

        public static async Task<List<AndroidManagedAppProtection>> GetAllAndroidManagedAppProtectionPolicies()
        {
            // Method to get the Android managed app protection policy

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            var result = await graphClient.DeviceAppManagement.AndroidManagedAppProtections.GetAsync((RequestConfiguration) =>
            {
                RequestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });

            // Create a list to store the Android app protection policies in

            List<AndroidManagedAppProtection> androidAppProtectionPolicies = new List<AndroidManagedAppProtection>();

            // Add to list
            androidAppProtectionPolicies.AddRange(result.Value);

            return androidAppProtectionPolicies;
        }

        public static async Task<List<WindowsManagedAppProtection>> GetAllWindowsAppProtectionPolicies()
        {
            // Method to get the Windows managed app protection policy

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            var result = await graphClient.DeviceAppManagement.WindowsManagedAppProtections.GetAsync((RequestConfiguration) =>
            {
                RequestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });

            // Create a list to store the Windows app protection policies in
            List<WindowsManagedAppProtection> windowsAppProtectionPolicies = new List<WindowsManagedAppProtection>();

            // Add to list
            windowsAppProtectionPolicies.AddRange(result.Value);

            return windowsAppProtectionPolicies;
        }

        public static async Task<List<MdmWindowsInformationProtectionPolicy>> GetAllMDMWindowsInformationProtectionPolicies()
        {
            // Method to get the MDM Windows Information Protection policy

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            var result = await graphClient.DeviceAppManagement.MdmWindowsInformationProtectionPolicies.GetAsync((RequestConfiguration) =>
            {
                RequestConfiguration.QueryParameters.Select = new string[] { "id", "displayName" };
            });

            // Create a list to store the MDM Windows Information Protection policies in

            List<MdmWindowsInformationProtectionPolicy> mdmWindowsInformationProtectionPolicies = new List<MdmWindowsInformationProtectionPolicy>();

            // Add to list
            mdmWindowsInformationProtectionPolicies.AddRange(result.Value);

            return mdmWindowsInformationProtectionPolicies;

        }

        public static async Task<List<string>> GetAppPermissions()
        {

            //Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Look up the app permissions

            try
            {
                // Look up the app permissions by the app ID (client ID)
                var result = await graphClient.Applications.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = "appID eq '" + TokenProvider.clientID + "'";
                    requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName", "requiredResourceAccess" };
                    //requestConfiguration.QueryParameters.Select = new string[] { "id", "displayName", "publishedPermissionScopes" };
                });

                // Create a list to store the app permissions in

                List<Microsoft.Graph.Beta.Models.Application> appPermissions = new List<Microsoft.Graph.Beta.Models.Application>();

                appPermissions.AddRange(result.Value);

                var appName = appPermissions[0].DisplayName;
                var appID = appPermissions[0].Id;
                var permissions = appPermissions[0].RequiredResourceAccess;
                var permissionCount = permissions[0].ResourceAccess.Count;


                // Convert the permissions to human-readable format
                // This variable has all configured permissions in the app with their display name (example - "Read and write Microsoft Intune apps")
                var roles = await TranslateAppPermissions(permissions);

                return roles;






                // Count the number of roles
                var rolesCount = roles.Count;



            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                MessageBox.Show(me.Message);
                throw;
            }
            //catch (Microsoft.Identity.Client.MsalServiceException me)
            //{
            //    MessageBox.Show(me.Message);
            //    throw;
            //}
        }

        public static async Task<List<string>> TranslateAppPermissions(List<RequiredResourceAccess> listOfPermissions)
        {
            // Method to translate the app permissions to human-readable format

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Create a list to store the permissions IDs in

            List<string> permissionsIDs = new List<string>();

            // Loop through the permissions and add the IDs to the list
            foreach (RequiredResourceAccess permission in listOfPermissions)
            {
                foreach (ResourceAccess resourceAccess in permission.ResourceAccess)
                {
                    permissionsIDs.Add(resourceAccess.Id.ToString());
                }
            }


            // Retrieve list of all permissions from Graph API

            var result = await graphClient.ServicePrincipals.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Filter = "appId eq '00000003-0000-0000-c000-000000000000'";
                requestConfiguration.QueryParameters.Select = new string[] { "publishedPermissionScopes" };
            });

            // Create a list to store the app roles in
            List<PermissionScope> appRoles = new List<PermissionScope>();

            // Add to list
            appRoles.AddRange(result.Value[0].PublishedPermissionScopes);

            HashSet<PermissionScope> uniquePermissions = new HashSet<PermissionScope>(appRoles);

            // make a list to store the permissions in
            List<string> permissionsFound = new List<string>();

            // Loop through the permissions IDs and match them with the app roles
            foreach (var id in permissionsIDs)
            {
                foreach (var appRole in uniquePermissions)
                {
                    if (id == appRole.Id.ToString())
                    {
                        permissionsFound.Add(appRole.AdminConsentDisplayName);
                        //MessageBox.Show("Found " + appRole.DisplayName);
                    }
                }
            }

            return permissionsFound;
        }

        public static List<string> FindCorrectPermissions(List<string> permissions)
        {
            // Method to check what permissions are correct

            // Create a new list to store the correct permissions in
            List<string> correctPermissions = new List<string>();

            foreach (var permission in permissions)
            {
                if (PermissionIDAndDisplayName.ContainsValue(permission))
                {
                    correctPermissions.Add(permission);
                }
            }


            return correctPermissions;
        }

        public static List<string> FindMissingPermissions(List<string> permissions)
        {
            // Method to check what permissions are missing

            // Create a new list to store the missing permissions in
            List<string> missingPermissions = new List<string>();

            foreach (var permission in PermissionIDAndDisplayName)
            {
                if (!permissions.Contains(permission.Value))
                {
                    missingPermissions.Add(permission.Value);
                }

            }
            return missingPermissions;
        }

        public static List<string> FindWrongPermissions(List<string> permissions)
        {
            // Method to check what permissions are wrong

            // Create a new list to store the wrong permissions in
            List<string> wrongPermissions = new List<string>();

            foreach (var permission in permissions)
            {
                if (!PermissionIDAndDisplayName.ContainsValue(permission))
                {
                    wrongPermissions.Add(permission);
                }
            }
            return wrongPermissions;
        }

        public static async Task<List<DeviceManagementIntent>> GetSecurityBaselines(GraphServiceClient graphClient)
        {
            /* 
            * This method gets all security baselines in the tenant
            * 
            * Note - Security baselines in this context is:
            * - Windows 10 security baselines
            * - Microsoft Defender for Endpoint security baselines
            * - Windows 365 security baselines
            * 
            * M365 and Edge are not included in this method because their backend is the Settings Catalog framework
           */

            // Make a call to Microsoft Graph

            var result = await graphClient.DeviceManagement.Intents.GetAsync();

            // Put result into a list for easy processing

            List<DeviceManagementIntent> securityBaselines = new List<DeviceManagementIntent>();

            securityBaselines.AddRange(result.Value);

            return securityBaselines;
        }

        public static async Task DeleteDeviceCompliancePolicyAssignments(List<string> groupIDs, string policyID)
        {

            // TODO - Bug in graph SDK? Not able to create device compliance policy request body. it defaults to configuration policy

            // Method to delete device compliance policy assignments

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Get all assignments for the policy

            var result = await GetCompliancePolicyAssignments(policyID);

            // Store all assignments in a list

            var allAssignments = new List<DeviceCompliancePolicyAssignment>();
            allAssignments.AddRange(result);

            // Create a new list to store the assignments you want to keep
            var assignmentsToKeep = new List<DeviceCompliancePolicyAssignment>();

            // Make the lists equal at first. Later, subtract the assignments you want to delete
            assignmentsToKeep.AddRange(allAssignments);



            foreach (var assignment in allAssignments)
            {
                var groupID = "";

                if (assignment.Target.GetType() == typeof(AllDevicesAssignmentTarget))
                {
                    groupID = allDevicesGroupID;
                }

                else if (assignment.Target.GetType() == typeof(AllLicensedUsersAssignmentTarget))
                {
                    groupID = allUsersGroupID;
                }
                else
                {
                    var groupAssignmentTarget = (GroupAssignmentTarget)assignment.Target;
                    groupID = groupAssignmentTarget.GroupId;
                }

                var ID = assignment.Id;

                if (groupIDs.Contains(groupID))
                {
                    // Remove the assignment from the list of assignments to keep
                    assignmentsToKeep.Remove(assignment);
                }
                else
                {
                    // Keep. Do nothing
                }
            }


            foreach (var groupID in groupIDs)
            {
                new DeviceCompliancePolicyAssignment
                {
                    Id = groupID
                };
            }

            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceCompliancePolicies.Item.Assign.AssignPostRequestBody
            {
                Assignments = new List<DeviceCompliancePolicyAssignment>()
            };

            // Add the assignments to the request body
            requestBody.Assignments.AddRange(assignmentsToKeep);

            // Make the POST request to delete the assignments

            await graphClient.DeviceManagement.DeviceCompliancePolicies[policyID].Assign.PostAsAssignPostResponseAsync(requestBody);


        }


        public static async Task DeleteSettingsCatalogPolicyAssignment(List<string> groupIDs, string policyID)
        {
            // Method to delete a settings catalog policy assignment

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Get all assignments for the policy

            var result = await GetSettingsCatalogAssignments(policyID);

            // Store all assignments in a list

            var allAssignments = new List<DeviceManagementConfigurationPolicyAssignment>();

            allAssignments.AddRange(result);

            // Create a new list to store the assignments you want to keep
            var assignmentsToKeep = new List<DeviceManagementConfigurationPolicyAssignment>();

            // Make the lists equal at first. Later, subtract the assignments you want to delete
            assignmentsToKeep.AddRange(allAssignments);

            // remove assignment objects that match their group ID with the group IDs in the list

            foreach (var assignment in allAssignments)
            {
                var groupID = "";

                if (assignment.Target.GetType() == typeof(AllDevicesAssignmentTarget))
                {
                    groupID = allDevicesGroupID;
                }

                else if (assignment.Target.GetType() == typeof(AllLicensedUsersAssignmentTarget))
                {
                    groupID = allUsersGroupID;
                }
                else
                {
                    var groupAssignmentTarget = (GroupAssignmentTarget)assignment.Target;
                    groupID = groupAssignmentTarget.GroupId;
                }

                var ID = assignment.Id;

                if (groupIDs.Contains(groupID))
                {
                    // Remove the assignment from the list of assignments to keep
                    assignmentsToKeep.Remove(assignment);
                }
                else
                {
                    // Keep. Do nothing
                }
            }

            foreach (var groupID in groupIDs)
            {
                new DeviceManagementConfigurationPolicyAssignment
                {
                    Id = groupID
                };
            }

            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.ConfigurationPolicies.Item.Assign.AssignPostRequestBody
            {
                Assignments = new List<DeviceManagementConfigurationPolicyAssignment>()
            };

            // Add the assignments to the request body
            requestBody.Assignments.AddRange(assignmentsToKeep);

            // Make the POST request to delete the assignments

            await graphClient.DeviceManagement.ConfigurationPolicies[policyID].Assign.PostAsync(requestBody);


        }


        public static async Task DeleteSecurityBaselineAssignments(List<string> groupIDs, string policyID)
        {
            // Method to deletes a security baseline assignment
            // Security baselines in this context are also known as intents in the Graph API, and require a different method to delete assignments
            // The way it works is that you have to make a POST with the group IDs you want to keep, and the Graph API will delete all other assignments
            // The list passed into this method should contain the group IDs you want to delete

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Get all assignments for the security baseline

            var result = await GetSecurityBaselineAssignments(policyID);


            // Store all assignments in a list

            var allAssignments = new List<DeviceManagementIntentAssignment>();
            allAssignments.AddRange(result);

            // Create a new list to store the assignments you want to keep
            var assignmentsToKeep = new List<DeviceManagementIntentAssignment>();

            // Make the lists equal at first. Later, subtract the assignments you want to delete
            assignmentsToKeep.AddRange(allAssignments);

            // remove assignment objects that match their group ID with the group IDs in the list
            foreach (var assignment in allAssignments)
            {

                var groupID = "";

                if (assignment.Target.GetType() == typeof(AllDevicesAssignmentTarget))
                {
                    groupID = allDevicesGroupID;
                }

                else if (assignment.Target.GetType() == typeof(AllLicensedUsersAssignmentTarget))
                {
                    groupID = allUsersGroupID;
                }
                else
                {
                    var groupAssignmentTarget = (GroupAssignmentTarget)assignment.Target;
                    groupID = groupAssignmentTarget.GroupId;
                }


                var ID = assignment.Id;

                if (groupIDs.Contains(groupID))
                {
                    // Remove the assignment from the list of assignments to keep
                    assignmentsToKeep.Remove(assignment);

                }
                else
                {
                    // Keep. Do nothing
                }

            }


            foreach (var groupID in groupIDs)
            {
                new DeviceManagementIntentAssignment
                {
                    Id = groupID
                };

            }

            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.Intents.Item.Assign.AssignPostRequestBody
            {

                Assignments = new List<DeviceManagementIntentAssignment>()
            };

            // Add the assignments to the request body
            requestBody.Assignments.AddRange(assignmentsToKeep);

            // Make the POST request to delete the assignments
            await graphClient.DeviceManagement.Intents[policyID].Assign.PostAsync(requestBody);

        }

        public static async Task<List<DeviceAndAppManagementAssignmentFilter>> GetAllAssignmentFilters()
        {
            // Method to get the assignment filters for a policy
            // Create a new instance of the GraphServiceClient class

            var graphClient = CreateGraphServiceClient();

            // Create a list to store the assignment filters in
            List<DeviceAndAppManagementAssignmentFilter> assignmentFilters = new List<DeviceAndAppManagementAssignmentFilter>();

            try
            {
                // Look up the assignment filters
                var result = await graphClient.DeviceManagement.AssignmentFilters.GetAsync();

                if (result != null && result.Value != null)
                {
                    // Create a page iterator
                    var pageIterator = PageIterator<DeviceAndAppManagementAssignmentFilter, DeviceAndAppManagementAssignmentFilterCollectionResponse>.CreatePageIterator(
                        graphClient,
                        result,
                        (filter) =>
                        {
                            assignmentFilters.Add(filter);
                            return true;
                        });

                    // Iterate through the pages
                    await pageIterator.IterateAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                WriteToLog($"An error occurred while getting assignment filters: {ex.Message}");
            }


            // clear the dictionary
            filterDictionary.Clear();
            filterNameAndID.Clear();

            // Add filter name and ID to the dictionary
            foreach (var filter in assignmentFilters)
            {
                filterNameAndID.Add(filter.DisplayName, filter.Id);
            }

            return assignmentFilters;
        }

        public static void AddFiltersToDictionary(Dictionary<string, string> filterDictionary, List<DeviceAndAppManagementAssignmentFilter> filters)
        {
            // Clear the dictionary
            filterDictionary.Clear();
            // Add a default value to the dictionary
            filterDictionary.Add("None", "None");

            // Add the filters to the dictionary
            foreach (var filter in filters)
            {
                filterDictionary.Add(filter.DisplayName, filter.Rule);
            }
        }

        public static void AddFiltersToComboBox(ComboBox comboBox, List<DeviceAndAppManagementAssignmentFilter> filters)
        {
            // Clear the combobox
            comboBox.Items.Clear();

            // Add a default value to the combobox
            comboBox.Items.Add("None");

            // Set the default value
            comboBox.SelectedIndex = 0;

            // Add the filters to the combobox
            foreach (var filter in filters)
            {
                if (filter.DisplayName != null)
                {
                    comboBox.Items.Add(filter.DisplayName);
                }
            }

            // Enable owner draw mode
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DrawItem += (sender, e) => ComboBox_DrawItem(sender, e, filterDictionary);

            // Create a ToolTip instance
            ToolTip toolTip = new ToolTip();
            comboBox.MouseMove += (sender, e) =>
            {
                Point point = comboBox.PointToClient(Cursor.Position);
                int index = comboBox.FindStringExact(comboBox.GetItemText(comboBox.Items[comboBox.SelectedIndex]));
                if (index >= 0 && index < comboBox.Items.Count)
                {
                    string itemText = comboBox.Items[index]?.ToString();
                    if (itemText != null && filterDictionary.TryGetValue(itemText, out string toolTipText))
                    {
                        toolTip.SetToolTip(comboBox, toolTipText);
                        toolTip.Show(toolTipText, comboBox, point.X, point.Y + comboBox.ItemHeight, 2000);
                    }
                }
                else
                {
                    toolTip.Hide(comboBox);
                }
            };
        }

        private static void ComboBox_DrawItem(object sender, DrawItemEventArgs e, Dictionary<string, string> filterDictionary)
        {
            Brush brush = new SolidBrush(Color.Salmon);
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && e.Index >= 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
                e.DrawFocusRectangle();
            }

            
        }

        public static void AddItemsToDictionary(Dictionary<string, string> dictionary, string name, string id)
        {
            // Add the items to the dictionary
            dictionary.Add(name, id);
        }

        public static void GetCheckedItemsFromCheckedListBox(CheckedListBox checkedListBox, List<string> checkedItems)
        {
            // Clear the list
            checkedItems.Clear();
            // Loop through the checked items
            foreach (var item in checkedListBox.CheckedItems)
            {
                // Add the checked items to the list
                checkedItems.Add(item.ToString());
            }
        }

        public static bool AreAllItemsInCLBChecked(CheckedListBox clb)
        {
            if (clb.Items.Count == 0)
            {
                return false; // Or true, depending on how you want to handle an empty list
            }

            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (!clb.GetItemChecked(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreAllItemsInDTGChecked(DataGridView dtg)
        {
            if (dtg.Rows.Count == 0)
            {
                return false; // Or true, depending on how you want to handle an empty list
            }
            for (int i = 0; i < dtg.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dtg.Rows[i].Cells[0].Value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
