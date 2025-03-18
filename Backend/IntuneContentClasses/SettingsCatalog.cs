using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;

namespace IntuneAssignments.Backend.Intune_content_classes
{
    public class SettingsCatalog
    {
        public static async Task<List<DeviceManagementConfigurationPolicy>> GetAllSettingsCatalogPolicies(Microsoft.Graph.Beta.GraphServiceClient graphServiceClient)
        {
            var result = await graphServiceClient.DeviceManagement.ConfigurationPolicies.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Top = 1000;
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

            int policyCount = 0;

            foreach (var policy in configurationPolicies)
            {

                var settingsQuery = await graphServiceClient.DeviceManagement.ConfigurationPolicies[policy.Id].Settings.GetAsync();

                // Add settings to the policy object
                configurationPolicies[policyCount].Settings = settingsQuery.Value.ToList() ?? new List<DeviceManagementConfigurationSetting>();
                policyCount++;

            }

            // return the list of policies
            return configurationPolicies;
        }
    }
}
