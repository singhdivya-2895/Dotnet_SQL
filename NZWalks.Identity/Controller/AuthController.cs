using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Identity.DTOs;

namespace NZWalks.Identity.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
           var identityResult =  await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

           if (identityResult.Succeeded)
           {
               //Add roles to this user
               if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
               {
                   identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                   if (identityResult.Succeeded)
                   {
                       return Ok("User was registered! Please Login");
                   }
               }
           }
           return BadRequest("Something went wrong");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //create token
                    return Ok();
                }
            }
            return BadRequest("UserName and password are incorrect.Please Try Again");
        }

    }
}
