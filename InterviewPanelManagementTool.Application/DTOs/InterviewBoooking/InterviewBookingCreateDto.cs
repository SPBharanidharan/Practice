using System;

namespace InterviewPanelManagementTool.Application.DTOs.InterviewBoooking;

public class InterviewBookingCreateDto
{
    public int CandidateId { get; set; }
    public int MemberId { get; set; }
    public int AvailabilityId { get; set; }
}
