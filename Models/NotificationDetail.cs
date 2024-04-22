using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationsView.Models
{
    public class NotificationDetail
    {
        public int ND_ID { get; set; }
        public int LC_ID { get; set; }
        public DateTime ND_Date { get; set; }
        public string ND_Description { get; set; }
        public string ND_Status { get; set; }
    }
}