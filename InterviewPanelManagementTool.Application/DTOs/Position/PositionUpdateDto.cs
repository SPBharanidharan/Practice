using System;

namespace InterviewPanelManagementTool.Application.DTOs.Position;

public class PositionUpdateDto
{
    public string? PositionName { get; set; }
    public int? Level { get; set; }
    public bool? IsActive { get; set; }
}
