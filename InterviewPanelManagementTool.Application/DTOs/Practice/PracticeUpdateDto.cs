using System;

namespace InterviewPanelManagementTool.Application.DTOs.Practice;

public class PracticeUpdateDto
{
    public string? PracticeName { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
}
