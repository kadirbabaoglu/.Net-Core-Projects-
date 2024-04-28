using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index(string q , string category)
        {
            var product = Repository.Products;

            if (!String.IsNullOrEmpty(q)) 
            {
                ViewBag.q = q;
                product = product.Where(i => i.Name!.ToLower().Contains(q)).ToList();
            }

            if (!String.IsNullOrEmpty(category) && category != "0")
            {
               product = product.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }


            ViewBag.category = new SelectList(Repository.Categories, "CategoryId", "CategoryName", category);

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllCategories = new SelectList(Repository.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products model , IFormFile imageFile)
        {

            var allowedImageType = new[] {".jpg" , ".jpeg" , ".png"};
            var extention = Path.GetExtension(imageFile.FileName).ToLower();
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extention}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);      
            
            if(imageFile != null)
            {
                if(!allowedImageType.Contains(extention))
                {
                    ModelState.AddModelError("", "Lütfen geçerli bir e posta adresi giriniz..!");
                }  
            }


            if (ModelState.IsValid) 
           {
                using(var stream = new FileStream(path , FileMode.Create))
                {
                    await imageFile!.CopyToAsync(stream);

                }
                model.Image = randomFileName;
                model.ProductId = Repository.Products.Count() + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
           }

            ViewBag.AllCategories = new SelectList(Repository.Categories, "CategoryId", "CategoryName");
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();  
            }

            var data = Repository.Products.FirstOrDefault(i => i.ProductId == id);

            if(data == null)
            {
                return NotFound();
            }

            ViewBag.AllCategories = new SelectList(Repository.Categories, "CategoryId", "CategoryName");

            return View(data);
        }

    }
}
