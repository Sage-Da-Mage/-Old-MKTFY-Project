using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Api.Helpers;
using MKTFY.Models.ViewModels.User;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    /// <summary>
    /// The controller for handling User-related endpoints
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// The Constructor that takes in a IUserService
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// The endpoint that generates a new user from passed in data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserVM>> Create([FromBody] UserAddVM data)
        {
            var userId = User.GetId();

            // Have the service create the new user
            var result = await _userService.Create(data, userId);

            // Return a 200 response with the UserVM
            return Ok(result);
        }

        /// <summary>
        /// The endpoint that gets a specific user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get([FromRoute] string id)
        {
            // Get the requested User entity from the service
            var result = await _userService.Get(id);

            // Return a 200 response with the UserVM
            return Ok(result);
        }

        /// <summary>
        /// The endpoint that updates a user.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<UserVM>> Update([FromBody] UserUpdateVM data)
        {
            // Update User entity from the service
            var result = await _userService.Update(data);

            // Return a 200 response with the UserVM
            return Ok(result);
        }
    }
}
