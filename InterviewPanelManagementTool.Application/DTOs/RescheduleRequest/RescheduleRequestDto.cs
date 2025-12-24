using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;

public class RescheduleRequestDto
{
    public int RequestId { get; set; }
    public int BookingId { get; set; }
    public int MemberId { get; set; }
    public string? Reason { get; set; }
    public DateTime RequestedAt { get; set; }
    public RescheduleStatus Status { get; set; }
    public int? ProcessedByAdminId { get; set; }
    public DateTime? ProcessedDate { get; set; }
    public DateOnly ProposedDate { get; set; }
    public TimeOnly NewStartTime { get; set; }
    public TimeOnly NewEndTime { get; set; }
}
