using NotificationPanel.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPanel.Controllers
{
    public class PostsController : Controller
    {
        NotificationPanelEntities2 db = new NotificationPanelEntities2();
        // GET: Posts
        public ActionResult Index(int id)
        {
            ViewBag.list = db.Posts.ToList().Where (x=>x.Id == id).FirstOrDefault();
            return View();
        }
    }
}