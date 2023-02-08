using System.ComponentModel.DataAnnotations;

namespace webProgram3.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
