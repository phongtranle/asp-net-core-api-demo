using System.Collections.Generic;

namespace DemoApi.Constants{
    public enum Role {
        SYSTEMROOT = 1,
        SYSTEMADMIN = 2,
        SHOPADMIN = 3
    }

    public static class Defines{
        public static Dictionary<int, string> RoleList = new Dictionary<int, string>() 
        {
            {(int)Role.SYSTEMROOT, Roles.SYSTEMROOT},
            {(int)Role.SYSTEMADMIN, Roles.SYSTEMADMIN},
            {(int)Role.SHOPADMIN, Roles.SHOPADMIN}
        };
    }
}