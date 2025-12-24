using System;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int userId);
    Task UpdateAsync(User user);
}
