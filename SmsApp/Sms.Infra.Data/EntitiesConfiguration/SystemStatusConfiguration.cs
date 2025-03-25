using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.Configurations
{
    public class SystemStatusConfiguration : IEntityTypeConfiguration<SystemStatus>
    {
        public void Configure(EntityTypeBuilder<SystemStatus> builder)
        {
            builder.ToTable("SystemStatus");

            builder.HasKey(s => s.ID);

            builder.Property(s => s.ID)
                .HasConversion<int>()
                .ValueGeneratedNever();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(s => s.Name).HasDatabaseName("IX_SystemStatus_Name");
        }
    }
}
