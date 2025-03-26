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
            // This method searches the Intune settings catalog for a specific query and returns the results as a list of DeviceManagementConfigurationPolicy objects
            try
            {
                WriteToLog("Searching for settings catalog policies. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(Name,'{searchQuery}')";
                    //requestConfiguration.QueryParameters.Expand = new[] { "settings" }; // Expand the settings of each policy. Note - this might take some time to load
                });

                List<DeviceManagementConfigurationPolicy> configurationPolicies = new List<DeviceManagementConfigurationPolicy>();
                // Iterate through the pages of results
                var pageIterator = PageIterator<DeviceManagementConfigurationPolicy, DeviceManagementConfigurationPolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                {
                    configurationPolicies.Add(policy);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();

                WriteToLog($"Found {configurationPolicies.Count} settings catalog policies.");

                // return the list of policies
                return configurationPolicies;
            }

            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                // Log the error message
                WriteToLog($"ODataError: {me.Message}");
                MessageBox.Show(me.Message);
            }
            catch (ServiceException ex)
            {
                // Log the error message
                WriteToLog($"ServiceException: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the error message
                WriteToLog($"Exception: {ex.Message}");
                MessageBox.Show(ex.Message);
            }

            // Return an empty list if an exception occurs
            return new List<DeviceManagementConfigurationPolicy>();
        }

        public static async Task<List<DeviceManagementConfigurationPolicy>> GetAllSettingsCatalogPolicies(GraphServiceClient graphServiceClient)
        {
            // This method retrieves all the configuration policies (Settings catalog) from Intune and returns them as a list of DeviceManagementConfigurationPolicy objects
            try
            {
                WriteToLog("Retrieving all settings catalog policies.");

                var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                    //requestConfiguration.QueryParameters.Expand = new[] { "settings" }; // Expand the settings of each policy. Note - this might take some time to load
                });

                List<DeviceManagementConfigurationPolicy> configurationPolicies = new List<DeviceManagementConfigurationPolicy>();
                // Iterate through the pages of results
                var pageIterator = PageIterator<DeviceManagementConfigurationPolicy, DeviceManagementConfigurationPolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                {
                    configurationPolicies.Add(policy);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();

                WriteToLog($"Found {configurationPolicies.Count} settings catalog policies.");

                // return the list of policies
                return configurationPolicies;
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                // Log the error message
                WriteToLog($"ODataError: {me.Message}");
                MessageBox.Show(me.Message);
            }
            catch (ServiceException ex)
            {
                // Log the error message
                WriteToLog($"ServiceException: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the error message
                WriteToLog($"Exception: {ex.Message}");
                MessageBox.Show(ex.Message);
            }

            // Return an empty list if an exception occurs
            return new List<DeviceManagementConfigurationPolicy>();
        }

        public static void AddSettingsCatalogToDTG(List<DeviceManagementConfigurationPolicy> policies, System.Windows.Forms.DataGridView dtg)
        {
            // Check if the policies list is null
            if (policies == null)
            {
                throw new ArgumentNullException(nameof(policies), "The policies list cannot be null.");
            }

            // Check if the DataGridView is null
            if (dtg == null)
            {
                throw new ArgumentNullException(nameof(dtg), "The DataGridView cannot be null.");
            }

            try
            {
                WriteToLog("Adding settings catalog policies to the DataGridView.");

                // Iterate through the policies and add them to the DataGridView
                foreach (var policy in policies)
                {
                    // Check if required properties are not null
                    if (policy.Id == null || policy.Name == null || policy.Description == null)
                    {
                        throw new InvalidOperationException("Policy properties cannot be null.");
                    }

                    dtg.Rows.Add(policy.Name, "Settings Catalog", policy.Platforms, policy.Id);
                }
            }
            catch (Exception ex)
            {
                // Log the error message
                WriteToLog($"Exception: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
        }

        public static List<string> GetSettingsCatalogFromDTG(DataGridView dtg)
        {
            string type = "Settings Catalog";
            List<string> matchingRows = new List<string>();

            foreach (DataGridViewRow row in dtg.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == type && row.Cells[3].Value != null)
                {
                    // Get the policy ID
                    var cellValue = row.Cells[3].Value?.ToString();
                    if (cellValue != null)
                    {
                        matchingRows.Add(cellValue);
                    }
                }
            }

            return matchingRows;
        }

        public static async Task ImportMultipleSettingsCatalog(GraphServiceClient sourceGraphServiceClient, GraphServiceClient destinationGraphServiceClient, DataGridView dtg, List<string> policies, RichTextBox rtb, bool assignments,bool filter, List<string> groups)
        {
            // This method imports multiple settings catalog policies from the source tenant to the destination tenant
            try
            {
                // TODO - Error handling and data validation

                rtb.AppendText($"Importing {policies.Count} settings catalog policies.\n");
                WriteToImportStatusFile($"Importing {policies.Count} settings catalog policies.");

                if(assignments ) 
                {
                    rtb.AppendText($"Group assignments will be added.\n");
                    WriteToImportStatusFile($"Group assignments will be added..");
                }

                // Begin importing the policies
                foreach (var policy in policies)
                {
                    try
                    {
                        // Get the policy from the source tenant with settings
                        var result = await sourceGraphServiceClient.DeviceManagement.ConfigurationPolicies[policy].GetAsync((requestConfiguration) =>
                        {
                            requestConfiguration.QueryParameters.Expand = new[] { "settings" }; // Expand the settings of each policy. Note - this might take some time to load
                        });

                        // Create a new policy object
                        var newPolicy = new DeviceManagementConfigurationPolicy
                        {
                            Name = result.Name,
                            Description = result.Description,
                            Platforms = result.Platforms,
                            Technologies = result.Technologies,
                            RoleScopeTagIds = result.RoleScopeTagIds,
                            Settings = result.Settings,
                            Assignments = new List<DeviceManagementConfigurationPolicyAssignment>() // Initialize the Assignments property
                        };

                        // add assignments if the bool variable is true

                        //if (assignments)
                        //{
                        //    // add an assignment object to the policy

                        //    foreach (var group in groups)
                        //    {
                        //        // Create a group assignment target object
                        //        var groupAssignmentTarget = new GroupAssignmentTarget
                        //        {
                        //            GroupId = group
                        //        };

                        //        // Create a configuration policy assignment object
                        //        var deviceConfigurationAssignmentTarget = new DeviceConfigurationAssignment
                        //        {
                        //            Target = groupAssignmentTarget
                        //        };

                        //        // Create a new device management configuration policy assignment object
                        //        var assignmentBody = new DeviceManagementConfigurationPolicyAssignment
                        //        {
                        //            OdataType = "#microsoft.graph.deviceManagementConfigurationPolicyAssignment",
                        //            Id = group,
                        //            Target = new GroupAssignmentTarget
                        //            {
                        //                OdataType = "#microsoft.graph.groupAssignmentTarget",
                        //                DeviceAndAppManagementAssignmentFilterId = null,
                        //                DeviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.Include,
                        //                GroupId = group,
                        //            },
                        //            Source = DeviceAndAppManagementAssignmentSource.Direct,
                        //            SourceId = group,

                        //        };
                        //        // add each assignment to the list of assignments
                        //        newPolicy.Assignments.Add(assignmentBody);
                        //    }
                        //}


                        // Import the policy to the destination tenant
                        var import = await destinationGraphServiceClient.DeviceManagement.ConfigurationPolicies.PostAsync(newPolicy);
                        rtb.AppendText($"Imported policy: {import.Name}\n");
                        WriteToImportStatusFile($"Imported policy: {import.Name}");

                        if (assignments)
                        {
                            await AssignGroupsToSingleSettingsCatalog(import.Id, groups, destinationGraphServiceClient);
                        }
                        

                    }
                    catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
                    {
                        // Log the error message
                        WriteToLog($"ODataError: {me.Message}");
                        rtb.AppendText($"Error importing policy {policy}. Error message: {me.Message}\n");
                        WriteToImportStatusFile($"Error importing policy {policy}. Error message: {me.Message}");
                    }
                    catch (ServiceException ex)
                    {
                        // Log the error message
                        WriteToLog($"ServiceException: {ex.Message}");
                        rtb.AppendText($"Error importing policy {policy}. Error message: {ex.Message}\n");
                        WriteToImportStatusFile($"Error importing policy {policy}. Error message: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Log the error message
                        WriteToLog($"Exception: {ex.Message}");
                        rtb.AppendText($"Error importing policy {policy}. Error message: {ex.Message}\n");
                        WriteToImportStatusFile($"Error importing policy {policy}. Error message: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error message
                WriteToLog($"Exception: {ex.Message}");
                rtb.AppendText($"Error during import process. Error message: {ex.Message}\n");
                WriteToImportStatusFile($"Error during import process. Error message: {ex.Message}");
            }
        }

        public static async Task AssignGroupsToSingleSettingsCatalog(string policyID, List<string> groupID ,GraphServiceClient destinationGraphServiceClient)

        {
            // This method will assign an array of groups to a single settings catalog policy

            // Check for null values

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


            // Create an empty list to store the assignments
            List<DeviceManagementConfigurationPolicyAssignment> assignments = new List<DeviceManagementConfigurationPolicyAssignment>();

            // Loop through the groupID array and create a group assignment target object for each group

            foreach (var group in groupID)
            {
                

                // Create a group assignment target object
                var groupAssignmentTarget = new GroupAssignmentTarget
                {
                    GroupId = group
                };

                // Create a configuration policy assignment object
                var deviceConfigurationAssignmentTarget = new DeviceConfigurationAssignment
                {
                    Target = groupAssignmentTarget
                };

                // Create a new device management configuration policy assignment object
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
                // add each assignment to the list of assignments
                assignments.Add(assignment);
            }

            // Create a request body object and add all assignment object to it
            var requestBody = new Microsoft.Graph.Beta.DeviceManagement.ConfigurationPolicies.Item.Assign.AssignPostRequestBody
            {
                Assignments = assignments
            };

            // Assign the policy to the groups



            try
            {
                var result = await destinationGraphServiceClient.DeviceManagement.ConfigurationPolicies[policyID].Assign.PostAsAssignPostResponseAsync(requestBody);
                WriteToImportStatusFile("Assigned groups to policy " + policyID);
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                WriteToImportStatusFile("Error assigning groups to policy " + policyID + " (ID:" + policyID + "). Error message: " + me.Message);
            }


        }


    }
}   

