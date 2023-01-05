using NotificationPanel.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Repository
{
    public  class PostImpl : Repository,IPostRepo
    {

        public void Create(Post p)
        {
            db.Posts.Add(p);
            db.SaveChanges();

        }

        public List<Post> FindAll()
        {
            return db.Posts.ToList();
        }

        public Post FindById(int id)
        {
         return   db.Posts.ToList().Where(x => x.Id == id).FirstOrDefault();
           
        }
    }
}
