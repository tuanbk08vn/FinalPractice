using DomainLayer.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.IService
{
    public interface IProductService
    {
        ProductDto AddProduct(ProductDto productDto);

        bool UpdateProduct(ProductDto productDto);

        bool DeleteProduct(int id);
        List<ProductDto> ListProduct();


        List<ProductDto> SearchProduct(int id);


        Product DetailsProduct(int id);


    }
}