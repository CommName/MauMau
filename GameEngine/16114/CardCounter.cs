using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16114
{
    class CardCounter
    {

        protected List<Karta>[] Boja;
        protected List<Karta>[] Broj;

       
        public CardCounter()
        {
            reset();
        }
        public void reset()
        {
            Boja = new List<Karta>[4];
            Broj = new List<Karta>[13];

            for(int i = 0; i < 4; i++)
            {
                Boja[i] = new List<Karta>();
            }
            for (int i = 0; i < 13; i++)
            {
                Broj[i] = new List<Karta>();
            }
            Spil karte = new Spil();
            foreach(Karta karta in karte.Karte)
            {
                Boja[(int)karta.Boja - 1].Add(karta);
                Broj[brojToNumber(karta.Broj) - 1].Add(karta);
            }

        }
        public void remove(List<Karta> karta)
        {
            foreach(Karta k  in karta)
            {
                remove(k);
            }
        }
        public void remove(Karta karta)
        {
            int bojaIndex = (int)karta.Boja - 1;
            for (int i = 0; i < Boja[bojaIndex].Count; i++)
            {
                if (karta.Broj == Boja[bojaIndex][i].Broj)
                {
                    Boja[bojaIndex].RemoveAt(i);
                    break;
                }
            }
            int brojIndex = brojToNumber(karta.Broj) - 1;
            for (int i = 0; i < Broj[brojIndex].Count; i++)
            {

            
                if (karta.Boja == Broj[bojaIndex][i].Boja){
                    Broj[brojIndex].RemoveAt(i);
                    break;
                }

            }
        }
        
             
   




        static public int brojToNumber(string broj)
        {
            switch (broj)
            {
                case "A": return 1;
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "10": return 10;
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                default: return 0;

            }
        }

    }
}
