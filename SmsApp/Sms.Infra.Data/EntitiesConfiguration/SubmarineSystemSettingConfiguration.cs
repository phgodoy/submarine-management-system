using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class SubmarineSystemSettingConfiguration : IEntityTypeConfiguration<SubmarineSystemSetting>
    {
        public void Configure(EntityTypeBuilder<SubmarineSystemSetting> builder)
        {
            builder.ToTable("SubmarineSystemSettings");

            builder.HasKey(s => s.ID);

            builder.Property(s => s.ID)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(s => s.SubmarineSystemId)
                .HasColumnName("SubmarineSystemId")
                .IsRequired();

            builder.Property(s => s.SettingKey)
                .HasColumnName("SettingKey")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.SettingValue)
                .HasColumnName("SettingValue")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.HasOne(s => s.SubmarineSystem)
                .WithMany(s => s.SubmarineSystemSettings)
                .HasForeignKey(s => s.SubmarineSystemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
