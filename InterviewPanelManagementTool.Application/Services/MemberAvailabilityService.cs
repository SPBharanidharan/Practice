using System;
using AutoMapper;
using InterviewPanelManagementTool.Application.DTOs.MemberAvailability;
using InterviewPanelManagementTool.Application.Interfaces;
using InterviewPanelManagementTool.Domain.Entities;
using InterviewPanelManagementTool.Domain.Enums;

namespace InterviewPanelManagementTool.Application.Services;

public class MemberAvailabilityService : IMemberAvailabilityService
{
    private readonly IMemberAvailabilityRepository _memberAvailabilityRepository;
    private readonly IMapper _mapper;

    public MemberAvailabilityService(IMemberAvailabilityRepository memberAvailabilityRepository, IMapper mapper)
    {
        _memberAvailabilityRepository = memberAvailabilityRepository;
        _mapper = mapper;
    }
    public async Task<MemberAvailabilityDto> AddAvailabilityAsync(int memberId,MemberAvailabilityCreateDto memberAvailabilityCreateDto)
    {
        if (memberAvailabilityCreateDto.Date <= DateOnly.FromDateTime(DateTime.UtcNow) && memberAvailabilityCreateDto.EndTime<=TimeOnly.FromDateTime(DateTime.Now))
        {
            throw new Exception("past dates can't be given");
        }

        if (memberAvailabilityCreateDto.StartTime > memberAvailabilityCreateDto.EndTime)
        {
            throw new Exception("start time should less than end time");
        }



        if (await IsOverlaped(
            memberId,
            memberAvailabilityCreateDto.Date,
            memberAvailabilityCreateDto.StartTime,
            memberAvailabilityCreateDto.EndTime
        ))
        {
            throw new Exception("Overlapping, availability slot exists for this member");
        }

        var availability = _mapper.Map<MemberAvailability>(memberAvailabilityCreateDto);
        availability.AvailabilityStatus = AvailabilityStatus.Available;
        availability.CreatedDate = DateTime.UtcNow;



        await _memberAvailabilityRepository.AddMemberAsync(availability);

        return _mapper.Map<MemberAvailabilityDto>(availability);


    }

    public async Task<bool> IsOverlaped(int memberId, DateOnly date, TimeOnly startTime, TimeOnly endTime)
    {
        return await _memberAvailabilityRepository.HasOverlappingAvailabilityAsync(memberId, date, startTime, endTime);
    }

    public async Task<List<MemberAvailabilityDto>> GetAvailabilityByMemberIdAsync(int memberId)
    {
        var availabilities = await _memberAvailabilityRepository.GetMemberAvailabulitiesByIdAsync(memberId);
        var currentDateTime_=DateTime.Now;  // local computer timings (24hours)
        bool hasUpdates=false;
        foreach(var availability in availabilities)
        {
            if (availability.AvailabilityStatus != AvailabilityStatus.Available)
            {
                continue;
            }
            var endDateTime=availability.Date.ToDateTime(availability.EndTime);
            if (endDateTime < currentDateTime_)
            {
                hasUpdates=true;
                availability.AvailabilityStatus=AvailabilityStatus.Expired;
            }
        }
        await _memberAvailabilityRepository.SaveChanges();
        return _mapper.Map<List<MemberAvailabilityDto>>(availabilities);
    }

    public async Task UpdateAvailabilityAsyncBeforeBook(int availabilityId, MemberAvailabilityUpdateDto memberAvailabilityUpdateDto)
    {
        var availability = await _memberAvailabilityRepository.GetAvailabilityByIdAsync(availabilityId);

        if (availability.AvailabilityStatus == AvailabilityStatus.Booked)
        {
            throw new Exception("Booked availability cannot be updated");
        }

        if (memberAvailabilityUpdateDto.Date < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new Exception("Cannot update availability for past dates");
        }

        if (memberAvailabilityUpdateDto.StartTime > memberAvailabilityUpdateDto.EndTime)
        {
            throw new Exception("Start time must be less than end time");
        }
       


        availability.Date = memberAvailabilityUpdateDto.Date;
        availability.StartTime = memberAvailabilityUpdateDto.StartTime;
        availability.EndTime = memberAvailabilityUpdateDto.EndTime;

        await _memberAvailabilityRepository.UpdateAvailabilityAsync(availability);

    }

    public async Task<MemberAvailabilityDto> GetAvailabilityByIdAsync(int availabilityId)
    {
        var availability = await _memberAvailabilityRepository.GetAvailabilityByIdAsync(availabilityId);
        return _mapper.Map<MemberAvailabilityDto>(availability);
    }

    public async Task CancelAvailabilityAsync(int availabilityId)
    {
        var availability = await _memberAvailabilityRepository.GetAvailabilityByIdAsync(availabilityId);
        if (availability.AvailabilityStatus == AvailabilityStatus.Booked)
        {
            throw new InvalidOperationException("Booked availability cannot be cancelled");
        }

        await _memberAvailabilityRepository.CancelAvailabilityAsync(availability);
    }

    public async Task<List<MemberAvailabilityDto>> GetAllMemberAvailabilitiesAsync()
    {
        var availabilities=await _memberAvailabilityRepository.GetAllAsync();
        return _mapper.Map<List<MemberAvailabilityDto>>(availabilities);
    }
}
