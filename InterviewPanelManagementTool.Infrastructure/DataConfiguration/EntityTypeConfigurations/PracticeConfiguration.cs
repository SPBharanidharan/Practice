using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class PracticeConfiguration : IEntityTypeConfiguration<Practice>
{
    public void Configure(EntityTypeBuilder<Practice> builder)
    {
        builder.HasKey(p => p.PracticeId);

        builder.Property(p => p.IsActive).HasDefaultValue(true);
        builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

        builder.HasMany(p => p.Positions)
               .WithOne(pos => pos.Practice)
               .HasForeignKey(pos => pos.PracticeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Members)
               .WithOne(u => u.Practice)
               .HasForeignKey(u => u.PracticeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InterviewBookings)
               .WithOne(b => b.Practice)
               .HasForeignKey(b => b.PracticeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}