using DemoApi.Models;
using DemoApi.Repositories;
using System.Linq;

namespace DemoApi.Services {
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IGenericRepository<User> _baseRepository) : base(_baseRepository)
        {
        }

        public User GetLoginUser(string username, string password)
        {
            var user = FindBy(m => m.Username == username && m.Password == password).FirstOrDefault();
            return user;
        }
    }
}