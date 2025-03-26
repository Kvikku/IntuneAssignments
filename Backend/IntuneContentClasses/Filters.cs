using Microsoft.Graph.Beta.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph.Beta;
using static IntuneAssignments.Backend.Utilities.FormUtilities;
using static IntuneAssignments.Backend.Utilities.GlobalVariables;

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class Filters
    {
        // Create a dictionary to store the filters
        


        public static Dictionary<string, string> filterNameAndID = new Dictionary<string, string>();
        public static string SelectedFilterName = "";
        public static string SelectedFilterID = "";
        public static DeviceAndAppManagementAssignmentFilterType deviceAndAppManagementAssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.None;


        public static async Task<List<DeviceAndAppManagementAssignmentFilter>> GetAllAssignmentFilters(GraphServiceClient graphServiceClient)
        {
            // Method to get the assignment filters for a policy
            // Create a new instance of the GraphServiceClient class

            // Create a list to store the assignment filters in
            List<DeviceAndAppManagementAssignmentFilter> assignmentFilters = new List<DeviceAndAppManagementAssignmentFilter>();

            try
            {
                // Look up the assignment filters
                var result = await graphServiceClient.DeviceManagement.AssignmentFilters.GetAsync();

                if (result != null && result.Value != null)
                {
                    // Create a page iterator
                    var pageIterator = PageIterator<DeviceAndAppManagementAssignmentFilter, DeviceAndAppManagementAssignmentFilterCollectionResponse>.CreatePageIterator(
                        graphServiceClient,
                        result,
                        (filter) =>
                        {
                            assignmentFilters.Add(filter);
                            return true;
                        });

                    // Iterate through the pages
                    await pageIterator.IterateAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                WriteToLog($"An error occurred while getting assignment filters: {ex.Message}");
            }


            // clear the dictionary
            filterDictionary.Clear();
            filterNameAndID.Clear();

            // Add filter name and ID to the dictionary
            foreach (var filter in assignmentFilters)
            {
                filterNameAndID.Add(filter.DisplayName, filter.Id);
            }

            return assignmentFilters;
        }
    }
}
