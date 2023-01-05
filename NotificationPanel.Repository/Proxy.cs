using NotificationPanel.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Repository
{
    public class Proxy : IPostRepo
    {

        private PostImpl pi = new PostImpl();
        public void Create(Post p)
        {
             pi.Create(p);
        }

        public List<Post> FindAll()
        {
             return pi.FindAll();
        }

        public Post FindById(int id)
        {
            return pi.FindById(id);
        }
    }
}
