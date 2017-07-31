using AutoMapper;
using DomainLayer.IUnitOfWork;
using DomainLayer.Models;
using DTO;
using Infracstructure.UnitOfWork;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;

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
        }

        public List<ProductDto> ListProduct()
        {
            try
            {
                var listInDb = _unitOfWork.Product.Get();

                var list = Mapper.Map<List<ProductDto>>(listInDb);
                foreach (var item in list)
                {
                    var category = _unitOfWork.Category.SelectOne(item.CategoryId);
                    var subCategory = _unitOfWork.SubCategory.SelectOne(item.SubCategoryId);
                    item.Category = Mapper.Map<CategoryDto>(category);
                    item.SubCategory = Mapper.Map<SubCategoryDto>(subCategory);
                }
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
                foreach (var item in result)
                {
                    var category = _unitOfWork.Category.SelectOne(item.CategoryId);
                    var subCategory = _unitOfWork.SubCategory.SelectOne(item.SubCategoryId);
                    item.Category = Mapper.Map<CategoryDto>(category);
                    item.SubCategory = Mapper.Map<SubCategoryDto>(subCategory);
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ProductDto> SearchProduct(string searchType, string input)
        {
            try
            {
                var result = new List<ProductDto>();
                var lowerInput = input.ToLower();
                switch (searchType)
                {
                    case "Name":
                        var resultWithName = _unitOfWork.Product
                            .SearchProducts(x => x.Name.ToLower().Contains(lowerInput)).ToList();
                        result = Mapper.Map<List<ProductDto>>(resultWithName);
                        break;
                    case "CodeSKU":
                        var resultWithCodeSKU = _unitOfWork.Product
                            .SearchProducts(x => x.CodeSKU.ToLower().Contains(lowerInput)).ToList();
                        result = Mapper.Map<List<ProductDto>>(resultWithCodeSKU);
                        break;
                    case "Category":
                        var categoryId = _unitOfWork.Category.GetByName(lowerInput);
                        var resultWithCategory = _unitOfWork.Product.SearchProducts(x => x.CategoryId == categoryId)
                            .ToList();
                        result = Mapper.Map<List<ProductDto>>(resultWithCategory);
                        break;
                    case "SubCategory":
                        var subCategoryId = _unitOfWork.SubCategory.GetByName(lowerInput);
                        var resultWithSubCategory = _unitOfWork.Product
                            .SearchProducts(x => x.SubCategoryId == subCategoryId).ToList();
                        result = Mapper.Map<List<ProductDto>>(resultWithSubCategory);
                        break;
                }

                foreach (var item in result)
                {
                    var category = _unitOfWork.Category.SelectOne(item.CategoryId);
                    var subCategory = _unitOfWork.SubCategory.SelectOne(item.SubCategoryId);
                    item.Category = Mapper.Map<CategoryDto>(category);
                    item.SubCategory = Mapper.Map<SubCategoryDto>(subCategory);
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ProductDto DetailsProduct(int id)
        {
            try
            {
                var product = _unitOfWork.Product.SelectOne(id);
                var productDto = Mapper.Map<ProductDto>(product);
                return productDto;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}