using Core.Data.DTOs;
using Core.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please, provide all the required fields");
            return Ok(await _authService.Register(model));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please, provide all required fields");
            return Ok(await _authService.Login(model));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please, provide all required fields");
            return Ok(await _authService.RefreshToken(model));
        }
    }
}
