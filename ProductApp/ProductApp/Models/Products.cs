using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Products
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunlu")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat zorunlu alan")]
        public decimal Price { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "Açıklama zorunlu alan")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Kategori zorunlu alan")]
        public int CategoryId { get; set; }

        public bool IsActive { get; set;}
    }
}
