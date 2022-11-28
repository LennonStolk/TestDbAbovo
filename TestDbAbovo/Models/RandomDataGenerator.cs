namespace TestDbAbovo.Models
{
    public class RandomDataGenerator
    {
        // Handige methods voor het halen van een random item uit een List
        Random random = new Random();

        string GetRandomItemFromList(List<string> list)
        {
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        int GetRandomItemFromList(List<int> list)
        {
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        decimal GetRandomItemFromList(List<decimal> list)
        {
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        bool GetRandomItemFromList(List<bool> list)
        {
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        DateTime GetRandomItemFromList(List<DateTime> list)
        {
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        ContractType GetRandomItemFromList(List<ContractType> list)
        {
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }




        // De functies om random data te genereren
        List<string> Voornamen = new List<string>()
        {
            "Jessica",
            "Anne",
            "Anna",
            "Job",
            "John",
            "Michael",
            "Mike",
            "Maria",
            "Teun"
        };

        List<string> Achternamen = new List<string>()
        {
            "de Boer",
            "de Vries",
            "Bot",
            "Smit",
            "Koning"
        };

        List<string> Geslachten = new List<string>()
        {
            "Man",
            "Vrouw",
            "Anders"
        };

        List<int> Leeftijden = new List<int>()
        {
            18,
            20,
            25,
            30,
            35,
            40,
            50,
            60,
        };

        List<decimal> Salarissen = new List<decimal>()
        {
            20400M,
            30600M,
            44444M,
            60000M,
            80000M,
            110550M,
        };

        List<string> Functies = new List<string>()
        {
            "Ontwikkelaar",
            "Marketeer",
            "Receptionist",
            "Manager",
            "CEO",
            "CTO",
            "Customer support"
        };

        List<ContractType> ContractTypes = new List<ContractType>()
        {
            ContractType.Fulltime,
            ContractType.Parttime,
            ContractType.Stage
        };

        public Medewerker GetRandomMedewerker()
        {
            var medewerker = new Medewerker();
            medewerker.ContractType = GetRandomItemFromList(ContractTypes);
            medewerker.Functie = GetRandomItemFromList(Functies);
            medewerker.Geslacht = GetRandomItemFromList(Geslachten);
            medewerker.Leeftijd = GetRandomItemFromList(Leeftijden);
            medewerker.Naam = GetRandomItemFromList(Voornamen) + " " + GetRandomItemFromList(Achternamen);
            medewerker.Salaris = GetRandomItemFromList(Salarissen);
            return medewerker;
        }

        public List<Medewerker> GetRandomMedewerkers(int amount)
        {
            List<Medewerker> medewerkers = new List<Medewerker>();
            for (int i = 0; i < amount; i++)
            {
                medewerkers.Add(GetRandomMedewerker());
            }
            return medewerkers;
        }

        List<string> AfdelingNamen = new List<string>()
        {
            "ICT",
            "Management",
            "Sales",
            "Marketing",
            "Financien"
        };

        List<string> Adressen = new List<string>()
        {
            "Beukenlaan 15 Hoorn",
            "Poeplaan 12 Enkhuizen",
            "Straatstraat 19 Zwaag",
            "Waterdreef 25 Bovenkarspel"
        };

        public Afdeling GetRandomAfdeling()
        {
            var afdeling = new Afdeling();
            afdeling.Naam = GetRandomItemFromList(AfdelingNamen);
            afdeling.Adres = GetRandomItemFromList(Adressen);
            return afdeling;
        }

        public List<Afdeling> GetRandomAfdelingen(int amount)
        {
            List<Afdeling> afdelingen = new List<Afdeling>();
            for (int i = 0; i < amount; i++)
            {
                afdelingen.Add(GetRandomAfdeling());
            }
            return afdelingen;
        }

        List<string> Emails = new List<string>()
        {
            "blala@gmail.nl",
            "okokokwww@gmail.com",
            "leukepapegaai@outlook.com",
            "stommepapegaai@live.nl"
        };

        public Klant GetRandomKlant()
        {
            var klant = new Klant();
            klant.Naam = GetRandomItemFromList(Voornamen) + " " + GetRandomItemFromList(Achternamen);
            klant.Adres = GetRandomItemFromList(Adressen);
            klant.Email = GetRandomItemFromList(Emails);
            return klant;
        }

        public List<Klant> GetRandomKlanten(int amount)
        {
            List<Klant> klanten = new List<Klant>();
            for (int i = 0; i < amount; i++)
            {
                klanten.Add(GetRandomKlant());
            }
            return klanten;
        }

        List<string> ProjectNamen = new List<string>()
        {
            "Restaurant d' Einder",
            "Het AD",
            "LIDL reclameproject",
            "Bakkerij de Zwart poster",
            "Banner voor nu.nl"
        };

        List<DateTime> BeginDatums = new List<DateTime>()
        {
            new DateTime(2022, 3, 5),
            new DateTime(2022, 4, 16),
            new DateTime(2022, 7, 28),
            new DateTime(2022, 9, 4),
            new DateTime(2022, 11, 11)
        };

        List<DateTime> EindDatums = new List<DateTime>()
        {
            new DateTime(2023, 4, 15),
            new DateTime(2023, 4, 18),
            new DateTime(2023, 6, 25),
            new DateTime(2023, 8, 13),
            new DateTime(2023, 12, 5)
        };

        List<bool> Statussen = new List<bool>()
        {
            true,
            false
        };

        List<decimal> Budgetten = new List<decimal>()
        {
            120000M,
            50500M,
            200M,
            1200M,
            2400M
        };

        public Project GetRandomProject()
        {
            var project = new Project();
            project.BeginDatum = GetRandomItemFromList(BeginDatums);
            project.Budget = GetRandomItemFromList(Budgetten);
            project.EindDatum = GetRandomItemFromList(EindDatums);
            project.IsKlaar = GetRandomItemFromList(Statussen);
            project.Naam = GetRandomItemFromList(ProjectNamen);
            return project;
        }

       public List<Project> GetRandomProjecten(int amount)
        {
            List<Project> projecten = new List<Project>();
            for (int i = 0; i < amount; i++)
            {
                projecten.Add(GetRandomProject());
            }
            return projecten;
        }
    }
}
