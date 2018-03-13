using DemoApi.Models;

namespace DemoApi.Repositories{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(demoContext context) : base(context)
        {
            
        }
    }
}