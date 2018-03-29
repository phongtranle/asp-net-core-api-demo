using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;

namespace DemoApi.Services
{
    public interface IStudentService : IGenericService<Student>
    {
        PagedList.PagedList<Student> GetStudents(StudentFilterModel model);
        Student GetById(int id);
    }
}