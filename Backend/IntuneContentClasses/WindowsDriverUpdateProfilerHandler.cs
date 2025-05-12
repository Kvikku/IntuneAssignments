using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Kiota.Abstractions; // Added for RequestInformation
using Microsoft.Kiota.Abstractions.Serialization; // Added for ParsableFactory
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Added for DataGridView and RichTextBox
using static IntuneAssignments.Backend.IntuneContentClasses.Filters; // Assuming Filters are needed
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class WindowsDriverUpdateProfilerHandler
    {
        public static async Task<List<WindowsDriverUpdateProfile>> SearchForDriverProfiles(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for Windows Driver Update Profiles. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.WindowsDriverUpdateProfiles.GetAsync();

                List<WindowsDriverUpdateProfile> driverProfiles = new List<WindowsDriverUpdateProfile>();

                if (result?.Value != null) // Check if result and Value are not null
                {
                    // Use PageIterator to handle paginated results
                    var pageIterator = PageIterator<WindowsDriverUpdateProfile, WindowsDriverUpdateProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                    {
                        if (!string.IsNullOrEmpty(profile.DisplayName) && profile.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                        {
                            driverProfiles.Add(profile);
                        }
                        return true;
                    });
                    await pageIterator.IterateAsync();

                    WriteToLog($"Found {driverProfiles.Count} Windows Driver Update Profiles matching the search query.");
                }
                else
                {
                     WriteToLog("No Windows Driver Update Profiles found matching the search query or the result was null.");
                }


                return driverProfiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for Windows Driver Update Profiles");
                return new List<WindowsDriverUpdateProfile>();
            }
        }

        public static async Task<List<WindowsDriverUpdateProfile>> GetAllDriverProfiles(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all Windows Driver Update Profiles.");

                var result = await graphServiceClient.DeviceManagement.WindowsDriverUpdateProfiles.GetAsync();

                List<WindowsDriverUpdateProfile> driverProfiles = new List<WindowsDriverUpdateProfile>();

                if (result?.Value != null) // Check if result and Value are not null
                {
                    var pageIterator = PageIterator<WindowsDriverUpdateProfile, WindowsDriverUpdateProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                    {
                        driverProfiles.Add(profile);
                        return true;
                    });
                    await pageIterator.IterateAsync();
                    WriteToLog($"Found {driverProfiles.Count} Windows Driver Update Profiles.");
                }
                 else
                {
                     WriteToLog("No Windows Driver Update Profiles found or the result was null.");
                }

                return driverProfiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all Windows Driver Update Profiles");
                return new List<WindowsDriverUpdateProfile>();
            }
        }

        public static void AddDriverProfilesToDTG(List<WindowsDriverUpdateProfile> profiles, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog("Adding Windows Driver Update Profiles to the DataGridView.");

                foreach (var profile in profiles)
                {
                    // Check only essential properties used in the Add method
                    if (profile.Id == null || profile.DisplayName == null)
                    {
                        WriteToLog($"Skipping profile with null ID or DisplayName: ID={profile.Id ?? "null"}, Name={profile.DisplayName ?? "null"}");
                        continue;
                    }

                    // Assuming the DTG columns are: Name, Type, Platform (might not apply), ID
                    // Adjust column indices and values as needed for WindowsDriverUpdateProfile
                    // Platform is implicitly Windows for these profiles.
                    dtg.Rows.Add(profile.DisplayName, "Windows Driver Update Profile", "Windows", profile.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding Windows Driver Update Profiles to the DataGridView");
            }
        }

        public static List<string> GetDriverProfilesFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Windows Driver Update Profile"; // Updated type string
                List<string> matchingRows = new List<string>();

                foreach (DataGridViewRow row in dtg.Rows)
                {
                    // Adjust column indices based on your DataGridView setup
                    // Assuming Type is column 1 and ID is column 3
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
                HandleException(ex, "An error occurred while retrieving Windows Driver Update Profiles from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleDriverProfiles(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> profileIds, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {profileIds.Count} Windows Driver Update Profiles.\n"); // Corrected newline
                WriteToImportStatusFile($"Importing {profileIds.Count} Windows Driver Update Profiles.");

                if (assignments)
                {
                    rtb.AppendText("Group assignments will be added.\n"); // Corrected newline
                    WriteToImportStatusFile("Group assignments will be added.");
                }

                // Note: Filters might not directly apply to Driver Update Profiles in the same way as Settings Catalog.
                // Review if filter logic is needed or how it applies here.
                if (filter)
                {
                    rtb.AppendText("Filters will be added (if applicable).\n"); // Corrected newline
                    WriteToImportStatusFile("Filters will be added (if applicable).");
                }

                foreach (var profileId in profileIds)
                {
                    var profileName = "";
                    try
                    {
                        // Get the source profile
                        var sourceProfile = await sourceGraphServiceClient.DeviceManagement.WindowsDriverUpdateProfiles[profileId].GetAsync();

                        if (sourceProfile == null)
                        {
                             WriteToImportStatusFile($"Profile with ID {profileId} not found in source tenant."); // Removed LogType
                             WriteErrorToRTB($"Profile with ID {profileId} not found in source tenant.", rtb);
                             continue;
                        }

                        profileName = sourceProfile.DisplayName ?? "Unknown Profile"; // Handle potential null DisplayName

                        // Create the new profile object for the destination tenant
                        // Map relevant properties. Check API documentation for required/allowed properties.
                        var newProfile = new WindowsDriverUpdateProfile
                        {
                            OdataType = "#microsoft.graph.windowsDriverUpdateProfile",
                            DisplayName = sourceProfile.DisplayName,
                            Description = sourceProfile.Description,
                            ApprovalType = sourceProfile.ApprovalType,
                            RoleScopeTagIds = sourceProfile.RoleScopeTagIds,
                            DeploymentDeferralInDays = sourceProfile.DeploymentDeferralInDays
                        };


                        var importResult = await destinationGraphServiceClient.DeviceManagement.WindowsDriverUpdateProfiles.PostAsync(newProfile);
                        rtb.AppendText($"Imported profile: {importResult?.DisplayName ?? "Unknown"}\n"); // Corrected newline, added null check
                        WriteToImportStatusFile($"Imported profile: {importResult?.DisplayName ?? "Unknown"}"); // Added null check

                        if (assignments && importResult?.Id != null)
                        {
                            // Assign groups using the specific method for Driver Update Profiles
                            await AssignGroupsToSingleDriverProfile(importResult.Id, groups, destinationGraphServiceClient, filter); // Pass filter status
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the specific policy ID that failed
                        HandleException(ex, $"Error importing Windows Driver Update policy with ID {profileId}", false);
                        HandleException(ex, "This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active", false);
                        rtb.AppendText($"Failed to import Windows Driver Update policy ID {profileId}: {ex.Message}\n");
                        rtb.AppendText($"This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active\n");
                        WriteToImportStatusFile($"Failed to import Windows Driver Update policy ID {profileId}: {ex.Message}");
                        WriteToImportStatusFile("This is most likely due to the feature not being licensed in the destination tenant. Please check that you have a Windows E3 or higher license active");
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the driver profile import process");
                WriteErrorToRTB("An unexpected error occurred during the import process. Check logs.", rtb);
            }
        }


        // Note: Assignment structure for Driver Update Profiles differs from Settings Catalog.
        public static async Task AssignGroupsToSingleDriverProfile(string profileID, List<string> groupIDs, GraphServiceClient destinationGraphServiceClient, bool useFilter)
        {
            try
            {
                if (string.IsNullOrEmpty(profileID))
                {
                    throw new ArgumentNullException(nameof(profileID));
                }

                if (groupIDs == null || !groupIDs.Any())
                {
                     WriteToLog($"No groups provided for assignment to profile {profileID}."); // Removed LogType
                    return; // Nothing to assign
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                WriteToLog($"Assigning {groupIDs.Count} groups to driver profile {profileID}. Filter enabled: {useFilter}");


                var assignments = new List<WindowsDriverUpdateProfileAssignment>();

                foreach (var groupId in groupIDs)
                {
                     var assignment = new WindowsDriverUpdateProfileAssignment
                     {
                         OdataType = "#microsoft.graph.windowsDriverUpdateProfileAssignment",
                         Target = new GroupAssignmentTarget
                         {
                             OdataType = "#microsoft.graph.groupAssignmentTarget",
                             GroupId = groupId,
                             // Apply filter information if 'useFilter' is true and a filter is selected
                             DeviceAndAppManagementAssignmentFilterId = useFilter ? SelectedFilterID : null, // Use SelectedFilterID from GlobalVariables
                             DeviceAndAppManagementAssignmentFilterType = useFilter ? deviceAndAppManagementAssignmentFilterType : Microsoft.Graph.Beta.Models.DeviceAndAppManagementAssignmentFilterType.None // Use type from GlobalVariables
                         }
                         // Source and SourceId might not be applicable/required for driver profile assignments directly via POST /assign
                     };
                     assignments.Add(assignment);
                }


                // The endpoint for assigning driver profiles is different
                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.WindowsDriverUpdateProfiles.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                };


                try
                {
                    // Use the correct endpoint and method for driver profile assignment
                    await destinationGraphServiceClient.DeviceManagement.WindowsDriverUpdateProfiles[profileID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile($"Successfully initiated assignment of {groupIDs.Count} groups to profile {profileID}. Filter: {SelectedFilterID ?? "None"}");
                }
                catch (ServiceException svcex)
                {
                     // More specific error handling for Graph API calls
                     // Extracting the error message might require inspecting the exception details further
                     string errorMessage = svcex.Message; // Basic message
                     // Consider logging svcex.ToString() for more details if needed
                     HandleException(svcex, $"Graph API error assigning groups to profile {profileID}. Status Code: {svcex.ResponseStatusCode}. Error: {errorMessage}");
                     WriteToImportStatusFile($"Graph API error assigning groups to profile {profileID}: {errorMessage}"); // Removed LogType
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to profile {profileID}");
                    WriteToImportStatusFile($"Error assigning groups to profile {profileID}: {ex.Message}"); // Removed LogType
                }
            }
            catch (ArgumentNullException argEx)
            {
                 HandleException(argEx, "Argument null exception during group assignment setup.");
            }
            catch (Exception ex)
            {
                // Catch unexpected errors during the setup phase
                HandleException(ex, "An unexpected error occurred while preparing group assignments for a driver profile.");
            }
        }


        public static async Task DeleteDriverProfile(GraphServiceClient graphServiceClient, string profileID)
        {
            try
            {
                if (graphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(graphServiceClient));
                }

                if (string.IsNullOrEmpty(profileID))
                {
                     throw new ArgumentNullException(nameof(profileID), "Profile ID cannot be null or empty.");
                }

                WriteToLog($"Attempting to delete Windows Driver Update Profile with ID: {profileID}");
                await graphServiceClient.DeviceManagement.WindowsDriverUpdateProfiles[profileID].DeleteAsync();
                WriteToLog($"Successfully deleted Windows Driver Update Profile with ID: {profileID}");
            }
             catch (ServiceException svcex) when (svcex.ResponseStatusCode == (int)System.Net.HttpStatusCode.NotFound) // Corrected comparison
            {
                // Handle case where the profile doesn't exist (might have been deleted already)
                WriteToLog($"Windows Driver Update Profile with ID {profileID} not found. It might have already been deleted."); // Removed LogType
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while deleting Windows Driver Update Profile with ID: {profileID}");
            }
        }
    }
}
