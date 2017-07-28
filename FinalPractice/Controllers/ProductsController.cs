using AutoMapper;
using DTO;
using FinalPractice.ViewModels;
using ServiceLayer.IService;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinalPractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        public ProductsController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            _subCategoryService = new SubCategoryService();
        }


        // Get: products
        public ActionResult Index()
        {
            try
            {
                var list = _productService.ListProduct();
                var product = Mapper.Map<List<ProductViewModel>>(list) ?? new List<ProductViewModel>();


                return View(product);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //GET: Products/Create
        public ActionResult Create()
        {
            //    var customers = _dbContext.Customers
            //        .Include(m => m.MembershipType)
            //        .Select(Mapper.Map<Customer, CustomerViewModel>)
            //        .ToList();
            var categories = _categoryService.ListCategory();
            var subCategories = _subCategoryService.ListSubCategory();

            var newProduct = new ProductFormViewModel()
            {
                Categories = Mapper.Map<IEnumerable<CategoryViewModel>>(categories),
                SubCategories = Mapper.Map<IEnumerable<SubCategoryViewModel>>(subCategories),
            };
            return View(newProduct);
        }

        [HttpPost]
        public ActionResult Create(ProductFormViewModel newProduct)
        {
            if (!ModelState.IsValid)
                return View(newProduct);
            try
            {
                var product = Mapper.Map<ProductDto>(newProduct.Product);
                //Add to Database
                var productDto = Mapper.Map<ProductDto>(product);
                _productService.AddProduct(productDto);

                TempData["Notification"] = "Successfully!";

                //Return new list in Index
                var list = _productService.ListProduct();
                var viewModel = Mapper.Map<List<ProductViewModel>>(list) ?? new List<ProductViewModel>();

                return View("Index", viewModel);
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }

        //Get: Products/Edit 
        public ActionResult Edit(int id)
        {
            try
            {
                var currentProduct = _productService.SearchProduct(id).FirstOrDefault();

                if (currentProduct == null)
                {
                    TempData["Notification"] = "Product not found!";
                    return View("Index");
                }

                var viewModel = Mapper.Map<ProductEditViewModel>(currentProduct);
                return View(viewModel);
            }
            catch (Exception e)
            {
                TempData["Notification"] = "Successfully!";
                return View("Index");
            }
        }

        //POST: Products/Edit 
        [HttpPost]
        public ActionResult Edit(ProductEditViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);
            try
            {
                var productDto = Mapper.Map<ProductDto>(product);
                var success = _productService.UpdateProduct(productDto);

                if (success)
                {
                    TempData["Notification"] = "Successfully";
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception e)
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["Notification"] = "Something Wrong";
                return JavaScript("<script>alert(\"Something Wrong\")</script>");
            }

            try
            {
                _productService.DeleteProduct(id);
                TempData["Notification"] = "Successfully!!!";
                return JavaScript("<script>alert(\"Delete Successfully!!!\")</script>");
            }
            catch (Exception e)
            {
                TempData["Notification"] = "Something Wrong";
                return JavaScript("<script>alert(\"Something Wrong\")</script>");
            }

        }
    }
}