using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webProgram3.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You must choose a category")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; } = "noimage.png";

        [NotMapped]
       
        public IFormFile ImageUpload { get; set; }
    }


}
