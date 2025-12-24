using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewPanelManagementTool.Application.DTOs.MemberAvailability;

public class MemberAvailabilityCreateDto
{
    [Required]
    public int MemberId { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }
}
