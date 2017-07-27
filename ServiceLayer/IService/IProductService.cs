using DomainLayer.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.IService
{
    public interface IProductService
    {
        ProductDto AddProduct(Product product);

        bool UpdateProduct(int id);

        bool DeleteProduct(int id);
        List<ProductDto> ListProduct();


        List<Product> SearchProduct(Expression<Func<Product, bool>> filter);


        Product DetailsProduct(int id);


    }
}