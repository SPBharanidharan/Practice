using System;
using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.Position;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.Services;

public class PositionService : IPositionService
{
    private readonly IPositionRepository _positionRepository;
    private readonly IMapper _mapper;
    public PositionService(IPositionRepository positionRepository, IMapper mapper)
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
    }

    public async Task<PositionDto> CreatePositionAsync(PositionCreateDto dto)
    {
        var position = _mapper.Map<Position>(dto);

        position.CreatedAt = DateTime.UtcNow;
        position.IsActive = true;

        await _positionRepository.AddAsync(position);
        await _positionRepository.SaveChangesAsync();

        return _mapper.Map<PositionDto>(position);
    }

    public async Task<List<PositionDto>> GetPositionsByPracticeAsync(int practiceId)
    {
        var positions = await _positionRepository.GetByPracticeIdAsync(practiceId);
        return _mapper.Map<List<PositionDto>>(positions);
    }

    public async Task TogglePositionStatusAsync(int positionId)
    {
        var position = await _positionRepository.GetByIdAsync(positionId)
                        ?? throw new Exception("Position Not Found");

        position.IsActive = !position.IsActive;
        await _positionRepository.SaveChangesAsync();
    }
}
