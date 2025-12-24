using InterviewPanelManagementTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewPanelManagementTool.Infrastructure.DataConfiguration.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Practice> Practices { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<MemberPosition> MemberPositions { get; set; }
    public DbSet<MemberAvailability> MemberAvailabilities { get; set; }
    public DbSet<InterviewBooking> InterviewBookings { get; set; }
    public DbSet<RescheduleRequest> RescheduleRequests { get; set; }
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
