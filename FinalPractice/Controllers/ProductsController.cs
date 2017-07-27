using AutoMapper;
using DTO;
using FinalPractice.ViewModels;
using ServiceLayer.IService;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinalPractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }


        // Get: Products
        public ActionResult Index()
        {

            try
            {
                var productListDto = _productService.ListProduct();
                List<ProductViewModel> product = new List<ProductViewModel>();

                product = Mapper.Map<List<ProductDto>, List<ProductViewModel>>(productListDto);

                return View(product);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Create(ProductFormViewModel newProduct)
        {
            if (!ModelState.IsValid)
                return View(newProduct);
            try
            {
                var newProductDto = Mapper.Map<ProductDto>(newProduct);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(newProduct);
            }
        }
        // GET: Products
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        var productListDto = _productService.ListProduct();


        //        var viewModel = new ProductFormViewModel();

        //        viewModel.ProductInsertViewModel = new ProductInsertViewModel();
        //        var test = Mapper.Map<ProductViewModel>(productListDto);
        //        viewModel.ProductListViewModel = Mapper.Map<List<ProductViewModel>>(productListDto).ToList();





        //        //var viewModel = Mapper.Map<List<ProductListDto>, List<ProductListViewModel>>(productDto);
        //        return View(viewModel);
        //    }
        //    catch (Exception e)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //}
    }
}