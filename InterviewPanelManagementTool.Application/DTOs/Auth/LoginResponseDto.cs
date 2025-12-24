using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.Auth;

public class LoginResponseDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public UserRole Email { get; set; }
    public bool IsFirstLogin { get; set; }
    public string Token { get; set; }
}
