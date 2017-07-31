using DomainLayer.IRepository;
using DomainLayer.Models;
using Infracstructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infracstructure.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly MyContext _dbContext;

        public WishListRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddToWishList(int productId, string userId)
        {
            try
            {
                var current = new WishList()
                {
                    UserId = userId,
                    ProductId = productId,
                };
                _dbContext.WishLists.Add(current);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public IEnumerable<WishList> Get(string userId)
        {
            return _dbContext.WishLists.Where(x => x.UserId == userId);
        }

        public IEnumerable<WishList> Get()
        {
            throw new NotImplementedException();
        }

        public bool Insert(WishList product)
        {
            throw new NotImplementedException();
        }

        public bool Update(WishList product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            try
            {
                var wishlist = _dbContext.WishLists.Find(id);
                if (wishlist != null)
                {
                    _dbContext.WishLists.Remove(wishlist);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public WishList SelectOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
