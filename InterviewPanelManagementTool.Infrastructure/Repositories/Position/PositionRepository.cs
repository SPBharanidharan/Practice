using System;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;
using InterviewPanelManagementTool.Infrastructure.DataConfiguration.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InterviewPanelManagementTool.Infrastructure.Repositories;

public class PositionRepository : IPositionRepository
{
    private readonly ApplicationDbContext _context;
    public PositionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Position position)
    {
        await _context.Positions.AddAsync(position);
    }

    public async Task<Position?> GetByIdAsync(int id)
    {
        return await _context.Positions.FindAsync(id);
    }

    public async Task<List<Position>> GetByPracticeIdAsync(int practiceId)
    {
        return await _context.Positions.Where(p => p.PracticeId == practiceId).ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
