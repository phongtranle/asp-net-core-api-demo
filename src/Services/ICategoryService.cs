using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;

namespace DemoApi.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
    }
}