using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationsView.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Notification()
        {
            {
                if (TempData["SuccessMessage"] != null)
                {
                    ViewBag.SuccessMessage = TempData["SuccessMessage"];
                }
                var locationList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "-- Select Location --" },
                    new SelectListItem { Value = "1", Text = "Noida" },
                    new SelectListItem { Value = "2", Text = "Ahmedabad" },
                    new SelectListItem { Value = "3", Text = "California" }
                };
                ViewBag.EmployeeDropDown = locationList;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Save(FormCollection frm)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertNotificationDetail", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LC_ID", frm["LocationDropDown"]);
                    cmd.Parameters.AddWithValue("@ND_Date", frm["NotificationDateTxtBox"]);
                    cmd.Parameters.AddWithValue("@ND_Description", frm["DescriptionTxtBox"]);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            TempData["SuccessMessage"] = "Data inserted successfully.";
            return RedirectToAction("Notifications");
        }
    }
}