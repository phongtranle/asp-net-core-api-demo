using DemoApi.Models;
using System.Linq;

namespace DemoApi.Repositories{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(demoContext context) : base(context)
        {
            
        }
    }
}