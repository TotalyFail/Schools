using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class SchoolApiContext : DbContext
    {
        public SchoolApiContext(DbContextOptions<SchoolApiContext> options)
            : base(options)
        {
        }

        public DbSet<Child> Child { get; set; }

        public DbSet<School> School { get; set; }

        public DbSet<Parent> Parent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<School>().HasKey(x => x.Id);

            modelBuilder.Entity<Parent>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Parent>().HasKey(x => x.Id);

            modelBuilder.Entity<Child>().Property(x => x.Parent_Id).IsRequired();
            modelBuilder.Entity<Child>().Property(x => x.School_Id).IsRequired();
            modelBuilder.Entity<Child>().HasKey(x => x.Id);
        }
    }
}
