using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.IService
{
    public interface IProductService
    {
        int AddProduct(Product product);

        void UpdateProduct(int id);

        void DeleteProduct(int id);
        List<Product> ListProduct();


        List<Product> SearchProduct(Expression<Func<Product, bool>> filter);


        Product DetailsProduct(int id);


    }
}