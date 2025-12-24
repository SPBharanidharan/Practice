using System;

namespace InterviewPanelManagementTool.Application.DTOs.Position;

public class PositionCreateDto
{
    public string PositionName { get; set; } = null!;
    public int Level { get; set; }
    public int PracticeId { get; set; }
}
