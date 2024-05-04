using System.ComponentModel.DataAnnotations;

namespace KursProjesi.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}" , ApplyFormatInEditMode = true)]
        public DateTime BaslamaTarihi { get; set; }

        public ICollection<Kurs> Kurs { get; set; } = new List<Kurs>();

        public string AdSoyad { get{ return this.Adi + " " + this.Soyadi; } }
    }
}
