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
using Windows.Security.Isolation;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class ADMXtemplates
    {
        public static async Task<List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration>> SearchForGroupPolicyConfigurations(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for group policy configurations. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.GroupPolicyConfigurations
                    .GetAsync(requestConfiguration =>
                    {
                        // Filter by group policy configuration displayName
                        requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                    });

                List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration> groupPolicyConfigurations = new();
                var pageIterator = PageIterator<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration, GroupPolicyConfigurationCollectionResponse>
                    .CreatePageIterator(graphServiceClient, result, (config) =>
                    {
                        groupPolicyConfigurations.Add(config);
                        return true;
                    });

                await pageIterator.IterateAsync();

                WriteToLog($"Found {groupPolicyConfigurations.Count} group policy configurations.");
                return groupPolicyConfigurations;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for group policy configurations");
                return new List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration>();
            }
        }

        public static async Task<List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration>> GetAllGroupPolicyConfigurations(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all group policy configurations.");

                var result = await graphServiceClient.DeviceManagement.GroupPolicyConfigurations
                    .GetAsync(requestConfiguration =>
                    {
                        requestConfiguration.QueryParameters.Top = 1000;
                    });

                List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration> groupPolicyConfigurations = new();
                var pageIterator = PageIterator<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration, GroupPolicyConfigurationCollectionResponse>
                    .CreatePageIterator(graphServiceClient, result, (config) =>
                    {
                        groupPolicyConfigurations.Add(config);
                        return true;
                    });

                await pageIterator.IterateAsync();

                WriteToLog($"Found {groupPolicyConfigurations.Count} group policy configurations.");
                return groupPolicyConfigurations;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all group policy configurations");
                return new List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration>();
            }
        }

        public static void AddGroupPolicyConfigurationsToDTG(List<Microsoft.Graph.Beta.Models.GroupPolicyConfiguration> groupPolicyConfigurations, DataGridView dtg)
        {
            try
            {
                if (groupPolicyConfigurations == null)
                {
                    throw new ArgumentNullException(nameof(groupPolicyConfigurations), "The configuration list cannot be null.");
                }

                if (dtg == null)
                {
                    throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
                }

                WriteToLog("Adding group policy configurations to the DataGridView.");

                foreach (var config in groupPolicyConfigurations)
                {
                    if (config.Id == null || config.DisplayName == null)
                    {
                        throw new InvalidOperationException("Configuration properties cannot be null.");
                    }

                    // Add row: Name, type, platform info, config ID
                    dtg.Rows.Add(config.DisplayName, "Group Policy Configuration", config.GetType().Name, config.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding group policy configurations to the DataGridView");
            }
        }

        public static List<string> GetGroupPolicyConfigurationsFromDTG(DataGridView dtg)
        {
            try
            {
                const string type = "Group Policy Configuration";
                List<string> matchingRows = new();

                foreach (DataGridViewRow row in dtg.Rows)
                {
                    if (row.Cells[1].Value != null &&
                        row.Cells[1].Value.ToString() == type &&
                        row.Cells[3].Value != null)
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
                HandleException(ex, "An error occurred while retrieving group policy configurations from DataGridView");
                return new List<string>();
            }
        }

        

        public static async Task ImportMultipleGroupPolicyConfigurations(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> configurationIds, RichTextBox rtb, bool assignments, bool filter, List<string> groups)
        {
            try
            {
                rtb.AppendText(Environment.NewLine);
                rtb.AppendText($"{DateTime.Now.ToString()} - Importing {configurationIds.Count} group policy configurations.\n");
                WriteToImportStatusFile(" ");
                WriteToImportStatusFile($"{DateTime.Now.ToString()} - Importing {configurationIds.Count} group policy configurations.");


                foreach (var configId in configurationIds)
                {
                    var policyName = string.Empty;
                    try
                    {
                        var originalConfig = await sourceGraphServiceClient.DeviceManagement.GroupPolicyConfigurations[configId].GetAsync(requestConfiguration =>
                            {
                                // Expand settings if needed
                                //requestConfiguration.QueryParameters.Expand = new[] { "settings" };
                            });

                        policyName = originalConfig.DisplayName ?? "Unnamed Policy";

                        // get the type of the policy object
                        var typeOfPolicy = originalConfig.GetType();

                        if (typeOfPolicy.IsAbstract)
                        {
                            MessageBox.Show("Error - Abstract class detected");
                            return;
                        }

                        // create a new instance of the policy object
                        var testRequestBody = Activator.CreateInstance(typeOfPolicy);

                        // copy all the properties from the original policy
                        foreach (var property in typeOfPolicy.GetProperties())
                        {
                            if (property.CanWrite)
                            {
                                var value = property.GetValue(originalConfig);

                                property.SetValue(testRequestBody, value);
                            }
                        }

                        // cast the object to a GroupPolicyConfiguration (this is necessary for the PostAsync method)
                        var groupPolicyConfiguration = testRequestBody as Microsoft.Graph.Beta.Models.GroupPolicyConfiguration;

                        groupPolicyConfiguration.Assignments = groupPolicyConfiguration.Assignments ?? new List<GroupPolicyConfigurationAssignment>();
                        groupPolicyConfiguration.OdataType = "#microsoft.Graph.Beta.Models.GroupPolicyConfiguration";

                        var import = await destinationGraphServiceClient.DeviceManagement.GroupPolicyConfigurations.PostAsync(groupPolicyConfiguration);

                        rtb.AppendText($"Successfully imported: {import.DisplayName}\n");
                        WriteToImportStatusFile($"Successfully imported: {import.DisplayName}");

                        if (assignments)
                        {
                            await AssignGroupsToSingleGroupPolicyConfiguration(import.Id, groups, destinationGraphServiceClient);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteErrorToRTB($"Error importing {policyName}\n",rtb);
                        WriteToImportStatusFile($"Error importing {policyName}",LogType.Error);
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
                rtb.AppendText(Environment.NewLine);
                rtb.AppendText($"{DateTime.Now.ToString()} - Import process for Group Policy Configurations has completed.\n");
                WriteToImportStatusFile(" ");
                WriteToImportStatusFile($" {DateTime.Now.ToString()} - Import process has completed for Group Policy Configurations.");
            }
        }

        public static async Task AssignGroupsToSingleGroupPolicyConfiguration(string configId, List<string> groupIds, GraphServiceClient destinationGraphServiceClient)
        {
            try
            {
                if (configId == null)
                {
                    throw new ArgumentNullException(nameof(configId));
                }

                if (groupIds == null)
                {
                    throw new ArgumentNullException(nameof(groupIds));
                }

                if (destinationGraphServiceClient == null)
                {
                    throw new ArgumentNullException(nameof(destinationGraphServiceClient));
                }

                var assignments = new List<GroupPolicyConfigurationAssignment>();

                foreach (var group in groupIds)
                {
                    // Adjust filter or assignment definitions as needed
                    assignments.Add(new GroupPolicyConfigurationAssignment
                    {
                        OdataType = "#microsoft.graph.groupPolicyConfigurationAssignment",
                        Target = new DeviceAndAppManagementAssignmentTarget
                        {
                            OdataType = "#microsoft.graph.groupAssignmentTarget",
                            AdditionalData = new Dictionary<string, object>
                            {
                                { "groupId", group }
                            },
                            DeviceAndAppManagementAssignmentFilterType = deviceAndAppManagementAssignmentFilterType,
                            DeviceAndAppManagementAssignmentFilterId = SelectedFilterID
                        }
                    });
                }

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.GroupPolicyConfigurations.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                };

                try
                {
                    var result = await destinationGraphServiceClient.DeviceManagement.GroupPolicyConfigurations[configId].Assign.PostAsAssignPostResponseAsync(requestBody);

                    WriteToImportStatusFile("Assigned groups to group policy configuration " + configId);
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to group policy configuration {configId}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while assigning groups to a single group policy configuration policy");
            }
        }
    }
}
