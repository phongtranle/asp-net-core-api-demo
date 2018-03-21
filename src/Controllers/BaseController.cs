using System.Collections.Generic;
using DemoApi.Constants;
using DemoApi.PagedList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DemoApi.Controllers
{
    public class BaseController : Controller
    {
        protected int _pageSize;
        protected int _pageNumber;
        public BaseController() 
        {
            _pageSize = 10;
            _pageNumber = 1;
        }
    }
}