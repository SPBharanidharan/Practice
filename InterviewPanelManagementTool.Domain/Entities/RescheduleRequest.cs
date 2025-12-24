using System;
using System.ComponentModel.DataAnnotations;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Domain.Entities;

public class RescheduleRequest
{
    public int RequestId { get; set; }
    [Required(ErrorMessage = "Booking ID is required")]
    public int BookingId { get; set; }
    [Required(ErrorMessage = "Member ID is required")]
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Please enter a reason")]
    [StringLength(250, ErrorMessage = "Reason cannot exceed 250 characters.")]
    public string? Reason { get; set; }
    [Required(ErrorMessage = "Requested date is required.")]
    public DateTime RequestedAt { get; set; }
    public RescheduleStatus Status { get; set; } = RescheduleStatus.InProgress;     // Default status
    public int? ProcessedByAdminId { get; set; }
    public DateTime? ProcessedDate { get; set; }
    [Required(ErrorMessage = "New date is required.")]
    public DateOnly ProposedDate { get; set; }
    [Required(ErrorMessage = "New start time is required.")]
    public TimeOnly NewStartTime { get; set; }
    [Required(ErrorMessage = "New end time is required.")]
    public TimeOnly NewEndTime { get; set; }

    public User Member { get; set; } = null!;
    public User? ProcessedByAdmin { get; set; }
    public InterviewBooking Booking { get; set; } = null!;
}
