﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;

public class SubmarineConfiguration : IEntityTypeConfiguration<Submarine>
{
    public void Configure(EntityTypeBuilder<Submarine> builder)
    {
        builder.HasKey(s => s.ID);

        builder.Property(s => s.ID)
            .HasColumnName("Id");

        builder.Property(s => s.Name)
            .HasColumnName("Name")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(s => s.Model)
            .HasColumnName("Model")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.CreationDate)
            .HasColumnName("CreationDate")
            .IsRequired();

        builder.Property(s => s.SubmarineStatusId)
            .HasColumnName("SubmarineStatusId")
            .IsRequired();

        builder.HasOne(s => s.SubmarineStatus)
            .WithMany()
            .HasForeignKey(s => s.SubmarineStatusId)
            .IsRequired();

        builder.HasIndex(s => s.CreationDate);
    }
}