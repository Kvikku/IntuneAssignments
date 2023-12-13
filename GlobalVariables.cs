using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuneAssignments
{
    public class GlobalVariables
    {

        public static string configurationFolder = @"C:\ProgramData\IntuneAssignments";
        public static string AppSettingsFile = @"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";
        public static string MainLogFile = @"C:\ProgramData\IntuneAssignments" + @"\Primary logfile.log";
        public static string graphAssembly = "Microsoft.Graph.Beta";
        public string graphClassNamePrefix = "Microsoft.Graph.Beta.Models.";

        public static string allUsersGroupID = "acacacac-9df4-4c7d-9d50-4ef0226f57a9";
        // "@odata.type": "#microsoft.graph.allLicensedUsersAssignmentTarget"
        public static string allUsersGroupName = "All Users";
        public static string allDevicesGroupName = "All Devices";


        public static string allDevicesGroupID = "adadadad-808e-44e2-905a-0b7873a8a531";
        // "@odata.type": "#microsoft.graph.allDevicesAssignmentTarget"


        public static string MSGraphAssembly
        {
            get { return graphAssembly; }
        }

    }
}
