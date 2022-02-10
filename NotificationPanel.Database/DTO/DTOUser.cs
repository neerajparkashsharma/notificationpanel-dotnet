using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Database.DTO
{
    public class DTOUser
    {

        public long Id { get; set; }
        public string Name { get; set; }
        
        public DateTime? CreatedOn { get; set; }

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

        public string Phone { get; set; }

        public long? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public string IsActiveStatus
        {
            get
            {
                return Convert.ToBoolean(IsActive) == true || !(IsActive).HasValue ? "Yes" : "No";
            }
        }

        public long? RoleId { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        
        public DateTime? DOB { get; set; }
        public string DOBString
        {
            get
            {
                return DOB != null ? DOB.Value.ToString("yyyy-MM-dd") : "Not Available";
            }
        }

        public string Gender { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public bool? IsOnline { get; set; }

        public string IsOnlineStatus { 
            get
            {
                return Convert.ToBoolean(IsOnline) == true  ? "Online" : "Not Online";
            }
        }

        public DateTime? LastOnlineDateTime{ get; set; }


        public string LastOnlineDateTimeString
        {
            get
            {
                return LastOnlineDateTime != null ? LastOnlineDateTime.Value.ToString("dd/MM/yyyy hh:mm") : "Not Available";
            }
        }

    }
}
