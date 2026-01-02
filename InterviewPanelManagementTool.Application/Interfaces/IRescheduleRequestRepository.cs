
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;
public interface IRescheduleRequestRepository
{
    Task<RescheduleRequest> AddAsync(RescheduleRequest request);
    Task<InterviewBooking?> GetBookingbyMemberIdAsync(int bookingId, int memberId);
    Task<RescheduleRequest?> GetByBookingIdAsync(int bookingId);
    Task<List<RescheduleRequest>> GetRequestsByMemberAsync(int userId);

    Task<IEnumerable<RescheduleRequest>> GetAllRequestAsync();
}