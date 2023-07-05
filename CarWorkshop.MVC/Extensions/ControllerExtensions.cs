using CarWorkshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarWorkshop.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string type, string messade)
        {
            var notification = new Notification(type, messade);
            controller.TempData["notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
