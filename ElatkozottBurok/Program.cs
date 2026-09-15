namespace ElatkozottBurok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fejleszto> fejlesztok = new List<Fejleszto>();

            fejlesztok.Add(
                new Fejleszto(
                    "Péter",
                    Munkakor.Senior,
                    1000,
                    "Kávé",
                    50,
                    20
                )
            );

            fejlesztok.Add(
                new Fejleszto(
                    "Anna",
                    Munkakor.Junior,
                    1500,
                    "Maci Laci",
                    60,
                    30
                )
            );

            Automata automata = new Automata();

            List<Nassolnivalo> termekek = new List<Nassolnivalo>();

            termekek.Add(new Nassolnivalo("Kávé", 20, 10, 300));
            termekek.Add(new Nassolnivalo("Maci Laci", 10, 10, 200));
            termekek.Add(new Nassolnivalo("Energiaital", 40, 5, 400));

            automata.Feltolt(termekek);

            Iroda i = new Iroda(fejlesztok, automata);

            i.MunkanapSzimulacio(8);

            i.NapiJelentes();

            Console.ReadKey();
        }

    }
    }

