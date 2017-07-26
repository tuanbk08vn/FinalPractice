using DomainLayer.IRepository;
using DomainLayer.IUnitOfWork;
using Infracstructure.DAL;
using Infracstructure.Repository;

namespace Infracstructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _dbContext;

        public IUserRepository User { get; set; }

        public IProductRepository Product { get; set; }

        public UnitOfWork()
        {
            _dbContext = new MyContext();
            User = new UserRepository(_dbContext);
            Product = new ProductRepository(_dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }



    }
}
