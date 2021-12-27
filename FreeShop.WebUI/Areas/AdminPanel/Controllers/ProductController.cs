using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.Business.Abstract;
using FreeShop.Entities.Concrete;
using FreeShop.WebUI.Helpers;
using FreeShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreeShop.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly IProductPhotoService _productPhotoService;

        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, IProductPhotoService productPhotoService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _productPhotoService = productPhotoService;
            _categoryService = categoryService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult NewProduct()
        {
            List<SelectListItem> categories = _categoryService.GetAll().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();

            categories.Insert(0, new SelectListItem
                {Text = "Seciniz", Value = "-1"});

            return View(categories);
        }

        [HttpPost]
        public IActionResult NewProduct(NewProductViewModel vm)
        {
            Product p = new Product();

            //vm'deki product'i buradaki Product p'ye tasiyoruz.
            p.CategoryId = vm.CategoryId;
            p.Discount = vm.Discount;
            p.ProductName = vm.ProductName;
            p.Price = vm.Price;
            p.ShortDescription = vm.ShortDescription;

            _productService.Insert(p);

            return Json(new {isOk = true, productId = p.Id});
        }

        [HttpPost]
        public IActionResult ProductPhotoUpload()
        {
            IFormFileCollection files = Request.Form.Files;

            var productId = Convert.ToInt32(Request.Form["prdId"].ToString());

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var randomFileName = RandomNameGenerator.GenerateFileName(Path.GetExtension(file.FileName));
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/adminlte/images/ProductPhotos", randomFileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //ProductPhoto ya insert edelim.
                    ProductPhoto photo = new ProductPhoto();
                    photo.ProductId = productId;
                    photo.PhotoPath = "wwwroot/adminlte/images/ProductPhotos/" + randomFileName;


                    _productPhotoService.Insert(photo);
                }

                return Json(new {isOk = true});
            }

            return Json(new {isOk = false });
        }
    }
}
