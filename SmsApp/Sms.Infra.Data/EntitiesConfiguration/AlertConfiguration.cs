using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class AlertConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.ToTable("Alerts");

            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(a => a.AlertType)
                .HasColumnName("AlertType")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Message)
                .HasColumnName("Message")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(a => a.ResolvedAt)
                .HasColumnName("ResolvedAt")
                .IsRequired(false);

            
            builder.HasOne(a => a.SubmarineSystem)
                .WithMany(s => s.Alerts)
                .HasForeignKey(a => a.SubmarineSystemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
