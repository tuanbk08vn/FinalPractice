using DomainLayer.Models;
using DTO;
using System.Collections.Generic;

namespace ServiceLayer.IService
{
    public interface ISubCategoryService
    {
        SubCategoryDto AddSubCategory(SubCategoryDto subCategoryDto);

        bool UpdateSubCategory(SubCategoryDto subCategoryDto);

        bool DeleteSubCategory(int id);
        List<SubCategoryDto> ListSubCategory();


        SubCategory DetailsSubCategory(int id);
    }
}
