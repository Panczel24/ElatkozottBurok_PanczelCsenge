using System;
using System.Collections.Generic;

namespace ElatkozottBurok
{
    public class Iroda
    {
        private List<Fejleszto> fejlesztok;
        private Automata automataGep;

        public Iroda(List<Fejleszto> fejlesztok, Automata automataGep)
        {
            this.fejlesztok = fejlesztok;
            this.automataGep = automataGep;
        }

        public List<Fejleszto> Fejlesztok
        {
            get => fejlesztok;
        }

        public Automata AutomataGep
        {
            get => automataGep;
        }

        public void MunkanapSzimulacio(int orakSzama)
        {
            for (int ora = 1; ora <= orakSzama; ora++)
            {
                Console.WriteLine();
                Console.WriteLine(" " + ora + ". óra");
                Console.ResetColor();

                foreach (Fejleszto fejleszto in fejlesztok)
                {
                    fejleszto.Dolgozik();

                    if (fejleszto.Kiegve == true)
                    {
                        continue;
                    }

                    if (fejleszto.Koffeinszint < 20 ||
                        fejleszto.StresszSzint > 70)
                    {
                        Vasarlas(fejleszto);
                    }
                }

                AllapotKiiras();
            }
        }

        private void Vasarlas(Fejleszto fejleszto)
        {
            Nassolnivalo kivalasztott = null;

            foreach (Nassolnivalo elem in automataGep.Keszlet)
            {
                if (elem.Nev == fejleszto.KedvencSnack)
                {
                    kivalasztott = elem;
                    break;
                }
            }

            if (kivalasztott == null)
            {
                foreach (Nassolnivalo elem in automataGep.Keszlet)
                {
                    if (kivalasztott == null ||
                        elem.Ar < kivalasztott.Ar)
                    {
                        kivalasztott = elem;
                    }
                }
            }

            if (kivalasztott == null)
            {
                Console.WriteLine(fejleszto.Nev + "Üres az automata");

                return;
            }

            Nassolnivalo megvasarolt =
                automataGep.Vasarlas(kivalasztott.Nev, fejleszto);

            if (megvasarolt != null)
            {
                fejleszto.Fogyaszt(megvasarolt);

                Console.WriteLine(fejleszto.Nev +" megvette és megette: " +  megvasarolt.Nev );
            }

            else if (automataGep.Elakadva == true)
            {
                Console.WriteLine(fejleszto.Nev +" megpróbálta belerúgással elérni célját" );
                automataGep.JavitasRugassal();
            }
        }

        private void AllapotKiiras()
        {
            Console.WriteLine();
            Console.WriteLine("Fejlesztők aktuális állapota:");

            foreach (Fejleszto fejleszto in fejlesztok)
            {
                if (fejleszto.Kiegve == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(
                    fejleszto.Nev +
                    " | Koffein: " +
                    fejleszto.Koffeinszint +
                    " | Stressz: " +
                    fejleszto.StresszSzint +
                    " | Pénz: " +
                    fejleszto.Penz +
                    " | Kiégve: " +
                    fejleszto.Kiegve
                );

                Console.ResetColor();
            }
        }

        public void NapiJelentes()
        {
            Console.WriteLine();
            Console.WriteLine("Napi jelentés");
            Console.ResetColor();

            List<Fejleszto> sorrendezett = new List<Fejleszto>();

            foreach (Fejleszto fejleszto in fejlesztok)
            {
                sorrendezett.Add(fejleszto);
            }

            for (int i = 0; i < sorrendezett.Count - 1; i++)
            {
                for (int j = i + 1; j < sorrendezett.Count; j++)
                {
                    if (sorrendezett[j].StresszSzint >
                        sorrendezett[i].StresszSzint)
                    {
                        Fejleszto ideiglenes = sorrendezett[i];

                        sorrendezett[i] = sorrendezett[j];
                        sorrendezett[j] = ideiglenes;
                    }
                }
            }

            int darab = sorrendezett.Count;

            if (darab > 3)
            {
                darab = 3;
            }

            Console.WriteLine();
            Console.WriteLine("3 legfeszültebb fejlesztő:");

            for (int i = 0; i < darab; i++)
            {
                Fejleszto fejleszto = sorrendezett[i];

                Console.WriteLine(
                    (i + 1) +
                    ". " +
                    fejleszto.Nev +
                    " | Stressz: " +
                    fejleszto.StresszSzint +
                    " | Koffein: " +
                    fejleszto.Koffeinszint +
                    " | Kiégve: " +
                    fejleszto.Kiegve
                );
            }

            int kiegtekSzama = 0;

            foreach (Fejleszto fejleszto in fejlesztok)
            {
                if (fejleszto.Kiegve == true)
                {
                    kiegtekSzama++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Kiégett / túladagolt fejlesztők: " + kiegtekSzama);

            Console.WriteLine("Automata teljes napi bevétele: " + automataGep.KeszpenzKassza + " Ft");

            Console.WriteLine("Automatában maradt készlet: " +automataGep.Keszlet.Count + " db");
        }
    }
}