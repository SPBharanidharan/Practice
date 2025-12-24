using System;
using Microsoft.AspNetCore.Identity;
using InterviewPanelManagementTool.Application.Interfaces;

namespace InterviewPanelManagementTool.API.Services;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<object> _hasher = new();

    public string Hash(string password)
        => _hasher.HashPassword(null!, password);

    public bool Verify(string hashedPassword, string providedPassword)
        => _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword)
           != PasswordVerificationResult.Failed;
}
