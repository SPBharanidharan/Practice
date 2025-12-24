using System.Security.Claims;
using InterviewPanelManagementTool.Application.DTOs;
using InterviewPanelManagementTool.Application.DTOs.User;
using InterviewPanelManagementTool.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPanelManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IPasswordHasherService _passwordHasher;

        public AdminController(IAdminService adminService,IPasswordHasherService passwordHasher)
        {
            _adminService = adminService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser(UserCreateDto dto)
        {
            int adminId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _adminService.CreateUserAsync(dto, adminId);
            return Ok(result);
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpPatch("users/{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            await _adminService.ToggleUserStatusAsync(id);
            return Ok(new { message = "User status updated" });
        }
    }
}
