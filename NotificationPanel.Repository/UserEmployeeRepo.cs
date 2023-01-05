using NotificationPanel.Database.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Repository
{
    public class UserEmployeeRepo : IUserRepo
    {
        UserRepository userRepo = new UserRepository();
        public override void create(DTOUser u)
        {
            u.RoleId = 2;
            userRepo.SaveUser(u);

        }

        public override List<DTOUser> findAll()
        {
           return userRepo.GetUser().Where(x=>x.RoleId == 2).ToList();
        }

        public override List<DTOUser> findByEmail(string email)
        {
            return userRepo.GetUserByEmail(email).Where(x => x.RoleId == 2).ToList();
        }

        public override DTOUser findById(int id)
        {
            return userRepo.GetUser(id);
        }

        public override List<DTOUser> findByName(string name)
        {
            return userRepo.GetUserByName(name).Where(x => x.RoleId == 2).ToList();
        }
    }
}
