using NotificationPanel.Database.DTO;
using NotificationPanel.Database.Model;
using NotificationPanel.Repository;
using System;
using NotificationPanel.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NotificationPanel.Controllers
{
    public class AccountController : Controller
    {

        NotificationPanelEntities2 db = new NotificationPanelEntities2();

        
        // GET: Account


        public ActionResult Login()
        {

            return View();
        }

        //[HttpPost]
        //public ActionResult CheckCredentials(string Email, string Password)
        //{
        //    UserRepository _userRepository = new UserRepository();
        //    bool Exists = false;
        //    if (Email != null || Password != null)
        //    {

            
        //    var list = _userRepository.GetUser()
        //        .Where(x => x.Email.ToLower() == Email.ToLower() && x.Password.ToLower() == Password.ToLower())
        //        .FirstOrDefault();
                
        //        if (list != null)
        //        {
        //            Exists = true;  
                    
        //            //return Json(Exists);
        //        }
        //        else
        //        {

        //            Exists = false;
        //            //return Json(Exists);
        //        }
        //    }
        //    return View(Exists);


        //}


        [HttpPost]
        public ActionResult Login(DTOLogin l)
        {

            UserRepository _userRepository = new UserRepository();
            if (l.Email  != null && l.Password !=null)
            {


                var emailExists = _userRepository.GetUser()
                    .Any(x => x.Email.ToLower() == l.Email.ToLower());


                //var passwordExists = _userRepository.GetUser()
                //    .Any(x=>x.Password.Equals(l.Password));

          
            var list = _userRepository.GetUser()
                .Where(x => x.Email.ToLower() == l.Email.ToLower() && x.Password.ToLower() == l.Password.ToLower())
                .FirstOrDefault();
                if (emailExists)
                {
                    TempData["LoginError"] = "Incorrect Password!";
                }
                else
                    TempData["LoginError"] = "Invalid Email Account!";
                if (list != null)
            {
                FormsAuthentication.SetAuthCookie(l.Email, false);

                    
                    Session["UserId"] = list.Id;
                    Session["Name"] = list.Name;
                    Session["RoleId"] = list.RoleId;
                    Session["RoleName"] = list.RoleName;
                    Session["Image"] = list.Image == null? "avatar.png" : list.Image;
                    Session["Email"] = list.Email;
                    Session["IsOnline"] = list.IsOnline;
                    Session["IsActive"] = list.IsActive;
                    Current.CurrentUser = list;
                   
                var data = _userRepository.Set_IsOnline(Convert.ToInt64(Session["UserId"]),true);

            
                
                return RedirectToAction("UserDashboard", "Home");
            }
            }
            return View();
        }

      

        [Authorize]
     
        public ActionResult Logout()
        {
            UserRepository userRepository = new UserRepository();
            if (Current.CurrentUser != null)
            {

          
                 userRepository.Set_IsOnline(Convert.ToInt64(Session["UserId"]), false);

                 userRepository.Set_LastOnlineTime(Convert.ToInt64(Session["UserId"]), DateTime.Now.AddMinutes(-2));
            }

            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage("Session=Expired");



            return RedirectToAction("Login");

        }
    }
}