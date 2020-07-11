using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.DataAccess.Models;
using NoteKeeper.Infrastructure.Interfaces;

namespace NoteKeeper.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserAccessor _userAccessor;

        public AuthController(IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
        {
            _jwtGenerator = jwtGenerator;
            _userAccessor = userAccessor;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok(_jwtGenerator.GenerateToken(new User {Email = "test@test.com", Id = Guid.NewGuid(), UserName = "johndoe"}));
        }

        [Authorize]
        [HttpGet("secret")]
        public IActionResult Secret()
        {
            var userId = _userAccessor.GetUserIdFromContext();

            return Ok(userId);
        }
    }
}