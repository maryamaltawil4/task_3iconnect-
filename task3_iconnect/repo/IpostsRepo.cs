using task3_iconnect.user.model;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.Models;
using Microsoft.EntityFrameworkCore;

namespace task3_iconnect.repo
{
    public interface IpostsRepo : IGenRepo<Post>
    {
     

    }
    public class PostRepo : GenRepo<Post> , IpostsRepo

    {
        public PostRepo(UserContext context) : base(context)
        {
           

        }
        public new List<Post>? getAll()
        {
            return _context.Posts.Include(c => c.user).ToList();
        }

    }
}