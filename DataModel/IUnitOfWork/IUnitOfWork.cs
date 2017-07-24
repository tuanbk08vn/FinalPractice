using DomainLayer.IRepository;

namespace DomainLayer.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }

        void Complete();



    }
}
