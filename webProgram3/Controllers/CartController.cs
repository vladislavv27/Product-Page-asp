using Microsoft.AspNetCore.Mvc;
using webProgram3.Models;

using webProgram3.Helpers;
using Microsoft.AspNetCore.Http;
using webProgram3.Data;
using Microsoft.EntityFrameworkCore;

namespace webProgram3.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {

        private readonly ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CartController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [Route("index")]

        public IActionResult Index()
        {
            var prod1 = new ProductListcs()
            {
                Adress = applicationDbContext.Adress,
                DiliveryType=applicationDbContext.DiliveryType
            };
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (cart==null)
            {
                ViewBag.totalcart = 0;
                ViewBag.total = 0;
                ViewBag.cart = null;
            }
            if (cart!=null)
            {
                ViewBag.totalcart = +cart.Sum(i => i.Product.Price * i.Quantity);
                ViewBag.total = cart.Sum(i => i.Product.Price * i.Quantity);
            }
           
           
            return View(prod1);
        }
        [Route("buy/{id}")]

        public IActionResult buy(long id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart")==null)
            {
                var cart=new List<Item>();
                cart.Add(new Item() { Product = applicationDbContext.Products.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, (int)id);
                if (index==-1)
                {
                    cart.Add(new Item() { Product = applicationDbContext.Products.Find(id), Quantity = 1 });

                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            return RedirectToAction("Index");
        }
        private int Exists(List<Item> cart,int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id==id)
                {
                    return i;
                }
            }
            return -1;
        }
        [Route("remove/{id}")]

        public IActionResult Remove(long id)
        {
          
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, (int)id);
            cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            
            return RedirectToAction("Index");
        }
        public IActionResult Checkout(CartToDb cartToDb)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            var category1 = new CartToDb()
            {
                UserName = User.Identity.Name,
                Adress = applicationDbContext.Adress.Where(p => p.UserName == User.Identity.Name),
                DiliveryTypeName = cartToDb.DiliveryTypeName,


            };


            applicationDbContext.CartToDb.Add(category1);
            applicationDbContext.SaveChanges();
           

            return RedirectToAction("Index");
        }


    }
}
