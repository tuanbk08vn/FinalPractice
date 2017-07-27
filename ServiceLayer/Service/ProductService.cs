using AutoMapper;
using DomainLayer.IUnitOfWork;
using DomainLayer.Models;
using DTO;
using Infracstructure.UnitOfWork;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ProductDto AddProduct(Product product)
        {
            try
            {
                _unitOfWork.Product.Insert(product);
                _unitOfWork.Complete();
                var productDto = Mapper.Map<Product, ProductDto>(product);
                return productDto;
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


        public bool UpdateProduct(int id)
        {
            try
            {
                _unitOfWork.Product.Update(id);
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
                var test = _unitOfWork.Product.Get().ToList();
 
                var list = Mapper.Map<List<ProductDto>>(test);
                return list;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public List<Product> SearchProduct(Expression<Func<Product, bool>> filter)
        {
            try
            {
                return _unitOfWork.Product.SearchProducts(filter);

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
