namespace InterviewPanelManagementTool.Application.DTOs.Practice;
public class PracticeCreateAndUpdateDto
{  
     public string PracticeName { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
