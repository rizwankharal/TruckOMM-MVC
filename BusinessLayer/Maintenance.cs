using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainEntities;

namespace BusinessLayer
{
    public class Maintenance
    {
        private readonly MaintenanceDB maintenanceDB;

        public Maintenance(string connectionString)
        {
            maintenanceDB = new MaintenanceDB(connectionString);
        }

        public List<MaintenanceEntities> GetMaintenanceData(string storedProcedureName)
        {
            return maintenanceDB.GetMaintenanceData(storedProcedureName);
        }

        public bool InsertDataInMaintenance(MaintenanceEntities maintenance, string storedProcedureName)
        {
            return maintenanceDB.InsertMaintenanceData(maintenance, storedProcedureName);
        }

        public bool DeleteMaintenanceRecord(int id, string storedProcedureName)
        {
            return maintenanceDB.DeleteMaintenanceRecord(id, storedProcedureName);
        }

    }
}
