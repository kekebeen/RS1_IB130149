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
            modelBuilder.Entity<ServiceTicket>()
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceTicket>()
                .HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(f => f.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceTicket>()
                .HasOne(x => x.ServiceRequest)
                .WithMany()
                .HasForeignKey(f => f.ServiceRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Odjeljenje>()
            //    .HasOne(x => x.Razrednik)
            //    .WithMany()
            //    .HasForeignKey(x => x.RazrednikID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AuthorizationToken> AuthorizationToken { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<ServiceTicket> ServiceTicket { get; set; }
        public DbSet<ServiceStatus> ServiceStatus { get; set; }
    }
}