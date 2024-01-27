using Lumina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumina.Data.Configurations;

public class StudyCenterConfiguration : IEntityTypeConfiguration<StudyCenter>
{
    public void Configure(EntityTypeBuilder<StudyCenter> builder)
    {
        // Primary Key
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.Name).IsRequired().HasMaxLength(25);
        builder.Property(s => s.Logo).HasMaxLength(150);
        builder.Property(s => s.Region).HasMaxLength(25);
        builder.Property(s => s.ReceptionNumber).HasMaxLength(20);
        builder.Property(s => s.TelegramLink).HasMaxLength(100);
        builder.Property(s => s.StartedDate).IsRequired();

        // Relationships
        builder.HasMany(sc => sc.Cources)
               .WithOne(c => c.StudyCenter)
               .HasForeignKey(c => c.StudyCenterId)
               .OnDelete(DeleteBehavior.Restrict);  

        builder.HasMany(sc => sc.Teachers)
               .WithMany(t => t.StudyCenters);

        builder.HasOne(sc => sc.ParentStudyCenter)
               .WithMany()
               .HasForeignKey(sc => sc.ParentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
