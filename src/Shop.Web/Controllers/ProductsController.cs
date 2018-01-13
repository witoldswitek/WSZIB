using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain;


namespace Shop.Web.Controllers
{
    public class ProductsController : Controller
    {

        private static readonly List<Product> _products = new List<Product>
        {
            new Product("Laptop", "Electronics", 3000),
            new Product("Jeans", "Trousers", 3000),
            new Product("Laptop", "Electronics", 3000),
        };

        public IActionResult Index()
        {
            return View(_products);
        }
    }
}