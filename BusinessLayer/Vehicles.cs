using DataAccessLayer;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Vehicles
    {
        private readonly MaintenanceDB maintenanceDB;

        public Vehicles(string connectionString)
        {
            maintenanceDB = new MaintenanceDB(connectionString);
        }

        public List<VehicleEntities> GetVehicleData(string storedProcedureName)
        {
            return maintenanceDB.GetVehiclesData(storedProcedureName);
        }
    }
}
