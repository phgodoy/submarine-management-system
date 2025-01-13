using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class SubmarineConfiguration : IEntityTypeConfiguration<Submarine>
    {
        public void Configure(EntityTypeBuilder<Submarine> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.ID)
                .HasColumnName("ID");

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.Model)
                .HasColumnName("Model")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.CommissionedDate)
                .HasColumnName("CommissionedDate")
                .IsRequired();

            builder.Property(s => s.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
