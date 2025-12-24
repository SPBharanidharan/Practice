using System;
using InterviewPanelManagementTool.Application.DTOs.User;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasher;

    public AdminService(IUserRepository userRepository, IPasswordHasherService passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto> CreateUserAsync(UserCreateDto dto, int adminId)
    {
        var passwordhash = _passwordHasher.Hash(dto.Password);
        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Passwordhash = passwordhash,
            Role = dto.Role,
            PracticeId = dto.PracticeId,
            DesignationPositionId = dto.DesignationPositionId,
            CreatedByUserId = adminId,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsFirstLogin = true
        };



        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return new UserDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive
        };
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(u => new UserDto
        {
            UserId = u.UserId,
            UserName = u.UserName,
            Email = u.Email,
            Role = u.Role,
            IsActive = u.IsActive
        }).ToList();
    }

    public async Task ToggleUserStatusAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
                   ?? throw new Exception("User not found");

        user.IsActive = !user.IsActive;
        await _userRepository.SaveChangesAsync();
    }
}
