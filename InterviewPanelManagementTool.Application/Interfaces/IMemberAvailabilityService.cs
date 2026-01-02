using System;
using InterviewPanelManagementTool.Application.DTOs.MemberAvailability;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IMemberAvailabilityService
{
    Task<MemberAvailabilityDto> AddAvailabilityAsync(int memberId,MemberAvailabilityCreateDto memberAvailabilityCreateDto);

    Task<List<MemberAvailabilityDto>> GetAvailabilityByMemberIdAsync(int memberId);


    Task UpdateAvailabilityAsyncBeforeBook(int availabilityId,MemberAvailabilityUpdateDto memberAvailabilityUpdateDto);

    Task<MemberAvailabilityDto> GetAvailabilityByIdAsync(int availabilityId);
    
    Task CancelAvailabilityAsync(int availabilityId);
    Task<List<MemberAvailabilityDto>> GetAllMemberAvailabilitiesAsync();
}
