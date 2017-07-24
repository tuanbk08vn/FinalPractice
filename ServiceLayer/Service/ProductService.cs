using DomainLayer.IUnitOfWork;
using ServiceLayer.IService;

namespace ServiceLayer.Service
{
    class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct()
        {

        }

        public void UpdateProduct()
        {

        }

        public void DeleteProduct()
        {

        }

        public void ListProduct()
        {

        }

        public void SearchProduct()
        {

        }

        public void DetailsProduct()
        {

        }
    }
}
