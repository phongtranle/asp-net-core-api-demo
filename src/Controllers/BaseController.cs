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
        private readonly IUrlHelper urlHelper;
        protected int _pageSize;
        protected int _pageNumber;
        public BaseController(IUrlHelper _urlHelper) 
        {
            urlHelper = _urlHelper;
            _pageSize = 10;
            _pageNumber = 1;
        }
        private LinkInfo CreateLink(
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

        public List<LinkInfo> GetLinks<T>(PagedList<T> list, string action, string method) where T : class
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink(action, list.PreviousPageNumber, 
                           list.PageSize, Rels.PREVIOUS_PAGE, method));

            links.Add(CreateLink(action, list.PageNumber, 
                           list.PageSize, Rels.SELF, method));

            if (list.HasNextPage)
                links.Add(CreateLink(action, list.NextPageNumber, 
                           list.PageSize, Rels.NEXT_PAGE, method));

            return links;
        }
    }
}