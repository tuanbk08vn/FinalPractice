using DomainLayer.IRepository;
using DomainLayer.IUnitOfWork;
using Infracstructure.DAL;
using Infracstructure.Repository;

namespace Infracstructure.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _dbContext;

        public IUserRepository User { get; set; }

        public IProductRepository Product { get; set; }

        public UnitOfWork(MyContext dbContext)
        {
            _dbContext = dbContext;
            User = new UserRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }



    }
}
