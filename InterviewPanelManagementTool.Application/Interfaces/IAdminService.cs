using System;
using InterviewPanelManagementTool.Application.DTOs.Auth;
using InterviewPanelManagementTool.Application.DTOs.User;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IAdminService
{
    Task<UserDto> CreateUserAsync(UserCreateDto dto, int adminId);
    Task<List<UserDto>> GetAllUsersAsync();
    Task ToggleUserStatusAsync(int userId);
}
