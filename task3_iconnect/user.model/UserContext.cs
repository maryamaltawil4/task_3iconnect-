using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using task3_iconnect.Auth;
using task3_iconnect.user.model;

namespace task3_iconnect.Models
{
    public class UserContext : IdentityDbContext<users, UserRoles, int>
    {

        //public UserContext(DbContextOptions options) : base(options) { }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<users> Users
        {
            get;
            set;
        }
        public DbSet<Post> Posts
        {
            get;
            set;
        }
        

    }
}