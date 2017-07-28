using DomainLayer.Models;
using System.Collections.Generic;

namespace DomainLayer.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(int id);
    }
}
