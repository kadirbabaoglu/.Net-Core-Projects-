using System.ComponentModel.DataAnnotations;

namespace KursProjesi.Data
{
    public class KursKayit
    {
        [Key]
        public int KayitId { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
