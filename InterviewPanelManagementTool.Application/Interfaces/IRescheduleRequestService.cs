using InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;

namespace InterviewPanelManagementTool.Application.Interfaces
{
    public interface IRescheduleRequestService
    {
        Task<RescheduleRequestResponseDto> CreateRequestAsync(RescheduleRequestCreateDto dto, int memberId);
        Task<List<RescheduleRequestResponseDto>> GetRequestsByMemberAsync(int userId);
        Task<IEnumerable<RescheduleRequestResponseDto>> GetAllRequestAsync();
    }
}
