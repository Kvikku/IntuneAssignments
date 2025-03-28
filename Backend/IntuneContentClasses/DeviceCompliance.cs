using Microsoft.Graph;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class DeviceCompliance
    {
        public static async Task<List<DeviceManagementCompliancePolicy>> GetAllDeviceCompliancePolicies(GraphServiceClient graphServiceClient)
        {
            // This method retrieves all the device compliance policies from Intune and returns them as a list of DeviceManagementCompliancePolicy objects
            try
            {
                WriteToLog("Retrieving all device compliance policies.");

                var result = await graphServiceClient.DeviceManagement.DeviceCompliancePolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Top = 1000;
                });

                List<DeviceManagementCompliancePolicy> compliancePolicies = new List<DeviceManagementCompliancePolicy>();
                // Iterate through the pages of results
                var pageIterator = PageIterator<DeviceManagementCompliancePolicy, DeviceCompliancePolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                {
                    compliancePolicies.Add(policy);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();

                WriteToLog($"Found {compliancePolicies.Count} device compliance policies.");

                // return the list of policies
                return compliancePolicies;
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
            return new List<DeviceManagementCompliancePolicy>();
        }

        public static async Task<List<DeviceManagementCompliancePolicy>> SearchForDeviceCompliancePolicies(GraphServiceClient graphServiceClient, string searchQuery)
        {
            // This method searches the Intune device compliance policies for a specific query and returns the results as a list of DeviceManagementCompliancePolicy objects
            try
            {
                WriteToLog("Searching for device compliance policies. Search query: " + searchQuery);

                var result = await graphServiceClient.DeviceManagement.DeviceCompliancePolicies.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Filter = $"contains(Name,'{searchQuery}')";
                });

                List<DeviceManagementCompliancePolicy> compliancePolicies = new List<DeviceManagementCompliancePolicy>();
                // Iterate through the pages of results
                var pageIterator = PageIterator<DeviceManagementCompliancePolicy, DeviceCompliancePolicyCollectionResponse>.CreatePageIterator(graphServiceClient, result, (policy) =>
                {
                    compliancePolicies.Add(policy);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();

                WriteToLog($"Found {compliancePolicies.Count} device compliance policies.");

                // return the list of policies
                return compliancePolicies;
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
            return new List<DeviceManagementCompliancePolicy>();
        }
    }
}
