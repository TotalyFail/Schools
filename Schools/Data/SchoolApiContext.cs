using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Data
{
    public class SchoolApiContext : DbContext
    {
        public SchoolApiContext(DbContextOptions<SchoolApiContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolApi.Models.Child> Child { get; set; }

        public DbSet<SchoolApi.Models.School> School { get; set; }

        public DbSet<SchoolApi.Models.Parent> Parent { get; set; }
    }
}
