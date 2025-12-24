using System;
using System.ComponentModel.DataAnnotations;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Domain.Entities;

public class InterviewBooking
{
    public int BookingId { get; set; }
    [Required(ErrorMessage = "Member ID is required")]
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Availability ID is required")]
    public int AvailabilityId { get; set; }
    [Required(ErrorMessage = "Candidate ID is required")]
    public int CandidateId { get; set; }
    [Required(ErrorMessage = "Admin ID is required")]
    public int AdminId { get; set; }
    [Required(ErrorMessage = "Practice ID is required")]
    public int PracticeId { get; set; }

    [Required(ErrorMessage = "Position ID is required")]
    public int PositionId { get; set; }
    public InterviewBookingStatus Status { get; set; } = InterviewBookingStatus.Scheduled;      // Default status
    public DateTime CreatedDate { get; set; }

    public User Member { get; set; } = null!;
    public User Admin { get; set; } = null!;
    public MemberAvailability Availability { get; set; } = null!;
    public Candidate Candidate { get; set; } = null!;
    public Practice Practice { get; set; } = null!;
    public Position Position { get; set; } = null!;
    public ICollection<RescheduleRequest> RescheduleRequests { get; set; } = new List<RescheduleRequest>();
}
