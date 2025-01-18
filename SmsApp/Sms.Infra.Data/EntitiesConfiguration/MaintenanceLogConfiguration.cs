using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class MaintenanceLogConfiguration : IEntityTypeConfiguration<MaintenanceLog>
    {
        public void Configure(EntityTypeBuilder<MaintenanceLog> builder)
        {
            builder.ToTable("MaintenanceLogs");

            builder.HasKey(m => m.ID);

            builder.Property(m => m.ID)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(m => m.SubmarineSystemId)
                .HasColumnName("SubmarineSystemId")
                .IsRequired();

            builder.Property(m => m.MaintenanceDate)
                .HasColumnName("MaintenanceDate")
                .IsRequired();

            builder.Property(m => m.TechnicianName)
                .HasColumnName("TechnicianName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Notes)
                .HasColumnName("Notes")
                .HasMaxLength(1000)
                .IsRequired();

            builder.HasOne(m => m.SubmarineSystem)
                 .WithMany()
                 .HasForeignKey(m => m.SubmarineSystemId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.SubmarineSystemId)
                .IsRequired();
        }
    }
}
