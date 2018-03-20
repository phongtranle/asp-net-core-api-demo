using DemoApi.Constants;
using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.Services;
using DemoApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private IConfiguration _config;
        private IUserService _userService;

        public LoginController(IUrlHelper urlHelper
                            ,IConfiguration config
                            , IUserService userService) : base (urlHelper)
        {
            _config = config;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel login)
        {
            if (login == null)
            {
                return BadRequest();
            }

            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        [Authorize(Roles = "SYSTEMROOT,SYSTEMADMIN")]
        [HttpGet("user")]
        public IActionResult GetCurentUser()
        {
            IActionResult response = Unauthorized();
            
            var user = HttpContext.User.Identity.Name;
            if (user != null)
            {
                response = Ok(user);
            }
            
            return response;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Loginname),
                new Claim(ClaimTypes.Role, Defines.RoleList[user.RoleId])
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(6),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginModel login)
        {
            return _userService.GetLoginUser(login.Username, login.Password);
        }
    }
}