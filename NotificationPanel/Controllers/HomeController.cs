using NotificationPanel.Common;
using NotificationPanel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPanel.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository = new UserRepository();


        NotificationRepository notificationRepository = new NotificationRepository();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.list = userRepository.GetUser();
            return View();
        }

        [Authorize]
        public ActionResult UserDashboard()
        {
            
           ViewBag.UserOnline = userRepository.GetOnlineUsers();
            ViewBag.LastActiveUsers = userRepository.GetUser().Where(x=>x.IsOnline == false);
            ViewBag.TotalUsersActive = userRepository.GetUser();
            if (Session["UserId"] != null)
            {

            ViewBag.unRead = notificationRepository.GetNotificationByReceiverId(Convert.ToInt64(Session["UserId"])).Where(x => x.IsRead != true).ToList();

            }

            ViewBag.DisabledUsers = userRepository.GetDisabledUsers();
            return View();

         }

       


    }
}