using System;
using System.ComponentModel.DataAnnotations;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public required string UserName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Please enter valid email address")]
    public required string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
    public required string Passwordhash { get; set; }
    [Required(ErrorMessage = "Role is required")]
    public UserRole Role { get; set; }
    public int? PracticeId { get; set; }
    public Practice? Practice { get; set; }
    public int? DesignationPositionId { get; set; }
    public Position? DesignationPosition { get; set; }
    public bool IsFirstLogin { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive{get;set;}

    public User? CreatedByUser { get; set; }        // Particular member is created by which admin
    public ICollection<User> CreatedUsers { get; set; } = new List<User>();     // Collection of users created by particular Admin
    public ICollection<MemberPosition> MemberPositions { get; set; } = new List<MemberPosition>();
    public ICollection<MemberAvailability> MemberAvailabilities { get; set; } = new List<MemberAvailability>();
    public ICollection<InterviewBooking> InterviewBookingsByAdmin { get; set; } = new List<InterviewBooking>();
    public ICollection<InterviewBooking> BookingsForMember { get; set; } = new List<InterviewBooking>();
    public ICollection<RescheduleRequest> MemberRescheduleRequests { get; set; } = new List<RescheduleRequest>();
    public ICollection<RescheduleRequest> ProcessedRescheduleRequests { get; set; } = new List<RescheduleRequest>();      // Member can have collection of reschedule request
}
