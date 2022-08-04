using Microsoft.AspNetCore.Identity;

namespace task3_iconnect.Auth
{

    public class UserRoles : IdentityRole<int>

        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
    
}
