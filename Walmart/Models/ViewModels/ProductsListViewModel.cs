using Walmart.Models;
using Walmart.Models.ViewModels;
using System.Collections.Generic;

namespace Walmart.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        public string SearchQuery { get; set; }
    }
}
