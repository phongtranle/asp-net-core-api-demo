using DemoApi.Constants;
using DemoApi.Models;
using DemoApi.PagedList;
using DemoApi.Services;
using DemoApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;

namespace DemoApi.Controllers
{
    [Authorize(Roles = Roles.SHOPADMIN)]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private IProductService productService;
        private ICategoryService categoryService;
        public ProductController(
            IUrlHelper _urlHelper 
            , IProductService _productService
            , ICategoryService _categoryService) : base (_urlHelper)
        {
            productService = _productService;
            categoryService = _categoryService;
        }

        private List<LinkInfo> GetLinks(PagedList<ProductModel> list, string action, string method)
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

        [HttpGet(Name="GetProducts")]
        public IActionResult GetProducts(ProductFilterModel model)
        {
            try
            {
                model.PageNumber = model.PageNumber > 0 ? model.PageNumber : _pageNumber;
                model.PageSize = model.PageSize > 0 ? model.PageSize : _pageSize;

                var lst = productService.GetProducts(model);
                lst.Links = GetLinks(lst, "GetProducts", Methods.GET);
            
                return Ok(lst);
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{id}", Name="GetProduct")]
        public IActionResult GetById(int id)
        {
            try
            {
                var prod = productService.GetById(id);
                if (prod == null)
                {
                    return NotFound();
                }
                return new ObjectResult(prod);
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product prod) 
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    if (prod == null) 
                    {
                        return BadRequest();
                    }
                    productService.Add(prod);
                    productService.Save();
                    
                    return CreatedAtRoute("GetProduct", new {id = prod.Id}, prod);
                } else 
                {
                    return BadRequest(ModelState);
                }
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (item == null || item.Id != id)
                    {
                        return BadRequest();
                    }
                    
                    var prod = productService.GetById(id);
                    if (prod == null)
                    {
                    return NotFound(); 
                    }

                    prod.Name = item.Name;
                    prod.Price = item.Price;

                    productService.Update(prod);
                    productService.Save();

                    return new NoContentResult();
                    }
                else 
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}