using InterviewPanelManagementTool.Application.DTOs.Practice;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IPracticeService
{
    Task<PracticeResponseDto> CreateAsync(PracticeCreateAndUpdateDto dto);
    Task<IEnumerable<PracticeResponseDto>> GetAllAsync();
    Task<PracticeResponseDto?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, PracticeCreateAndUpdateDto dto);
    Task<bool> DeleteAsync(int id); 
}
