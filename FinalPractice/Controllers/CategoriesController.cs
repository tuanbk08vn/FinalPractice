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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }

        // GET: Categories
        public ActionResult Index()
        {
            try
            {
                var list = _categoryService.ListCategory();
                var viewModel = Mapper.Map<List<CategoryViewModel>>(list) ?? new List<CategoryViewModel>();

                return View(viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        //GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Categories/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
                return View(category);
            try
            {
                //Add to Database
                var categoryDto = Mapper.Map<CategoryDto>(category);
                _categoryService.AddCategory(categoryDto);

                TempData["Notification"] = "Successfully!";

                //Return new list in Index
                var list = _categoryService.ListCategory();
                var viewModel = Mapper.Map<List<CategoryViewModel>>(list) ?? new List<CategoryViewModel>();

                return View("Index", viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Create");
            }
        }
    }
}