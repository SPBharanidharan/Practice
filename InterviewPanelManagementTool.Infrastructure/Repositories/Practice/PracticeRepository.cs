using InterviewPanelManagementTool.Domain.Entities;
using InterviewPanelManagementTool.Infrastructure.DataConfiguration.DataContext;
using InterviewPanelManagementTool.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InterviewPanelManagementTool.Infrastructure.Repositories;

public class PracticeRepository : IPracticeRepository
{
    private readonly ApplicationDbContext _context;

    public PracticeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Practice> AddAsync(Practice practice)
    {
        _context.Practices.Add(practice);
        await _context.SaveChangesAsync();
        return practice;
    }

    public async Task<IEnumerable<Practice>> GetAllAsync()
        => await _context.Practices.ToListAsync();

    public async Task<Practice?> GetByIdAsync(int id)
        => await _context.Practices.FindAsync(id);

    public async Task UpdateAsync(Practice practice)
    {
        _context.Practices.Update(practice);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Practice practice)
    {
        practice.IsActive = false; // soft delete
        await _context.SaveChangesAsync();
    }
}
