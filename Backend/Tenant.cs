using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuneAssignments.Backend
{
    
    // Maybe not needed after all. 
    
    public class Tenant 
    {
        public Dictionary<string, TenantInfo> Tenants { get; set; }
    }

    public class TenantInfo
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
    }
}
