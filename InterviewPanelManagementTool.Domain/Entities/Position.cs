using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewPanelManagementTool.Domain.Entities;

public class Position
{
    public int PositionId { get; set; }
    [Required(ErrorMessage = "Position name is required")]
    [MaxLength(50, ErrorMessage = "Position cannot exceeded 50 characters")]
    [MinLength(3, ErrorMessage = "Position must be atleast 3 characters")]
    public required string PositionName { get; set; }
    [Required(ErrorMessage ="Level is required")]
    public int Level { get; set; }  
    [Required(ErrorMessage = "Practice Id is required")]
    public int PracticeId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public Practice Practice { get; set; } = null!;
    public ICollection<MemberPosition> MemberPositions { get; set; } = new List<MemberPosition>();
    public ICollection<InterviewBooking> InterviewBookings { get; set; } = new List<InterviewBooking>();
    public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}
