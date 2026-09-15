using System;
using System.Collections.Generic;
using System.Linq;


namespace ElatkozottBurok
{
    public class Fejleszto
    {
        private string nev;
        private Munkakor munkakor;
        private int penz;
        private int koffeinszint;
        private int stresszSzint;
        private bool kiegve;
        private string kedvencSnack;

        public Fejleszto(
            string nev,
            Munkakor munkakor,
            int penz,
            string kedvencSnack,
            int koffeinszint,
            int stresszSzint)
        {
            Nev = nev;
            Munkakor = munkakor;
            Penz = penz;
            KedvencSnack = kedvencSnack;
            Koffeinszint = koffeinszint;
            StresszSzint = stresszSzint;
        }

        public string Nev
        {
            get => nev;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    nev = "Ismeretlen fejlesztő";
                }
                else
                {
                    nev = value;
                }
            }
        }
        public Munkakor Munkakor
        {
            get => munkakor;
            set => munkakor = value;
        }

        public int Penz
        {
            get => penz;
            set
            {
                if (value < 0)
                {
                    penz = 0;
                }
                else
                {
                    penz = value;
                }
            }
        }
        public int Koffeinszint
        {
            get => koffeinszint;
            set
            {
                if (value < 0)
                {
                    koffeinszint = 0;
                }
                else if (value >= 100)
                {
                    koffeinszint = 100;
                    kiegve = true;
                }
                else
                {
                    koffeinszint = value;
                }
            }
        }

        public int StresszSzint
        {
            get => stresszSzint;
            set
            {
                if (value < 0)
                {
                    stresszSzint = 0;
                }
                else if (value >= 100)
                {
                    stresszSzint = 100;
                    kiegve = true;
                }
                else
                {
                    stresszSzint = value;
                }
            }
        }

        public bool Kiegve
        {
            get => kiegve;
        }
        public string KedvencSnack
        {
            get => kedvencSnack;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    kedvencSnack = "Nincs kedvenc snack";
                }
                else
                {
                    kedvencSnack = value;
                }
            }
        }
        public void Fogyaszt(Nassolnivalo nassolnivalo)
        {
            if (nassolnivalo == null || Kiegve)
            {
                return;
            }

            int stresszCsokkenes = nassolnivalo.StresszOldas;
            //2x a kedvenc snack
            //extra(+5)
            if (nassolnivalo.Nev == KedvencSnack)
            {
                stresszCsokkenes *= 2;
                Koffeinszint += nassolnivalo.KoffeinLoket + 5;
            }
            else
            {
                Koffeinszint += nassolnivalo.KoffeinLoket;
            }
            StresszSzint -= stresszCsokkenes;
        }

        //nincs tesztelve de igy kell megcsinalni a dolgozik metodust 
        public void Dolgozik()
        {
            if (Kiegve == true)
            {
                Console.WriteLine(Nev + " kiégett, ezért már nem tud dolgozni!");
                return;
            }
            if (Munkakor == Munkakor.Junior)
            {
                Koffeinszint = Koffeinszint - 25;
                StresszSzint = StresszSzint + 20;
            }
            else if (Munkakor == Munkakor.Senior)
            {
                Koffeinszint = Koffeinszint - 15;
                StresszSzint = StresszSzint + 10;
            }
            else if (Munkakor == Munkakor.DevOpsVarazslo)
            {
                Koffeinszint = Koffeinszint - 10;
                StresszSzint = StresszSzint + 25;
            }

            if (Koffeinszint < 15)
            {
                Console.WriteLine(Nev + " agya lefagyott (BlueScreen), koffeinre van szüksége!");
            }
        }
    }
}