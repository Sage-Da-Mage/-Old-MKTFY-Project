using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Models.ViewModels.Auth;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    /// <summary>
    /// The controller for Authorization endpoints
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Set up the constructor with an IAuthService passed in
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Exchange an Auth Code for an Access token
        /// </summary>
        /// <param name="authCode"></param>
        /// <returns></returns>
        [HttpPost("token")]
        public async Task<ActionResult<AuthResponseVM>> Token([FromQuery] string authCode)
        {
            // Exchange the token
            var result = await _authService.ExchangeToken(authCode);
            if (result == null)
                return BadRequest(new { message = "Unable to authorize access" });
            return Ok(result);
        }
    }

}
