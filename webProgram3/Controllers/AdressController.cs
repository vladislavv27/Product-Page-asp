using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webProgram3.Data;
using webProgram3.Models;

namespace webProgram3.Controllers
{
    public class AdressController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdressController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.applicationDbContext = applicationDbContext;
        }


        [HttpGet]

        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {

            var adress = applicationDbContext.Adress.ToList();
            return View(adress);
        }

        [HttpGet]

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]



        public IActionResult Create(Adress adress)

        {
     

            var adress1 = new Adress()
            {
                Country = adress.Country,
                city = adress.city,
                streetname = adress.streetname,
                postcode = adress.postcode,
                UserName= User.Identity.Name,
            };



            applicationDbContext.Adress.Add(adress1);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "ProductBuy");


        }

        [HttpGet]


        public IActionResult Edit(long id)
        {
            Adress adress = applicationDbContext.Adress.Find(id);

            return View(adress);
        }

        [HttpPost]


        public IActionResult Edit(int id, Adress adress)
        {


            applicationDbContext.Update(adress);
            applicationDbContext.SaveChanges();

            TempData["Success"] = "The product has been edited!";


            return RedirectToAction("Index");
        }


        public IActionResult Delete(long id)
        {
            Adress adress = applicationDbContext.Adress.Find(id);



            applicationDbContext.Adress.Remove(adress);
            applicationDbContext.SaveChanges();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }
    }
}
