using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;



namespace _16114
{
    

    public class CardCounter
    {

        protected List<Karta>[] Boja;
        protected List<Karta>[] Broj;

        protected int numOfRemCard;


        private const int singleCard = 13;
        private const double granica = 0.5;


        public CardCounter()
        {
            reset();
        }
        public CardCounter(CardCounter copy)
        {
            Boja = new List<Karta>[4];
            Broj = new List<Karta>[13];

            for (int i = 0; i < 4; i++)
            {
                Boja[i] = new List<Karta>();
                Boja[i].AddRange(copy.Boja[i]);
            }
            for (int i = 0; i < 13; i++)
            {
                Broj[i] = new List<Karta>();
                Broj[i].AddRange(copy.Broj[i]);
            }
            numOfRemCard = copy.numOfRemCard;
        }

        public void reset()
        {
            numOfRemCard = 52;
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
                    numOfRemCard--;
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
        public int count(Boja boja)
        {
            return Boja[(int)boja - 1].Count;
        }
        public int count(string broj)
        {
            return Broj[brojToNumber(broj)].Count;
        }
             
        List<Karta> valid(Karta talon,Boja b,int numOfEnemieCards)
        {
            List<Karta> ret = new List<Karta>();
            if (talon.Broj == "J")
            {
                ret.AddRange((Boja[(int)b - 1]));
            }
            else if(talon.Broj == "7")
            {
                if (Broj[6].Count > 1)
                {
                    ret.AddRange(Broj[6]);
                }
                else if (Broj[6].Count == 1 && ((numOfRemCard + numOfEnemieCards) <= singleCard))
                {
                    //maybe change to a chance
                    ret.Add(Broj[6].First());
                }
                else
                {
                    ret.AddRange(Boja[(int)talon.Boja - 1]);
                }
            }
            else
            {
                
                if (chance(Boja[(int)talon.Boja - 1].Count,numOfEnemieCards)>=granica)
                {
                    ret.AddRange(Boja[(int)talon.Boja - 1]);
                }
                
                if (chance(Boja[(int)talon.Boja - 1].Count, numOfEnemieCards) > granica)
                {
                    ret.Add(Broj[10].First());
                }

                if (chance(Broj[brojToNumber(talon.Broj) - 1].Count, numOfEnemieCards) >= granica)
                {
                    ret.AddRange(Broj[brojToNumber(talon.Broj) - 1]);
                }

            }
            return ret;
        }
        protected double chance(int numOfCards,int numOfDraws)
        {
            double ret = 1;
            for(int i = 0; i < numOfDraws; i++)
            {
                ret *= (1 - ((double)(numOfCards + i) / numOfRemCard));
            }
            return 1 - ret;
        }
        //dodati statistiku Hypergeometric Distribution

        // Dodati listu karata koje nema protivnik i sa tim uporedjivati
        //filter opcija i pointer na ruku

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
