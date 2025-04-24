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
using static IntuneAssignments.Backend.IntuneContentClasses.Filters; // Assuming Filters might be needed later
using System.Windows.Forms; // Added for DataGridView and RichTextBox

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class ShellScriptmacOS
    {
        /*
         * TODO
         * Search
         * List all
         * Add to dtg
         * Import content
         * Assignment
         * Filter (Note: Filters might not apply directly to shell scripts in the same way as Settings Catalog)
         */

        public static async Task<List<DeviceShellScript>> SearchForShellScriptmacOS(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for macOS shell scripts. Search query: " + searchQuery);

                // Note: The Graph API for DeviceShellScript might not support filtering by name directly in the same way.
                // This might require fetching all and filtering locally, or adjusting the query if supported.
                // For now, let's assume a similar filter structure, but this might need adjustment.
                var result = await graphServiceClient.DeviceManagement.DeviceShellScripts.GetAsync((requestConfiguration) =>
                {
                    // Filter for macOS platform and name contains search query
                    requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                    requestConfiguration.QueryParameters.Top = 1000; // Adjust as needed
                });

                List<DeviceShellScript> shellScripts = new List<DeviceShellScript>();
                var pageIterator = PageIterator<DeviceShellScript, DeviceShellScriptCollectionResponse>.CreatePageIterator(graphServiceClient, result, (script) =>
                {
                    shellScripts.Add(script);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {shellScripts.Count} macOS shell scripts matching the search.");

                return shellScripts;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for macOS shell scripts");
                return new List<DeviceShellScript>();
            }
        }

        public static async Task<List<DeviceShellScript>> GetAllShellScriptmacOS(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all macOS shell scripts.");

                var result = await graphServiceClient.DeviceManagement.DeviceShellScripts.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000; // Adjust as needed
                });

                List<DeviceShellScript> shellScripts = new List<DeviceShellScript>();
                var pageIterator = PageIterator<DeviceShellScript, DeviceShellScriptCollectionResponse>.CreatePageIterator(graphServiceClient, result, (script) =>
                {
                    shellScripts.Add(script);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {shellScripts.Count} macOS shell scripts.");

                return shellScripts;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all macOS shell scripts");
                return new List<DeviceShellScript>();
            }
        }

        public static void AddShellScriptmacOSToDTG(List<DeviceShellScript> scripts, System.Windows.Forms.DataGridView dtg)
        {
            try
            {
                if (scripts == null)
                {
                    throw new ArgumentNullException(nameof(scripts), "The scripts list cannot be null.");
                }

                if (dtg == null)
                {
                    throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
                }

                WriteToLog("Adding macOS shell scripts to the DataGridView.");

                foreach (var script in scripts)
                {
                    if (script.Id == null || script.DisplayName == null) // Description might be null
                    {
                        // Log or handle appropriately if critical properties are missing
                        WriteToLog($"Skipping script with missing ID or DisplayName. ID: {script.Id}, Name: {script.DisplayName}");
                        continue;
                        // Or throw: throw new InvalidOperationException("Script properties (ID, DisplayName) cannot be null.");
                    }

                    // Assuming columns are: Name, Type, Platform, ID
                    dtg.Rows.Add(script.DisplayName, "macOS Shell Script", "macOS", script.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding macOS shell scripts to the DataGridView");
            }
        }

        public static List<string> GetShellScriptmacOSFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "macOS Shell Script"; // Match the type added in AddShellScriptmacOSToDTG
                List<string> matchingRows = new List<string>();

                foreach (DataGridViewRow row in dtg.Rows)
                {
                    // Check column 1 for type and column 3 for ID
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == type && row.Cells[3].Value != null)
                    {
                        var cellValue = row.Cells[3].Value?.ToString();
                        if (cellValue != null)
                        {
                            matchingRows.Add(cellValue);
                        }
                    }
                }
                WriteToLog($"Retrieved {matchingRows.Count} macOS shell script IDs from the DataGridView.");
                return matchingRows;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving macOS shell scripts from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleShellScriptmacOS(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> scriptIDs, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {scriptIDs.Count} macOS shell scripts.\n");
                WriteToImportStatusFile($"Importing {scriptIDs.Count} macOS shell scripts.");

                if (assignments)
                {
                    rtb.AppendText("Group assignments will be added.\n");
                    WriteToImportStatusFile("Group assignments will be added.");
                }

                // Note: Filters might not be applicable to Shell Scripts in the same way.
                // The 'filter' parameter usage might need reconsideration for shell scripts.
                if (filter)
                {
                    rtb.AppendText("Filters will be added (Note: Filter application might differ for shell scripts).\n");
                    WriteToImportStatusFile("Filters will be added (Note: Filter application might differ for shell scripts).");
                }

                foreach (var scriptId in scriptIDs)
                {
                    try
                    {
                        // Get the full script object, including script content
                        var sourceScript = await sourceGraphServiceClient.DeviceManagement.DeviceShellScripts[scriptId].GetAsync();


                        if (sourceScript == null)
                        {
                             rtb.AppendText($"Script with ID {scriptId} not found in source tenant. Skipping.\n");
                             WriteToImportStatusFile($"Script with ID {scriptId} not found in source tenant. Skipping.");
                             continue;
                        }

                        var newScript = new DeviceShellScript
                        {
                            
                        };

                        foreach (var property in sourceScript.GetType().GetProperties())
                        {
                            var value = property.GetValue(sourceScript);
                            if (value != null && property.CanWrite)
                            {
                                property.SetValue(newScript, value);
                            }
                        }

                        var importResult = await destinationGraphServiceClient.DeviceManagement.DeviceShellScripts.PostAsync(newScript);

                        if (importResult != null)
                        {
                            rtb.AppendText($"Imported script: {importResult.DisplayName}\n");
                            WriteToImportStatusFile($"Imported script: {importResult.DisplayName} (ID: {importResult.Id})");

                            if (assignments && groups != null && groups.Any())
                            {
                                // Shell script assignments use a different structure
                                await AssignGroupsToSingleShellScriptmacOS(importResult.Id, groups, destinationGraphServiceClient, filter); // Pass filter bool if needed for assignment logic
                            }
                        }
                        else
                        {
                             rtb.AppendText($"Failed to import script: {sourceScript.DisplayName} (ID: {scriptId}). Result was null.\n");
                             WriteToImportStatusFile($"Failed to import script: {sourceScript.DisplayName} (ID: {scriptId}). Result was null.");
                        }

                    }
                    catch (Exception ex)
                    {
                        // Attempt to get the script name for better logging if possible
                        string scriptNameToLog = scriptId;
                        try {
                            var failedScript = dtg.Rows.Cast<DataGridViewRow>()
                                                .FirstOrDefault(r => r.Cells[3].Value?.ToString() == scriptId);
                            if (failedScript != null && failedScript.Cells[0].Value != null) {
                                scriptNameToLog = failedScript.Cells[0].Value.ToString();
                            }
                        } catch {} // Ignore errors during name lookup for logging

                        HandleException(ex, $"Error importing macOS shell script '{scriptNameToLog}' (ID: {scriptId})", false);
                        rtb.AppendText($"Failed to import script '{scriptNameToLog}': {ex.Message}\n");
                        WriteToImportStatusFile($"Failed to import script '{scriptNameToLog}' (ID: {scriptId}): {ex.Message}");
                    }
                }
                 rtb.AppendText("macOS shell script import process finished.\n");
                 WriteToImportStatusFile("macOS shell script import process finished.");
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the macOS shell script import process");
                 rtb.AppendText($"An error occurred during the macOS shell script import process: {ex.Message}\n");
                 WriteToImportStatusFile($"An error occurred during the macOS shell script import process: {ex.Message}");
            }
        }


        // Note: Assignment structure for Shell Scripts is different from Configuration Policies
        public static async Task AssignGroupsToSingleShellScriptmacOS(string scriptId, List<string> groupIDs, GraphServiceClient destinationGraphServiceClient, bool applyFilter)
        {
            if (string.IsNullOrEmpty(scriptId))
            {
                throw new ArgumentNullException(nameof(scriptId));
            }
            if (groupIDs == null || !groupIDs.Any())
            {
                WriteToLog($"No group IDs provided for assignment to script {scriptId}. Skipping assignment.");
                return; // Nothing to assign
            }
            if (destinationGraphServiceClient == null)
            {
                throw new ArgumentNullException(nameof(destinationGraphServiceClient));
            }

            WriteToLog($"Assigning {groupIDs.Count} groups to macOS shell script {scriptId}. Apply Filter: {applyFilter}");


            var assignments = new List<DeviceManagementScriptGroupAssignment>();

            foreach (var groupId in groupIDs)
            {
                 if (string.IsNullOrEmpty(groupId)) {
                    WriteToLog($"Skipping empty or null group ID during assignment to script {scriptId}.");
                    continue;
                }

                assignments.Add(new DeviceManagementScriptGroupAssignment
                {
                    OdataType = "#microsoft.graph.deviceManagementScriptGroupAssignment",
                    TargetGroupId = groupId
                    // Filters are not directly part of the group assignment object for shell scripts.
                    // They are associated with the assignment target within the policy/script object itself,
                    // but the Assign action for scripts might not support setting filters directly.
                    // This might require updating the script object after creation if filters are needed.
                });
            }

             if (!assignments.Any()) {
                WriteToLog($"No valid group assignments to process for script {scriptId}.");
                return;
            }


            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceShellScripts.Item.Assign.AssignPostRequestBody
            {
                DeviceManagementScriptGroupAssignments = assignments,
                // DeviceManagementScriptAssignments = null // Use GroupAssignments for assigning to groups
            };

            try
            {
                // The Assign action for shell scripts might return void or a different response type. Adjust accordingly.
                await destinationGraphServiceClient.DeviceManagement.DeviceShellScripts[scriptId].Assign.PostAsync(requestBody);
                WriteToImportStatusFile($"Successfully submitted assignment request for {assignments.Count} groups to macOS shell script {scriptId}.");

                 // If filters need to be applied, it might require a separate PATCH request to update the script's assignments property,
                 // potentially fetching the script again to get assignment IDs if necessary. This is more complex.
                 if (applyFilter && !string.IsNullOrEmpty(SelectedFilterID)) {
                     WriteToImportStatusFile($"Filter application requested for script {scriptId}, but direct filter assignment via Assign action might not be supported for shell scripts. Manual verification/update might be needed.");
                     // TODO: Implement filter application logic if possible/required via script update.
                 }
            }
            catch (Exception ex)
            {
                HandleException(ex, $"Error assigning groups to macOS shell script {scriptId}");
                WriteToImportStatusFile($"Error assigning groups to macOS shell script {scriptId}: {ex.Message}");
                // Rethrow or handle as appropriate for the application flow
                // throw;
            }
        }

    }
}
