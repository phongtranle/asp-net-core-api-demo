using System;
using System.Collections.Generic;

namespace DemoApi.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime? Created { get; set; }
    }
}
