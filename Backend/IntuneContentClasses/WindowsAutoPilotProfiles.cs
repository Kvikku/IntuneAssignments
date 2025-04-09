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

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class WindowsAutoPilotProfiles
    {
        public static async Task<List<WindowsAutopilotDeploymentProfile>> SearchForWindowsAutoPilotProfiles(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for Windows AutoPilot profiles. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.WindowsAutopilotDeploymentProfiles.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                });

                List<WindowsAutopilotDeploymentProfile> profiles = new List<WindowsAutopilotDeploymentProfile>();
                var pageIterator = PageIterator<WindowsAutopilotDeploymentProfile, WindowsAutopilotDeploymentProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                {
                    profiles.Add(profile);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {profiles.Count} Windows AutoPilot profiles.");

                return profiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for Windows AutoPilot profiles");
                return new List<WindowsAutopilotDeploymentProfile>();
            }
        }

        public static async Task<List<WindowsAutopilotDeploymentProfile>> GetAllWindowsAutoPilotProfiles(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all Windows AutoPilot profiles.");

                var result = await graphServiceClient.DeviceManagement.WindowsAutopilotDeploymentProfiles.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                });

                List<WindowsAutopilotDeploymentProfile> profiles = new List<WindowsAutopilotDeploymentProfile>();
                var pageIterator = PageIterator<WindowsAutopilotDeploymentProfile, WindowsAutopilotDeploymentProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                {
                    profiles.Add(profile);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {profiles.Count} Windows AutoPilot profiles.");

                return profiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all Windows AutoPilot profiles");
                return new List<WindowsAutopilotDeploymentProfile>();
            }
        }

        public static void AddWindowsAutoPilotProfilesToDTG(List<WindowsAutopilotDeploymentProfile> profiles, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog("Adding Windows AutoPilot profiles to the DataGridView.");

                foreach (var profile in profiles)
                {
                    if (profile.Id == null || profile.DisplayName == null || profile.Description == null)
                    {
                        throw new InvalidOperationException("Profile properties cannot be null.");
                    }

                    dtg.Rows.Add(profile.DisplayName.ToString(), "Windows AutoPilot Profile", "Windows", profile.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding Windows AutoPilot profiles to the DataGridView");
            }
        }

        public static List<string> GetWindowsAutoPilotProfilesFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Windows AutoPilot Profiles";
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
                HandleException(ex, "An error occurred while retrieving Windows AutoPilot profiles from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleWindowsAutoPilotProfiles(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> profiles, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {profiles.Count} Windows AutoPilot profiles.\n");
                WriteToImportStatusFile($"Importing {profiles.Count} Windows AutoPilot profiles.");

                if (assignments)
                {
                    rtb.AppendText("Group assignments will be added.\n");
                    WriteToImportStatusFile("Group assignments will be added.");
                }

                if (filter)
                {
                    rtb.AppendText("Filters will be added.\n");
                    WriteToImportStatusFile("Filters will be added.");
                }

                foreach (var profile in profiles)
                {
                    try
                    {
                        var result = await sourceGraphServiceClient.DeviceManagement.WindowsAutopilotDeploymentProfiles[profile].GetAsync();

                        // Check what Autopilot profile it is

                        if (result.OdataType.Contains("ActiveDirectory", StringComparison.OrdinalIgnoreCase))
                        {
                            // TODO - Continue
                        }

                        var requestBody = new WindowsAutopilotDeploymentProfile
                        {
                        };

                        foreach (var property in profile.GetType().GetProperties())
                        {
                            var value = property.GetValue(profile);
                            if (value != null && property.CanWrite)
                            {
                                property.SetValue(requestBody, value);
                            }
                        }

                        var import = await destinationGraphServiceClient.DeviceManagement.WindowsAutopilotDeploymentProfiles.PostAsync(requestBody);
                        rtb.AppendText($"Imported profile: {requestBody.DisplayName}\n");
                        WriteToImportStatusFile($"Imported profile: {requestBody.DisplayName}");

                        if (assignments)
                        {
                            await AssignGroupsToSingleWindowsAutoPilotProfile(requestBody.Id, groups, destinationGraphServiceClient);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, $"Error importing profile {profile}", false);
                        rtb.AppendText($"Failed to import {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the import process");
            }
        }

        public static async Task AssignGroupsToSingleWindowsAutoPilotProfile(string profileID, List<string> groupID, GraphServiceClient destinationGraphServiceClient)
        {
            try
            {
                if (profileID == null)
                {
                    throw new ArgumentNullException(nameof(profileID));
                }

                if (groupID == null)
                {
                    throw new ArgumentNullException(nameof(groupID));
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                List<WindowsAutopilotDeploymentProfileAssignment> assignments = new List<WindowsAutopilotDeploymentProfileAssignment>();

                foreach (var group in groupID)
                {
                    var assignment = new WindowsAutopilotDeploymentProfileAssignment
                    {
                        OdataType = "#microsoft.graph.windowsAutopilotDeploymentProfileAssignment",
                        Id = group,
                        Target = new GroupAssignmentTarget
                        {
                            OdataType = "#microsoft.graph.groupAssignmentTarget",
                            DeviceAndAppManagementAssignmentFilterId = SelectedFilterID,
                            DeviceAndAppManagementAssignmentFilterType = deviceAndAppManagementAssignmentFilterType,
                            GroupId = group,
                        },
                        Source = DeviceAndAppManagementAssignmentSource.Direct,
                        SourceId = group,
                    };
                    assignments.Add(assignment);
                }

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.WindowsAutopilotDeploymentProfiles.Item.Assign.AssignPostRequestBody
                {
                    
                };

                try
                {
                    await destinationGraphServiceClient.DeviceManagement.WindowsAutopilotDeploymentProfiles[profileID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile("Assigned groups to profile " + profileID + " with filter type" + deviceAndAppManagementAssignmentFilterType.ToString());
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to profile {profileID}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while assigning groups to a single Windows AutoPilot profile");
            }
        }
    }
}
