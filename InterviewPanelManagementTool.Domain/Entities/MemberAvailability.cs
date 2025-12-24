using System;
using System.ComponentModel.DataAnnotations;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Domain.Entities;

public class MemberAvailability
{
    public int AvailabilityId { get; set; }
    [Required(ErrorMessage = "Member ID is required")]
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Please enter a availability date")]
    public DateOnly Date { get; set; }
    [Required(ErrorMessage = "Please enter a start time")]
    public TimeOnly StartTime { get; set; }
    [Required(ErrorMessage = "Please enter a end time")]
    public TimeOnly EndTime { get; set; }
    public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.Available;      // Default status
    public DateTime CreatedDate { get; set; }

    public User Member { get; set; } = null!;
    public InterviewBooking? Booking { get; set; }

}
