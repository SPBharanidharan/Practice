using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.User;

public class UserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public UserRole Role { get; set; }
    public bool IsFirstLogin { get; set; }
    public bool IsActive { get; set; }
    public int? PracticeId { get; set; }
    public int? DesignationPositionId { get; set; }
    public DateTime CreatedAt { get; set; }
}
