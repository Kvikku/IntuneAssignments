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
    public class WindowsFeatureUpdateProfileHandler
    {
        // Adapted from SettingsCatalog.cs

        public static async Task<List<WindowsFeatureUpdateProfile>> SearchForWindowsFeatureUpdateProfiles(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for Windows Feature Update profiles. Search query: " + searchQuery);

                // Note: The Graph API for WindowsFeatureUpdateProfile might not support filtering by name directly in the same way.
                // Adjust the query or filter locally if needed. This example assumes direct filtering is possible or fetches all and filters locally.
                // Let's fetch all first and then filter locally as a safer approach.
                var allProfiles = await GetAllWindowsFeatureUpdateProfiles(graphServiceClient);
                // Add null checks for profile and DisplayName
                var filteredProfiles = allProfiles.Where(p => p?.DisplayName != null && p.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                WriteToLog($"Found {filteredProfiles.Count} Windows Feature Update profiles matching the search query.");

                return filteredProfiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for Windows Feature Update profiles");
                return new List<WindowsFeatureUpdateProfile>();
            }
        }

        public static async Task<List<WindowsFeatureUpdateProfile>> GetAllWindowsFeatureUpdateProfiles(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all Windows Feature Update profiles.");

                var result = await graphServiceClient.DeviceManagement.WindowsFeatureUpdateProfiles.GetAsync((requestConfiguration) =>
                {
                    //requestConfiguration.QueryParameters.Top = 1000; // Adjust as needed
                });

                List<WindowsFeatureUpdateProfile> profiles = new List<WindowsFeatureUpdateProfile>();

                // Add null check for result before creating iterator
                if (result?.Value != null)
                {
                    var pageIterator = PageIterator<WindowsFeatureUpdateProfile, WindowsFeatureUpdateProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                    {
                        profiles.Add(profile);
                        return true;
                    });
                    await pageIterator.IterateAsync();
                }
                else
                {
                    WriteToLog("No Windows Feature Update profiles found or result was null.");
                }

                WriteToLog($"Found {profiles.Count} Windows Feature Update profiles.");

                return profiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all Windows Feature Update profiles");
                return new List<WindowsFeatureUpdateProfile>();
            }
        }

        public static void AddWindowsFeatureUpdateProfilesToDTG(List<WindowsFeatureUpdateProfile> profiles, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog("Adding Windows Feature Update profiles to the DataGridView.");

                foreach (var profile in profiles)
                {
                    if (profile.Id == null || profile.DisplayName == null) // Description might be optional
                    {
                        // Log or handle profiles with missing essential info if necessary
                        continue; // Skip adding this profile
                        // OR: throw new InvalidOperationException("Profile properties cannot be null.");
                    }

                    // Assuming column structure: Name, Type, Platform (implicitly Windows), ID
                    dtg.Rows.Add(profile.DisplayName, "Windows Feature Update", "Windows", profile.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding Windows Feature Update profiles to the DataGridView");
            }
        }

        public static List<string> GetWindowsFeatureUpdateProfilesFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Windows Feature Update"; // Match the type string used in AddWindowsFeatureUpdateProfilesToDTG
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
                HandleException(ex, "An error occurred while retrieving Windows Feature Update profiles from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleWindowsFeatureUpdateProfiles(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> profileIDs, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {profileIDs.Count} Windows Feature Update profiles.\n");
                WriteToImportStatusFile($"Importing {profileIDs.Count} Windows Feature Update profiles.");

                if (assignments)
                {
                    rtb.AppendText("Group assignments will be added.\n");
                    WriteToImportStatusFile("Group assignments will be added.");
                }

                // Note: Filters are not supported for feature updates yet
                //if (filter)
                //{
                //    rtb.AppendText("Filters will be added (if applicable).\n");
                //    WriteToImportStatusFile("Filters will be added (if applicable).");
                //}

                foreach (var profileId in profileIDs)
                {
                    try
                    {
                        // Fetch the source profile
                        var sourceProfile = await sourceGraphServiceClient.DeviceManagement.WindowsFeatureUpdateProfiles[profileId].GetAsync();

                        if (sourceProfile == null)
                        {
                            rtb.AppendText($"Skipping profile ID {profileId}: Not found in source tenant.\n");
                            WriteToImportStatusFile($"Skipping profile ID {profileId}: Not found in source tenant.");
                            continue;
                        }

                        // Create the new profile object for the destination tenant
                        var newProfile = new WindowsFeatureUpdateProfile
                        {
                        };

          
                        foreach (var property in sourceProfile.GetType().GetProperties())
                        {
                            if (property.Name.Equals("createdDateTime", StringComparison.OrdinalIgnoreCase) ||
                                property.Name.Equals("lastModifiedDateTime", StringComparison.OrdinalIgnoreCase))
                            {
                                continue; // Skip these properties
                            }

                            var value = property.GetValue(sourceProfile);
                            if (value != null && property.CanWrite)
                            {
                                property.SetValue(newProfile, value);
                            }
                        }
                        

                        newProfile.Id = "";
                        newProfile.OdataType = "#microsoft.graph.windowsFeatureUpdateProfile";

                        // Create the profile in the destination tenant
                        
                        var importedProfile = await destinationGraphServiceClient.DeviceManagement.WindowsFeatureUpdateProfiles.PostAsync(newProfile);

                        // Add null check for importedProfile and DisplayName
                        rtb.AppendText($"Imported profile: {importedProfile?.DisplayName ?? "Unnamed Profile"} (ID: {importedProfile?.Id ?? "Unknown ID"})\n");
                        WriteToImportStatusFile($"Imported profile: {importedProfile?.DisplayName ?? "Unnamed Profile"} (ID: {importedProfile?.Id ?? "Unknown ID"})");

                        // Handle assignments if requested
                        if (assignments && groups != null && groups.Any() && importedProfile?.Id != null)
                        {
                            await AssignGroupsToSingleWindowsFeatureUpdateProfile(importedProfile.Id, groups, destinationGraphServiceClient, filter); // Pass filter flag if needed for assignment logic
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the specific profile ID that failed
                        HandleException(ex, $"Error importing Windows Feature Update profile with ID {profileId}", false);
                        HandleException(ex, "This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active", false);
                        rtb.AppendText($"Failed to import Windows Feature Update profile ID {profileId}: {ex.Message}\n");
                        rtb.AppendText($"This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active\n");
                        WriteToImportStatusFile($"Failed to import Windows Feature Update profile ID {profileId}: {ex.Message}");
                        WriteToImportStatusFile("This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active");
                    }
                }
                rtb.AppendText("Windows Feature Update profile import process finished.\n");
                WriteToImportStatusFile("Windows Feature Update profile import process finished.");
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the Windows Feature Update profile import process");
                rtb.AppendText($"An error occurred during the import process: {ex.Message}\n");
                WriteToImportStatusFile($"An error occurred during the import process: {ex.Message}");
            }
        }

        public static async Task AssignGroupsToSingleWindowsFeatureUpdateProfile(string profileID, List<string> groupIDs, GraphServiceClient destinationGraphServiceClient, bool applyFilter)
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
                    return; // Nothing to assign
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                WriteToLog($"Assigning {groupIDs.Count} groups to Windows Feature Update profile {profileID}. Apply filter: {applyFilter}");

                List<WindowsFeatureUpdateProfileAssignment> assignments = new List<WindowsFeatureUpdateProfileAssignment>();

                foreach (var groupId in groupIDs)
                {
                    var assignmentTarget = new GroupAssignmentTarget
                    {
                        OdataType = "#microsoft.graph.groupAssignmentTarget",
                        GroupId = groupId,
                        // Filters might be applied differently or not at all for Feature Update profiles compared to Settings Catalog.
                        // Check Graph API documentation for WindowsFeatureUpdateProfileAssignment specifics.
                        // If filters are supported via DeviceAndAppManagementAssignmentFilterId:
                        DeviceAndAppManagementAssignmentFilterId = applyFilter ? SelectedFilterID : null, // Use SelectedFilterID if applyFilter is true
                        DeviceAndAppManagementAssignmentFilterType = applyFilter ? deviceAndAppManagementAssignmentFilterType : Microsoft.Graph.Beta.Models.DeviceAndAppManagementAssignmentFilterType.None, // Use selected filter type or None
                    };

                    var assignment = new WindowsFeatureUpdateProfileAssignment
                    {
                        OdataType = "#microsoft.graph.windowsFeatureUpdateProfileAssignment",
                        Target = assignmentTarget,
                        // Source and SourceId might not be applicable/required here as they were in Settings Catalog assignment.
                        // Check the WindowsFeatureUpdateProfileAssignment documentation.
                    };
                    assignments.Add(assignment);
                }

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.WindowsFeatureUpdateProfiles.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                    // Other properties like 'windowsUpdateForBusinessUpdateWeeks' or 'windowsUpdateForBusinessUpdateDays' might be needed here
                    // depending on the specific assignment requirements for Feature Update profiles.
                };

                try
                {
                    // The Assign action might return void or a specific response type. Adjust accordingly.
                    await destinationGraphServiceClient.DeviceManagement.WindowsFeatureUpdateProfiles[profileID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile($"Successfully assigned {groupIDs.Count} groups to profile {profileID}. Filter applied: {applyFilter}");
                }
                catch (Exception ex)
                {
                    // Log specific error for this assignment attempt
                    HandleException(ex, $"Error assigning groups to Windows Feature Update profile {profileID}");
                    WriteToImportStatusFile($"Error assigning groups to profile {profileID}: {ex.Message}");
                    // Decide if you want to re-throw or just log
                }
            }
            catch (Exception ex)
            {
                // Catch argument null exceptions or other setup errors
                HandleException(ex, "An error occurred while preparing to assign groups to a Windows Feature Update profile");
                WriteToImportStatusFile($"An error occurred while preparing assignment for profile {profileID}: {ex.Message}");
            }
        }
    }
}
