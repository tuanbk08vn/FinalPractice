using DomainLayer.Models;
using DTO;
using System.Collections.Generic;

namespace ServiceLayer.IService
{
    public interface IWishListService
    {
        void AddToWishList(int productId, string userId);

        bool UpdateWishList(WishListDto wishListDto);

        bool DeleteWishList(int id);
        List<WishListDto> ListWishList(string userId);


        WishList DetailsWishList(int id);
    }
}
