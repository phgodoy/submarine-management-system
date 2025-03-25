using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sms.Domain.Entities;
using Sms.Domain.Enums;

namespace Sms.Infra.Data.Configurations
{
    public class SubmarineSystemConfiguration : IEntityTypeConfiguration<SubmarineSystem>
    {
        public void Configure(EntityTypeBuilder<SubmarineSystem> builder)
        {
            builder.ToTable("SubmarineSystems");

            builder.HasKey(s => s.ID);

            builder.HasOne(s => s.Submarine)
                .WithMany(sub => sub.SubmarineSystems)
                .HasForeignKey(s => s.SubmarineId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(s => s.SystemStatus)
                .WithMany()
                .HasForeignKey(s => s.SystemStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.SubmarineId)
                .IsRequired();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.SystemStatusId)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(s => s.LastMaintenanceDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasIndex(s => s.Name).HasDatabaseName("IX_SubmarineSystem_Name");
        }
    }
}
