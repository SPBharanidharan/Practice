using System;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IPositionRepository
{
    Task AddAsync(Position position);
    Task<List<Position>> GetByPracticeIdAsync(int practiceId);
    Task<Position?> GetByIdAsync(int id);
    Task SaveChangesAsync();
}
