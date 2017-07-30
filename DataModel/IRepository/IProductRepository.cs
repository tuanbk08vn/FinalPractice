using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace DomainLayer.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(int id);
        List<Product> SearchProducts(Func<Product, bool> lamda);
    }
}
