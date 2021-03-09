using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwelleryStore.Business.Services;
using JwelleryStore.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwelleryStoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticationModel authentication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userService.Authenticate(authentication.Username, authentication.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or password is incorrect" });


            return Ok(user);
        }

    }
}