using System;
using InterviewPanelManagementTool.Application.DTOs.Position;

namespace InterviewPanelManagementTool.Application.Interfaces;

public interface IPositionService
{
    Task<PositionDto> CreatePositionAsync(PositionCreateDto dto);
    Task<List<PositionDto>> GetPositionsByPracticeAsync(int practiceId);
    Task TogglePositionStatusAsync(int positionId);
}
