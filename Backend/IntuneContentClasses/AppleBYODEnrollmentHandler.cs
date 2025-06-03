using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ODataErrors; // Added for ODataError
using Microsoft.Kiota.Abstractions; // Added for RequestInformation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Added for DataGridView and RichTextBox
using static IntuneAssignments.Backend.IntuneContentClasses.Filters; // Assuming Filters might be needed
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class AppleBYODEnrollmentHandler
    {
        private const string PolicyType = "Apple User Initiated Enrollment Profile";

        public static async Task<List<AppleUserInitiatedEnrollmentProfile>> SearchForAppleBYODEnrollmentProfiles(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog($"Searching for {PolicyType} policies. Search query: {searchQuery}");

                var result = await graphServiceClient.DeviceManagement.AppleUserInitiatedEnrollmentProfiles.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(DisplayName,'{searchQuery}')";
                });

                if (result == null || result.Value == null)
                {
                    WriteToLog($"Search returned null or empty result for {PolicyType} policies.");
                    return new List<AppleUserInitiatedEnrollmentProfile>();
                }

                List<AppleUserInitiatedEnrollmentProfile> enrollmentProfiles = new List<AppleUserInitiatedEnrollmentProfile>();
                var pageIterator = PageIterator<AppleUserInitiatedEnrollmentProfile, AppleUserInitiatedEnrollmentProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                {
                    enrollmentProfiles.Add(profile);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {enrollmentProfiles.Count} {PolicyType} policies.");

                return enrollmentProfiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while searching for {PolicyType} policies");
                return new List<AppleUserInitiatedEnrollmentProfile>();
            }
        }

        public static async Task<List<AppleUserInitiatedEnrollmentProfile>> GetAllAppleBYODEnrollmentProfiles(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog($"Retrieving all {PolicyType} policies.");

                var result = await graphServiceClient.DeviceManagement.AppleUserInitiatedEnrollmentProfiles.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 999;
                });

                if (result == null || result.Value == null)
                {
                     WriteToLog($"Get all returned null or empty result for {PolicyType} policies.");
                     return new List<AppleUserInitiatedEnrollmentProfile>();
                }

                List<AppleUserInitiatedEnrollmentProfile> enrollmentProfiles = new List<AppleUserInitiatedEnrollmentProfile>();
                var pageIterator = PageIterator<AppleUserInitiatedEnrollmentProfile, AppleUserInitiatedEnrollmentProfileCollectionResponse>.CreatePageIterator(graphServiceClient, result, (profile) =>
                {
                    enrollmentProfiles.Add(profile);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {enrollmentProfiles.Count} {PolicyType} policies.");

                return enrollmentProfiles;
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while retrieving all {PolicyType} policies");
                return new List<AppleUserInitiatedEnrollmentProfile>();
            }
        }

        public static void AddAppleBYODEnrollmentProfilesToDTG(List<AppleUserInitiatedEnrollmentProfile> profiles, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog($"Adding {PolicyType} policies to the DataGridView.");

                foreach (var profile in profiles)
                {
                    if (profile.Id == null || profile.DisplayName == null)
                    {
                        WriteToLog($"Skipping profile with null Id or DisplayName: {profile.Id ?? "N/A"}");
                        continue;
                    }
                    dtg.Rows.Add(profile.DisplayName, PolicyType, "iOS/iPadOS/macOS", profile.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while adding {PolicyType} policies to the DataGridView");
            }
        }

        public static List<string> GetAppleBYODEnrollmentProfilesFromDTG(DataGridView dtg)
        {
            try
            {
                List<string> matchingRows = new List<string>();

                foreach (DataGridViewRow row in dtg.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == PolicyType && row.Cells[3].Value != null)
                    {
                        var cellValue = row.Cells[3].Value?.ToString();
                        if (cellValue != null)
                        {
                            matchingRows.Add(cellValue);
                        }
                    }
                }
                WriteToLog($"Retrieved {matchingRows.Count} {PolicyType} IDs from DataGridView.");
                return matchingRows;
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while retrieving {PolicyType} from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleAppleBYODEnrollmentProfiles(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> profileIds, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText(Environment.NewLine);
                rtb.AppendText($"{DateTime.Now.ToString()} - Importing {profileIds.Count} {PolicyType}(s).\n");
                WriteToImportStatusFile(" ");
                WriteToImportStatusFile($"{DateTime.Now.ToString()} - Importing {profileIds.Count} {PolicyType}(s).");

                foreach (var profileId in profileIds)
                {
                    // FIX: Declare sourceProfile outside the try block to be accessible in catch
                    AppleUserInitiatedEnrollmentProfile? sourceProfile = null;
                    var profileName = string.Empty;

                    try
                    {
                        sourceProfile = await sourceGraphServiceClient.DeviceManagement.AppleUserInitiatedEnrollmentProfiles[profileId].GetAsync();

                        if (sourceProfile == null)
                        {
                             rtb.AppendText($"Skipping profile ID {profileId}: Not found in source tenant.\n");
                             WriteToImportStatusFile($"Skipping profile ID {profileId}: Not found in source tenant.");
                             continue;
                        }

                        profileName = sourceProfile.DisplayName ?? "Unknown Profile";

                        var newProfile = new AppleUserInitiatedEnrollmentProfile
                        {

                        };

                        // Get the type of the policy with reflection
                        var type = sourceProfile.GetType();

                        // Create a new instance of the same type
                        var newPolicy = Activator.CreateInstance(type);

                        // Copy all settings from the source policy to the new policy
                        foreach (var property in sourceProfile.GetType().GetProperties())
                        {
                            if (property.CanWrite && property.Name != "Id" && property.Name != "CreatedDateTime" && property.Name != "LastModifiedDateTime")
                            {
                                var value = property.GetValue(sourceProfile);
                                if (value != null)
                                {
                                    property.SetValue(newProfile, value);
                                }
                            }
                        }

                        var importedProfile = await destinationGraphServiceClient.DeviceManagement.AppleUserInitiatedEnrollmentProfiles.PostAsync(newProfile);

                        rtb.AppendText($"Successfully imported {importedProfile.DisplayName}\n");
                        WriteToImportStatusFile($"Successfully imported {importedProfile.DisplayName}");

                        if (assignments && groups != null && groups.Any())
                        {
                            await AssignGroupsToSingleAppleBYODEnrollmentProfile(importedProfile.Id, groups, destinationGraphServiceClient, filter);
                        }

                        // TODO - delete this code block if not needed

                        //if (importedProfile != null && !string.IsNullOrEmpty(importedProfile.Id))
                        //{
                        //    rtb.AppendText($"Successfully imported {importedProfile.DisplayName}\n");
                        //    WriteToImportStatusFile($"Successfully imported {importedProfile.DisplayName}");

                        //    if (assignments && groups != null && groups.Any())
                        //    {
                        //        await AssignGroupsToSingleAppleBYODEnrollmentProfile(importedProfile.Id, groups, destinationGraphServiceClient, filter);
                        //    }
                        //}
                        //else
                        //{
                        //     rtb.AppendText($"Error importing {sourceProfile.DisplayName}\n");
                        //     WriteToImportStatusFile($"Error importing {sourceProfile.DisplayName} (ID: {profileId}).");
                        //}
                    }
                    catch (Exception ex)
                    {
                        WriteErrorToRTB($"Failed to import {profileName}\n",rtb);
                        WriteToImportStatusFile($"Failed to import {profileName}: {ex.Message}",LogType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrorToRTB($"An unexpected error occurred during the import process: {ex.Message}", rtb);
                WriteToImportStatusFile($"An unexpected error occurred during the import process: {ex.Message}", LogType.Error);
            }
            finally
            {
                rtb.AppendText($"{DateTime.Now.ToString()} - Import process for {PolicyType} completed.\n");
                WriteToImportStatusFile($" {DateTime.Now.ToString()} - Import process {PolicyType} completed.");
            }
        }

        public static async Task AssignGroupsToSingleAppleBYODEnrollmentProfile(string profileId, List<string> groupIds, GraphServiceClient destinationGraphServiceClient, bool applyFilter)
        {
            try
            {
                if (groupIds == null || !groupIds.Any())
                {
                    WriteToLog($"No group IDs provided for assignment to profile {profileId}. Skipping assignment.");
                    return;
                }
                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                WriteToLog($"Assigning {groupIds.Count} groups to {PolicyType} profile ID: {profileId}. Apply filter: {applyFilter}");

                foreach (var groupId in groupIds)
                {
                    var assignment = new AppleEnrollmentProfileAssignment
                    {
                        OdataType = "#microsoft.graph.appleEnrollmentProfileAssignment",
                        Target = new GroupAssignmentTarget
                        {
                            OdataType = "#microsoft.graph.groupAssignmentTarget",
                            GroupId = groupId,
                            DeviceAndAppManagementAssignmentFilterId = applyFilter ? SelectedFilterID : null,
                            DeviceAndAppManagementAssignmentFilterType = applyFilter ? deviceAndAppManagementAssignmentFilterType : DeviceAndAppManagementAssignmentFilterType.None
                        }
                    };

                    try
                    {
                        await destinationGraphServiceClient.DeviceManagement.AppleUserInitiatedEnrollmentProfiles[profileId].Assignments.PostAsync(assignment);

                        string filterInfo = applyFilter && !string.IsNullOrEmpty(SelectedFilterID) ? $" with filter ID {SelectedFilterID} (Type: {deviceAndAppManagementAssignmentFilterType})" : "";
                        WriteToLog($"Successfully assigned group {groupId} to profile {profileId}{filterInfo}.");
                        WriteToImportStatusFile($"Assigned group {groupId} to profile {profileId}{filterInfo}.");
                    }
                    catch (ODataError odataError)
                    {
                        HandleException(odataError, $"Graph API error assigning group {groupId} to profile {profileId}: {odataError.Error?.Message}");
                        WriteToImportStatusFile($"Graph API error assigning group {groupId} to profile {profileId}: {odataError.Error?.Code} - {odataError.Error?.Message}");
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, $"Error assigning group {groupId} to profile {profileId}");
                        WriteToImportStatusFile($"Error assigning group {groupId} to profile {profileId}: {ex.Message}");
                    }
                }
            }
            catch (ArgumentNullException argEx)
            {
                 HandleException(argEx, $"Invalid argument provided for assigning groups to {PolicyType}");
                 WriteToImportStatusFile($"Invalid argument provided for assigning groups to {PolicyType}: {argEx.Message}");
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An unexpected error occurred while preparing group assignments for {PolicyType} profile ID {profileId}");
                WriteToImportStatusFile($"An unexpected error occurred while preparing group assignments for {PolicyType} profile ID {profileId}: {ex.Message}");
            }
        }

        public static async Task DeleteAppleBYODEnrollmentProfile(GraphServiceClient graphServiceClient, string profileID)
        {
            try
            {
                if (graphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(graphServiceClient));
                }

                if (profileID == null)
                {
                    throw new InvalidOperationException("Profile ID cannot be null.");
                }



                await graphServiceClient.DeviceManagement.AppleUserInitiatedEnrollmentProfiles[profileID].DeleteAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while deleting Apple BYOD Enrollment profiles");
            }
        }
    }
}
