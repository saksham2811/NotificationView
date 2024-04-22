using NotificationsView.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationsView.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            List<NotificationDetail> notificationsList = new List<NotificationDetail>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))

            {

                string query = "SELECT ND_ID, LC_ID, ND_DATE, ND_DESCRIPTION, ND_STATUS FROM NotificationDetail";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {

                    NotificationDetail notificationDetail = new NotificationDetail();

                    notificationDetail.ND_ID = (int)reader["ND_ID"];

                    notificationDetail.LC_ID = (int)reader["LC_ID"];
                    
                    notificationDetail.ND_Date = (DateTime)reader["ND_DATE"];

                    notificationDetail.ND_Description = reader["ND_Description"].ToString();

                    notificationDetail.ND_Status = reader["ND_Status"].ToString();

                    notificationsList.Add(notificationDetail);

                }

            }
            return View(notificationsList);
        }
    }
}