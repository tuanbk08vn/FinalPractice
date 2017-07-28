﻿using AutoMapper;
using DomainLayer.IUnitOfWork;
using DomainLayer.Models;
using DTO;
using Infracstructure.UnitOfWork;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ProductDto AddProduct(ProductDto productDto)
        {
            try
            {
                var product = Mapper.Map<Product>(productDto);
                _unitOfWork.Product.Insert(product);
                _unitOfWork.Complete();

                return productDto;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool UpdateProduct(ProductDto productDto)
        {
            try
            {
                var productNeedUpdate = Mapper.Map<Product>(productDto);

                _unitOfWork.Product.Update(productNeedUpdate);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                _unitOfWork.Product.Delete(id);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public List<ProductDto> ListProduct()
        {
            try
            {
                var listInDb = _unitOfWork.Product.Get();

                var list = Mapper.Map<List<ProductDto>>(listInDb);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ProductDto> SearchProduct(int id)
        {
            try
            {
                var resultInDb = _unitOfWork.Product.SearchProducts(id);
                var result = Mapper.Map<List<ProductDto>>(resultInDb);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Product DetailsProduct(int id)
        {
            try
            {
                return _unitOfWork.Product.SelectOne(id);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}