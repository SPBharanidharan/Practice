using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.User;

public class UserCreateDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    
}
