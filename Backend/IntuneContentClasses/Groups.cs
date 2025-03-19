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

namespace IntuneAssignments.Backend.IntuneContentClasses
{
    public class Groups
    {
        public static async Task<List<Group>> GetAllGroups(GraphServiceClient graphServiceClient)
        {
            // This method gets all the groups in the tenant and returns them as a list of Group objects
            try
            {
                WriteToLog("Getting all groups in the tenant");
                var result = await graphServiceClient.Groups.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Count = true;
                    requestConfiguration.QueryParameters.Filter = "not(groupTypes/any(g:g eq 'Unified'))";
                    requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
                });

                List<Group> groups = new List<Group>();

                // Iterate through the pages of results
                var pageIterator = PageIterator<Group, GroupCollectionResponse>.CreatePageIterator(graphServiceClient, result, (group) =>
                {
                    groups.Add(group);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();
                WriteToLog($"Found {groups.Count} groups in the tenant");
                // return the list of groups
                return groups;
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                // Log the error message
                WriteToLog($"ODataError: {me.Message}");
                MessageBox.Show(me.Message);
                return null;
            }
        }

        public static async Task<List<Group>> SearchForGroups(GraphServiceClient graphServiceClient, string searchQuery)
        {
            // This method searches for groups in the tenant based on a search query and returns the results as a list of Group objects
            try
            {
                WriteToLog("Searching for groups. Search query: " + searchQuery);

                var result = await graphServiceClient.Groups.GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Search = "\"displayName:" + searchQuery + "\"";
                    requestConfiguration.QueryParameters.Filter = "not(groupTypes/any(g:g eq 'Unified'))";
                    requestConfiguration.Headers.Add("ConsistencyLevel", "eventual");
                });
                List<Group> groups = new List<Group>();

                // Iterate through the pages of results
                var pageIterator = PageIterator<Group, GroupCollectionResponse>.CreatePageIterator(graphServiceClient, result, (group) =>
                {
                    groups.Add(group);
                    return true;
                });
                // start the iteration
                await pageIterator.IterateAsync();
                WriteToLog($"Found {groups.Count} groups in the tenant");
                // return the list of groups
                return groups;
            }
            catch (Microsoft.Graph.Beta.Models.ODataErrors.ODataError me)
            {
                // Log the error message
                WriteToLog($"ODataError: {me.Message}");
                MessageBox.Show(me.Message);
                return null;
            }
        }
        public static void AddGroupsToDTG(List<Group> groups, System.Windows.Forms.DataGridView dtg)
        {
            // Check if the groups list is null
            if (groups == null)
            {
                WriteToLog("Groups list is null");
                return;
            }
            // Clear the data grid view
            dtg.Rows.Clear();
            // Add the groups to the data grid view
            foreach (Group group in groups)
            {

                var groupType = "";
                var memberShipRule = "N/A";

                if (group.GroupTypes.Count > 0)
                {
                    groupType = "Dynamic group";
                    memberShipRule = group.MembershipRule;
                }
                else
                {
                    groupType = "Assigned";
                }

                    dtg.Rows.Add(group.DisplayName, groupType, memberShipRule, group.Id);
            }
        }
    }
}
