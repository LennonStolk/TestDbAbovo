namespace TestDbAbovo.Models
{
    public class Medewerker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Geslacht { get; set; }
        public int Leeftijd { get; set; }
        public decimal Salaris { get; set; }
        public string Functie { get; set; }
        public Afdeling? Afdeling { get; set; }
        public ContractType ContractType { get; set; }
    }

    public enum ContractType {
        Fulltime = 0,
        Parttime = 1,
        Stage = 2
    }
}
