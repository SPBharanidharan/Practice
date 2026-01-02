using InterviewPanelManagementTool.Application.DTOs.Position;
using InterviewPanelManagementTool.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPanelManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost]
        public async Task<ActionResult<PositionDto>> CreatePosition(PositionCreateDto dto)
        {
            var result = await _positionService.CreatePositionAsync(dto);
            return Ok(result);
        }

        [HttpGet("practice/{practiceId}")]
        public async Task<ActionResult<PositionDto>> GetByPractice(int practiceId)
        {
            var result = await _positionService.GetPositionsByPracticeAsync(practiceId);
            return Ok(result);
        }

        [HttpPatch("{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            await _positionService.TogglePositionStatusAsync(id);
            return NoContent();
        }
    }
}
