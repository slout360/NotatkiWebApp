namespace NotatkiWebApp.Models
{
    public enum Kategoria
    {
        Brak,
        Praca,
        Szkoła,
        Prywatne,
        Inne
    }

    public class Notatka
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Tresc { get; set; }
        public Kategoria Kategoria { get; set; }
        public DateTime DataUtworzenia { get; set; } = DateTime.Now;
        public DateTime? DataEdycji { get; set; }
        public bool Ulubiona { get; set; } = false;
    }
}
