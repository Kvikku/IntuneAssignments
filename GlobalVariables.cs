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


        public static string MSGraphAssembly
        {
            get { return graphAssembly; }
        }

    }
}
