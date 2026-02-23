using DemoASP.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoASP.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) { 

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
