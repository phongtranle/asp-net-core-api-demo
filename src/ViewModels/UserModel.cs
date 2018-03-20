using System;

namespace DemoApi.ViewModels
{
    public class UserModel
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Loginname { get; set; }
        public string Mail { get; set; }
        public int Storeid { get; set; }
        public string Storename { get; set; }
        public DateTime? Created { get; set; }
    }
}