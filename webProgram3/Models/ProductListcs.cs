using Microsoft.AspNetCore.Mvc.Rendering;

namespace webProgram3.Models
{
    public class ProductListcs
    {
        public IEnumerable<Adress> Adress { get; set; }
        public IEnumerable<DiliveryType> DiliveryType { get; set; }
        public IEnumerable<Category> Category { get; set; }

        public IEnumerable<Product> Products { get; set; }
 
            public int currentcat { get; set; }

    }
   
}
