using System;

namespace InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;

public class RescheduleRequestCreateDto
{
    public int BookingId { get; set; }
    public int MemberId { get; set; }
    public string? Reason { get; set; }
    public DateOnly ProposedDate { get; set; }
    public TimeOnly NewStartTime { get; set; }
    public TimeOnly NewEndTime { get; set; }
}
