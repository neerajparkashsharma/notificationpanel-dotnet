using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NotificationPanel.Database.DTO
{
    public class DTONotification
    {
        public long Id { get; set; }
        public string NotificationText { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ReadOn { get; set; }

        public string ReadOnString
        {
            get
            {
                return ReadOn != null ? ReadOn.Value.ToString("dd/MM/yyyy") : "Not Available";
            }

        }
        public string CreatedOnString
        {
            get
            {
                return CreatedOn != null ? CreatedOn.Value.ToString("dd/MM/yyyy") : "Not Available";
            }
        }

        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string UpdatedOnString
        {
            get
            {
                return UpdatedOn != null ? UpdatedOn.Value.ToString("dd/MM/yyyy") : "Not Available";
            }
        }

        public long? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public string IsActiveStatus
        {
            get
            {
                return Convert.ToBoolean(IsActive) == true || !(IsActive).HasValue ? "Yes" : "No";
            }
        }
        public bool? IsRead { get; set; }

        public string IsReadStatus
        {
            get
            {
                return Convert.ToBoolean(IsRead) == true ? "Yes" : "No";
            }
        }

        public long? SenderId { get; set; }

        public string SenderName { get; set; }
        public long? ReceiverId { get; set; }

        public string ReceiverName { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
       
        public string SenderImage { get; set; }
        public string ReceiverImage { get; set; }
        public string Image { get; set; }

        public string Subject { get; set; }

        public HttpPostedFileBase file { get; set; }


        public bool? IsAccepted { get; set; }


        public string IsAcceptedStatus
        {
            get
            {
                return Convert.ToBoolean(IsAccepted) == true ? "Yes" : "No";
            }

        }


        public bool? IsRejected { get; set; }


        public string IsRejectedStatus
        {
            get
            {
                return Convert.ToBoolean(IsRejected) == true ? "Yes" : "No";
            }

        }
        public long?GroupId { get; set; }


    }

}