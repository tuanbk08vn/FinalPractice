using DomainLayer.IRepository;
using Infracstructure.DAL;

namespace Infracstructure.Repository
{
    class ProductRepository : IProductRepository
    {
        private readonly MyContext _dbContext;

        public ProductRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetProduct()
        {
            return 1;
        }

        public void SetProduct()
        {

        }
    }
}
