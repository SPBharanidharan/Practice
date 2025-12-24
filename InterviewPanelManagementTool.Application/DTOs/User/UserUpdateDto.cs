using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.User;

public class UserUpdateDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public UserRole? Role { get; set; }
    public bool? IsActive { get; set; }
    public int? PracticeId { get; set; }
    public int? DesignationPositionId { get; set; }

}
