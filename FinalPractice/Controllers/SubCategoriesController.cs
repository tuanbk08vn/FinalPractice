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
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoriesController()
        {
            _subCategoryService = new SubCategoryService();
        }

        // GET: Categories
        public ActionResult Index()
        {
            try
            {
                var list = _subCategoryService.ListSubCategory();
                var viewModel = Mapper.Map<List<SubCategoryViewModel>>(list) ?? new List<SubCategoryViewModel>();

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
        public ActionResult Create(SubCategoryViewModel subCategory)
        {
            if (!ModelState.IsValid)
                return View(subCategory);
            try
            {
                //Add to Database
                var subCategoryDto = Mapper.Map<SubCategoryDto>(subCategory);
                _subCategoryService.AddSubCategory(subCategoryDto);

                TempData["Notification"] = "Successfully!";

                //Return new list in Index
                var list = _subCategoryService.ListSubCategory();
                var viewModel = Mapper.Map<List<SubCategoryViewModel>>(list) ?? new List<SubCategoryViewModel>();

                return View("Index", viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Create");
            }
        }
    }
}