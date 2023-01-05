using NotificationPanel.Database.DTO;
using System.Collections.Generic;

namespace NotificationPanel.Repository
{
    public abstract class IUserRepo
    {
      public abstract void create(DTOUser u);
        
        public abstract  List<DTOUser> findAll();

        public abstract DTOUser findById(int id);

        public abstract List<DTOUser> findByEmail(string email);
        
        public abstract   List<DTOUser> findByName(string name);

    }
}
