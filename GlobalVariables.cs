namespace IntuneAssignments
{
    public class GlobalVariables
    {

        public static string configurationFolder = @"C:\ProgramData\IntuneAssignments";
        public static string AppSettingsFile = @"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";
        public static string MainLogFile = @"C:\ProgramData\IntuneAssignments" + @"\Primary Logfile.log";



        public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string appFolderName = "IntuneAssignments";
        public static string appDataFolder = Path.Combine(appDataPath, appFolderName);

        public static string logFileName = "IntuneAssignments.log";
        public static string appSettingsFileName = "AppSettings.json";
        public static string primaryLogFile = Path.Combine(appDataPath,appFolderName,logFileName);
        public static string appSettingsFile = Path.Combine(appDataPath, appFolderName, appSettingsFileName);






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
