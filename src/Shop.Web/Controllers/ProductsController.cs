﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{    
    [Route("products")]
    public class ProductsController : Controller
    {        
        private static readonly List<Product> _products = new List<Product>
        {
            new Product("Laptop", "Electronics", 3000),
            new Product("Jeans", "Trousers", 3000),
            new Product("Laptop", "Electronics", 3000),
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpGet("add")]
        public IActionResult AddProduct()
        {
            var viewModel = new ProductViewModel();
            return View(viewModel);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(ProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            _products.Add(new Product(model.Name, model.Category, model.Price));
            return RedirectToAction(nameof(Index));
            
        }
    }
}