using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.User;

public class UserUpdateDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }
}
