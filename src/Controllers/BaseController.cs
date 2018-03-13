using System.Collections.Generic;
using DemoApi.PagedList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DemoApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUrlHelper urlHelper;
        public BaseController(IUrlHelper _urlHelper) => urlHelper = _urlHelper;
        public LinkInfo CreateLink(
            string routeName, int pageNumber, int pageSize,
            string rel, string method)
        {
            return new LinkInfo
            {
                Href = urlHelper.Link(routeName,
                            new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }
    }
}