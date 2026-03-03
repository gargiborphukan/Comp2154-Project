using Microsoft.EntityFrameworkCore;
using Comp2154_System_Development_Project.Models;

namespace Comp2154_System_Development_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } //Maps the user model to a database table
    }
}