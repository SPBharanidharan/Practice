using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class MemberPositionConfiguration : IEntityTypeConfiguration<MemberPosition>
{
    public void Configure(EntityTypeBuilder<MemberPosition> builder)
    {
        builder.HasKey(mp => new { mp.MemberId, mp.PositionId });

        builder.HasOne(mp => mp.Member)
               .WithMany(u => u.MemberPositions)
               .HasForeignKey(mp => mp.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(mp => mp.Position)
               .WithMany(p => p.MemberPositions)
               .HasForeignKey(mp => mp.PositionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}