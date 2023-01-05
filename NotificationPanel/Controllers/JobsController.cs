using NotificationPanel.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;


namespace NotificationPanel.Controllers
{
    public class JobsController : Controller
    {
        NotificationPanelEntities2 db = new NotificationPanelEntities2();
        // GET: Jobs
        public ActionResult Index()
        {
            ViewBag.list = db.Posts.ToList();


            return View();
        }


        

        public ActionResult CreateJob()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteJob(int id)
        {

            NotificationPanelEntities2 d = new NotificationPanelEntities2();
          
            d.Posts.Remove(d.Posts.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CreateJob(Post p)
        {


            try { 
            p.CreatedBy = Session["name"].ToString();
            p.CreatedOn = DateTime.Now;
            db.Posts.Add(p);


                TempData["m"] = "Success!";


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch(Exception e)
            {
                TempData["m"] = "Some Error Occured";
                return View();
            }


            

        }


    }
}