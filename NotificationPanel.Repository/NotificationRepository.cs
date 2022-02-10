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
    public class NotificationRepository : Repository
    {

        #region Notification

        public virtual List<DTONotification> GetNotification()
        {
            var listNotification = db.Notifications

             .Include(x => x.User)
            .Where(x => x.IsActive == true || x.IsActive == null)
            .ToList()
            .Select(x => new DTONotification()
            {

                Id = x.Id,
                NotificationText = x.NotificationText,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                SenderName = x.User == null ? "" : x.User.Name,
                ReceiverName = x.User1 == null ? "" : x.User1.Name,
                SenderEmail = x.User == null ? "" : x.User.Email,
                ReceiverEmail = x.User1 == null ? "" : x.User1.Email,
                SenderImage = x.User == null ? "" : x.User.Image,
                ReceiverImage = x.User1 == null ? "" : x.User1.Image,
                Subject = x.Subject,
                Image = x.Image,
                IsRead = x.IsRead,
                ReadOn = x.ReadOn


            })
            .ToList();
            return listNotification;
        }

        public virtual DTONotification GetNotification(long Id)
        {
            var obj = db.Notifications

          .Where(x => (x.IsActive == true || x.IsActive == null))
            .Where(x => x.Id == Id).FirstOrDefault();

            if (obj != null)
            {

                DTONotification DTOObj = new DTONotification();
                DTOObj.Id = obj.Id;
                DTOObj.NotificationText = obj.NotificationText;
                DTOObj.IsActive = obj.IsActive;
                DTOObj.CreatedOn = obj.CreatedOn;
                DTOObj.CreatedBy = obj.CreatedBy;
                DTOObj.UpdatedOn = obj.UpdatedOn;
                DTOObj.UpdatedBy = obj.UpdatedBy;
                DTOObj.SenderName = obj.User == null ? "": obj.User.Name ;
                DTOObj.SenderImage = obj.User == null ? "" : obj.User.Image;
                DTOObj.ReceiverImage = obj.User1 == null ? "" : obj.User1.Image;
                DTOObj.ReceiverName = obj.User1 == null ? "" : obj.User1.Name;
                DTOObj.SenderEmail = obj.User == null ? "" :obj.User.Email;
                DTOObj.ReceiverEmail = obj.User1 == null ? "" : obj.User1.Email;
                DTOObj.Subject = obj.Subject;
                DTOObj.Image = obj.Image;
                DTOObj.IsRead = obj.IsRead;
                DTOObj.ReadOn = obj.ReadOn;
         
                return DTOObj;

            }
            return null;
        }


        public DTONotification SaveNotification(DTONotification DTOObj)
        {


      
            var dbObj = db.Notifications.Where(x => x.Id == DTOObj.Id).FirstOrDefault();
            if (dbObj != null)
            {
                dbObj.Id = DTOObj.Id;
                dbObj.NotificationText = DTOObj.NotificationText;
                dbObj.Image = DTOObj.Image;
                dbObj.Subject = DTOObj.Subject;
                dbObj.SenderId = DTOObj.SenderId;
                dbObj.ReceiverId = DTOObj.ReceiverId;
              
                dbObj.IsActive = DTOObj.IsActive;
              
                dbObj.UpdatedBy = DTOObj.UpdatedBy;
                dbObj.CreatedBy = DTOObj.CreatedBy;

                dbObj.UpdatedOn = DTOObj.UpdatedOn;
              
                dbObj.CreatedOn = DTOObj.CreatedOn;
                dbObj.CreatedBy = DTOObj.CreatedBy;
                dbObj.UpdatedOn = DateTime.Now;
                dbObj.UpdatedBy = NotificationPanel.Common.Current.CurrentUser.Id;
                dbObj.IsActive = DTOObj.IsActive;

                dbObj.IsRead = DTOObj.IsRead;
                dbObj.ReadOn = DTOObj.ReadOn;

            }
            else
            {
                dbObj = new Notification();
                dbObj.Id = DTOObj.Id;
                dbObj.NotificationText = DTOObj.NotificationText;
                dbObj.Image = DTOObj.Image;
                dbObj.Subject = DTOObj.Subject;
                dbObj.SenderId = DTOObj.SenderId;
                dbObj.ReceiverId = DTOObj.ReceiverId;
                
                dbObj.IsActive = DTOObj.IsActive;

                dbObj.UpdatedBy = DTOObj.UpdatedBy;
                dbObj.CreatedBy = DTOObj.CreatedBy;

                dbObj.UpdatedOn = DTOObj.UpdatedOn;

                dbObj.CreatedOn = DateTime.Now;
                dbObj.CreatedBy = NotificationPanel.Common.Current.CurrentUser.Id;
                dbObj.UpdatedOn = DTOObj.UpdatedOn;
                dbObj.UpdatedBy =DTOObj.UpdatedBy;

                dbObj.IsRead = DTOObj.IsRead;
                dbObj.ReadOn = DTOObj.ReadOn;


                db.Notifications.Add(dbObj);
            }

            db.SaveChanges();

            DTOObj.Id = dbObj.Id;

           

            DTOObj.NotificationText = dbObj.NotificationText;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.SenderName = dbObj.User == null ? "" : dbObj.User.Name;
            DTOObj.ReceiverName = dbObj.User1 == null ? "" : dbObj.User1.Name;
            DTOObj.SenderEmail = dbObj.User == null ? " " : dbObj.User.Email;
            DTOObj.ReceiverEmail = dbObj.User1 == null ? " " : dbObj.User1.Email;
            DTOObj.Subject = dbObj.Subject;
            DTOObj.Image = dbObj.Image;
            dbObj.IsRead = DTOObj.IsRead;
            dbObj.ReadOn = DTOObj.ReadOn;

            return DTOObj;
        }

        public DTONotification Set_IsActive(long Id, bool Value)
        {
            var dbObj = db.Notifications.Where(x => x.Id == Id).FirstOrDefault();
            if (dbObj != null)
            {

                dbObj.IsActive = Value;


            }


            db.SaveChanges();

            DTONotification DTOObj = new DTONotification();

            DTOObj.Id = dbObj.Id;
            DTOObj.NotificationText = dbObj.NotificationText;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.SenderName = dbObj.User == null ? "" : dbObj.User.Name;
            DTOObj.ReceiverName = dbObj.User1 == null ? "" : dbObj.User1.Name;
            DTOObj.SenderEmail = dbObj.User.Email;
            DTOObj.ReceiverEmail = dbObj.User1.Email;
            DTOObj.Subject = dbObj.Subject;
            DTOObj.Image = dbObj.Image;
            DTOObj.IsRead = dbObj.IsRead;
            DTOObj.ReadOn = dbObj.ReadOn;


            return DTOObj;
        }


        public DTONotification Set_IsRead(long Id)
        {
            var dbObj = db.Notifications.Where(x => x.Id == Id).FirstOrDefault();
            if (dbObj != null)
            {

                dbObj.IsRead = true;
                dbObj.ReadOn = DateTime.Now;

            }


            db.SaveChanges();

            DTONotification DTOObj = new DTONotification();

            DTOObj.Id = dbObj.Id;
            DTOObj.NotificationText = dbObj.NotificationText;
            DTOObj.IsActive = dbObj.IsActive;
            DTOObj.CreatedOn = dbObj.CreatedOn;
            DTOObj.CreatedBy = dbObj.CreatedBy;
            DTOObj.UpdatedOn = dbObj.UpdatedOn;
            DTOObj.UpdatedBy = dbObj.UpdatedBy;
            DTOObj.SenderName = dbObj.User == null ? "" : dbObj.User.Name;
            DTOObj.ReceiverName = dbObj.User1 == null ? "" : dbObj.User1.Name;
            DTOObj.SenderEmail = dbObj.User == null ? "" : dbObj.User.Email;
            DTOObj.ReceiverEmail = dbObj.User1 == null ?"" : dbObj.User1.Email;
            DTOObj.Subject = dbObj.Subject;
            DTOObj.Image = dbObj.Image;
            DTOObj.IsRead = dbObj.IsRead;
            DTOObj.ReadOn = dbObj.ReadOn;
            return DTOObj;
        }

        #endregion Notification
        #region Filter on Notification
        // Additional filters

        public virtual List<DTONotification> GetNotificationByReceiverId(long ReceiverId)
        {
            var listNotification = db.Notifications

             .Include(x => x.User)
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x=>x.ReceiverId == ReceiverId)
            .ToList()
            .Select(x => new DTONotification()
            {

                Id = x.Id,
                NotificationText = x.NotificationText,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                SenderName = x.User == null ? "" : x.User.Name,
                ReceiverId = x.ReceiverId,
                SenderId = x.SenderId,
                ReceiverName = x.User1 == null ? "" : x.User1.Name,
                SenderEmail = x.User == null ? "" : x.User.Email,
                ReceiverEmail = x.User1 == null ? "" : x.User1.Email,
                SenderImage = x.User == null ? "" : x.User.Image,
                Subject = x.Subject,
                Image = x.Image,
                IsRead =x.IsRead,
                ReadOn = x.ReadOn
               

            })
            .ToList();
            return listNotification;
        }
        public virtual DTONotification GetNotificationView(long NotificationId, long Id)
        {
            var obj = db.Notifications

          .Where(x => (x.IsActive == true || x.IsActive == null))
            .Where(x => x.Id == NotificationId &&  (x.ReceiverId == Id || x.SenderId ==Id )).FirstOrDefault();

            if (obj != null)
            {

                DTONotification DTOObj = new DTONotification();
                DTOObj.Id = obj.Id;
                DTOObj.NotificationText = obj.NotificationText;
                DTOObj.IsActive = obj.IsActive;
                DTOObj.CreatedOn = obj.CreatedOn;
                DTOObj.CreatedBy = obj.CreatedBy;
                DTOObj.UpdatedOn = obj.UpdatedOn;
                DTOObj.UpdatedBy = obj.UpdatedBy;
                
                DTOObj.SenderName = obj.User == null ? "" : obj.User.Name;
                DTOObj.SenderImage = obj.User == null ? "" : obj.User.Image;
                
                DTOObj.ReceiverImage = obj.User1 == null ? "" : obj.User1.Image;
                DTOObj.ReceiverName = obj.User1 == null ? "" : obj.User1.Name;
                DTOObj.ReceiverId = obj.ReceiverId;
                DTOObj.SenderId = obj.SenderId;
                DTOObj.SenderEmail = obj.User == null ? "" : obj.User.Email;
                DTOObj.ReceiverEmail = obj.User1 == null ? "" : obj.User1.Email;
                DTOObj.IsRead = obj.IsRead;
                DTOObj.ReadOn = obj.ReadOn;
                DTOObj.Subject = obj.Subject;
                DTOObj.Image = obj.Image;
                
                return DTOObj;

            }
            return null;
        }


        public virtual List<DTONotification> GetNotificationBySenderId(long SenderId)
        {
            var listNotification = db.Notifications

             .Include(x => x.User)
            .Where(x => x.IsActive == true || x.IsActive == null)
            .Where(x => x.SenderId == SenderId)
            .ToList()
            .Select(x => new DTONotification()
            {

                Id = x.Id,
                NotificationText = x.NotificationText,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                SenderName = x.User == null ? "" : x.User.Name,
                ReceiverName = x.User1 == null ? "" : x.User1.Name,
                SenderEmail = x.User == null ? "" : x.User.Email,
                ReceiverEmail = x.User1 == null ? "" : x.User1.Email,
                Subject = x.Subject,
                Image = x.Image,
                ReceiverImage = x.User1 == null ? "" : x.User1.Image,
                SenderImage = x.User == null ? "":x.User.Image  ,
                IsRead = x.IsRead,
                ReadOn = x.ReadOn

            })
            .ToList();
            return listNotification;
        }

        public virtual List<DTONotification> GetNotificationsByReceiverId(long ReceiverId)
        {
            var listNotification = db.Notifications

             .Include(x => x.User)
            .Where(x => x.ReceiverId == ReceiverId || x.IsActive == null)
            .ToList()
            .Select(x => new DTONotification()
            {

                Id = x.Id,
                NotificationText = x.NotificationText,
                IsActive = x.IsActive,
                CreatedOn = x.CreatedOn,
                CreatedBy = x.CreatedBy,
                UpdatedOn = x.UpdatedOn,
                UpdatedBy = x.UpdatedBy,
                SenderName = x.User == null ? "" : x.User.Name,
                ReceiverName = x.User1 == null ? "" : x.User1.Name,
                SenderEmail = x.User == null ? "" : x.User.Email,
                ReceiverEmail = x.User1 == null ? "" : x.User1.Email,
                Subject = x.Subject,
                Image = x.Image,

                IsRead = x.IsRead,
                ReadOn = x.ReadOn


            })
            .ToList();
            return listNotification;
        }



        #endregion Notification

    }
}