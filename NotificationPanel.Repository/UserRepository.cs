using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using NotificationPanel.Database.Model;
using NotificationPanel.Database.DTO;
using NotificationPanel.Common;

namespace NotificationPanel.Repository
{

    public  class UserRepository : Repository
    {
        #region User



        public virtual List<DTOUser> GetUser()
        {
            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == true || x.IsActive == null)
            .ToList()
            .Select(x => new DTOUser()
            {
                
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleId = x.RoleId,
                RoleName = x.Role == null ? "Not Available" :x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,  Phone = x.Phone


            })
            .ToList();
            return listUser;
        }


        public virtual List<DTOUser> GetDisabledUsers()
        {
            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == false)
            .ToList()
            .Select(x => new DTOUser()
            {

                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleName = x.Role == null ? "Not Available" : x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,
                Phone = x.Phone


            })
            .ToList();
            return listUser;
        }

        public virtual List<DTOUser> GetUserByName(string name)

        {
            
            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x=>x.Name==name)
            .ToList()
            .Select(x => new DTOUser()
            {


                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleName = x.Role == null ? "Not Available" : x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,
                Phone = x.Phone

            })
            .ToList();
            return listUser;
        }
        public virtual List<DTOUser> GetUserByRoleId(long roleId)

        {

            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x => x.RoleId == roleId)
            .ToList()
            .Select(x => new DTOUser()
            {

                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleName = x.Role == null ? "Not Available" : x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,
                Phone = x.Phone



            })
            .ToList();
            return listUser;
        }
        public virtual List<DTOUser> GetOnlineUsers()

        {

            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x => x.IsOnline== true)
            .ToList()
            .Select(x => new DTOUser()
            {


                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleId = x.RoleId,
                RoleName = x.Role == null ? "Not Available" : x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,
                Phone = x.Phone



            })
            .ToList();
            return listUser;
        }
        public virtual List<DTOUser> GetUserByDOB(DateTime DOB)

        {

            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x => x.DOB == DOB)
            .ToList()
            .Select(x => new DTOUser()
            {


                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleName = x.Role == null ? "Not Available" : x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,
                Phone = x.Phone



            })
            .ToList();
            return listUser;
        }
        public virtual List<DTOUser> GetUserByEmail(string email)

        {

            var listUser = db.Users

             .Include(x => x.Role)
            //.Where(x => x.LastOnlineDateTime.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x => x.Email == email)
            .ToList()
            .Select(x => new DTOUser()
            {


                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,  
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                DOB = x.DOB,
                RoleName = x.Role == null ? "Not Available" : x.Role.Name,
                Password = x.Password,
                Email = x.Email,
                Gender = x.Gender,
                Address = x.Address,
                IsOnline = x.IsOnline,
                Image = x.Image,
                LastOnlineDateTime = x.LastOnlineDateTime,
                Phone = x.Phone



            })
            .ToList();
            return listUser;
        }
        public virtual DTOUser GetUser(long Id)
        {
            var obj = db.Users


                .Include(x=>x.Role)
               .Where(x => (x.IsActive == true || x.IsActive == null))
            .Where(x => x.Id == Id).FirstOrDefault();

            if (obj != null)
            {

                DTOUser DTOObj = new DTOUser();
                DTOObj.Id = obj.Id;

                DTOObj.Name = obj.Name;
                DTOObj.IsActive = obj.IsActive;
                DTOObj.CreatedOn = obj.CreatedOn;
                DTOObj.CreatedBy = obj.CreatedBy;
                DTOObj.UpdatedOn = obj.UpdatedOn;
                DTOObj.UpdatedBy = obj.UpdatedBy;
                DTOObj.DOB = obj.DOB;
                DTOObj.Address = obj.Address;
                DTOObj.RoleId = obj.RoleId;
                DTOObj.RoleName = obj.Role == null ?  "" : obj.Role.Name ;
                DTOObj.Password = obj.Password;
                DTOObj.Email = obj.Email;
                DTOObj.Gender = obj.Gender;
                DTOObj.Address = obj.Address;
                DTOObj.IsOnline = obj.IsOnline;
                DTOObj.Image = obj.Image;
                DTOObj.LastOnlineDateTime = obj.LastOnlineDateTime;
                DTOObj.Phone = obj.Phone;




                return DTOObj;

            }
            return null;
        }



        public DTOUser SaveUser(DTOUser DTOObj)
        {
            var dbObj = db.Users.Where(x => x.Id == DTOObj.Id).FirstOrDefault();
            if (dbObj != null)
            {
                dbObj.Id = DTOObj.Id;
                dbObj.Name = DTOObj.Name;
                dbObj.Email = DTOObj.Email;
                dbObj.Password = DTOObj.Password;
                dbObj.DOB = DTOObj.DOB;
                dbObj.Gender = DTOObj.Gender;
                dbObj.Image = DTOObj.Image;
                dbObj.IsActive = DTOObj.IsActive;
                dbObj.Address = DTOObj.Address;
                dbObj.IsOnline = DTOObj.IsOnline;
                dbObj.LastOnlineDateTime = DTOObj.LastOnlineDateTime;
                dbObj.IsOnline = DTOObj.IsOnline;
                dbObj.RoleId = DTOObj.RoleId;
                dbObj.UpdatedBy = DTOObj.UpdatedBy;
                dbObj.CreatedBy= DTOObj.CreatedBy;
              
                dbObj.UpdatedOn = DTOObj.UpdatedOn;
                dbObj.RoleId = DTOObj.RoleId;
                dbObj.Phone = DTOObj.Phone;
                dbObj.Address = DTOObj.Address;

                dbObj.CreatedOn = DTOObj.CreatedOn;
                dbObj.CreatedBy = DTOObj.CreatedBy;
                dbObj.UpdatedOn = DateTime.Now;
                dbObj.UpdatedBy = NotificationPanel.Common.Current.CurrentUser == null ? 0 : NotificationPanel.Common.Current.CurrentUser.Id;
                dbObj.IsActive = DTOObj.IsActive;


            }
            else
            {
                dbObj = new User();
                dbObj.Id = DTOObj.Id;
                dbObj.Name = DTOObj.Name;
                dbObj.IsActive = DTOObj.IsActive;
                dbObj.CreatedBy = NotificationPanel.Common.Current.CurrentUser.Id; ;
                
                dbObj.UpdatedBy = DTOObj.UpdatedBy;
                dbObj.UpdatedOn = DTOObj.UpdatedOn;
                dbObj.RoleId = DTOObj.RoleId;
                dbObj.Password = DTOObj.Password;
                dbObj.DOB = DTOObj.DOB;
                dbObj.Gender = DTOObj.Gender;
                dbObj.Email = DTOObj.Email;
                dbObj.Image = DTOObj.Image;
                dbObj.CreatedOn = DateTime.Now;
                dbObj.Address = DTOObj.Address;

                dbObj.IsOnline = DTOObj.IsOnline;
                dbObj.Address = DTOObj.Address;
                dbObj.LastOnlineDateTime= DTOObj.LastOnlineDateTime;
                dbObj.Phone = DTOObj.Phone;
                db.Users.Add(dbObj);
            }

            db.SaveChanges();

            DTOObj.Id = dbObj.Id;

            DTOObj.Name = dbObj.Name;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.DOB = dbObj.DOB;
            DTOObj.Phone = dbObj.Phone;
            DTOObj.Password = dbObj.Password;
            DTOObj.Email = dbObj.Email;
            DTOObj.Gender = dbObj.Gender;
            DTOObj.Address = dbObj.Address;
            DTOObj.Address = dbObj.Address;
            DTOObj.IsOnline = dbObj.IsOnline;
            DTOObj.Image = dbObj.Image;
            DTOObj.LastOnlineDateTime = dbObj.LastOnlineDateTime;


            return DTOObj;
        }
        #endregion User
        #region Filter on User
        // Additional filters

    
       
      
        public DTOUser Set_IsActive(long Id, bool Value)
        {
            var dbObj = db.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (dbObj != null)
            {

                dbObj.IsActive = Value;


            }


            db.SaveChanges();

            DTOUser DTOObj = new DTOUser();
            DTOObj.Id = dbObj.Id;

            DTOObj.Name = dbObj.Name;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.DOB = dbObj.DOB.Value;
            DTOObj.RoleId = dbObj.RoleId;
            DTOObj.Password = dbObj.Password;
            DTOObj.Email = dbObj.Email;
            DTOObj.Gender = dbObj.Gender;
            DTOObj.Address = dbObj.Address;
            DTOObj.IsOnline = dbObj.IsOnline;
            DTOObj.Image = dbObj.Image;
            DTOObj.LastOnlineDateTime = dbObj.LastOnlineDateTime;
            DTOObj.Phone = dbObj.Phone;

            return DTOObj;
        }

        public DTOUser Set_LastOnlineTime(long Id,DateTime Value)
        {
            var dbObj = db.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (dbObj != null)
            {

                dbObj.LastOnlineDateTime = Value;


            }


            db.SaveChanges();

            DTOUser DTOObj = new DTOUser();
            DTOObj.Id = dbObj.Id;

            DTOObj.Name = dbObj.Name;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.DOB = dbObj.DOB;
            DTOObj.RoleId = dbObj.RoleId;
            DTOObj.Password = dbObj.Password;
            DTOObj.Email = dbObj.Email;
            DTOObj.Gender = dbObj.Gender;
            DTOObj.Address = dbObj.Address;
            DTOObj.IsOnline = dbObj.IsOnline;
            DTOObj.Image = dbObj.Image;
            DTOObj.LastOnlineDateTime = dbObj.LastOnlineDateTime;


            return DTOObj;
        }

        public DTOUser Set_IsOnline(long Id, bool Value)
        {
            var dbObj = db.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (dbObj != null)
            {

                dbObj.IsOnline = Value;


            }


            db.SaveChanges();

            DTOUser DTOObj = new DTOUser();
            DTOObj.Id = dbObj.Id;

            DTOObj.Name = dbObj.Name;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.DOB = dbObj.DOB;
            DTOObj.RoleId = dbObj.RoleId;
            DTOObj.Password = dbObj.Password;
            DTOObj.Email = dbObj.Email;
            DTOObj.Gender = dbObj.Gender;
            DTOObj.Address = dbObj.Address;
            DTOObj.IsOnline = dbObj.IsOnline;
            DTOObj.Image = dbObj.Image;
            DTOObj.LastOnlineDateTime = dbObj.LastOnlineDateTime;


            return DTOObj;
        }
    }

    #endregion Filter on User

}
