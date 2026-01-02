using System;
using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.User;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly IMapper _mapper;

    public AdminService(IUserRepository userRepository, IPasswordHasherService passwordHasher, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAsync(UserCreateDto dto, int adminId)
    {
        var user = _mapper.Map<User>(dto);

        user.Passwordhash = _passwordHasher.Hash(dto.Password);
        user.CreatedByUserId = adminId;
        user.CreatedAt = DateTime.UtcNow;
        user.IsFirstLogin = true;
        user.IsActive = true;

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task ToggleUserStatusAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new Exception("User not found");

        user.IsActive = !user.IsActive;
        await _userRepository.SaveChangesAsync();
    }

    public async Task<UserDto> UpdateUserAsync(int userId, UserUpdateDto dto, int adminId)
    {
        var user = await _userRepository.GetByIdAsync(userId)
        ?? throw new Exception("User not found");

        if (!string.IsNullOrWhiteSpace(dto.UserName))
            user.UserName = dto.UserName;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            user.Email = dto.Email;

        if (dto.Role.HasValue)
            user.Role = dto.Role.Value;

        if (dto.IsActive.HasValue)
            user.IsActive = dto.IsActive.Value;

        if (dto.PracticeId.HasValue)
            user.PracticeId = dto.PracticeId.Value;

        if (dto.DesignationPositionId.HasValue)
            user.DesignationPositionId = dto.DesignationPositionId.Value;

        await _userRepository.UpdateAsync(user);

        return _mapper.Map<UserDto>(user);
    }

}
