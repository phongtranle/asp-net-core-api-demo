using DemoApi.Models;
using DemoApi.PagedList;
using DemoApi.Repositories;
using DemoApi.ViewModels;
using System.Linq;

namespace DemoApi.Services {
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IGenericRepository<Store> storeRepository;
        public UserService(IGenericRepository<User> _baseRepository
            , IGenericRepository<Store> _storeRepository) : base(_baseRepository)
        {
            storeRepository = _storeRepository;
        }

        public User GetLoginUser(string loginname, string password)
        {
            var user = FindBy(m => m.Loginname == loginname && m.Password == password).FirstOrDefault();
            return user;
        }

        public PagedList<UserModel> GetUsers(UserFilterModel model)
        {
            var users = GetAll();
            var stores = storeRepository.GetAll();

            var lst = from user in users
                        join store in stores on user.StoreId equals store.Id
                        select new UserModel {
                            Userid = user.Id,
                            Username = user.Username,
                            Loginname = user.Loginname,
                            Mail = user.Email,
                            Storeid = store.Id,
                            Storename = store.Name,
                            Created = user.Created
                        };
            

            if (!string.IsNullOrWhiteSpace(model.UserName)) 
            {
                lst = lst.Where(m => m.Username.Contains(model.UserName));
            }

            if (!string.IsNullOrWhiteSpace(model.LoginName))
            {
                lst = lst.Where(m => m.Loginname.Contains(model.LoginName));
            }

            if (!string.IsNullOrWhiteSpace(model.StoreName))
            {
                lst = lst.Where(m => m.Storename.Contains(model.StoreName));
            }

            return lst.ToPagedList(model.PageNumber, model.PageSize);
        }
    }
}