using InterviewPanelManagementTool.Domain.Entities;
using InterviewPanelManagementTool.Infrastructure.DataConfiguration.DataContext;
using InterviewPanelManagementTool.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InterviewPanelManagementTool.Infrastructure.Repositories;

public class RescheduleRequestRepository:IRescheduleRequestRepository
{
    private readonly ApplicationDbContext _context;

    public RescheduleRequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RescheduleRequest> AddAsync(RescheduleRequest request)
    {
        _context.RescheduleRequests.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task<InterviewBooking?> GetBookingbyMemberIdAsync(int bookingId, int memberId)
    {
        return await _context.InterviewBookings
                .Include(b => b.Member)
                .Include(b => b.Candidate)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId && b.MemberId == memberId);
    }
    public async Task<RescheduleRequest?> GetByBookingIdAsync(int bookingId)
    {
        return await _context.RescheduleRequests.Include(r => r.Member)
                .Include(r => r.Booking)
                    .ThenInclude(b => b.Candidate)
                .FirstOrDefaultAsync(r => r.BookingId == bookingId);
    }

    public async Task<List<RescheduleRequest>> GetRequestsByMemberAsync(int memberId)
    {
       

        return await _context.RescheduleRequests
            .Include(r => r.Member)
            .Include(r => r.Booking)
                .ThenInclude(b => b.Candidate)
            .Where(r => r.MemberId == memberId) 
            .ToListAsync();
    }


    public async Task<IEnumerable<RescheduleRequest>> GetAllRequestAsync()
    {
        return await _context.RescheduleRequests.Include(r => r.Member)
                .Include(r => r.Booking)
                    .ThenInclude(b => b.Candidate)
                .ToListAsync();
    }
}


