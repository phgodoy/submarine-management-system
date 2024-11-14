using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class SubmarineSystemConfiguration : IEntityTypeConfiguration<SubmarineSystem>
    {
        public void Configure(EntityTypeBuilder<SubmarineSystem> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.ID).HasColumnName("ID");
            builder.Property(s => s.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(s => s.Type).HasColumnName("Type").HasMaxLength(100).IsRequired();
            builder.Property(s => s.OperationalStatus).HasColumnName("OperationalStatus").HasMaxLength(50).IsRequired();
            builder.Property(s => s.LastMaintenanceDate).HasColumnName("LastMaintenanceDate").IsRequired();

            
        }
    }
}
