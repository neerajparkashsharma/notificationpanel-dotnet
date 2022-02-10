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
    public class UsersController : Controller

    {
        UserRepository userRepository = new UserRepository();

        // GET: Users
        //public ActionResult List()
        //{


        //    ViewBag.list = userRepository.GetOnlineUsers();
        //    return View();


        //}


        [Authorize(Roles ="Admin")]
        public ActionResult Create(string Id)
        {
            

                if (!String.IsNullOrEmpty(Id))
                {
                    long ItemId = 0;
                    var IsId = Int64.TryParse(Id, out ItemId);

                    if (IsId)
                    {

                        UserRepository UserRepository = new UserRepository();
                        var item = UserRepository.GetUser(Convert.ToInt64(Id));

                        ViewBag.Item = item;
                    

                }
                    else
                    {
                        return View("/Home/UserDashboard");
                    }
               

            }


                else
                {

              
                
                 ViewBag.Item = new DTOUser();
                
               
              
            }

                return View();
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Delete(string Id)
        {
            RequestMessage requestMessage = new RequestMessage();
            try
            {
                UserRepository UserRepository = new UserRepository();
                var data = UserRepository.Set_IsActive(Convert.ToInt64(Id), false);
                requestMessage.IsSuccess = true;
                requestMessage.RequestedString = "Deleted Successfully!";
               

            }
            catch (Exception)
            {
                requestMessage.IsSuccess = false;
                requestMessage.RequestedString = "Not Deleted Successfully!";

                throw;

            }
            return Json(requestMessage);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult ReActive(string Id)
        {
            RequestMessage requestMessage = new RequestMessage();
            try
            {
                UserRepository UserRepository = new UserRepository();
                var data = UserRepository.Set_IsActive(Convert.ToInt64(Id), true);
                requestMessage.IsSuccess = true;
                requestMessage.RequestedString = "Restored Successfully!";
             
            }
            catch (Exception)
            {
                requestMessage.IsSuccess = false;
                requestMessage.RequestedString = "Not Restored Successfully!";

                throw;

            }
            return Json(requestMessage);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public virtual ActionResult Create(DTOUser obj, HttpPostedFileBase file)
        {
            RequestMessage requestMessage = new RequestMessage();

            // Initialize Respository

            try
            {
                requestMessage.IsSuccess = true;

                if (file != null && file.ContentLength > 0)
                {
                    // Save Object User
                  
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Images/" + ImageName);
                    file.SaveAs(physicalPath);

                  


                    
                    obj.Image = ImageName;
                    obj = userRepository.SaveUser(obj);
                    
                    requestMessage.ResponseObject = obj;

                   return RedirectToAction("UserDashboard", "Home");
                 
                }
                else
                {

                    obj = userRepository.SaveUser(obj);
                    requestMessage.ResponseObject = obj;
                    return RedirectToAction("UserDashboard", "Home");
                }

            }
            catch (Exception ex)
            {
                requestMessage.IsSuccess = false;
                requestMessage.ResponseString = "Error in Saving Data";
                requestMessage.ResponseObject = ex;
            }


            // return to action
            return RedirectToAction("UserDashboard","Home");
        }


        [Authorize]
        public ActionResult  YourProfile()
        {
            if (Session["UserId"]== null)
            {
                return RedirectToAction("Login", "Account");
            }
            else { 
            ViewBag.data = userRepository.GetUser(Convert.ToInt64(Session["UserId"]));
            }
            return View();
        }

        [HttpPost]
     
    
        public JsonResult CheckEmail(string Email)
        {
            UserRepository userRepository = new UserRepository();
            bool EmailExists = false;
            if (Email != null)
            {


                EmailExists = userRepository.GetUser().Select(x => x.Email == null ? "" : x.Email.ToLower()).ToList().Contains(Email.ToLower());
                return Json(EmailExists);
            }
            else if(Email == null)
            {
                return Json(EmailExists = false);
            }
            else {
                return Json(EmailExists= false);
            }
           


        }


    }


}