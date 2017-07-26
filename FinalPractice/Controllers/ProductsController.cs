using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.IService;
using ServiceLayer.Service;

namespace FinalPractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        // GET: Products
        public ActionResult Index()
        {
            var model = _productService.ListProduct();
            return View(model);
        }
    }
}