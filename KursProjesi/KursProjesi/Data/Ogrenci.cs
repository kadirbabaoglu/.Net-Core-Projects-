using System.ComponentModel.DataAnnotations;

namespace KursProjesi.Data
{
    public class Ogrenci
    {
        [Key]
        [Display(Name ="No")]
        public int OgrenciId { get; set; }

        [Display(Name = "Öğrenci Adı")]
        public string? OgrenciAdi { get; set; }

        [Display(Name = "Öğrenci Soyadı")]
        public string? OgrenciSoyadi { get; set; }

        [Display(Name = "Eposta")]
        public string? Eposta { get; set; }

        [Display(Name = "Telefon")]
        public string? Telefon { get; set; }

        public string AdSoyad { get { return this.OgrenciAdi + " " + this.OgrenciSoyadi; } }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}
