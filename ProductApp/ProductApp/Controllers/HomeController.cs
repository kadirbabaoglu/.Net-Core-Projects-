using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Models;
using System.Diagnostics;

namespace ProductApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        public IActionResult Index(string q , string category)
        {
            var product = Repository.Products;

            if (!String.IsNullOrEmpty(q)) 
            {
                ViewBag.q = q;
                product = product.Where(i => i.Name.ToLower().Contains(q)).ToList();
            }

            if (!String.IsNullOrEmpty(category) && category != "0")
            {
               product = product.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }


            ViewBag.category = new SelectList(Repository.Categories, "CategoryId", "CategoryName", category);

            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
