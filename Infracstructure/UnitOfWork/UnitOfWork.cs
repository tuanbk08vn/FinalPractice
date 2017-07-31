using DomainLayer.IRepository;
using DomainLayer.IUnitOfWork;
using Infracstructure.DAL;
using Infracstructure.Repository;
using System;
using System.Diagnostics;

namespace Infracstructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _dbContext;
        private bool disposed = false;

        public IUserRepository User { get; set; }

        public IProductRepository Product { get; set; }
        public ICategoryRepository Category { get; set; }
        public ISubCategoryRepository SubCategory { get; set; }
        public IWishListRepository WishList { get; set; }

        public UnitOfWork()
        {
            _dbContext = new MyContext();
            User = new UserRepository(_dbContext);
            Product = new ProductRepository(_dbContext);
            Category = new CategoryRepository(_dbContext);
            SubCategory = new SubCategoryRepository(_dbContext);
            WishList = new WishListRepository(_dbContext);

        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
