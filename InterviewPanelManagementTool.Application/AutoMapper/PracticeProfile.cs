using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.Practice;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.AutoMapper;

public class PracticeProfile : Profile
{
    public PracticeProfile()
    {
        CreateMap<PracticeCreateAndUpdateDto, Practice>();

        CreateMap<Practice, PracticeResponseDto>();
    }
}
