using DomainLayer.IRepository;
using DomainLayer.Models;
using Infracstructure.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

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
            return _dbContext.Products.ToList();
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

        public bool Update(Product product)
        {
            try
            {
                //var currentProduct = _dbContext.Products.Find(productId);
                var currentInDb = _dbContext.Products.Find(product.Id);

                if (currentInDb != null)
                {
                    currentInDb = product;
                    _dbContext.Products.AddOrUpdate(currentInDb);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int productId)
        {
            try
            {
                var product = _dbContext.Products.Find(productId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> SearchProducts(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            try
            {
                return _dbContext.Products.Where(i => i.Id == id).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Product> SearchProducts(Func<Product, bool> lamda)
        {
            try
            {
                var result = _dbContext.Products.Where(lamda).ToList();
                return result;
            }
            catch (Exception e)
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