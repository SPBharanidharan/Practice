using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Interfaces.Repositories;

public interface IPracticeRepository
{
    Task<Practice> AddAsync(Practice practice);
    Task<IEnumerable<Practice>> GetAllAsync();
    Task<Practice?> GetByIdAsync(int id);
    Task UpdateAsync(Practice practice);
    Task DeleteAsync(Practice practice);
}
