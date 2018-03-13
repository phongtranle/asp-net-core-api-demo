using DemoApi.Models;
using DemoApi.Repositories;
using DemoApi.PagedList;
using DemoApi.ViewModels;

namespace DemoApi.Services
{
    public interface IProductService : IGenericService<Product>
    {
        Product GetById(int id);
        PagedList.PagedList<ProductModel> GetProducts(ProductFilterModel model);
    }
}