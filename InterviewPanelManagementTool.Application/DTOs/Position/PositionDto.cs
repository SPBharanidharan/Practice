using System;

namespace InterviewPanelManagementTool.Application.DTOs.Position;

public class PositionDto
{
    public int PositionId { get; set; }
    public string PositionName { get; set; } = null!;
    public int Level { get; set; }
    public int PracticeId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
