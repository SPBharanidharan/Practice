using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewPanelManagementTool.Domain.Entities;

public class Practice
{
    public int PracticeId { get; set; }
    [Required(ErrorMessage = "Practice name is required")]
    [MaxLength(50, ErrorMessage = "Practice cannot exceeded 50 characters")]
    [MinLength(3, ErrorMessage = "Practice must be atleast 3 characters")]
    public required string PracticeName { get; set; }
    [MaxLength(250, ErrorMessage = "Description cannot exceeded 250 characters")]
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Position> Positions { get; set; } = new List<Position>();
    public ICollection<User> Members { get; set; } = new List<User>();
    public ICollection<InterviewBooking> InterviewBookings { get; set; } = new List<InterviewBooking>();
    public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}
