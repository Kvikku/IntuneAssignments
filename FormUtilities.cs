using Azure.Identity;
using Microsoft.Graph.Beta.Models;
using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IntuneAssignments.GraphServiceClientCreator;

namespace IntuneAssignments
{
    public class FormUtilities
    {
        // This class will contain methods that are used by multiple forms to reduce code duplication and improve maintainability of the codebase as a whole.

        // All members must be static so that they can be called from other classes without instantiating an object of this class

        public static void ClearRichTextBox(RichTextBox richTextBox)
        {

            richTextBox.Clear();

        }

        public static void ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static void ClearCheckedListBox(CheckedListBox checkedListBox)
        {

            checkedListBox.Items.Clear();

        }

        public static void PurgeLogFileContent()
        {

            // This method will be used to purge the content of the log file

            File.WriteAllText(GlobalVariables.MainLogFile, string.Empty);

        }

        public static void WriteSystemSummaryToLog()
        {
            // This method will be used to write a summary of the system to the log file

            // Create a new instance of the StreamWriter class
            System.IO.StreamWriter sw = new System.IO.StreamWriter(GlobalVariables.MainLogFile, true);

            // Write the data to the log file
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Beginning system summary");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The running system is {Environment.OSVersion} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The running system hostname is  {Environment.MachineName} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The running user is {Environment.UserName} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The executing assembly version is {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The executing assembly location is {System.Reflection.Assembly.GetExecutingAssembly().Location} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The executing assembly name is {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - The .NET Runtime Version is {Environment.Version} ");
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Finished system summary");
           

            // Close the StreamWriter instance
            sw.Close();
        }

        public static void WriteToLog(string data)
        {

            // This method will be used to log data to the main log file

            // Create a new instance of the StreamWriter class
            System.IO.StreamWriter sw = new System.IO.StreamWriter(GlobalVariables.MainLogFile, true);

            // Write the data to the log file
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {data}");

            // Close the StreamWriter instance
            sw.Close();

        }

        

        public static async Task<List<Group>> getAllEntraGroups()
        {

            

            /*
             * Method to look up groups in the Entra ID
             * 
             * TO DO
             * 
             * Replace other methods that look up groups in the Entra ID with this method
             * 
             */


            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();


            // Look up all groups in Entra ID and retrieve only the id, memberShipRule and displayName properties of the groups 

            var result = await graphClient.Groups.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "id", "memberShipRule", "displayName", "members" };
            });


            // Create a new list to store the groups in
            List<Group> entraGroups = new List<Group>();


            // Add the groups to the list
            entraGroups.AddRange(result.Value);

            return entraGroups;
            
        }


        // TODO

        // OK -  count group members
        // show if user or device group (or both)
        // show if group is dynamic or static, and show the membership rule if dynamic


        // method to filter through all members in a group and separate into users and devices


        public static async Task<List<DirectoryObject>> getGroupMembersFromGroup(string groupID)
        {

            // Method to look up group membership in the Entra ID



            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();

            // Look up all members of the group
            var result = await graphClient.Groups[groupID].Members.GetAsync();

            // Create list

            List<DirectoryObject> groupMembers = new List<DirectoryObject>();

            // Add to list

            groupMembers.AddRange(result.Value);

            // check odata type foreach member

            return groupMembers;

        }


        // Method to process list of group members and sort into users and devices


        public static void sortGroupMembers(DirectoryObject groupMember)
        {

            // Create lists to store users and devices in

            
            
            


            

        }




        // may need to delete this later:

        public static async Task<List<Device>> getEntraGroupMembership(string groupID)
        {
            // Method to look up group membership in the Entra ID

            // Create a new instance of the GraphServiceClient class
            var graphClient = CreateGraphServiceClient();


            // Look up all members of the group and retrieve only the id, displayName
            // Use OData casts to specify the type of the object to be returned
            // https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/dev/docs/upgrade-to-v5.md#support-for-odata-casts-in-request-builders


            var result = await graphClient.Groups[groupID].Members.GraphDevice.GetAsync(); //OData cast to GraphDevice

            

            // create a new list to store the group members in

            List<Device> groupMembers = new List<Device>();

            // Add the group members to the list

            groupMembers.AddRange(result.Value);

            foreach (var member in groupMembers)
            {
                MessageBox.Show(member.DisplayName);
            }
            
            return groupMembers;

        }


    }
}
