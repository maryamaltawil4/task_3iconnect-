using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace task3_iconnect.user.model
{
    public class users: IdentityUser<int>, IBaseModel
    {
   
        public string? first_name { get; set; }

        public string? last_name { get; set; }

      //  public string? email { get; set; }
        public ICollection<Post> ? Posts { get; set; }



    }
}
