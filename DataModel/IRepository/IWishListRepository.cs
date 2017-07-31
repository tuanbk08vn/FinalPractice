using System.Collections.Generic;
using DomainLayer.Models;

namespace DomainLayer.IRepository
{
    public interface IWishListRepository : IRepository<WishList>
    {
        bool AddToWishList(int productId, string userId);
        IEnumerable<WishList> Get(string userId);
    }
}
