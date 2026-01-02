using System;
using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.MemberAvailability;
using InterviewPanelManagementTool.Domain.Entities;

namespace InterviewPanelManagementTool.Application.MappingProfiles;

public class MemberAvailabilityProfile:Profile
{
    public MemberAvailabilityProfile()
    {
        CreateMap<MemberAvailabilityCreateDto,MemberAvailability>();
        CreateMap<MemberAvailability,MemberAvailabilityDto>();
    }
}
