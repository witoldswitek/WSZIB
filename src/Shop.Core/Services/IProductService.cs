﻿using Shop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        void Add(string name, string category, decimal price);
    }
}
