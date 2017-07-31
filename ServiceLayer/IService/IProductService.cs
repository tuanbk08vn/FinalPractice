using DTO;
using System.Collections.Generic;

namespace ServiceLayer.IService
{
    public interface IProductService
    {
        ProductDto AddProduct(ProductDto productDto);

        bool UpdateProduct(ProductDto productDto);

        bool DeleteProduct(int id);
        List<ProductDto> ListProduct();


        List<ProductDto> SearchProduct(int id);

        List<ProductDto> SearchProduct(string searchType, string input);

        ProductDto DetailsProduct(int id);




    }
}