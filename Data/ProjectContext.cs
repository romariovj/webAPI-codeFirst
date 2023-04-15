using Microsoft.EntityFrameworkCore;
using WebAPI_CodeFirst.Data.Models;

namespace WebAPI_CodeFirst.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            
        }

        public ProjectContext(DbContextOptions option): base(option)
        {
        }
        public DbSet<Project> Projects { get; set; }
    }
}
