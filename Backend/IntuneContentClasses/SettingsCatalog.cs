using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using static IntuneAssignments.Backend.Utilities.FormUtilities;

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
                // This method searches the Intune settings catalog for a specific query and returns the results as a list of DeviceManagementConfigurationPolicy objects
                var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(Name,'{searchQuery}')";
                    requestConfiguration.QueryParameters.Expand = new[] { "settings" }; // Expand the settings of each policy. Note - this might take some time to load
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
            try
            {
                // This method retrieves all the configuration policies (Settings catalog) from Intune and returns them as a list of DeviceManagementConfigurationPolicy objects
                var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                    requestConfiguration.QueryParameters.Expand = new[] { "settings" }; // Expand the settings of each policy. Note - this might take some time to load
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
                // Iterate through the policies and add them to the DataGridView
                foreach (var policy in policies)
                {
                    // Check if required properties are not null
                    if (policy.Id == null || policy.Name == null || policy.Description == null)
                    {
                        throw new InvalidOperationException("Policy properties cannot be null.");
                    }

                    dtg.Rows.Add(policy.Name,"Settings Catalog",policy.Platforms,policy.Id );
                }
            }
            catch (Exception ex)
            {
                // Log the error message
                WriteToLog($"Exception: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
