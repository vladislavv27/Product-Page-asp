using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using webProgram3.Data;
using webProgram3.Models;

namespace webProgram3.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CategoryController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {

            var categories = applicationDbContext.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {        

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Create(Category category)

        {
           
            var category1 = new Category()
            {
                Name = category.Name,

            };


            applicationDbContext.Categories.Add(category1);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(long id)
        {
            Category category = applicationDbContext.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(int id, Category category)
        {


            applicationDbContext.Update(category);
            applicationDbContext.SaveChanges();

            TempData["Success"] = "The product has been edited!";


            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(long id)
        {
            Category category =  applicationDbContext.Categories.Find(id);



            applicationDbContext.Categories.Remove(category);
             applicationDbContext.SaveChanges();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }
    }
}
