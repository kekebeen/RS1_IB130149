using IB130149.Models;
using Microsoft.EntityFrameworkCore;

namespace IB130149.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Odjeljenje>()
            //    .HasOne(x => x.Razrednik)
            //    .WithMany()
            //    .HasForeignKey(x => x.RazrednikID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}