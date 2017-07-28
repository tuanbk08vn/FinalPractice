using DomainLayer.Models;
using DTO;
using System.Collections.Generic;

namespace ServiceLayer.IService
{
    public interface ICategoryService
    {
        CategoryDto AddCategory(CategoryDto categoryDto);

        bool UpdateCategory(CategoryDto categoryDto);

        bool DeleteCategory(int id);
        List<CategoryDto> ListCategory();


        Category DetailsCategory(int id);
    }
}
