using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
