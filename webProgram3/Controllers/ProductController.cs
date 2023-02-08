using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using webProgram3.Data;
using webProgram3.Models;

namespace webProgram3.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(ApplicationDbContext applicationDbContext,IWebHostEnvironment webHostEnvironment)
        {
            this.applicationDbContext = applicationDbContext;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Index() { 
            
            var products = applicationDbContext.Products.Include(c => c.Category);
            return View(products.ToList());
        }




        
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(applicationDbContext.Categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Create(Product product)

        {
            string fileName = null;
            if (product.ImageUpload != null)
            {


                string uploaddir = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/img");
                fileName = product.ImageUpload.FileName;
                string filepath = Path.Combine(uploaddir, fileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    product.ImageUpload.CopyTo(fileStream);
                }
            }



            var product1 = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Image = fileName,


                };


           
            applicationDbContext.Products.Add(product1);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");


           


        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(long id)
        {
            Product product =  applicationDbContext.Products.Find(id);

            ViewBag.Categories = new SelectList(applicationDbContext.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(int id, Product product)
        {
            ViewBag.Categories = new SelectList(applicationDbContext.Categories, "Id", "Name", product.CategoryId);

              

                string fileName = null;
                if (product.ImageUpload != null)
                {


                    string uploaddir = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/img");
                    fileName = product.ImageUpload.FileName;
                    string filepath = Path.Combine(uploaddir, fileName);
                    using (var fileStream = new FileStream(filepath, FileMode.Create))
                    {
                         product.ImageUpload.CopyTo(fileStream);
                    }
                }
                product.Image = fileName;

                

                applicationDbContext.Update(product);
                 applicationDbContext.SaveChanges();

                TempData["Success"] = "The product has been edited!";


            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(long id)
        {
            Product product = await applicationDbContext.Products.FindAsync(id);



            applicationDbContext.Products.Remove(product);
            await applicationDbContext.SaveChangesAsync();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }

    }
}
