using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Infrastructure.Dto.Auth;
using NoteKeeper.Services.Auth;

namespace NoteKeeper.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var response = await _authService.Register(registerUserDto);
            
            return Created(new Uri(Request.Path, UriKind.Relative), response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            return Ok(await _authService.Login(loginUserDto));
        }

        [Authorize]
        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            return Ok(await _authService.GetUserInfo());
        }
    }
}