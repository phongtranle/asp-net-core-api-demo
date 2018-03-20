using System;

namespace DemoApi.ViewModels
{
    public class UserModel
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Loginname { get; set; }
        public string Email { get; set; }
        public int Storeid { get; set; }
        public string Storename { get; set; }
        public string Created { get; set; }
    }
}