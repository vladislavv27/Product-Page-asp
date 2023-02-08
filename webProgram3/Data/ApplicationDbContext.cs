using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webProgram3.Models;
namespace webProgram3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<DiliveryType> DiliveryType { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<CartToDb> CartToDb { get; set; }

    }
}