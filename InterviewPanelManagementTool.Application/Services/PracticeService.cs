using InterviewPanelManagementTool.Application.DTOs.Practice;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;
using AutoMapper;

namespace InterviewPanelManagementTool.Application.Services;

public class PracticeService : IPracticeService
{
    private readonly IPracticeRepository _repo;
    private readonly IMapper _mapper;

    public PracticeService(IPracticeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<PracticeResponseDto> CreateAsync(PracticeCreateAndUpdateDto dto)
    {
        var practice = _mapper.Map<Practice>(dto);
        practice.CreatedAt = DateTime.Now;
        practice.IsActive = true;
        await _repo.AddAsync(practice);
        return _mapper.Map<PracticeResponseDto>(practice);
    }

    public async Task<IEnumerable<PracticeResponseDto>> GetAllAsync()
    {
        var practices = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<PracticeResponseDto>>(practices);
    }

    public async Task<PracticeResponseDto?> GetByIdAsync(int id)
    {
        var practice = await _repo.GetByIdAsync(id);
        return practice == null ? null : _mapper.Map<PracticeResponseDto>(practice);
    }

    public async Task<bool> UpdateAsync(int id, PracticeCreateAndUpdateDto dto)
    {
        var practice = await _repo.GetByIdAsync(id);
        if (practice == null) return false;

        _mapper.Map(dto, practice);
        await _repo.UpdateAsync(practice);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var practice = await _repo.GetByIdAsync(id);
        if (practice == null) return false;

        await _repo.DeleteAsync(practice);
        return true;
    }
}
