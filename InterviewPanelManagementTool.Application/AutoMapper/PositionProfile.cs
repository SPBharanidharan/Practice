using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.Position;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.AutoMapper;

public class PositionProfile : Profile
{
    public PositionProfile()
    {
        CreateMap<PositionCreateDto, Position>();
        CreateMap<Position, PositionDto>();
    }
}
