using System.ComponentModel.DataAnnotations;

namespace webProgram3.Models
{
    public class CartItem
    {
        [Key]
        public string Id { get; set; }


        public int Quantity { get; set; }
        public decimal price { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public string ShopCartId { get; set; }
    }
}
