using System;

namespace InterviewPanelManagementTool.Application.DTOs.Practice;

public class PracticeCreateDto
{
    public string PracticeName { get; set; } = null!;
    public string? Description { get; set; }
}
