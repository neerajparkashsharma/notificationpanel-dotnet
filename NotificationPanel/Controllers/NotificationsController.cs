using NotificationPanel.Common;
using NotificationPanel.Database.DTO;
using NotificationPanel.Database.Model;
using NotificationPanel.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPanel.Controllers
{
   
    
    public class NotificationsController : Controller
    {

        NotificationRepository objNotificationRepository = new NotificationRepository();
        // GET: Notifications
        public ActionResult Compose()
        {
            UserRepository u = new UserRepository();
            //if (!String.IsNullOrEmpty(Id))
            //{
            //    long ItemId = 0;
            //    var IsId = Int64.TryParse(Id, out ItemId);
            //    if (IsId)
            //    {
                   
            //        NotificationRepository notificationRepository = new NotificationRepository();
            //        var item = notificationRepository.GetNotification(Convert.ToInt64(Id));

                    

            //        ViewBag.Item = item;
                   
            //    }
            //    else
            //    {
            //        return View("All");
            //    }
            //}


            //else
            //{
               
               
                    ViewBag.Item = new DTONotification();
            ViewBag.SenderId = Convert.ToInt64(Session["UserId"]);
                    ViewBag.ReceiverList =(u.GetUser().ToList());

    


            //}
           
            return View();
        }

        [HttpPost]
        public virtual ActionResult Compose(DTONotification obj)
        {
            RequestMessage requestMessage = new RequestMessage();

            // Initialize Respository
           
            try
            {
                if (obj.file !=null)
                {
                    string ImageName = System.IO.Path.GetFileName(obj.file.FileName);
                    string physicalPath = Server.MapPath("~/Images/" + ImageName);
                   obj.file.SaveAs(physicalPath);

                   
                    obj.Image = ImageName;
                    obj = objNotificationRepository.SaveNotification(obj);
                    return RedirectToAction("Sent");
                }
                else
                {
                    obj = objNotificationRepository.SaveNotification(obj);
                    return RedirectToAction("Sent");
                }
             


                //}
            }
            catch (Exception ex)
            {
                requestMessage.IsSuccess = false;
                requestMessage.ResponseString = "Error in Saving Data";
                requestMessage.ResponseObject = ex;
            }


            // return to action
            return RedirectToAction("Sent");
        }


        public  ActionResult All()
        {


            if (Session["UserId"] != null)
            {
                ViewBag.list = objNotificationRepository.GetNotificationByReceiverId(Convert.ToInt64(Session["UserId"]));
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }

        }

        [Authorize]
        public ActionResult Unread()
        {

            if (Session["UserId"] != null)
            {
                ViewBag.list = objNotificationRepository.GetNotificationByReceiverId(Convert.ToInt64(Session["UserId"])).Where(x=>x.IsRead != true);
                
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }


       
        [HttpPost]
        public JsonResult Read(string Id)
        {
            RequestMessage requestMessage = new RequestMessage();
            try
            {
                NotificationRepository NotificationRepository = new NotificationRepository();
                if (NotificationRepository.GetNotification(Convert.ToInt64(Id)).IsRead != true )
                {

              
         
                var data = NotificationRepository.Set_IsRead(Convert.ToInt64(Id));
                
                requestMessage.IsSuccess = true;
                requestMessage.RequestedString = "Read Successfully!";
                }

            }
            catch (Exception e)
            {
                requestMessage.IsSuccess = false;
              


            }
            return Json(requestMessage);
        }
        [Authorize]
        public ActionResult Sent()
        {

            if (Session["UserId"] != null)
            {
                ViewBag.list = objNotificationRepository.GetNotificationBySenderId(Convert.ToInt64(Session["UserId"]));

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }


        }



    
        [Authorize]
        public ActionResult View(long Id)
        {

            if(Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            else {
              

               
                ViewBag.data = objNotificationRepository.GetNotificationView(Id, Convert.ToInt64(Session["UserId"]));

                if (ViewBag.data == null)
                {
                    ViewBag.Message = "Invalid";
                    return ViewBag.Message;
                }
                else
                {
                    
                    return View();
                }
            
            }

          
        }



      
        public JsonResult ReceiverList()
        {
            UserRepository _userRepository = new UserRepository();
            var list = _userRepository.GetUser().Where(x=>x.Id != Convert.ToInt64(Session["UserId"])).ToList();

            return Json(list,JsonRequestBehavior.AllowGet);

        }


    }
}