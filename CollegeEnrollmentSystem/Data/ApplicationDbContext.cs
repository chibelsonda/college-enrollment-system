using CollegeEnrollmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeEnrollmentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
    
}
