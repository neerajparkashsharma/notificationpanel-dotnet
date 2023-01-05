using NotificationPanel.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Repository
{
    public interface IPostRepo
    {

        void Create(Post p);

        List<Post> FindAll();

        Post FindById(int id);



    }
}
