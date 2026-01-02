using System;
using InterviewPanelManagementTool.Application.DTOs.Auth;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(UserLoginDto dto);
    Task ChangePasswordAsync(int userId, ChangePasswordDto dto);
}