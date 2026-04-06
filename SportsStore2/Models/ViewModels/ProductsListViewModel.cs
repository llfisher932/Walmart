using SportsStore2.Models;
using SportsStore2.Models.ViewModels;
using System.Collections.Generic;

namespace SportsStore2.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
