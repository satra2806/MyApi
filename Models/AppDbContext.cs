using Microsoft.EntityFrameworkCore;

namespace MyApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
         public DbSet<Location> locationTbl { get; set; }
         public DbSet<ProjectCordinatortbl> ProjectCordinatortbl { get; set; }
        public DbSet<projectPlanningtbl> projectPlanningtbl { get; set; }
    }
}
