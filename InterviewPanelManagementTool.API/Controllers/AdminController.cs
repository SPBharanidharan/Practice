using System.Security.Claims;
using InterviewPanelManagementTool.Application.DTOs;
using InterviewPanelManagementTool.Application.DTOs.User;
using InterviewPanelManagementTool.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InterviewPanelManagementTool.Application.DTOs.Common;


namespace InterviewPanelManagementTool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("users")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserCreateDto dto)
        {
            if (!int.TryParse(
                    User.FindFirstValue(ClaimTypes.NameIdentifier),
                    out int adminId))
            {
                return Unauthorized("Invalid admin identity.");
            }

            var createdUser = await _adminService.CreateUserAsync(dto, adminId);
            return Ok(createdUser);
        }

        [HttpGet("users")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _adminService.GetAllUsersAsync();
        }

        [HttpPatch("users/{id:int}/toggle-status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ToggleUserStatus(int id)
        {
            await _adminService.ToggleUserStatusAsync(id);
            return Ok(new ApiResponse("User status updated successfully."));
        }

        [HttpPatch("users/{id:int}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int adminId))
            {
                return Unauthorized("Invalid admin identity.");
            }

            var updatedUser = await _adminService.UpdateUserAsync(id, dto, adminId);
            return Ok(updatedUser);
        }
    }
}
