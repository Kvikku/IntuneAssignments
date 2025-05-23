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
using static IntuneAssignments.Backend.IntuneContentClasses.Filters;
using System.Windows.Forms; // Added for DataGridView and RichTextBox

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class WindowsQualityUpdatePoliciesHandler
    {
        // For Windows Quality Updates (Not expedite policy)

        public static async Task<List<WindowsQualityUpdatePolicy>> SearchForWindowsQualityUpdatePolicies(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for Windows Quality Update policies. Search query: " + searchQuery);

                // Fetch all first and then filter locally as a safer approach.
                var allPolicies = await GetAllWindowsQualityUpdatePolicies(graphServiceClient);
                // Add null checks for policy and DisplayName
                var filteredPolicies = allPolicies.Where(p => p?.DisplayName != null && p.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                WriteToLog($"Found {filteredPolicies.Count} Windows Quality Update policies matching the search query.");

                return filteredPolicies;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for Windows Quality Update policies");
                return new List<WindowsQualityUpdatePolicy>();
            }
        }

        public static async Task<List<WindowsQualityUpdatePolicy>> GetAllWindowsQualityUpdatePolicies(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all Windows Quality Update policies.");

                var result = await graphServiceClient.DeviceManagement.WindowsQualityUpdatePolicies.GetAsync((requestConfiguration) =>
                {
                    //requestConfiguration.QueryParameters.Top = 1000; // Adjust as needed
                });

                List<WindowsQualityUpdatePolicy> policies = new List<WindowsQualityUpdatePolicy>();

                // Add null check for result before creating iterator
                if (result?.Value != null)
                {
                    var pageIterator = PageIterator<WindowsQualityUpdatePolicy, WindowsQualityUpdatePolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                    {
                        policies.Add(policy);
                        return true;
                    });
                    await pageIterator.IterateAsync();
                }
                else
                {
                    WriteToLog("No Windows Quality Update policies found or result was null.");
                }

                WriteToLog($"Found {policies.Count} Windows Quality Update policies.");

                return policies;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all Windows Quality Update policies");
                return new List<WindowsQualityUpdatePolicy>();
            }
        }

        public static void AddWindowsQualityUpdatePoliciesToDTG(List<WindowsQualityUpdatePolicy> policies, System.Windows.Forms.DataGridView dtg)
        {
            try
            {
                if (policies == null)
                {
                    throw new ArgumentNullException(nameof(policies), "The policies list cannot be null.");
                }

                if (dtg == null)
                {
                    throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
                }

                WriteToLog("Adding Windows Quality Update policies to the DataGridView.");

                foreach (var policy in policies)
                {
                    if (policy.Id == null || policy.DisplayName == null) // Description might be optional
                    {
                        // Log or handle policies with missing essential info if necessary
                        continue; // Skip adding this policy
                    }

                    // Assuming column structure: Name, Type, Platform (implicitly Windows), ID
                    dtg.Rows.Add(policy.DisplayName, "Windows Quality Update", "Windows", policy.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding Windows Quality Update policies to the DataGridView");
            }
        }

        public static List<string> GetWindowsQualityUpdatePoliciesFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Windows Quality Update"; // Match the type string used in AddWindowsQualityUpdatePoliciesToDTG
                List<string> matchingRows = new List<string>();

                foreach (DataGridViewRow row in dtg.Rows)
                {
                    // Assuming Type is in the second column (index 1) and ID is in the fourth column (index 3)
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == type && row.Cells[3].Value != null)
                    {
                        var cellValue = row.Cells[3].Value?.ToString();
                        if (cellValue != null)
                        {
                            matchingRows.Add(cellValue);
                        }
                    }
                }

                return matchingRows;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving Windows Quality Update policies from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleWindowsQualityUpdatePolicies(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> policyIDs, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {policyIDs.Count} Windows Quality Update policies.\n");
                WriteToImportStatusFile($"Importing {policyIDs.Count} Windows Quality Update policies.");

                if (assignments)
                {
                    rtb.AppendText("Group assignments will be added.\n");
                    WriteToImportStatusFile("Group assignments will be added.");
                }

                if (filter)
                {
                    rtb.AppendText("Filters will be added (if applicable).\n");
                    WriteToImportStatusFile("Filters will be added (if applicable).");
                }

                string profileName = "";

                foreach (var policyId in policyIDs)
                {
                    try
                    {
                        // Fetch the source policy
                        var sourcePolicy = await sourceGraphServiceClient.DeviceManagement.WindowsQualityUpdatePolicies[policyId].GetAsync();

                        if (sourcePolicy == null)
                        {
                            rtb.AppendText($"Skipping policy ID {policyId}: Not found in source tenant.\n");
                            WriteToImportStatusFile($"Skipping policy ID {policyId}: Not found in source tenant.");
                            continue;
                        }

                        profileName = sourcePolicy.DisplayName ?? "ERROR GETTING NAME";

                        // Create the new policy object for the destination tenant
                        var newPolicy = new WindowsQualityUpdatePolicy
                        {
                            // Initialize properties needed for creation. Copy relevant ones from sourcePolicy.
                            // Be careful about read-only properties like Id, CreatedDateTime, LastModifiedDateTime.
                        };

                        // Dynamically copy properties (excluding specific ones)
                        foreach (var property in sourcePolicy.GetType().GetProperties())
                        {
                            // Skip read-only or problematic properties
                            if (property.Name.Equals("id", StringComparison.OrdinalIgnoreCase) ||
                                property.Name.Equals("createdDateTime", StringComparison.OrdinalIgnoreCase) ||
                                property.Name.Equals("lastModifiedDateTime", StringComparison.OrdinalIgnoreCase) ||
                                property.Name.Equals("assignments", StringComparison.OrdinalIgnoreCase) || // Assignments are handled separately
                                !property.CanWrite) // Skip properties without a setter
                            {
                                continue;
                            }

                            var value = property.GetValue(sourcePolicy);
                            // Check if the property exists on the newPolicy object before setting
                            var destProperty = newPolicy.GetType().GetProperty(property.Name);
                            if (destProperty != null && destProperty.CanWrite)
                            {
                                destProperty.SetValue(newPolicy, value);
                            }
                        }

                        // Ensure OdataType is set correctly
                        newPolicy.OdataType = "#microsoft.graph.windowsQualityUpdatePolicy";

                        // Create the policy in the destination tenant
                        var importedPolicy = await destinationGraphServiceClient.DeviceManagement.WindowsQualityUpdatePolicies.PostAsync(newPolicy);

                        // Add null check for importedPolicy and DisplayName
                        rtb.AppendText($"Imported policy: {importedPolicy?.DisplayName ?? "Unnamed Policy"} (ID: {importedPolicy?.Id ?? "Unknown ID"})\n");
                        WriteToImportStatusFile($"Imported policy: {importedPolicy?.DisplayName ?? "Unnamed Policy"} (ID: {importedPolicy?.Id ?? "Unknown ID"})");

                        // Handle assignments if requested
                        if (assignments && groups != null && groups.Any() && importedPolicy?.Id != null)
                        {
                            await AssignGroupsToSingleWindowsQualityUpdatePolicy(importedPolicy.Id, groups, destinationGraphServiceClient, filter);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the specific policy ID that failed
                        HandleException(ex, $"Error importing Windows Quality Update policy {profileName}", false);
                        HandleException(ex, "This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active", false);
                        rtb.AppendText($"Failed to import Windows Quality Update policy {profileName}\n");
                        //rtb.AppendText($"This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active\n");
                        WriteToImportStatusFile($"Failed to import Windows Quality Update policy {profileName}: {ex.Message}");
                        WriteToImportStatusFile("This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active");
                    }
                }
                rtb.AppendText("Windows Quality Update policy import process finished.\n");
                WriteToImportStatusFile("Windows Quality Update policy import process finished.");
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the Windows Quality Update policy import process");
                rtb.AppendText($"An error occurred during the import process: {ex.Message}\n");
                WriteToImportStatusFile($"An error occurred during the import process: {ex.Message}");
            }
        }

        public static async Task AssignGroupsToSingleWindowsQualityUpdatePolicy(string policyID, List<string> groupIDs, GraphServiceClient destinationGraphServiceClient, bool applyFilter)
        {
            try
            {
                if (string.IsNullOrEmpty(policyID))
                {
                    throw new ArgumentNullException(nameof(policyID));
                }

                if (groupIDs == null || !groupIDs.Any())
                {
                    WriteToLog($"No groups provided for assignment to policy {policyID}. Skipping assignment.");
                    return; // Nothing to assign
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                WriteToLog($"Assigning {groupIDs.Count} groups to Windows Quality Update policy {policyID}. Apply filter: {applyFilter}");

                List<WindowsQualityUpdatePolicyAssignment> assignments = new List<WindowsQualityUpdatePolicyAssignment>();

                foreach (var groupId in groupIDs)
                {
                    var assignmentTarget = new GroupAssignmentTarget
                    {
                        OdataType = "#microsoft.graph.groupAssignmentTarget",
                        GroupId = groupId,
                        // Apply filters if applicable and supported for Quality Update Policy assignments
                        DeviceAndAppManagementAssignmentFilterId = applyFilter ? SelectedFilterID : null,
                        DeviceAndAppManagementAssignmentFilterType = applyFilter ? deviceAndAppManagementAssignmentFilterType : Microsoft.Graph.Beta.Models.DeviceAndAppManagementAssignmentFilterType.None,
                    };

                    var assignment = new WindowsQualityUpdatePolicyAssignment
                    {
                        OdataType = "#microsoft.graph.windowsQualityUpdatePolicyAssignment",
                        Target = assignmentTarget,
                        // Source and SourceId might not be applicable/required here. Check documentation.
                    };
                    assignments.Add(assignment);
                }

                // The request body structure for assigning Quality Update Policies might differ.
                // Check the Graph API documentation for the correct structure.
                // Assuming it's similar to Feature Updates for now.
                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.WindowsQualityUpdatePolicies.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                    // Other properties specific to Quality Update Policy assignment might be needed here.
                };

                try
                {
                    // The Assign action might return void or a specific response type. Adjust accordingly.
                    await destinationGraphServiceClient.DeviceManagement.WindowsQualityUpdatePolicies[policyID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile($"Successfully assigned {groupIDs.Count} groups to policy {policyID}. Filter applied: {applyFilter}");
                }
                catch (Exception ex)
                {
                    // Log specific error for this assignment attempt
                    HandleException(ex, $"Error assigning groups to Windows Quality Update policy {policyID}");
                    WriteToImportStatusFile($"Error assigning groups to policy {policyID}: {ex.Message}");
                    // Decide if you want to re-throw or just log
                }
            }
            catch (Exception ex)
            {
                // Catch argument null exceptions or other setup errors
                HandleException(ex, "An error occurred while preparing to assign groups to a Windows Quality Update policy");
                WriteToImportStatusFile($"An error occurred while preparing assignment for policy {policyID}: {ex.Message}");
            }
        }

        public static async Task DeleteWindowsQualityUpdatePolicy(GraphServiceClient graphServiceClient, string policyID)
        {
            try
            {
                if (graphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(graphServiceClient));
                }

                if (policyID == null)
                {
                    throw new InvalidOperationException("Policy ID cannot be null.");
                }

                await graphServiceClient.DeviceManagement.WindowsQualityUpdatePolicies[policyID].DeleteAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while deleting a Windows Quality Update policy");
            }
        }
    }
}
