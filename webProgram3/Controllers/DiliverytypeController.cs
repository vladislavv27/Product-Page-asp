using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webProgram3.Data;
using webProgram3.Models;

namespace webProgram3.Controllers
{
    public class DiliverytypeController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public DiliverytypeController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {

            var categories = applicationDbContext.DiliveryType.ToList();
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

        public IActionResult Create(DiliveryType diliveryType)

        {

            var DiliveryType1 = new DiliveryType()
            {
                Name = diliveryType.Name,

            };


            applicationDbContext.DiliveryType.Add(DiliveryType1);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(long id)
        {
            DiliveryType diliveryType = applicationDbContext.DiliveryType.Find(id);

            return View(diliveryType);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(int id, DiliveryType diliveryType)
        {


            applicationDbContext.Update(diliveryType);
            applicationDbContext.SaveChanges();

            TempData["Success"] = "The product has been edited!";


            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(long id)
        {
            DiliveryType diliveryType = applicationDbContext.DiliveryType.Find(id);



            applicationDbContext.DiliveryType.Remove(diliveryType);
            applicationDbContext.SaveChanges();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }
    }
}
