using DomainLayer.IRepository;

namespace DomainLayer.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }
        IWishListRepository WishList { get; }
        void Complete();
        void Dispose(bool disposing);
        void Dispose();



    }
}
