
using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.AutoMapper;
public class RescheduleRequestProfile : Profile
{
    public RescheduleRequestProfile()
        {
            
            CreateMap<RescheduleRequestCreateDto, RescheduleRequest>();

            CreateMap<RescheduleRequest, RescheduleRequestResponseDto>()
                .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Member.UserName))
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => src.Booking.Candidate.Name));
        }
}