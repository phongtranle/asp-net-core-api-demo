using System;
using System.Collections.Generic;

namespace DemoApi.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
    }
}
