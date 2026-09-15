using System;
using System.Transactions;

namespace ElatkozottBurok
{
    public class Nassolnivalo
    {
        Random random = new Random();

        private string nev;
        private int koffeinLoket;
        private int stresszOldas;
        private int ar;
        //alt+enter; ctrl+.

        public Nassolnivalo(string nev, int koffeinLoket, int stresszOldas, int ar)

        {
            Nev = nev;
            KoffeinLoket = koffeinLoket;
            StresszOldas = stresszOldas;
            Ar = ar;

        }


        public string Nev { get => nev; set
            {
                if (nev == "" || nev == null)
                {
                    nev = "Ismeretlen nassolnivaló";
                }
                else
                {
                    nev = value;
                }
            }
        }

        //•	KoffeinLoket (int): Hány százalékkal növeli a koffeinszintet (0 és50 között lehet, tartományon kívül vágja le az értéket 0-ra vagy 50re).
        public int KoffeinLoket
        {
            get => koffeinLoket;
            set
            {
                //koffeinLoket = random.Next(0, 51);

                if (value <0 )
                {
                    koffeinLoket = 0;
                }
                else if(value > 50)
                {
                    koffeinLoket = 50;
                }
                else
                {
                    koffeinLoket = value;
                }
            }
        }
        public int StresszOldas { get => stresszOldas; set
            {
                if (value < 0)
                {
                    stresszOldas = 0;
                }
                else if (value > 30)
                {
                    stresszOldas = 30;
                }
                else
                {
                    stresszOldas = value;
                }
            }
        }
        public int Ar { get => ar; set
            {
                if (value <= 0 || ar <100)
                {
                    ar = 100;
                }
                else
                {
                    ar = value;
                }
            }
        }
    }
}