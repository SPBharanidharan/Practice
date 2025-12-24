using InterviewPanelManagementTool.Application.DTOs.Auth;
using InterviewPanelManagementTool.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPanelManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            await _authService.ChangePasswordAsync(dto);
            return Ok(new { message = "Password changed successfully" });
        }

        [Authorize]
        [HttpPost("logout")]

        [Authorize]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out successfully. Please remove token from client." });
        }
    }
}
