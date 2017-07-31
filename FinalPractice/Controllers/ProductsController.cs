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
                product.Reverse();

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

                viewModel.Reverse();
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
        public JsonResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["Notification"] = "Something Wrong";
                //return JavaScript("<script>alert(\"Something Wrong\")</script>");
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            }

            try
            {
                _productService.DeleteProduct(id);
                TempData["Notification"] = "Successfully!!!";
                //return JavaScript("<script>alert(\"Delete Successfully!!!\")</script>");
                return Json(new { success = true, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                TempData["Notification"] = "Something Wrong";
                return Json(new { success = false, JsonRequestBehavior.AllowGet });
            }
        }

        //GET: Products/Detail/id
        public ActionResult Detail(int id)
        {
            if (!ModelState.IsValid)
                return View("Index");
            try
            {
                var product = _productService.DetailsProduct(id);
                var result = Mapper.Map<ProductViewModel>(product);
                return View(result);
            }
            catch (Exception e)
            {
                TempData["Notification"] = "Product Not Found";
                return View("Index");
            }
        }

        //POST: Products/Search/{input}


        [HttpPost]
        public ActionResult Search(string searchTypeInput, string searchInput)
        {
            if (!ModelState.IsValid)
                return View("Index");
            try
            {
                var result = _productService.SearchProduct(searchTypeInput, searchInput);

                if (result.Count == 0)
                {
                    TempData["Notification"] = "Results not found!!!";
                }
                else
                {
                    TempData["Notification"] = "Results found!!!";
                }
                var viewModel = Mapper.Map<List<ProductViewModel>>(result);
                return View("Index", viewModel);
            }
            catch (Exception e)
            {
                TempData["Notification"] = "No result found!!!";
                return View("Index");
            }
        }


    }
}