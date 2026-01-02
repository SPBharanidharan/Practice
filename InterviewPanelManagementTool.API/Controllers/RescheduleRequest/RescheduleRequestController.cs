using InterviewPanelManagementTool.Application.DTOs.RescheduleRequest;
using InterviewPanelManagementTool.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace InterviewPanelManagementTool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
   
    public class RescheduleRequestController : ControllerBase
    {
        private readonly IRescheduleRequestService _service;

        public RescheduleRequestController(IRescheduleRequestService service)
        {
            _service = service;
        }

        
        [HttpPost("create-request")]
        public async Task<IActionResult> Create(RescheduleRequestCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Invalid token");
        
            int memberId = int.Parse(userId);
            var result = await _service.CreateRequestAsync(dto, memberId);
            return Ok(result);
        }

        [HttpGet("my-requests")]
        public async Task<IActionResult> GetMyRescheduleRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Invalid token");

            int memberId = int.Parse(userId);

            var result = await _service.GetRequestsByMemberAsync(memberId);

            return Ok(result);
        }

        
        [HttpGet("all-Request")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRequest()
        {
            var result = await _service.GetAllRequestAsync();
            return Ok(result);
        }
        

    }
}
