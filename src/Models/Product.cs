using System;
using System.Collections.Generic;

namespace DemoApi.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CateId { get; set; }
        public DateTime Created { get; set; }
    }
}
