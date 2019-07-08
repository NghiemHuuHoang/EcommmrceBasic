using Ecommerce.Entities;
using Ecommerce.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommereBasic.App.Controllers
{
    
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ProductTable(string search)
        {
            var products = productService.Products();
            if (string.IsNullOrEmpty(search) == false)
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();

            }
            return PartialView(products);


        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productService.GetProduct(ID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            productService.DeleteProduct(product.ID);
            return RedirectToAction("ProductTable");
        }
    }
}