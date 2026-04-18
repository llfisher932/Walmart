using Microsoft.AspNetCore.Mvc;
using Walmart.Models;
using Walmart.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Walmart.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 16;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1, string searchQuery = null)
        {
            var filtered = repository.Products
                .Where(p => category == null || p.Category == category)
                .Where(p => searchQuery == null || p.Name.Contains(searchQuery) || p.Description.Contains(searchQuery));

            return View(new ProductsListViewModel
            {
                Products = filtered
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = filtered.Count()
                },
                CurrentCategory = category,
                SearchQuery = searchQuery
            });
        }


    }
}