using AutoMapper;
using FinalPractice.ViewModels;
using Microsoft.AspNet.Identity;
using ServiceLayer.IService;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinalPractice.Controllers
{
    public class WishListsController : Controller
    {
        private readonly IWishListService _wishListService;
        private readonly IProductService _productService;
        public WishListsController()
        {
            _wishListService = new WishListService();
            _productService = new ProductService();
        }

        //GET: WishList/
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var wishListDtos = _wishListService.ListWishList(User.Identity.GetUserId());
                var viewModel = Mapper.Map<List<WishListViewModel>>(wishListDtos);
                foreach (var item in viewModel)
                {
                    var itemProduct = _productService.SearchProduct(item.ProductId).FirstOrDefault();
                    item.Product = Mapper.Map<ProductViewModel>(itemProduct);
                }
                return View("Index", viewModel);
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }

        //POST: WishLists/AddToWishList
        [HttpPost]
        [Authorize]
        public JsonResult AddToWishList(int productId)
        {
            if (!ModelState.IsValid)
            {
                TempData["Notification"] = "Something Wrong";
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            }
            try
            {
                var userId = User.Identity.GetUserId();
                _wishListService.AddToWishList(productId, userId);
                TempData["Notification"] = "Successfully";

                return Json(new { success = true, JsonRequestBehavior.AllowGet });

            }
            catch (Exception e)
            {
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["WishList"] = "SomeThing Wrong!!!";
                return RedirectToAction("Index");
            }
            try
            {
                var list = _wishListService.DeleteWishList(id);
                TempData["WishList"] = "Delete Successfully !!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["WishList"] = "SomeThing Wrong!!!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Detail(int id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            try
            {
                return Redirect("~/Products/Details/" + id);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}