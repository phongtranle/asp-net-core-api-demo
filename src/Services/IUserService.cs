using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;

namespace DemoApi.Services
{
    public interface IUserService : IGenericService<User>
    {
        User GetLoginUser(string username, string password);
    }
}