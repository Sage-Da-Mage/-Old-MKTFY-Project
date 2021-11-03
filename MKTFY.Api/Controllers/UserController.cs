using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Update the user profile
        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult> ProfileUpdate()
        {
            // Get the Auth Token from the header
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            // Perform the update
            var result = await _userService.CreateOrUpdate(accessToken);
            if (result != null)
                return BadRequest(new { message = "Unable to update the user profile" });

            return Ok();
        }
    }
}
