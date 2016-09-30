using HomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeServices.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>(); // create list of type product (which was defined in model Product.cs)

            products.Add(new Models.Product()
            {
                ProductId = 1,
                Name = "Chlen",
                Description = "Very big",
                Size = 21m,
                Category = "Mine"
            });

            products.Add(new Models.Product()
            {
                ProductId = 2,
                Name = "Herenok",
                Description = "Very small",
                Size = 1m,
                Category = "Cheegr"
            });


            return View(products); // send the model List<product> to the view 
        }
    }
}