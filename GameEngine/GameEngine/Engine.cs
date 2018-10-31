using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace GameEngine
{

    public class Engine
    {
        protected Spil deck;
        protected Karta topCard;
        protected List<Karta> player1Hand;
        protected List<Karta> player2Hand;

        public List<Karta> player1 { get { return player1Hand; } }
        public List<Karta> player2 { get { return player2Hand; } }
        public Karta talon { get { return topCard; } }

        public Engine() {
            deck = new Spil(true);
            player1Hand = new List<Karta>();
            player2Hand = new List<Karta>();
            topCard = deck.Karte[0];
            deck.Karte.RemoveAt(0);
            //Dealibg cards
            for(int i = 0; i < 2; i++)
            {
      
                player1Hand.AddRange(deck.Karte.GetRange(0, 3));
                deck.Karte.RemoveRange(0, 3);
                player2Hand.AddRange(deck.Karte.GetRange(0, 3));
                deck.Karte.RemoveRange(0, 3);
            }

        }

        bool Game()
        {



            return true;
        }

        public void playCard(List<Karta> cards)
        {

        }

        //is it a valid move
        protected bool isValid(Karta card)
        {
            if ((card.Broj == "J") || (card.Boja == topCard.Boja) || (card.Broj == card.Broj))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


        public bool gameOver()
        {
            if (player1Hand.Count == 0 || player2Hand.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void autoMovePlayer1()
        {
           
        }
        public void autoMovePlayer2()
        {

        }
        public void manualMovePlayer1(TipPoteza type,List<Karta> cards,Boja color)
        {

        }
        public void manualMovePlayer2(TipPoteza type, List<Karta> cards, Boja color)
        {

        }

        public static string handToString(List<Karta> hand)
        {
            string ret = "";
            foreach(Karta a in hand)
            {
                ret += "|" + a.Boja + " " + a.Broj;
            }
            return ret;
        }


    }
}
