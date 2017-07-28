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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public SubCategoryDto AddSubCategory(SubCategoryDto subCategoryDto)
        {
            try
            {
                var subCategory = Mapper.Map<SubCategory>(subCategoryDto);
                _unitOfWork.SubCategory.Insert(subCategory);
                _unitOfWork.Complete();

                return subCategoryDto;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool UpdateSubCategory(SubCategoryDto subCategoryDto)
        {
            try
            {
                var subCategoryNeedUpdate = Mapper.Map<SubCategory>(subCategoryDto);

                _unitOfWork.SubCategory.Update(subCategoryNeedUpdate);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSubCategory(int id)
        {
            try
            {
                _unitOfWork.SubCategory.Delete(id);
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

        public List<SubCategoryDto> ListSubCategory()
        {
            try
            {
                var listInDb = _unitOfWork.SubCategory.Get().ToList();

                var list = Mapper.Map<List<SubCategoryDto>>(listInDb);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public SubCategory DetailsSubCategory(int id)
        {
            try
            {
                return _unitOfWork.SubCategory.SelectOne(id);
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
