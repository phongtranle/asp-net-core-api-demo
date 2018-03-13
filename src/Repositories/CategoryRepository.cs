using DemoApi.Models;

namespace DemoApi.Repositories{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(demoContext context) : base(context)
        {
        }
    }
}