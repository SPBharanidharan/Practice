using System;

namespace InterviewPanelManagementTool.Application.DTOs.Practice;

public class PracticeDto
{
    public int PracticeId { get; set; }
    public string PracticeName { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
