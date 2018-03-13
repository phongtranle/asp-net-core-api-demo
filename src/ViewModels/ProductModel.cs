using System;

namespace DemoApi.ViewModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int CateId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public DateTime Created{get;set;}
    }
}