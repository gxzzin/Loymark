using Microsoft.EntityFrameworkCore;
using UsersControl.Models;

namespace UsersControl.Context
{
    public class UsersControlDbContext : DbContext
    {
        public UsersControlDbContext(DbContextOptions<UsersControlDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}