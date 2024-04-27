using System.ComponentModel.DataAnnotations;

namespace MeetingProject.Models
{
    public class UserRepostory
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Ad alanı zorunlu")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Telefon alanı zorunlu")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Email alanı zorunlu")]
        [EmailAddress(ErrorMessage = "Email Formatı yanlış")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Katılım Durumu alanı zorunlu")]
        public bool? Status { get; set; }
    }
}
