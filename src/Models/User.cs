using System;
using System.Collections.Generic;

namespace DemoApi.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public sbyte Gender { get; set; }
        public DateTime Created { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
    }
}
