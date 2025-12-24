using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;

public class RescheduleRequestResponseDto
{
    public int RequestId { get; set; }
    public int BookingId { get; set; }
    public string MemberName { get; set; } = null!;
    public string CandidateName { get; set; } = null!;
    public string? Reason { get; set; }
    public RescheduleStatus Status { get; set; }
    public DateOnly ProposedDate { get; set; }
    public TimeOnly NewStartTime { get; set; }
    public TimeOnly NewEndTime { get; set; }
}
