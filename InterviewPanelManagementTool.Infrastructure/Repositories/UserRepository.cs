using System;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;
using InterviewPanelManagementTool.Infrastructure.DataConfiguration.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InterviewPanelManagementTool.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
