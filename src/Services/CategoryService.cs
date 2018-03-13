using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;
using System.Linq;

namespace DemoApi.Services {
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> _baseRepository) : base(_baseRepository)
        {
        }
    }
}