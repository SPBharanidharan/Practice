using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class MemberAvailabilityConfiguration : IEntityTypeConfiguration<MemberAvailability>
{
    public void Configure(EntityTypeBuilder<MemberAvailability> builder)
    {
        builder.HasKey(a => a.AvailabilityId);



        builder.Property(a => a.CreatedDate)
       .HasDefaultValueSql("GETDATE()");


        builder.Property(a => a.Date).IsRequired();
        builder.Property(a => a.StartTime).IsRequired();
        builder.Property(a => a.EndTime).IsRequired();



        builder.HasIndex(a => new 
              { a.MemberId, a.Date, a.StartTime, a.EndTime })
              .IsUnique();
        builder.ToTable(t =>
        {
              t.HasCheckConstraint(
              "CK_MemberAvailability_Time",
              "[EndTime] > [StartTime]");
        });


        builder.HasOne(a => a.Member)
               .WithMany(u => u.MemberAvailabilities)
               .HasForeignKey(a => a.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Booking)
               .WithOne(b => b.Availability)
               .HasForeignKey<InterviewBooking>(b => b.AvailabilityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.AvailabilityStatus)
               .HasConversion<int>()
               .IsRequired();
    }
}
