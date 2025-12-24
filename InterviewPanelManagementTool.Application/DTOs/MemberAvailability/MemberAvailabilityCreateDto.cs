using System;


namespace InterviewPanelManagementTool.Application.DTOs.MemberAvailability;

public class MemberAvailabilityCreateDto
{

    public int MemberId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
