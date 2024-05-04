using System.ComponentModel.DataAnnotations;

namespace KursProjesi.Data
{
    public class Kurs
    {
        [Key]
        [Display(Name = "No")]
        public int KursId { get; set; }

        [Display(Name ="Kurs Başlığı")]
        public string? Baslik { get; set; }

        public Ogretmen Ogretmen { get; set; } = null!;

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}
