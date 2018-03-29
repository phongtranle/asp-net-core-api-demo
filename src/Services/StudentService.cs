using DemoApi.Models;
using DemoApi.PagedList;
using DemoApi.Repositories;
using DemoApi.ViewModels;
using System.Linq;

namespace DemoApi.Services {
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(IGenericRepository<Student> _baseRepository) : base(_baseRepository)
        {
        }

        public PagedList<Student> GetStudents(StudentFilterModel model)
        {
            var lst = GetAll();

            if (!string.IsNullOrWhiteSpace(model.Name)) {
                lst = lst.Where(m => m.Name.Contains(model.Name));
            }

            return lst.ToPagedList(model.PageNumber, model.PageSize);
        }
    }
}