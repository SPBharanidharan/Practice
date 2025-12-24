using System;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;
using InterviewPanelManagementTool.Infrastructure.DataConfiguration.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InterviewPanelManagementTool.Infrastructure.Repositories;

public class MemberAvailabilityRepository : IMemberAvailabilityRepository
{
    private readonly ApplicationDbContext _context;
    public MemberAvailabilityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HasOverlappingAvailabilityAsync(int MemberId, DateOnly date, TimeOnly startTime, TimeOnly endTime)
    {
        return await _context.MemberAvailabilities.AnyAsync(a =>
                a.MemberId == MemberId &&
                 a.Date == date &&
                 startTime < a.EndTime &&
                 endTime > a.StartTime);
    }
    public async Task AddMemberAsync(MemberAvailability memberAvailability)
    {
        await _context.MemberAvailabilities.AddAsync(memberAvailability);
        await _context.SaveChangesAsync();
    }



    public async Task<List<MemberAvailability>> GetMemberAvailabulitiesByIdAsync(int memberId)
    {
        return await _context.MemberAvailabilities.Where(a => a.MemberId == memberId).ToListAsync();
    }

    public async Task<MemberAvailability> GetAvailabilityByIdAsync(int availabilityId)
    {
        return await _context.MemberAvailabilities.FirstOrDefaultAsync(a=>a.AvailabilityId==availabilityId);
    }

    public async Task UpdateAvailabilityAsync(MemberAvailability memberAvailability)
    {
        _context.MemberAvailabilities.Update(memberAvailability);
        await _context.SaveChangesAsync();
    }
}
