using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Shop.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Product> Products;

        public IndexModel(
            IProductsRepository repository,
            ILogger<IndexModel> logger)
        {
            Products = repository.Get().Result.ToList();
            _logger = logger;
        }

        public void OnGet()
        {
            var rnd = new Random();
            var randomList = Products.OrderBy(x => rnd.Next()).Take(6);
            Products = randomList;
        }
    }
}
