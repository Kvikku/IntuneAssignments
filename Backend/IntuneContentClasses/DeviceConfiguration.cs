﻿using System;
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
    public class DeviceConfiguration
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

        public static async Task<List<Microsoft.Graph.Beta.Models.DeviceConfiguration>> SearchForDeviceConfigurations(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog("Searching for device configuration policies. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.DeviceConfigurations
                    .GetAsync(requestConfiguration =>
                    {
                        // Filter by device configuration displayName
                        requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                    });

                List<Microsoft.Graph.Beta.Models.DeviceConfiguration> deviceConfigurations = new();
                var pageIterator = PageIterator<Microsoft.Graph.Beta.Models.DeviceConfiguration, DeviceConfigurationCollectionResponse>
                    .CreatePageIterator(graphServiceClient, result, (config) =>
                    {
                        deviceConfigurations.Add(config);
                        return true;
                    });

                await pageIterator.IterateAsync();

                WriteToLog($"Found {deviceConfigurations.Count} device configuration policies.");
                return deviceConfigurations;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while searching for device configuration policies");
                return new List<Microsoft.Graph.Beta.Models.DeviceConfiguration>();
            }
        }

        public static async Task<List<Microsoft.Graph.Beta.Models.DeviceConfiguration>> GetAllDeviceConfigurations(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog("Retrieving all device configuration policies.");

                var result = await graphServiceClient.DeviceManagement.DeviceConfigurations
                    .GetAsync(requestConfiguration =>
                    {
                        requestConfiguration.QueryParameters.Top = 1000;
                    });

                List<Microsoft.Graph.Beta.Models.DeviceConfiguration> deviceConfigurations = new();
                var pageIterator = PageIterator<Microsoft.Graph.Beta.Models.DeviceConfiguration, DeviceConfigurationCollectionResponse>
                    .CreatePageIterator(graphServiceClient, result, (config) =>
                    {
                        deviceConfigurations.Add(config);
                        return true;
                    });

                await pageIterator.IterateAsync();

                WriteToLog($"Found {deviceConfigurations.Count} device configuration policies.");
                return deviceConfigurations;
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while retrieving all device configuration policies");
                return new List<Microsoft.Graph.Beta.Models.DeviceConfiguration>();
            }
        }

        public static void AddDeviceConfigurationsToDTG(List<Microsoft.Graph.Beta.Models.DeviceConfiguration> deviceConfigurations,DataGridView dtg)
        {
            try
            {
                if (deviceConfigurations == null)
                {
                    throw new ArgumentNullException(nameof(deviceConfigurations), "The configuration list cannot be null.");
                }

                if (dtg == null)
                {
                    throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
                }

                WriteToLog("Adding device configuration policies to the DataGridView.");

                foreach (var config in deviceConfigurations)
                {
                    if (config.Id == null || config.DisplayName == null)
                    {
                        throw new InvalidOperationException("Configuration properties cannot be null.");
                    }

                    // Add row: Name, type, platform info, config ID
                    dtg.Rows.Add(config.DisplayName, "Device Configuration", config.GetType().Name, config.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while adding device configuration policies to the DataGridView");
            }
        }

        public static List<string> GetDeviceConfigurationsFromDTG(DataGridView dtg)
        {
            try
            {
                const string type = "Device Configuration";
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
                HandleException(ex, "An error occurred while retrieving device configurations from DataGridView");
                return new List<string>();
            }
        }

        public static async Task ImportMultipleDeviceConfigurations(GraphServiceClient sourceGraphServiceClient,GraphServiceClient destinationGraphServiceClient,DataGridView dtg,List<string> configurationIds,RichTextBox rtb,bool assignments,bool filter,List<string> groups)
        {
            try
            {
                rtb.AppendText($"Importing {configurationIds.Count} device configuration policies.\n");
                WriteToImportStatusFile($"Importing {configurationIds.Count} device configuration policies.");

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

                foreach (var configId in configurationIds)
                {
                    try
                    {
                        var originalConfig = await sourceGraphServiceClient
                            .DeviceManagement
                            .DeviceConfigurations[configId]
                            .GetAsync(requestConfiguration =>
                            {
                                // Expand settings if needed
                                // requestConfiguration.QueryParameters.Expand = new[] { "settings" };
                            });

                        var newConfig = new Microsoft.Graph.Beta.Models.DeviceConfiguration
                        {
                            DisplayName = originalConfig.DisplayName,
                            Description = originalConfig.Description,
                            RoleScopeTagIds = originalConfig.RoleScopeTagIds
                            // Add other properties as needed
                        };

                        var import = await destinationGraphServiceClient
                            .DeviceManagement
                            .DeviceConfigurations
                            .PostAsync(newConfig);

                        rtb.AppendText($"Imported device configuration: {import.DisplayName}\n");
                        WriteToImportStatusFile($"Imported device configuration: {import.DisplayName}");

                        if (assignments)
                        {
                            await AssignGroupsToSingleDeviceConfiguration(import.Id, groups, destinationGraphServiceClient);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, $"Error importing device configuration {configId}");
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred during the import process");
            }
        }

        public static async Task AssignGroupsToSingleDeviceConfiguration(string configId,List<string> groupIds,GraphServiceClient destinationGraphServiceClient)
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

                var assignments = new List<DeviceConfigurationAssignment>();

                foreach (var group in groupIds)
                {
                    // Adjust filter or assignment definitions as needed
                    assignments.Add(new DeviceConfigurationAssignment
                    {
                        OdataType = "#microsoft.graph.deviceConfigurationAssignment",
                        Target = new DeviceAndAppManagementAssignmentTarget
                        {
                            OdataType = "#microsoft.graph.groupAssignmentTarget",
                            GroupId = group
                        }
                    });
                }

                var requestBody = new Microsoft.Graph.Beta.DeviceManagement.DeviceConfigurations.Item.Assign.AssignPostRequestBody
                {
                    Assignments = assignments
                };

                try
                {
                    var result = await destinationGraphServiceClient
                        .DeviceManagement
                        .DeviceConfigurations[configId]
                        .Assign
                        .PostAsync(requestBody);

                    WriteToImportStatusFile("Assigned groups to device configuration " + configId);
                }
                catch (Exception ex)
                {
                    HandleException(ex, $"Error assigning groups to device configuration {configId}");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "An error occurred while assigning groups to a single device configuration policy");
            }
        }
    }
}
