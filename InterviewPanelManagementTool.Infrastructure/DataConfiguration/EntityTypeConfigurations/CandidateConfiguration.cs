using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.EntityTypeConfigurations;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasKey(c => c.CandidateId);

        builder.Property(c => c.CreatedAt)
              .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.CandidateCode)
               .IsRequired();

        builder.Property(c => c.PracticeId).IsRequired();
        builder.Property(c => c.PositionId).IsRequired();

        builder.HasOne(c => c.Practice)
               .WithMany(p => p.Candidates)
               .HasForeignKey(c => c.PracticeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Position)
               .WithMany(p => p.Candidates)
               .HasForeignKey(c => c.PositionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.InterviewBookings)
               .WithOne(b => b.Candidate)
               .HasForeignKey(b => b.CandidateId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => c.CandidateCode)
               .IsUnique();
    }
}
