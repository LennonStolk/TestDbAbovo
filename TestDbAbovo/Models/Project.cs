namespace TestDbAbovo.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Klant? Klant { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public bool IsKlaar { get; set; }
        public decimal Budget { get; set; }
        public List<Medewerker> Medewerkers { get; set; }
        public List<Afdeling> Afdelingen { get; set; }
    }
}
