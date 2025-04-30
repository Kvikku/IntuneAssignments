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
    public class PowerShellScripts
    {
        public static async Task<List<DeviceManagementScript>> SearchForPowerShellScripts(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for PowerShell scripts. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.DeviceManagementScripts.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                });

                List<DeviceManagementScript> scripts = new List<DeviceManagementScript>();
                var pageIterator = PageIterator<DeviceManagementScript, DeviceManagementScriptCollectionResponse>.CreatePageIterator(graphServiceClient, result, (script) =>
                {
                    scripts.Add(script);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {scripts.Count} PowerShell scripts.");

                return scripts;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for PowerShell scripts");
                return new List<DeviceManagementScript>();
            }
        }

        public static async Task<List<DeviceManagementScript>> GetAllPowerShellScripts(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all PowerShell scripts.");

                var result = await graphServiceClient.DeviceManagement.DeviceManagementScripts.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                });

                List<DeviceManagementScript> scripts = new List<DeviceManagementScript>();
                var pageIterator = PageIterator<DeviceManagementScript, DeviceManagementScriptCollectionResponse>.CreatePageIterator(graphServiceClient, result, (script) =>
                {
                    scripts.Add(script);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {scripts.Count} PowerShell scripts.");

                return scripts;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all PowerShell scripts");
                return new List<DeviceManagementScript>();
            }
        }

        public static void AddPowerShellScriptsToDTG(List<DeviceManagementScript> scripts, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog("Adding PowerShell scripts to the DataGridView.");

                foreach (var script in scripts)
                {
                    if (script.Id == null || script.DisplayName == null || script.Description == null)
                    {
                        throw new InvalidOperationException("Script properties cannot be null.");
                    }

                    dtg.Rows.Add(script.DisplayName.ToString(), "PowerShell Script", "Windows", script.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding PowerShell scripts to the DataGridView");
            }
        }

        public static List<string> GetPowerShellScriptsFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "PowerShell Script";
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
                HandleException(ex, "An error occurred while retrieving PowerShell scripts from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultiplePowerShellScripts(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> scripts, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {scripts.Count} PowerShell scripts.\n");
                WriteToImportStatusFile($"Importing {scripts.Count} PowerShell scripts.");

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

                foreach (var script in scripts)
                {
                    try
                    {
                        var result = await sourceGraphServiceClient.DeviceManagement.DeviceManagementScripts[script].GetAsync();

                        var requestBody = new DeviceManagementScript
                        {
                        };

                        foreach (var property in result.GetType().GetProperties())
                        {
                            var value = property.GetValue(result);
                            if (value != null && property.CanWrite)
                            {
                                property.SetValue(requestBody, value);
                            }
                        }

                        requestBody.Id = "";

                        var import = await destinationGraphServiceClient.DeviceManagement.DeviceManagementScripts.PostAsync(requestBody);
                        rtb.AppendText($"Imported script: {requestBody.DisplayName}\n");
                        WriteToImportStatusFile($"Imported script: {requestBody.DisplayName}");

                        if (assignments)
                        {
                            await AssignGroupsToSinglePowerShellScript(import.Id, groups, destinationGraphServiceClient);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, $"Error importing script {script}", false);
                        rtb.AppendText($"Failed to import {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the import process");
            }
        }

        public static async Task AssignGroupsToSinglePowerShellScript(string scriptID, List<string> groupID, GraphServiceClient destinationGraphServiceClient)
        {
            try
            {
                if (scriptID == null)
                {
                    throw new ArgumentNullException(nameof(scriptID));
                }

                if (groupID == null)
                {
                    throw new ArgumentNullException(nameof(groupID));
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                List<DeviceManagementScriptAssignment> assignments = new List<DeviceManagementScriptAssignment>();

                foreach (var group in groupID)
                {
                    var assignment = new DeviceManagementScriptAssignment
                    {
                        OdataType = "#microsoft.graph.deviceManagementScriptAssignment",
                        Id = group,
                        Target = new GroupAssignmentTarget
                        {
                            OdataType = "#microsoft.graph.groupAssignmentTarget",
                            DeviceAndAppManagementAssignmentFilterId = SelectedFilterID,
                            DeviceAndAppManagementAssignmentFilterType = deviceAndAppManagementAssignmentFilterType,
                            GroupId = group,
                        },
                    };
                    assignments.Add(assignment);
                }

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceManagementScripts.Item.Assign.AssignPostRequestBody
                {
                    DeviceManagementScriptAssignments = assignments,
                };

                try
                {
                    await destinationGraphServiceClient.DeviceManagement.DeviceManagementScripts[scriptID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile("Assigned groups to script " + scriptID + " with filter type" + deviceAndAppManagementAssignmentFilterType.ToString());
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to script {scriptID}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while assigning groups to a single PowerShell script");
            }
        }

        public static async Task DeletePowerShellScript(GraphServiceClient graphServiceClient, string scriptID)
        {
            try
            {
                if (graphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(graphServiceClient));
                }

                if (scriptID == null)
                {
                    throw new InvalidOperationException("Script ID cannot be null.");
                }
                await graphServiceClient.DeviceManagement.DeviceManagementScripts[scriptID].DeleteAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while deleting PowerShell scripts");
            }
        }
    }
}
