using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain
{
    class Products
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; set; }
        public decimal Price { get; }


        public Products(string name, string category, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
