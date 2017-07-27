using System.Collections.Generic;

namespace DTO
{
    public class ProductFormDto
    {
        public ProductInsertDto ProductInsertDto { get; set; }

        public List<ProductDto> ProductListDto { get; set; }
    }
}
