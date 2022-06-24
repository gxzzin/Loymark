using Microsoft.EntityFrameworkCore;
using UsersControl.Models;
using Microsoft.Extensions.Configuration;

namespace UsersControl.Data
{
    public class UsersControlDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public UsersControlDbContext(DbContextOptions<UsersControlDbContext> opt, IConfiguration configuration) : base(opt)
        {
             _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_configuration.GetConnectionString("LoymarkDbContext"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}