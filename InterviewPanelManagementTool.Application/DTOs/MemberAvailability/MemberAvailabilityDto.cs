using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.MemberAvailability;

public class MemberAvailabilityDto
{
    public int AvailabilityId { get; set; }
    public int MemberId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public AvailabilityStatus AvailabilityStatus { get; set; }
}
