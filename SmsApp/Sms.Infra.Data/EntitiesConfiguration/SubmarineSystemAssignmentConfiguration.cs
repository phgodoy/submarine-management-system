using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;

namespace Sms.Infra.Data.EntitiesConfiguration
{
    public class SubmarineSystemAssignmentConfiguration : IEntityTypeConfiguration<SubmarineSystemAssignment>
    {
        public void Configure(EntityTypeBuilder<SubmarineSystemAssignment> builder)
        {
            builder.HasKey(assignment => assignment.ID);

            builder.Property(assignment => assignment.ID)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(assignment => assignment.SubmarineId)
                .HasColumnName("SubmarineId")
                .IsRequired();

            builder.Property(assignment => assignment.SubmarineSystemId)
                .HasColumnName("SubmarineSystemId")
                .IsRequired();

            builder.Property(assignment => assignment.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.HasOne(assignment => assignment.Submarine)
                .WithMany(submarine => submarine.SubmarineSystemAssignments)
                .HasForeignKey(assignment => assignment.SubmarineId);

            builder.HasOne(assignment => assignment.SubmarineSystem)
                .WithMany(system => system.SubmarineSystemAssignments)
                .HasForeignKey(assignment => assignment.SubmarineSystemId);

            builder.ToTable("SubmarineSystemAssignment");
        }
    }
}
