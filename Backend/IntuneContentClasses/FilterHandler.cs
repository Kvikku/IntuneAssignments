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
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;


namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class FilterHandler
    {
        private const string PolicyType = "Assignment Filter";

        public static async Task<List<DeviceAndAppManagementAssignmentFilter>> SearchForAssignmentFilters(GraphServiceClient graphServiceClient, string searchQuery)
        {
            try
            {
                WriteToLog($"Searching for {PolicyType} policies. Search query: {searchQuery}");

                // Assignment filters don't have a direct filter on DisplayName in the same way,
                // so we get all and filter locally, or adjust if a specific filter query is needed.
                // For simplicity, getting all and filtering locally for now.
                // A server-side filter might look like: $"contains(displayName,'{searchQuery}')" if supported.
                // Let's try the filter first.
                var result = await graphServiceClient.DeviceManagement.AssignmentFilters.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(displayName,'{searchQuery}')";
                    requestConfiguration.QueryParameters.Top = 999; // Ensure we get enough results if filtering client-side later
                });


                if (result == null || result.Value == null)
                {
                    WriteToLog($"Search returned null or empty result for {PolicyType} policies.");
                    return new List<DeviceAndAppManagementAssignmentFilter>();
                }

                List<DeviceAndAppManagementAssignmentFilter> assignmentFilters = new List<DeviceAndAppManagementAssignmentFilter>();
                var pageIterator = PageIterator<DeviceAndAppManagementAssignmentFilter, DeviceAndAppManagementAssignmentFilterCollectionResponse>.CreatePageIterator(graphServiceClient, result, (filter) =>
                {
                    assignmentFilters.Add(filter);
                    return true; // Continue iterating
                });
                await pageIterator.IterateAsync();


                // If server-side filter doesn't work as expected, filter client-side:
                // assignmentFilters = assignmentFilters.Where(f => f.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();


                WriteToLog($"Found {assignmentFilters.Count} {PolicyType} policies matching the search query.");

                return assignmentFilters;
            }
            catch (ODataError odataError) when (odataError.ResponseStatusCode == 400) // Handle potential filter query issues
            {
                 WriteToLog($"Server-side filtering might not be supported or the query is invalid for {PolicyType}. Trying client-side filtering. Error: {odataError.Error?.Message}");
                 // Fallback: Get all and filter client-side
                 var allFilters = await GetAllAssignmentFilters(graphServiceClient);
                 return allFilters.Where(f => f.DisplayName != null && f.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while searching for {PolicyType} policies");
                return new List<DeviceAndAppManagementAssignmentFilter>();
            }
        }

        public static async Task<List<DeviceAndAppManagementAssignmentFilter>> GetAllAssignmentFilters(GraphServiceClient graphServiceClient)
        {
            try
            {
                WriteToLog($"Retrieving all {PolicyType} policies.");

                var result = await graphServiceClient.DeviceManagement.AssignmentFilters.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 999; // Request up to 999 items per page
                });

                if (result == null || result.Value == null)
                {
                     WriteToLog($"Get all returned null or empty result for {PolicyType} policies.");
                     return new List<DeviceAndAppManagementAssignmentFilter>();
                }

                List<DeviceAndAppManagementAssignmentFilter> assignmentFilters = new List<DeviceAndAppManagementAssignmentFilter>();
                var pageIterator = PageIterator<DeviceAndAppManagementAssignmentFilter, DeviceAndAppManagementAssignmentFilterCollectionResponse>.CreatePageIterator(graphServiceClient, result, (filter) =>
                {
                    assignmentFilters.Add(filter);
                    return true; // Continue iterating
                });

                await pageIterator.IterateAsync(); // Iterate through all pages

                WriteToLog($"Found {assignmentFilters.Count} {PolicyType} policies.");

                return assignmentFilters;
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while retrieving all {PolicyType} policies");
                return new List<DeviceAndAppManagementAssignmentFilter>();
            }
        }

        public static void AddAssignmentFiltersToDTG(List<DeviceAndAppManagementAssignmentFilter> filters, System.Windows.Forms.DataGridView dtg)
        {
            try
            {
                if (filters == null)
                {
                    throw new ArgumentNullException(nameof(filters), "The filters list cannot be null.");
                }

                if (dtg == null)
                {
                    throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
                }

                WriteToLog($"Adding {PolicyType} policies to the DataGridView.");

                foreach (var filter in filters)
                {
                    if (filter.Id == null || filter.DisplayName == null)
                    {
                        WriteToLog($"Skipping filter with null Id or DisplayName: {filter.Id ?? "N/A"}");
                        continue;
                    }
                    // Assuming DataGridView columns are: Name, Type, Platform, ID
                    dtg.Rows.Add(filter.DisplayName, PolicyType, filter.Platform?.ToString() ?? "Unknown", filter.Id);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred while adding {PolicyType} policies to the DataGridView");
            }
        }


        public static List<string> GetAssignmentFiltersFromDTG(DataGridView dtg)
        {
            try
            {
                List<string> matchingRows = new List<string>();

                // Assuming DataGridView columns are: Name (0), Type (1), Platform (2), ID (3)
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


        public static async Task ImportMultipleAssignmentFilters(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, RichTextBox rtb, List<string> filterIds)
        {
            try
            {
                rtb.AppendText($"Importing {filterIds.Count} {PolicyType} policies.{Environment.NewLine}");
                WriteToImportStatusFile($"Importing {filterIds.Count} {PolicyType} policies.");


                foreach (var filterId in filterIds)
                {
                    DeviceAndAppManagementAssignmentFilter? sourceFilter = null;
                    try
                    {
                        sourceFilter = await sourceGraphServiceClient.DeviceManagement.AssignmentFilters[filterId].GetAsync();

                        if (sourceFilter == null)
                        {
                             rtb.AppendText($"Skipping filter ID {filterId}: Not found in source tenant.{Environment.NewLine}");
                             WriteToImportStatusFile($"Skipping filter ID {filterId}: Not found in source tenant.");
                             continue;
                        }

                        // Create the new filter object based on the source
                        var newFilter = new DeviceAndAppManagementAssignmentFilter
                        {
                        };


                        // Copy the display name and description
                        newFilter.DisplayName = sourceFilter.DisplayName;
                        newFilter.Description = sourceFilter.Description;
                        newFilter.Platform = sourceFilter.Platform; // Assuming Platform is a property of the filter
                        newFilter.Rule = sourceFilter.Rule; // Assuming Rule is a property of the filter
                        newFilter.OdataType = "#microsoft.graph.deviceAndAppManagementAssignmentFilter";



                        var importedFilter = await destinationGraphServiceClient.DeviceManagement.AssignmentFilters.PostAsync(newFilter);

                        if (importedFilter != null && !string.IsNullOrEmpty(importedFilter.Id))
                        {
                            rtb.AppendText($"Imported filter: {importedFilter.DisplayName} (ID: {importedFilter.Id}){Environment.NewLine}");
                            WriteToImportStatusFile($"Imported filter: {importedFilter.DisplayName} (ID: {importedFilter.Id})");

                            // Assignment logic is not applicable here as filters are used *in* assignments, not assigned *to* groups directly.
                            // If RoleScopeTags need to be copied, that logic would go here.
                        }
                        else
                        {
                             rtb.AppendText($"Failed to import filter: {sourceFilter.DisplayName} (ID: {filterId}). Result or ID was null.{Environment.NewLine}");
                             WriteToImportStatusFile($"Failed to import filter: {sourceFilter.DisplayName} (ID: {filterId}). Result or ID was null.");
                        }
                    }
                    catch (Exception ex)
                    {
                        string filterIdentifier = $"filter ID {filterId}";
                        if (sourceFilter != null && !string.IsNullOrEmpty(sourceFilter.DisplayName))
                        {
                            filterIdentifier = $"filter '{sourceFilter.DisplayName}' (ID: {filterId})";
                        }

                        HandleException(ex, $"Error importing {filterIdentifier}", false); // Log without showing message box for each failure in loop
                        rtb.AppendText($"Failed to import {filterIdentifier}: {ex.Message}{Environment.NewLine}");
                        WriteToImportStatusFile($"Failed to import {filterIdentifier}: {ex.Message}");
                    }
                }
                 rtb.AppendText($"Finished importing {PolicyType} policies.{Environment.NewLine}");
                 WriteToImportStatusFile($"Finished importing {PolicyType} policies.");
            }
            catch (Exception ex)
            {
                HandleException(ex, $"An error occurred during the {PolicyType} import process");
                 rtb.AppendText($"An error occurred during the {PolicyType} import process: {ex.Message}{Environment.NewLine}");
                 WriteToImportStatusFile($"An error occurred during the {PolicyType} import process: {ex.Message}");
            }
        }

        // Assignment logic specific to Apple BYOD profiles is removed as it doesn't apply directly to filters.
        // Filters are applied when assigning other resources (apps, policies, etc.).
    }
}
