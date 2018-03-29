using System;
using System.Net;
using DemoApi.Models;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try 
            {
                var std = studentService.GetById(id);
                return Ok(std);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Student model)
        {
            try 
            {
                studentService.Add(model);
                studentService.Save();
                
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public IActionResult Update(int id,[FromBody] Student model)
        {
            try 
            {
                var student = studentService.GetById(id);

                if (student == null) 
                {
                    return NotFound();
                }

                student.Name = model.Name;
                student.Age = model.Age;
                student.Address = model.Address;
                student.Created = model.Created;

                studentService.Update(student);
                studentService.Save();

                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}