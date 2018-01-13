using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain;
using Shop.Web.Models;
using Shop.Core.Repositories;
using Shop.Core.Services;

namespace Shop.Web.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        /*
        private static readonly List<Product> _products = new List<Product>
        {
            new Product("Laptop", "Electronics", 3000),
            new Product("Jeans", "Trousers", 3000),
            new Product("Hammer", "Tools", 3000),
        };
        */

            /*
        private IProductRepository _productRepository;
        
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }*/
        
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService
                .GetAll()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    Price = p.Price
                }
            );
            return View(products);
        }

        [HttpGet("add")]
        public IActionResult AddProduct()
        {
            var viewModel = new AddProductViewModel();
            return View(viewModel);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            /*
            _products.Add(new Product(model.Name, model.Category, model.Price));
            
            */
            _productService.Add(model.Name, model.Category, model.Price);
            return RedirectToAction(nameof(Index));
        }
    }
}