using System.Collections.Generic;

namespace FinalPractice.ViewModels
{
    public class ProductFormViewModel
    {
        public ProductViewModel Product { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}