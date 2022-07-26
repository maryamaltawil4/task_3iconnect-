using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using task3_iconnect.user.model;

namespace task3_iconnect.Models
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions options) : base(options) { }
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