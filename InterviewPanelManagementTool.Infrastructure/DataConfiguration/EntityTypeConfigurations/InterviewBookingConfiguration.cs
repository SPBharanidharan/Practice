using System;
using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EnitityTypeConfigurations;

public class InterviewBookingConfiguration : IEntityTypeConfiguration<InterviewBooking>
{
       public void Configure(EntityTypeBuilder<InterviewBooking> builder)
       {
              builder.HasKey(b => b.BookingId);

              builder.Property(b => b.CreatedDate)
                     .HasDefaultValueSql("GETDATE()");


              builder.HasOne(b => b.Member)
                     .WithMany(u => u.BookingsForMember)
                     .HasForeignKey(b => b.MemberId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(b => b.Admin)
                     .WithMany(u => u.InterviewBookingsByAdmin)
                     .HasForeignKey(b => b.AdminId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(b => b.Availability)
                     .WithOne(a => a.Booking)
                     .HasForeignKey<InterviewBooking>(b => b.AvailabilityId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(b => b.Candidate)
                     .WithMany(c => c.InterviewBookings)
                     .HasForeignKey(b => b.CandidateId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(b => b.Practice)
                     .WithMany(p => p.InterviewBookings)
                     .HasForeignKey(b => b.PracticeId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(b => b.Position)
                     .WithMany(p => p.InterviewBookings)
                     .HasForeignKey(b => b.PositionId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasMany(b => b.RescheduleRequests)
                     .WithOne(r => r.Booking)
                     .HasForeignKey(r => r.BookingId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.Property(b => b.Status)
                     .HasConversion<int>()
                     .IsRequired();

              builder.HasIndex(b => b.AvailabilityId)
                     .IsUnique();

       }

}
