using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class MaintenanceEntities
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public int vehicleID { get; set; }
        public string model { get; set; }
        public string type { get; set; }
       // public IList<Vehicle> Vehicles { get; set; }

    }
}
