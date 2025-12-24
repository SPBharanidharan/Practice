using System;

namespace InterviewPanelManagementTool.Application.DTOs.InterviewBoooking;

public class InterviewBookingCreateDto
{

    public int MemberId { get; set; }
    public int AdminId { get; set; }
    public int AvailabilityId { get; set; }
    public int CandidateId { get; set; }
    public int PracticeId { get; set; }
    public int PositionId { get; set; }

}
