using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DemoApi.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int StoreId { get; set; }
        public DateTime? Created { get; set; }
    }
}
