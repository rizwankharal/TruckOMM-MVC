using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DomainEntities;
using System.Web.Services;
using Newtonsoft.Json;


namespace TransportationManagementSystemMaintenanceModule
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetData();
        }

       
        public  List<MaintenanceEntities> GetMaintenanceDataForTable()
        {
            string connectionString = "Data Source=STELLA-262\\SQLEXPRESS;Initial Catalog=TruckOOM;Integrated Security=True;Encrypt=False";
            Maintenance _maintenance = new Maintenance(connectionString);

           

            List<MaintenanceEntities> maintenancesData = _maintenance.GetMaintenanceData("[dbo].[FetchDataFromVehiclesAndMaintienance]");

            return maintenancesData;
           

           
        }
    }
}