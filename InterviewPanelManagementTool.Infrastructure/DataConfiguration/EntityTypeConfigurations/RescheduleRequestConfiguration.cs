using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class RescheduleRequestConfiguration : IEntityTypeConfiguration<RescheduleRequest>
{
    public void Configure(EntityTypeBuilder<RescheduleRequest> builder)
    {
        builder.HasKey(r => r.RequestId);

        builder.HasOne(r => r.Member)
               .WithMany(u => u.MemberRescheduleRequests)
               .HasForeignKey(r => r.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.ProcessedByAdmin)
               .WithMany(u => u.ProcessedRescheduleRequests)
               .HasForeignKey(r => r.ProcessedByAdminId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Booking)
               .WithMany(b => b.RescheduleRequests)
               .HasForeignKey(r => r.BookingId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(r => r.Status)
               .HasConversion<int>()
               .IsRequired();

        builder.Property(r => r.ProposedDate).IsRequired();
        builder.Property(r => r.NewStartTime).IsRequired();
        builder.Property(r => r.NewEndTime).IsRequired();
    }
}
