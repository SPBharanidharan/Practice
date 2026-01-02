using System;
using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.User;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
        
        CreateMap<UserCreateDto, User>()
            .ForMember(dest => dest.Passwordhash, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.IsFirstLogin, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore());
    }
}
