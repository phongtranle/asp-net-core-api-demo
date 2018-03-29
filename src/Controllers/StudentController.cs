using System;
using System.Net;
using DemoApi.Services;
using DemoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers 
{
    [Route("api/[controller]")]
    public class StudentController : BaseController 
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService _studentService) : base() 
        {
            studentService = _studentService;
        }

        [HttpGet]
        public IActionResult GetAll(StudentFilterModel model) 
        {
            try 
            {
                model.PageNumber = model.PageNumber > 0 ? model.PageNumber : _pageNumber;
                model.PageSize = model.PageSize > 0 ? model.PageSize : _pageSize;

                var lst = studentService.GetStudents(model);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}