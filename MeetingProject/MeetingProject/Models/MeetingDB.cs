namespace MeetingProject.Models
{
    public class MeetingDB
    {
        public int Id { get; set; }
        public string? Toplanti_yeri { get; set; }
        public DateTime Date { get; set; }
        public int KatilimciSayisi { get; set; }
    }
}
