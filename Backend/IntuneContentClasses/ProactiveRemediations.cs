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
    public class ProactiveRemediations
    {
        public static async Task<List<DeviceHealthScript>> SearchForProactiveRemediations(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for proactive remediation scripts. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.DeviceHealthScripts.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                });

                List<DeviceHealthScript> healthScripts = new List<DeviceHealthScript>();
                var pageIterator = PageIterator<DeviceHealthScript, DeviceHealthScriptCollectionResponse>.CreatePageIterator(graphServiceClient, result, (script) =>
                {
                    if (!script.Publisher.Equals("Microsoft", StringComparison.OrdinalIgnoreCase))
                    {
                        healthScripts.Add(script);
                    }
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {healthScripts.Count} proactive remediation scripts.");

                return healthScripts;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for proactive remediation scripts");
                return new List<DeviceHealthScript>();
            }
        }

        public static async Task<List<DeviceHealthScript>> GetAllProactiveRemediations(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all proactive remediation scripts.");

                var result = await graphServiceClient.DeviceManagement.DeviceHealthScripts.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                });

                List<DeviceHealthScript> healthScripts = new List<DeviceHealthScript>();
                var pageIterator = PageIterator<DeviceHealthScript, DeviceHealthScriptCollectionResponse>.CreatePageIterator(graphServiceClient, result, (script) =>
                {
                    if (!script.Publisher.Equals("Microsoft", StringComparison.OrdinalIgnoreCase))
                    {
                        healthScripts.Add(script);
                    }
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {healthScripts.Count} proactive remediation scripts.");

                return healthScripts;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all proactive remediation scripts");
                return new List<DeviceHealthScript>();
            }
        }

        public static void AddProactiveRemediationsToDTG(List<DeviceHealthScript> scripts, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog("Adding proactive remediation scripts to the DataGridView.");

                foreach (var script in scripts)
                {
                    if (script.Id == null || script.DisplayName == null || script.Description == null)
                    {
                        throw new InvalidOperationException("Script properties cannot be null.");
                    }

                    dtg.Rows.Add(script.DisplayName.ToString(), "Proactive Remediations", "Windows", script.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding proactive remediation scripts to the DataGridView");
            }
        }

        public static List<string> GetProactiveRemediationsFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Proactive Remediations";
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
                HandleException(ex, "An error occurred while retrieving proactive remediation scripts from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleProactiveRemediations(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> scripts, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {scripts.Count} proactive remediation scripts.\n");
                WriteToImportStatusFile($"Importing {scripts.Count} proactive remediation scripts.");

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
                        var result = await sourceGraphServiceClient.DeviceManagement.DeviceHealthScripts[script].GetAsync();

                        var requestBody = new DeviceHealthScript
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
                        

                        var import = await destinationGraphServiceClient.DeviceManagement.DeviceHealthScripts.PostAsync(requestBody);
                        rtb.AppendText($"Imported script: {import.DisplayName}\n");
                        WriteToImportStatusFile($"Imported script: {import.DisplayName}");

                        if (assignments)
                        {
                            await AssignGroupsToSingleProactiveRemediation(import.Id, groups, destinationGraphServiceClient);
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

        public static async Task AssignGroupsToSingleProactiveRemediation(string scriptID, List<string> groupID, GraphServiceClient destinationGraphServiceClient)
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

                List<DeviceHealthScriptAssignment> assignments = new List<DeviceHealthScriptAssignment>();

                foreach (var group in groupID)
                {
                    var assignment = new DeviceHealthScriptAssignment
                    {
                        OdataType = "#microsoft.graph.deviceHealthScriptAssignment",
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

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceHealthScripts.Item.Assign.AssignPostRequestBody
                {
                    DeviceHealthScriptAssignments = assignments,
                };

                try
                {
                    await destinationGraphServiceClient.DeviceManagement.DeviceHealthScripts[scriptID].Assign.PostAsync(requestBody);
                    WriteToImportStatusFile("Assigned groups to script " + scriptID + " with filter type" + deviceAndAppManagementAssignmentFilterType.ToString());
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to script {scriptID}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while assigning groups to a single proactive remediation script");
            }
        }
    }
}
