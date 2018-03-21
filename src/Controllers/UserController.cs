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
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService) : base ()
        {
            _userService = userService;
        }

        [HttpGet(Name="GetUsers")]
        public IActionResult GetProducts(UserFilterModel model)
        {
            try
            {
                model.PageNumber = model.PageNumber > 0 ? model.PageNumber : _pageNumber;
                model.PageSize = model.PageSize > 0 ? model.PageSize : _pageSize;

                var lst = _userService.GetUsers(model);
            
                return Ok(lst);
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}