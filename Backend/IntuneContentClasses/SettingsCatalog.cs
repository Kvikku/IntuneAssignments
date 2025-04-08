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

namespace IntuneAssignments.Backend.Intune_content_classes
{
    public class SettingsCatalog
    {

        /*
         * TODO
         * Search
         * List all 
         * Add to dtg
         * Import content
         * Assignment
         * Filter
         */

        public static async Task<List<DeviceManagementConfigurationPolicy>> SearchForSettingsCatalog(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for settings catalog policies. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(Name,'{searchQuery}')";
                });

                List<DeviceManagementConfigurationPolicy> configurationPolicies = new List<DeviceManagementConfigurationPolicy>();
                var pageIterator = PageIterator<DeviceManagementConfigurationPolicy, DeviceManagementConfigurationPolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                {
                    configurationPolicies.Add(policy);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {configurationPolicies.Count} settings catalog policies.");

                return configurationPolicies;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for settings catalog policies");
                return new List<DeviceManagementConfigurationPolicy>();
            }
        }

        public static async Task<List<DeviceManagementConfigurationPolicy>> GetAllSettingsCatalogPolicies(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all settings catalog policies.");

                var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                });

                List<DeviceManagementConfigurationPolicy> configurationPolicies = new List<DeviceManagementConfigurationPolicy>();
                var pageIterator = PageIterator<DeviceManagementConfigurationPolicy, DeviceManagementConfigurationPolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                {
                    configurationPolicies.Add(policy);
                    return true;
                });
                await pageIterator.IterateAsync();

                WriteToLog($"Found {configurationPolicies.Count} settings catalog policies.");

                return configurationPolicies;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all settings catalog policies");
                return new List<DeviceManagementConfigurationPolicy>();
            }
        }

        public static void AddSettingsCatalogToDTG(List<DeviceManagementConfigurationPolicy> policies, System.Windows.Forms.DataGridView dtg)
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

                WriteToLog("Adding settings catalog policies to the DataGridView.");

                foreach (var policy in policies)
                {
                    if (policy.Id == null || policy.Name == null || policy.Description == null)
                    {
                        throw new InvalidOperationException("Policy properties cannot be null.");
                    }

                    dtg.Rows.Add(policy.Name.ToString(), "Settings Catalog", policy.Platforms.ToString(), policy.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding settings catalog policies to the DataGridView");
            }
        }

        public static List<string> GetSettingsCatalogFromDTG(DataGridView dtg)
        {
            try
            {
                string type = "Settings Catalog";
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
                HandleException(ex, "An error occurred while retrieving settings catalog from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleSettingsCatalog(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> policies, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {policies.Count} settings catalog policies.\n");
                WriteToImportStatusFile($"Importing {policies.Count} settings catalog policies.");

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

                foreach (var policy in policies)
                {
                    try
                    {
                        var result = await sourceGraphServiceClient.DeviceManagement.ConfigurationPolicies[policy].GetAsync((requestConfiguration) =>
                        {
                            requestConfiguration.QueryParameters.Expand = new[] { "settings" };
                        });

                        var newPolicy = new DeviceManagementConfigurationPolicy
                        {
                            Name = result.Name,
                            Description = result.Description,
                            Platforms = result.Platforms,
                            Technologies = result.Technologies,
                            RoleScopeTagIds = result.RoleScopeTagIds,
                            Settings = result.Settings,
                            Assignments = new List<DeviceManagementConfigurationPolicyAssignment>()
                        };

                        var import = await destinationGraphServiceClient.DeviceManagement.ConfigurationPolicies.PostAsync(newPolicy);
                        rtb.AppendText($"Imported policy: {import.Name}\n");
                        WriteToImportStatusFile($"Imported policy: {import.Name}");

                        if (assignments)
                        {
                            await AssignGroupsToSingleSettingsCatalog(import.Id, groups, destinationGraphServiceClient);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, $"Error importing policy {policy}", false);
                        rtb.AppendText($"Failed to import {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the import process");
            }
        }

        public static async Task AssignGroupsToSingleSettingsCatalog(string policyID, List<string> groupID, GraphServiceClient destinationGraphServiceClient)
        {
            try
            {
                if (policyID == null)
                {
                    throw new ArgumentNullException(nameof(policyID));
                }

                if (groupID == null)
                {
                    throw new ArgumentNullException(nameof(groupID));
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                List<DeviceManagementConfigurationPolicyAssignment> assignments = new List<DeviceManagementConfigurationPolicyAssignment>();

                foreach (var group in groupID)
                {
                    var assignment = new DeviceManagementConfigurationPolicyAssignment
                    {
                        OdataType = "#microsoft.graph.deviceManagementConfigurationPolicyAssignment",
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

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.ConfigurationPolicies.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                };

                try
                {
                    var result = await destinationGraphServiceClient.DeviceManagement.ConfigurationPolicies[policyID].Assign.PostAsAssignPostResponseAsync(requestBody);
                    WriteToImportStatusFile("Assigned groups to policy " + policyID + " with filter type" + deviceAndAppManagementAssignmentFilterType.ToString());
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to policy {policyID}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while assigning groups to a single settings catalog policy");
            }
        }
    }
}

