using Microsoft.Graph.Beta.DeviceManagement.Intents.Item.Categories.Item;
using Microsoft.Graph.Beta.Models;

namespace IntuneAssignments.Backend.Utilities
{
    public static class GlobalVariables
    {
        // TODO - Delete program data folder variables
        public static string configurationFolder = @"C:\ProgramData\IntuneAssignments";
        public static string AppSettingsFile = @"C:\ProgramData\IntuneAssignments" + @"\AppSettings.json";
        public static string MainLogFile = @"C:\ProgramData\IntuneAssignments" + @"\Primary Logfile.log";



        public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string appFolderName = "IntuneAssignments";
        public static string appDataFolder = Path.Combine(appDataPath, appFolderName);

        public static string logFileName = "IntuneAssignments.log";
        public static string appSettingsFileName = "AppSettings.json";
        public static string primaryLogFile = Path.Combine(appDataPath, appFolderName, logFileName);
        public static string appSettingsFile = Path.Combine(appDataPath, appFolderName, appSettingsFileName);

        public static string SourceTenantSettingsFileName = "SourceTenantSettings.json";
        public static string DestinationTenantSettingsFileName = "DestinationTenantSettings.json";
        public static string sourceTenantSettingsFile = Path.Combine(appDataPath, appFolderName, SourceTenantSettingsFileName);
        public static string destinationTenantSettingsFile = Path.Combine(appDataPath, appFolderName, DestinationTenantSettingsFileName);
        public static string ImportStatusFileName = $"{DateTime.Now:yyyy-MM-dd-HH-mm}-ImportStatus.log";
        public static string importStatusFile = Path.Combine(appDataPath, appFolderName, ImportStatusFileName);

        public static bool isSourceTenantConnected = false;
        public static bool isDestinationTenantConnected = false;

        public static string sourceTenantName { get; set; }
        public static string destinationTenantName { get; set; }

        //public static string? sourceClientID { get; set; }
        //public static string? sourceTenantID { get; set; }
        //public static string? destinationClientID { get; set; }
        //public static string? destinationTenantID { get; set; }


        // Old variable for permissions - delete
        public static List<string> permissionsToCheck = new List<string> { "Read and write Microsoft Intune apps", "Read Microsoft Intune device configuration and policies",
        "Read and write Microsoft Intune device configuration and policies","Read and write Microsoft Intune devices","Read and write Microsoft Intune configuration",
        "Read directory data"};



        // new variable for permissions
        public static Dictionary<string, string> PermissionIDAndDisplayName = new Dictionary<string, string>
        {
            {"7b3f05d5-f68c-4b8d-8c59-a2ecd12f24af", "Read and write Microsoft Intune apps" },
            {"0883f392-0a7a-443d-8c76-16a6d39c7b63", "Read and write Microsoft Intune Device Configuration and Policies" },
            {"662ed50a-ac44-4eef-ad86-62eed9be2a29", "Read and write Microsoft Intune configuration" },
            {"44642bfe-8385-4adc-8fc6-fe3cb2c375c3", "Read and write Microsoft Intune devices" },
            {"06da0dbc-49e2-44d2-8312-53f166ab848a", "Read directory data" }
        };

        public static Color defaultColor = Color.FromArgb(46, 51, 73);
        public static Color currentColor = Color.FromArgb(46, 51, 73);

        public static string graphAssembly = "Microsoft.Graph.Beta";
        public static string graphClassNamePrefix = "Microsoft.Graph.Beta.Models.";

        public static string allUsersGroupID = "acacacac-9df4-4c7d-9d50-4ef0226f57a9";
        // "@odata.type": "#microsoft.graph.allLicensedUsersAssignmentTarget"
        public static string allUsersGroupName = "All Users";
        public static string allDevicesGroupName = "All Devices";


        public static string allDevicesGroupID = "adadadad-808e-44e2-905a-0b7873a8a531";
        // "@odata.type": "#microsoft.graph.allDevicesAssignmentTarget"


        // This variable is used to define apps that have read only descriptions, which cannot be modified by the user in the UI
        public static string[] readOnlyDescription = new string[] { "AndroidManagedStoreApp", "ManagedAndroidStoreApp", "ManagedIOSStoreApp", "IosVppApp" };

        // Create a dictionary to store the filter names and their corresponding rule properties
        public static Dictionary<string, string> filterDictionary = new Dictionary<string, string>();

        // Create a dictionary to store the filter name and ID
        public static Dictionary<string, string> filterNameAndID = new Dictionary<string, string>();

        // Create a dictionary to store settings catalog name and ID
        public static Dictionary<string, string> settingsCatalogNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> deviceComplianceNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> deviceConfigurationNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> ADMXtemplateNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> proactiveRemediationNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> powerShellScriptsNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> autopilotProfilesNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> macOSShellScriptsNameAndID = new Dictionary<string, string>();
        public static Dictionary<string, string> WindowsFeatureUpdateProfileNameAndID = new Dictionary<string, string>();


        public static string? AssignmentFilterID = null;
        public static DeviceAndAppManagementAssignmentFilterType AssignmentFilterType = DeviceAndAppManagementAssignmentFilterType.None;

        public static string MSGraphAssembly
        {
            get { return graphAssembly; }
        }


        



    }
}
