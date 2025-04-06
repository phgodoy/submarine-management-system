using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class SubmarineStatusConfiguration : IEntityTypeConfiguration<SubmarineStatus>
    {
        public void Configure(EntityTypeBuilder<SubmarineStatus> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(s => s.Name)
                .IsUnique();

            builder.ToTable("SubmarineStatus");
        }
    }
}