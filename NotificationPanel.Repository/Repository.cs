using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationPanel.Database.Model;


namespace NotificationPanel.Repository
{
    //Singleton
    public class Repository
    {
        NotificationPanelEntities2 _db = new NotificationPanelEntities2();


        protected NotificationPanelEntities2 db
        {
            get
            { 
                return _db;
            }
        }
    }
}
