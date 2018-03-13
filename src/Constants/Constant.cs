using System.Collections.Generic;

namespace DemoApi.Constants {
    public static class Roles 
    {
        public const string SYSTEMROOT = "SYSTEMROOT";
        public const string SYSTEMADMIN = "SYSTEMADMIN";
        public const string SHOPADMIN = "SHOPADMIN";
    }

    public static class Methods
    {
        public const string POST = "POST";
        public const string GET = "GET";
    }

    public static class Rels
    {
        public const string PREVIOUS_PAGE = "previousPage";
        public const string NEXT_PAGE = "nextPage";
        public const string SELF = "self";
    }
}