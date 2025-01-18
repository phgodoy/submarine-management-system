using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;
using Sms.Infra.Data.Identity;

namespace Sms.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<SubmarineSystem> SubmarineSystems { get; set; }
        public DbSet<Submarine> Submarines { get; set; }
        public DbSet<SubmarineSystemAssignment> submarineSystemAssignments { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public ICollection<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
