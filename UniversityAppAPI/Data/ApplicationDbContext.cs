using Microsoft.EntityFrameworkCore;
using UniversityAppAPI.Models;

namespace UniversityAppAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<University> Universities { get; set; }
    }
}
