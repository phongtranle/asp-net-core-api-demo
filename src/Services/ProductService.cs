using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;
using System.Linq;

namespace DemoApi.Services {
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IGenericRepository<Category> categoryRepository;
        public ProductService(
            IGenericRepository<Product> _baseRepository
            , IGenericRepository<Category> _categoryRepository) : base(_baseRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public Product GetById(int id)
        {
            return FindById(m => m.Id == id);
        }

        public PagedList<ProductModel> GetProducts(ProductFilterModel model)
        {
            var prods = GetAll();
            var cates = categoryRepository.GetAll();

            var lst = from prod in prods
                      join cate in cates on prod.CateId equals cate.Id
                      select new ProductModel {
                          ProductId = prod.Id,
                          CateId = cate.Id,
                          ProductName = prod.Name,
                          CategoryName = cate.Name,
                          Price = prod.Price
                      };

            if (!string.IsNullOrWhiteSpace(model.ProductName)) 
            {
                lst = lst.Where(m => m.ProductName.Contains(model.ProductName));
            }

            if (model.Price != 0)
            {
                lst = lst.Where(m => m.Price == model.Price);
            }

            return lst.ToPagedList(model.PageNumber, model.PageSize);
        }
    }
}