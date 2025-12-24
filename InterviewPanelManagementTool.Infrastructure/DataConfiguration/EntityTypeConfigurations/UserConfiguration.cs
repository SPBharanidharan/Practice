using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);


        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Passwordhash)
               .IsRequired()
               .HasMaxLength(16);


        builder.Property(u => u.Role)
               .HasConversion<int>()
               .IsRequired();
        
        builder.Property(u => u.CreatedAt)
              .HasDefaultValueSql("GETDATE()");


        builder.HasOne(u => u.CreatedByUser)
               .WithMany(u => u.CreatedUsers)
               .HasForeignKey(u => u.CreatedByUserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.MemberAvailabilities)
               .WithOne(a => a.Member)
               .HasForeignKey(a => a.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.BookingsForMember)
               .WithOne(b => b.Member)
               .HasForeignKey(b => b.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.InterviewBookingsByAdmin)
               .WithOne(b => b.Admin)
               .HasForeignKey(b => b.AdminId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.MemberRescheduleRequests)
               .WithOne(r => r.Member)
               .HasForeignKey(r => r.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.ProcessedRescheduleRequests)
               .WithOne(r => r.ProcessedByAdmin)
               .HasForeignKey(r => r.ProcessedByAdminId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
