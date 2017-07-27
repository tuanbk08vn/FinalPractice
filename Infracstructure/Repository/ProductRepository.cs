using DomainLayer.IRepository;
using DomainLayer.Models;
using Infracstructure.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Infracstructure.Repository
{
    class ProductRepository : IProductRepository
    {
        private readonly MyContext _dbContext;

        //public ProductRepository()
        //{
        //    _dbContext = new MyContext();
        //}

        public ProductRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> Get()
        {

            return _dbContext.Products;
        }

        public bool Insert(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Update(int productId)
        {
            try
            {
                var currentProduct = _dbContext.Products.Find(productId);
                if (currentProduct != null)
                    _dbContext.Products.AddOrUpdate(currentProduct);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int productId)
        {
            try
            {
                var product = _dbContext.Products.Find(productId);
                if (product != null) _dbContext.Products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> SearchProducts(Expression<Func<Product, bool>> filter)
        {
            try
            {
                return _dbContext.Products.Where(filter).ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Product SelectOne(int id)
        {
            return _dbContext.Products.FirstOrDefault(m => m.Id == id);
        }

    }
}
