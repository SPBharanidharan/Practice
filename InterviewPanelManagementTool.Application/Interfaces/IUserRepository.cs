using System;
using InterviewPanelManagementTool.Application.DTOs.User;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int userId);
    Task UpdateAsync(User user);
    Task AddAsync(User user);
    Task<List<User>> GetAllAsync();
    Task SaveChangesAsync();

}
