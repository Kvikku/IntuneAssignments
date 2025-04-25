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
using System.Windows.Forms;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class WindowsQualityUpdateProfileHandler
    {
        // Expedite policies (not regular quality update policies)
        public static async Task<List<WindowsQualityUpdateProfile>> SearchForWindowsQualityUpdateProfiles(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for Windows Quality Update profiles. Search query: " + searchQuery);

                var allProfiles = await GetAllWindowsQualityUpdateProfiles(graphServiceClient);
                var filteredProfiles = allProfiles.Where(p => p?.DisplayName != null && p.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                WriteToLog($"Found {filteredProfiles.Count} Windows Quality Update profiles matching the search query.");

                return filteredProfiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for Windows Quality Update profiles");
                return new List<WindowsQualityUpdateProfile>();
            }
        }

        public static async Task<List<WindowsQualityUpdateProfile>> GetAllWindowsQualityUpdateProfiles(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all Windows Quality Update profiles.");

                var result = await graphServiceClient.DeviceManagement.WindowsQualityUpdateProfiles.GetAsync((requestConfiguration) =>
                {
                });

                List<WindowsQualityUpdateProfile> profiles = new List<WindowsQualityUpdateProfile>();

                if (result?.Value != null)
                {
                    var pageIterator = PageIterator<WindowsQualityUpdateProfile, WindowsQualityUpdateProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                    {
                        profiles.Add(profile);
                        return true;
                    });
                    await pageIterator.IterateAsync();
                }
                else
                {
                    WriteToLog("No Windows Quality Update profiles found or result was null.");
                }

                WriteToLog($"Found {profiles.Count} Windows Quality Update profiles.");

                return profiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all Windows Quality Update profiles");
                return new List<WindowsQualityUpdateProfile>();
            }
        }

        public static void AddWindowsQualityUpdateProfilesToDTG(List<WindowsQualityUpdateProfile> profiles, System.Windows.Forms.DataGridView dtg)
        {
            try
            {
                if (profiles == null)
                {
                    throw new ArgumentNullException(nameof(profiles), "The profiles list cannot be null.");
                }

                if (dtg == null)
                {
                    throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
                }

                WriteToLog("Adding Windows Quality Update profiles to the DataGridView.");

                foreach (var profile in profiles)
                {
                    if (profile.Id == null || profile.DisplayName == null)
                    {
                        continue;
                    }

                    dtg.Rows.Add(profile.DisplayName, "Windows Expedite Update", "Windows", profile.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding Windows Quality Update profiles to the DataGridView");
            }
        }

        public static List<string> GetWindowsQualityUpdateProfilesFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Windows Expedite Update";
                List<string> matchingRows = new List<string>();

                foreach (DataGridViewRow row in dtg.Rows)
                {
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
                HandleException(ex, "An error occurred while retrieving Windows Quality Update profiles from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleWindowsQualityUpdateProfiles(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> profileIDs, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {profileIDs.Count} Windows Quality Update profiles.\n");
                WriteToImportStatusFile($"Importing {profileIDs.Count} Windows Quality Update profiles.");

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

                foreach (var profileId in profileIDs)
                {
                    try
                    {
                        var sourceProfile = await sourceGraphServiceClient.DeviceManagement.WindowsQualityUpdateProfiles[profileId].GetAsync();

                        if (sourceProfile == null)
                        {
                            rtb.AppendText($"Skipping profile ID {profileId}: Not found in source tenant.\n");
                            WriteToImportStatusFile($"Skipping profile ID {profileId}: Not found in source tenant.");
                            continue;
                        }

                        var newPolicy = new WindowsQualityUpdateProfile
                        {
                            // Initialize properties needed for creation. Copy relevant ones from sourcePolicy.
                            // Be careful about read-only properties like Id, CreatedDateTime, LastModifiedDateTime.
                        };

                        // Dynamically copy properties (excluding specific ones)
                        foreach (var property in sourceProfile.GetType().GetProperties())
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

                            var value = property.GetValue(sourceProfile);
                            // Check if the property exists on the newPolicy object before setting
                            var destProperty = newPolicy.GetType().GetProperty(property.Name);
                            if (destProperty != null && destProperty.CanWrite)
                            {
                                destProperty.SetValue(newPolicy, value);
                            }
                        }

                        newPolicy.OdataType = "#microsoft.graph.windowsQualityUpdateProfile";

                        var importedProfile = await destinationGraphServiceClient.DeviceManagement.WindowsQualityUpdateProfiles.PostAsync(newPolicy);

                        rtb.AppendText($"Imported profile: {importedProfile?.DisplayName ?? "Unnamed Profile"} (ID: {importedProfile?.Id ?? "Unknown ID"})\n");
                        WriteToImportStatusFile($"Imported profile: {importedProfile?.DisplayName ?? "Unnamed Profile"} (ID: {importedProfile?.Id ?? "Unknown ID"})");

                        if (assignments && groups != null && groups.Any() && importedProfile?.Id != null)
                        {
                            await AssignGroupsToSingleWindowsQualityUpdateProfile(importedProfile.Id, groups, destinationGraphServiceClient, filter);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, $"Error importing Windows Quality Update profile with ID {profileId}", false);
                        rtb.AppendText($"Error importing profile {profileId}: {ex.Message}\n");
                        WriteToImportStatusFile($"Error importing profile {profileId}: {ex.Message}");
                    }
                }
                rtb.AppendText("Windows Quality Update profile import process finished.\n");
                WriteToImportStatusFile("Windows Quality Update profile import process finished.");
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the Windows Quality Update profile import process");
                rtb.AppendText($"An error occurred during the import process: {ex.Message}\n");
                WriteToImportStatusFile($"An error occurred during the import process: {ex.Message}");
            }
        }


        public static async Task AssignGroupsToSingleWindowsQualityUpdateProfile(string profileID, List<string> groupIDs, GraphServiceClient destinationGraphServiceClient, bool applyFilter)
        {
            try
            {
                if (string.IsNullOrEmpty(profileID))
                {
                    throw new ArgumentNullException(nameof(profileID));
                }

                if (groupIDs == null || !groupIDs.Any())
                {
                    WriteToLog($"No groups provided for assignment to profile {profileID}. Skipping assignment.");
                    return;
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                WriteToLog($"Assigning {groupIDs.Count} groups to Windows Quality Update profile {profileID}. Apply filter: {applyFilter}");

                List<WindowsQualityUpdateProfileAssignment> assignments = new List<WindowsQualityUpdateProfileAssignment>();

                foreach (var groupId in groupIDs)
                {
                    var assignmentTarget = new GroupAssignmentTarget
                    {
                        OdataType = "#microsoft.graph.groupAssignmentTarget",
                        GroupId = groupId,
                        DeviceAndAppManagementAssignmentFilterId = applyFilter ? SelectedFilterID : null,
                        DeviceAndAppManagementAssignmentFilterType = applyFilter ? deviceAndAppManagementAssignmentFilterType : Microsoft.Graph.Beta.Models.DeviceAndAppManagementAssignmentFilterType.None,
                    };

                    var assignment = new WindowsQualityUpdateProfileAssignment
                    {
                        OdataType = "#microsoft.graph.windowsQualityUpdateProfileAssignment",
                        Target = assignmentTarget,
                    };
                    assignments.Add(assignment);
                }

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.WindowsQualityUpdateProfiles.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                };

                try
                {
                    await destinationGraphServiceClient.DeviceManagement.WindowsQualityUpdateProfiles[profileID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile($"Successfully assigned {groupIDs.Count} groups to profile {profileID}. Filter applied: {applyFilter}");
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to Windows Quality Update profile {profileID}");
                    WriteToImportStatusFile($"Error assigning groups to profile {profileID}: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while preparing to assign groups to a Windows Quality Update profile");
                WriteToImportStatusFile($"An error occurred while preparing assignment for profile {profileID}: {ex.Message}");
            }
        }
    }
}
