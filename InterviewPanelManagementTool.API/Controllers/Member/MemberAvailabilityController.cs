using System.Security.Claims;
using InterviewPanelManagementTool.Application.DTOs.MemberAvailability;
using InterviewPanelManagementTool.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPanelManagementTool.API.Controllers.Member;

[Route("api/[controller]")]
[ApiController]

public class MemberAvailabilityController : ControllerBase
{
    private readonly IMemberAvailabilityService _memberAvailabilityService;
    public MemberAvailabilityController(IMemberAvailabilityService memberAvailabilityService)
    {
        _memberAvailabilityService = memberAvailabilityService;
    }

    [HttpPost]
    public async Task<IActionResult> AddMemberAvailability(MemberAvailabilityCreateDto memberAvailabilityCreateDto)
    {
        // var memberId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _memberAvailabilityService.AddAvailabilityAsync(memberAvailabilityCreateDto);
        return Ok(result);
    }

    [HttpGet("member/{memberId}")]
    public async Task<IActionResult> GetMemberAvailabilitiesById(int memberId)
    {
        var availabilities = await _memberAvailabilityService.GetAvailabilityByMemberIdAsync(memberId);
        return Ok(availabilities);
    }

    [HttpPut("{availabilityId}")]
    public async Task<IActionResult> UpdateAvailability(int availabilityId, MemberAvailabilityUpdateDto memberAvailabilityUpdateDto)
    {
        await _memberAvailabilityService.UpdateAvailabilityAsyncBeforeBook(availabilityId, memberAvailabilityUpdateDto);
        return NoContent();
    }

    [HttpGet("availability/{availabilityId}")]
    public async Task<IActionResult> GetAvailabulityById(int availabilityId)
    {
        var availability = await _memberAvailabilityService.GetAvailabilityByIdAsync(availabilityId);
        return Ok(availability);
    }

    [HttpDelete("{availabilityId}")]
    public async Task<IActionResult> CancelAvailability(int availabilityId)
    {
        await _memberAvailabilityService.CancelAvailabilityAsync(availabilityId);
        return NoContent();
    }

}
