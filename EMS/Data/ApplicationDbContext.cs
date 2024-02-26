using Microsoft.EntityFrameworkCore;
using EMS.Models.Entities;

namespace EMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
