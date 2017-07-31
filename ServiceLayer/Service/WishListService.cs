using AutoMapper;
using DomainLayer.IUnitOfWork;
using DomainLayer.Models;
using DTO;
using Infracstructure.UnitOfWork;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Service
{
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishListService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void AddToWishList(int productId, string userId)
        {
            try
            {
                if (productId != 0 && userId != null)
                {
                    _unitOfWork.WishList.AddToWishList(productId, userId);
                    _unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
            }
        }


        public bool UpdateWishList(WishListDto wishListDto)
        {
            try
            {
                var wishListNeedUpdate = Mapper.Map<WishList>(wishListDto);

                _unitOfWork.WishList.Update(wishListNeedUpdate);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteWishList(int id)
        {
            try
            {
                _unitOfWork.WishList.Delete(id);
                _unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<WishListDto> ListWishList(string userId)
        {
            try
            {
                var listInDb = _unitOfWork.WishList.Get(userId).ToList();

                var list = Mapper.Map<List<WishListDto>>(listInDb);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public WishList DetailsWishList(int id)
        {
            try
            {
                return _unitOfWork.WishList.SelectOne(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
