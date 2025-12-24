using System;
using InterviewPanelManagementTool.Application.DTOs.Auth;
using InterviewPanelManagementTool.Application.Interfaces;

namespace InterviewPanelManagementTool.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasherService _passwordHasher;

    public AuthService(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasherService passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResponseDto> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null ||
            !_passwordHasher.Verify(user.Passwordhash, dto.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new LoginResponseDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            Role = user.Role,
            Token = token,
            IsFirstLogin = user.IsFirstLogin
        };
    }

    public async Task ChangePasswordAsync(ChangePasswordDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        if (!_passwordHasher.Verify(user.Passwordhash, dto.CurrentPassword))
            throw new UnauthorizedAccessException("Current password is incorrect");

        user.Passwordhash = _passwordHasher.Hash(dto.NewPassword);
        user.IsFirstLogin = false;

        await _userRepository.UpdateAsync(user);
    }
}

