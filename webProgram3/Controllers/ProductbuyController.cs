using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webProgram3.Data;
using webProgram3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace webProgram3.Controllers
{
    public class ProductbuyController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductbuyController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var prod1 = new ProductListcs()
            {
                Category = applicationDbContext.Categories,
                Products = applicationDbContext.Products.Include(c => c.Category)

            };
            return View(prod1); /*products.ToList()*/
        }
        [Authorize]
        public IActionResult Index(int currentcat)
        {
            if (currentcat!=10)
            {
                var prod1 = new ProductListcs()
                {
                    Products = applicationDbContext.Products.Where(p => p.Category.Id == currentcat),
                    Category = applicationDbContext.Categories

                };
                return View(prod1); /*products.ToList()*/

            }
            else
            {
                var prod1 = new ProductListcs()
                {
                    Products = applicationDbContext.Products.Include(c => c.Category),
                                    Category = applicationDbContext.Categories

                };
                return View(prod1); /*products.ToList()*/

            }


        }

    }
}
