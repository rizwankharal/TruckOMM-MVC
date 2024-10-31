using BusinessLayer;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRANSPORTATIONMANAGEMENTSYSTEM.Controllers
{
    public class HomeController : Controller
    {
        private readonly static string connectionString= "Data Source=STELLA-262\\SQLEXPRESS;Initial Catalog=TruckOOM;Integrated Security=True;Encrypt=False";
        Maintenance maintenance = new Maintenance(connectionString);
        Vehicles _vehicles = new Vehicles(connectionString);
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult FetchDataFromVehiclesAndMaintienance()
        {
            var FetechData = maintenance.GetMaintenanceData("[dbo].[FetchDataFromVehiclesAndMaintienance]");
            return Json(FetechData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchVehicalsData()
        {
            var FetechData = _vehicles.GetVehicleData("[dbo].[Fetchvehicles]");
            return Json(FetechData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMaintenanceData(MaintenanceEntities maintenancedata)
        {
            try
            {

                if (maintenancedata.id > 0)
                {
                     maintenance.InsertDataInMaintenance(maintenancedata, "UpdateMaintenanceData");

                    return Json(new { success = true, message = "Data updated successfully." });
                }
                else
                {
                     maintenance.InsertDataInMaintenance(maintenancedata, "InsertMaintenanceData");

                    return Json(new { success = true, message = "Data saved successfully." });
                }

                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteMaintenanceData(int id)
        {
            try
            {

                if (id > 0)
                {
                    maintenance.DeleteMaintenanceRecord(id, "DeleteMaintenanceRecord");

                    return Json(new { success = true, message = "Data updated successfully." });
                }
                else
                {
                 

                    return Json(new { success = false, message = "Some thing went wrong" });
                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}