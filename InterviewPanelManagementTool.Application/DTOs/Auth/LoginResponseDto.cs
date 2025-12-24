using System;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.DTOs.Auth;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public UserRole Role { get; set; }
    public string Token { get; set; } = null!;   // JWT token or session token
    public bool IsFirstLogin { get; set; }
}
