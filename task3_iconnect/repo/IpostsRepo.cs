using task3_iconnect.user.model;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.Models;

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
    }
}