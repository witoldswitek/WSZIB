﻿using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using System.Linq;
using Shop.Core.Domain;

namespace Shop.Core.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<ProductDTO> GetAll()
        => _productRepository
            .GetAll()
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price
            });

        public void Add(string name, string category, decimal price)
        {
            var product = new Product(name, category, price);
            _productRepository.Add(product);
        }
    }
}
