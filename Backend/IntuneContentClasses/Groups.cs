using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class Groups
    {
        public static async Task<List<Group>> GetAllGroups(GraphServiceClient graphServiceClient)
        {
            // This method gets all the groups in the tenant and returns them as a list of Group objects
            try
            {
                WriteToLog("Getting all groups in the tenant");
                var result = await graphServiceClient.Groups.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Count = true;
                    requestConfiguration.QueryParameters.Filter = "not(groupTypes/any(g:g eq 'Unified'))";
                    requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
                });

                List<Group> groups = new List<Group>();

                // Iterate through the pages of results
                var pageIterator = PageIterator<Group, GroupCollectionResponse>.CreatePageIterator(graphServiceClient, result, (group) =>
                {
                    groups.Add(group);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();
                WriteToLog($"Found {groups.Count} groups in the tenant");
                // return the list of groups
                return groups;
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                // Log the error message
                WriteToLog($"ODataError: {me.Message}");
                MessageBox.Show(me.Message);
                return null;
            }
        }

        public static async Task<List<Group>> SearchForGroups(GraphServiceClient graphServiceClient, string searchQuery)
        {
            // This method searches for groups in the tenant based on a search query and returns the results as a list of Group objects
            try
            {
                WriteToLog("Searching for groups. Search query: " + searchQuery);

                var result = await graphServiceClient.Groups.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Search = "\"displayName:" + searchQuery + "\"";
                    requestConfiguration.QueryParameters.Filter = "not(groupTypes/any(g:g eq 'Unified'))";
                    requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
                });
                List<Group> groups = new List<Group>();

                // Iterate through the pages of results
                var pageIterator = PageIterator<Group, GroupCollectionResponse>.CreatePageIterator(graphServiceClient, result, (group) =>
                {
                    groups.Add(group);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();
                WriteToLog($"Found {groups.Count} groups in the tenant");
                // return the list of groups
                return groups;
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                // Log the error message
                WriteToLog($"ODataError: {me.Message}");
                MessageBox.Show(me.Message);
                return null;
            }
        }
        public static void AddGroupsToDTG(List<Group> groups, System.Windows.Forms.DataGridView dtg)
        {
            // Check if the groups list is null
            if (groups == null)
            {
                WriteToLog("Groups list is null");
                return;
            }
            // Clear the data grid view
            dtg.Rows.Clear();
            // Add the groups to the data grid view
            foreach (Group group in groups)
            {

                var groupType = "";
                var memberShipRule = "N/A";

                if (group.GroupTypes.Count > 0)
                {
                    groupType = "Dynamic group";
                    memberShipRule = group.MembershipRule;
                }
                else
                {
                    groupType = "Static group";
                }

                    dtg.Rows.Add(group.DisplayName, groupType, memberShipRule, group.Id);
            }
        }

        public static List<string> GetGroupsFromDTG(System.Windows.Forms.DataGridView dtg)
        {
            // This method gets the group IDs from the selected rows in the DataGridView
            try
            {
                if (dtg == null)
                {
                    WriteToLog("DataGridView is null, cannot get group IDs.");
                    return new List<string>();
                }

                List<string> groupIds = new List<string>();

                // Assuming DataGridView columns are: Name (0), Type (1), Membership Rule (2), ID (3)
                // Iterate through ALL rows to get the IDs the user intends to work with.
                foreach (DataGridViewRow row in dtg.Rows)
                {
                    // Check if the row is valid and the ID cell (index 3) has a value
                    if (!row.IsNewRow && row.Cells.Count > 3 && row.Cells[3].Value != null)
                    {
                        var cellValue = row.Cells[3].Value?.ToString();
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            groupIds.Add(cellValue);
                        }
                    }
                }
                WriteToLog($"Retrieved {groupIds.Count} Group IDs from selected rows in DataGridView.");
                return groupIds;
            }
            catch (Exception ex)
            {
                // Using WriteToLog as HandleException might not be available here
                WriteToLog($"Error retrieving Group IDs from DataGridView: {ex.Message}");
                MessageBox.Show($"An error occurred while retrieving Group IDs from DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }


        public static async Task ImportMultipleGroups(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, System.Windows.Forms.RichTextBox rtb, List<string> groupIds)
        {
            // This method imports multiple groups from the source tenant to the destination tenant
            const string ItemType = "Group"; // Define item type for logging/messages

            // Basic null checks for arguments
            if (sourceGraphServiceClient == null || destinationGraphServiceClient == null || rtb == null || groupIds == null)
            {
                WriteToLog("ImportMultipleGroups called with null arguments.");
                MessageBox.Show("An internal error occurred. Required components for import are missing.", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                rtb.AppendText($"Starting import of {groupIds.Count} {ItemType}(s).{Environment.NewLine}");
                WriteToLog($"Starting import of {groupIds.Count} {ItemType}(s).");


                foreach (var groupId in groupIds)
                {
                    Group? sourceGroup = null;
                    try
                    {
                        // Get the group from the source tenant
                        // Select specific properties to potentially reduce payload size and avoid issues with read-only properties
                        sourceGroup = await sourceGraphServiceClient.Groups[groupId].GetAsync();
                       


                        if (sourceGroup == null)
                        {
                            rtb.AppendText($"Skipping {ItemType} ID {groupId}: Not found in source tenant.{Environment.NewLine}");
                            WriteToLog($"Skipping {ItemType} ID {groupId}: Not found in source tenant.");
                            continue;
                        }

                        // Optional: Check if a group with the same name already exists in the destination tenant
                        var existingGroups = await destinationGraphServiceClient.Groups.GetAsync(q => {
                            q.QueryParameters.Filter = $"displayName eq '{sourceGroup.DisplayName?.Replace("'", "''")}'"; // Handle potential apostrophes in name
                            q.QueryParameters.Select = new string[] { "id", "displayName" }; // Only need ID and name for check
                            q.Headers.Add("ConsistencyLevel", "eventual"); // Required for advanced filters like displayName
                            q.QueryParameters.Count = true; // Request count
                        });

                        if (existingGroups?.Value?.Count > 0)
                        {
                            rtb.AppendText($"Skipping {ItemType} '{sourceGroup.DisplayName}' (ID: {groupId}): A group with this name already exists in the destination tenant.{Environment.NewLine}");
                            WriteToLog($"Skipping {ItemType} '{sourceGroup.DisplayName}' (ID: {groupId}): Name conflict in destination.");
                            continue;
                        }


                        // Create the new group object based on the source
                        var newGroup = new Group
                        {
                            DisplayName = sourceGroup.DisplayName,
                            //Description = sourceGroup.Description ?? $"Imported from source group {sourceGroup.DisplayName}", // Provide default if null
                            MailEnabled = sourceGroup.MailEnabled ?? false, // Default to false if null
                            SecurityEnabled = sourceGroup.SecurityEnabled ?? true, // Default to true if null
                            MailNickname = $"group_{Guid.NewGuid().ToString().Substring(0, 8)}", // Needs a unique mail nickname
                            // Visibility = sourceGroup.Visibility, // Copy visibility if needed (e.g., for M365 groups, though we filtered them out earlier)
                            OdataType = "#microsoft.graph.group",
                            MembershipRuleProcessingState = sourceGroup.MembershipRuleProcessingState, // Copy if applicable

                        };

                        // Handle dynamic group properties
                        if (sourceGroup.GroupTypes != null && sourceGroup.GroupTypes.Contains("DynamicMembership"))
                        {
                            if (string.IsNullOrWhiteSpace(sourceGroup.MembershipRule))
                            {
                                rtb.AppendText($"Skipping Dynamic {ItemType} '{sourceGroup.DisplayName}' (ID: {groupId}): Membership rule is missing or empty in source.{Environment.NewLine}");
                                WriteToLog($"Skipping Dynamic {ItemType} '{sourceGroup.DisplayName}' (ID: {groupId}): Missing membership rule.");
                                continue; // Cannot create dynamic group without a rule
                            }
                            newGroup.GroupTypes = new List<string> { "DynamicMembership" };
                            newGroup.MembershipRule = sourceGroup.MembershipRule;
                            // MembershipRuleProcessingState is read-only and set by the system
                        }
                        else
                        {
                            // Ensure assigned groups are explicitly marked if needed, though usually default
                            newGroup.GroupTypes = new List<string>(); // Ensure it's not dynamic if source wasn't
                        }


                        // Create the group in the destination tenant
                        var importedGroup = await destinationGraphServiceClient.Groups.PostAsync(newGroup);

                        if (importedGroup != null && !string.IsNullOrEmpty(importedGroup.Id))
                        {
                            rtb.AppendText($"Successfully imported {ItemType}: {importedGroup.DisplayName} (ID: {importedGroup.Id}){Environment.NewLine}");
                            WriteToLog($"Successfully imported {ItemType}: {importedGroup.DisplayName} (ID: {importedGroup.Id})");

                            // Post-import actions (e.g., adding owners/members) could go here.
                            // Be mindful of throttling if adding many members.
                        }
                        else
                        {
                            rtb.AppendText($"Failed to import {ItemType}: {sourceGroup.DisplayName} (ID: {groupId}). The creation process returned null or an empty ID.{Environment.NewLine}");
                            WriteToLog($"Failed to import {ItemType}: {sourceGroup.DisplayName} (ID: {groupId}). Creation returned null/empty ID.");
                        }
                    }
                    catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError odataError)
                    {
                        // More specific error handling for Graph API errors
                        string groupIdentifier = GetGroupIdentifier(sourceGroup, groupId, ItemType);
                        string errorMessage = odataError.Error?.Message ?? "Unknown OData error";
                        WriteToLog($"ODataError importing {groupIdentifier}: {errorMessage} (Code: {odataError.Error?.Code})");
                        rtb.AppendText($"Failed to import {groupIdentifier}: {errorMessage}{Environment.NewLine}");
                    }
                    catch (Exception ex)
                    {
                        string groupIdentifier = GetGroupIdentifier(sourceGroup, groupId, ItemType);
                        // Log without showing message box for each failure in loop
                        WriteToLog($"Error importing {groupIdentifier}: {ex.Message}");
                        rtb.AppendText($"Failed to import {groupIdentifier}: {ex.ToString()}{Environment.NewLine}"); // Include full exception details in RTB for debugging
                    }
                }
                rtb.AppendText($"Finished importing {ItemType}(s).{Environment.NewLine}");
                WriteToLog($"Finished importing {ItemType}(s).");
            }
            catch (Exception ex)
            {
                // Handle overall process error
                WriteToLog($"An critical error occurred during the {ItemType} import process: {ex.Message}");
                MessageBox.Show($"An critical error occurred during the {ItemType} import process: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtb.AppendText($"An critical error occurred during the {ItemType} import process: {ex.ToString()}{Environment.NewLine}");
            }
        }

        // Helper function to get a consistent identifier string for logging/messages
        private static string GetGroupIdentifier(Group? group, string groupId, string itemType)
        {
            if (group != null && !string.IsNullOrEmpty(group.DisplayName))
            {
                return $"{itemType} '{group.DisplayName}' (ID: {groupId})";
            }
            return $"{itemType} ID {groupId}";
        }
    }

}