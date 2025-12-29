using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeEnrollmentSystem.Controllers.Api
{
    [ApiController]
    [Route("api/debug")]
    public class DebugController : ControllerBase
    {
        // No Authorize here on purpose
        // This endpoint INSPECTS the request, even if auth failed
        [Authorize]
        [HttpGet("jwt")]
        public IActionResult InspectJwt()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            return Ok(new
            {
                AuthorizationHeader = authHeader,
                HasAuthorizationHeader = !string.IsNullOrEmpty(authHeader),

                IsAuthenticated = User.Identity?.IsAuthenticated,
                AuthenticationType = User.Identity?.AuthenticationType,

                Claims = User.Claims.Select(c => new
                {
                    c.Type,
                    c.Value
                })
            });
        }

        [Authorize]
        [HttpGet("jwt-protected")]
        public IActionResult JwtProtected()
        {
            return Ok(new
            {
                Message = "JWT AUTH WORKS",
                User = User.Identity?.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

        [HttpGet("manual-jwt")]
        public async Task<IActionResult> ManualJwt()
        {
            var result = await HttpContext.AuthenticateAsync(
                JwtBearerDefaults.AuthenticationScheme
            );

            return Ok(new
            {
                JwtHandlerRan = true,
                Succeeded = result.Succeeded,
                Failure = result.Failure?.Message,
                PrincipalAuthType = result.Principal?.Identity?.AuthenticationType,
                Claims = result.Principal?.Claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}
