using NotificationPanel.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Repository
{
    public class UserFactory
    {

        public IUserRepo GetUser(string userType)
        {

            if (userType == "ADMIN")
            {
                return new UserAdminRepo();
            }
            else if(userType == "EMPLOYEE")
            {
                return new UserEmployeeRepo();
            }
            return null;

        }
    }
}
