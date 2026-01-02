using System;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IMemberAvailabilityRepository
{
    Task<bool> HasOverlappingAvailabilityAsync(
        int MemberId,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime
    );

    Task AddMemberAsync(MemberAvailability memberAvailability);

    Task<List<MemberAvailability>> GetMemberAvailabulitiesByIdAsync(int memberId);

    Task<MemberAvailability> GetAvailabilityByIdAsync(int availabilityId);

    Task UpdateAvailabilityAsync(MemberAvailability memberAvailability);

    Task CancelAvailabilityAsync(MemberAvailability memberAvailability);

    Task<List<MemberAvailability>> GetAllAsync();


    //Just for SaveChangesAsync
    Task SaveChanges();
}
