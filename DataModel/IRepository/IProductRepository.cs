using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(Expression<Func<Product, bool>> filter);
    }
}
