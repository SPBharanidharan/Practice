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
[Authorize]
public class MemberAvailabilityController : ControllerBase
{

    private readonly IMemberAvailabilityService _memberAvailabilityService;
    public MemberAvailabilityController(IMemberAvailabilityService memberAvailabilityService)
    {
        _memberAvailabilityService = memberAvailabilityService;
    }


    [HttpGet("all-availabilities")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAllMemberAvailabilities()
    {
        var result = await _memberAvailabilityService
            .GetAllMemberAvailabilitiesAsync();

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "member")]
    public async Task<IActionResult> AddMemberAvailability(MemberAvailabilityCreateDto memberAvailabilityCreateDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("Invalid token");
        int memberId = int.Parse(userId);

        var result = await _memberAvailabilityService.AddAvailabilityAsync(memberId, memberAvailabilityCreateDto);
        return Ok(result);
    }

    [HttpGet("member/{memberId}")]
    public async Task<IActionResult> GetMemberAvailabilitiesById()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("Invalid token");
        int memberId = int.Parse(userId);

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
