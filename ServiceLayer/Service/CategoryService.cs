using AutoMapper;
using DomainLayer.IUnitOfWork;
using DomainLayer.Models;
using DTO;
using Infracstructure.UnitOfWork;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public CategoryDto AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = Mapper.Map<Category>(categoryDto);
                _unitOfWork.Category.Insert(category);
                _unitOfWork.Complete();

                return categoryDto;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                var categoryNeedUpdate = Mapper.Map<Category>(categoryDto);

                _unitOfWork.Category.Update(categoryNeedUpdate);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                _unitOfWork.Category.Delete(id);
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

        public List<CategoryDto> ListCategory()
        {
            try
            {
                var listInDb = _unitOfWork.Category.Get();

                var list = Mapper.Map<List<CategoryDto>>(listInDb);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public Category DetailsCategory(int id)
        {
            try
            {
                return _unitOfWork.Category.SelectOne(id);
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