using Microsoft.AspNetCore.Mvc;
using task3_iconnect.Models;
using task3_iconnect.user.model;
namespace task3_iconnect.repo

{
    public interface IUserInterface  : IGenRepo<users>
    {




    }
    public class UserRepo :  GenRepo<users> ,IUserInterface
    {
        public UserRepo(UserContext context): base(context)
        {

        }

      
   }
}


   
   