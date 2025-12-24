using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
       public void Configure(EntityTypeBuilder<Position> builder)
       {
              builder.HasKey(p => p.PositionId);

              builder.Property(p => p.IsActive)
                     .HasDefaultValue(true);

              builder.Property(p => p.CreatedAt)
                     .HasDefaultValueSql("GETDATE()");

              builder.HasIndex(p => new { p.PracticeId, p.PositionName })
                    .IsUnique();


              builder.HasOne(p => p.Practice)
                     .WithMany(pr => pr.Positions)
                     .HasForeignKey(p => p.PracticeId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasMany(p => p.InterviewBookings)
                     .WithOne(b => b.Position)
                     .HasForeignKey(b => b.PositionId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasMany(p => p.MemberPositions)
                     .WithOne(mp => mp.Position)
                     .HasForeignKey(mp => mp.PositionId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasMany(p => p.Candidates)
                     .WithOne(c => c.Position)
                     .HasForeignKey(c => c.PositionId)
                     .OnDelete(DeleteBehavior.Restrict);

       }
}