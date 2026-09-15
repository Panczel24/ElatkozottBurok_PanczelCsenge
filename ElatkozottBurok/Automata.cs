using System;
using System.Collections.Generic;
using System.Linq;


namespace ElatkozottBurok
{
    public class Automata
    {
        private int keszpenzKassza;
        private List<Nassolnivalo> keszlet;
        private bool elakadva;

        Random random = new Random();

        public Automata()
        {
            keszpenzKassza = 0;
            keszlet = new List<Nassolnivalo>();
            elakadva = false;
        }

        public int KeszpenzKassza
        {
            get => keszpenzKassza;
        }

        public List<Nassolnivalo> Keszlet
        {
            get => keszlet;
        }

        public bool Elakadva
        {
            get => elakadva;
            set => elakadva = value;
        }

        public void Feltolt(List<Nassolnivalo> ujElemek)
        {
            if (ujElemek == null)
            {
                return;
            }

            foreach (Nassolnivalo elem in ujElemek)
            {
                keszlet.Add(elem);
            }
        }

        public Nassolnivalo Vasarlas(string termekNev, Fejleszto vasarlo)
        {
            if (Elakadva == true)
            {
                Console.WriteLine("Az automata elakadt!");
                vasarlo.StresszSzint += 15;
                return null;
            }

            Nassolnivalo termek = null;

            foreach (Nassolnivalo elem in keszlet)
            {
                if (elem.Nev == termekNev)
                {
                    termek = elem;
                    break;
                }
            }

            if (termek == null)
            {
                Console.WriteLine("A termék kifogyott!");
                return null;
            }

            if (vasarlo.Penz < termek.Ar)
            {
                Console.WriteLine("A vásárlónak nincs elég pénze!");
                return null;
            }

            int veletlen = random.Next(1, 101);

            if (veletlen < 15)
            {
                elakadva = true;

                vasarlo.Penz -= termek.Ar;
                vasarlo.StresszSzint += 30;

                Console.WriteLine("Az automata elakadt! A termék nem került kiadásra.");

                return null;
            }

            vasarlo.Penz -= termek.Ar;
            keszpenzKassza += termek.Ar;

            keszlet.Remove(termek);

            return termek;
        }

        public void JavitasRugassal()
        {
            if (Elakadva == false)
            {
                Console.WriteLine("Az automata nem akadt el.");
                return;
            }

            int veletlen = random.Next(1, 101);

            if (veletlen <= 50)
            {
                elakadva = false;
                Console.WriteLine("A rúgás sikeres volt, az automata megjavult!");
            }
            else
            {
                Console.WriteLine("RIASZTÓ! A rúgás nem segített!");
            }
        }
    }
}