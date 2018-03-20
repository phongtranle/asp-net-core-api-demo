using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;

namespace DemoApi.Services
{
    public interface IUserService : IGenericService<User>
    {
        User GetLoginUser(string loginname, string password);
        PagedList.PagedList<UserModel> GetUsers(UserFilterModel model);
    }
}