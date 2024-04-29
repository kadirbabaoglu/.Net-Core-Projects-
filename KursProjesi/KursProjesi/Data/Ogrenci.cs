using System.ComponentModel.DataAnnotations;

namespace KursProjesi.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyadi { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
    }
}
