﻿using DomainLayer.IUnitOfWork;
using DomainLayer.Models;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infracstructure.UnitOfWork;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int AddProduct(Product product)
        {

            _unitOfWork.Product.Insert(product);
            _unitOfWork.Complete();
            return product.Id.GetValueOrDefault();
        }


        public void UpdateProduct(int id)
        {
            _unitOfWork.Product.Update(id);
            _unitOfWork.Complete();
        }

        public void DeleteProduct(int id)
        {
            _unitOfWork.Product.Delete(id);
            _unitOfWork.Complete();
        }

        public List<Product> ListProduct()
        {
            var list = _unitOfWork.Product.Get();
            return list;

        }

        public List<Product> SearchProduct(Expression<Func<Product, bool>> filter)
        {
            return _unitOfWork.Product.SearchProducts(filter);
        }

        public Product DetailsProduct(int id)
        {
            return _unitOfWork.Product.SelectOne(id);
        }

    }
}
