using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;


namespace _16114
{
    public class Board
    {
        public IMove talon { get; set; }
        public bool yourTurn { get; set; }
        public List<Karta> hand { get; set; }
        public int enemyHand { get; set; }
        public CardCounter counter;
        public bool kazna { get; set; }
        public List<IMove> moves { get; }

        public Board()
        {

        }
        public Board(IMove lastMove,bool turn,List<Karta> yourHand,int enemy,CardCounter used)
        {
            counter = new CardCounter(used);
            talon = lastMove;
            hand = new List<Karta>();
            hand.AddRange(yourHand);
            enemyHand = enemy;
            counter = new CardCounter(used);

        }

        List<IMove> getYourMoves()
        {
            bool J = false; //J 2 puta
            List<IMove> ret = new List<IMove>();
            foreach(Karta karta in hand)
            {
                if (!J&&karta.Broj == "J" )
                {
                    J = true;
                    for(int i = 1; i < 5; i++)
                    {
                        Move temp = new Move();
                        temp.setKarta(karta);
                        temp.NovaBoja = (Boja)i;
                        temp.Tip = TipPoteza.BacaKartu;
                        ret.Add(temp);
                    }
                }
                else
                {
                    Move temp = new Move();
                    temp.setKarta(karta);
                    ret.Add(temp);
                }
            }


            return ret;

        }

        

        public int evaluation()
        {

            int evaluacija = 0;
            if (hand.Count == 0)
            {
                if (talon.Karte.Last().Broj == "A")
                {
                    evaluacija = 8;
                }
                else
                {
                    evaluacija = -40;
                }
            }
            else {
                foreach (Karta k in hand)
                {
                    evaluacija += cardPoints(k);
                }
            }
            // avrage card is 8 points
            evaluacija -= 8 * enemyHand;

            if(enemyHand ==0 || hand.Count == 0)
            {
                if (talon.Karte.Last().Broj == "J")
                {
                    evaluacija *= 2;
                    //shift 2
                }
            }

            return evaluacija;
        }

        public static int cardPoints(Karta karta)
        {
            switch (karta.Broj)
            {
                case "A": return 10;
                case "2": if (karta.Boja == Boja.Tref) return 10; else return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 10;
                case "8": return 10;
                case "9": return 9;
                case "10": return 10;
                case "J": return 25;
                case "Q": return 10;
                case "K": return 10;
                default: return 8;
            }
        }
    }
}
