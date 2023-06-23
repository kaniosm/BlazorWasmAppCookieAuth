using BlazorWasmAppCookieAuth.Server.Data;
using BlazorWasmAppCookieAuth.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorWasmAppCookieAuth.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpGet]
        [Route("user-profile")]
        public async Task<IActionResult> UserProfileAsync()
        {
            string userId = HttpContext.User.Claims.Where(_ => _.Type == ClaimTypes.NameIdentifier).Select(_ => _.Value).First();

            var userProfile = await _applicationDbContext.Users.Where(_ => _.Id == userId)
            .Select(_ => new UserProfileDto
            {
                UserId = _.Id,
                Email = _.Email,
                Name = _.UserName,
            }).FirstOrDefaultAsync();

            return Ok(userProfile);
        }
    }
}
