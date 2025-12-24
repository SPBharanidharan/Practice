using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewPanelManagementTool.Domain.Entities;

public class Candidate
{
    public int CandidateId { get; set; }
    public int CandidateCode { get; set; }
    public required string Name { get; set; }
    [Required(ErrorMessage = "Practice Id is required")]
    public int PracticeId { get; set; }

    [Required(ErrorMessage = "Position Id is required")]
    public int PositionId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Practice Practice { get; set; } = null!;
    public Position Position { get; set; } = null!;
    public ICollection<InterviewBooking> InterviewBookings { get; set; } = new List<InterviewBooking>();
}
