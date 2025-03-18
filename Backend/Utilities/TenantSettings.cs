using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuneAssignments.Backend.Utilities
{
    public class TenantSettings
    {
        public string? TenantName { get; set; }
        public string? TenantID { get; set; }
        public string? ClientID { get; set; }

        public static void SaveSettings(string tenantName, string tenantID, string clientID, string filePath)
        {
            var settings = new TenantSettings
            {
                TenantName = tenantName,
                TenantID = tenantID,
                ClientID = clientID
            };

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

      
    }
}
