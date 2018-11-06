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

        protected List<Karta> poslednjeBacene;

        public PlayerUser player1 { get; set; } 
        public PlayerUser player2 { get; set; }
        public PlayerUser current { get; set; }
        public Karta talon { get { return topCard; } }

        public Engine() {
            deck = new Spil(true);
            player1Hand = new List<Karta>();
            player2Hand = new List<Karta>();

            player1 = new PlayerUser();
            player2 = new PlayerUser();

            player1.nextPlayer = player2;
            player1.previousPlayer = player2;
            player2.nextPlayer = player1;
            player2.nextPlayer = player1;


            player1.SetRuka(player1Hand);
            player2.SetRuka(player2Hand);

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

            current = player1;

        }

        bool Game()
        {
            if (gameOver())
                return false;

            current.Bacenekarte(poslednjeBacene);
            current.findBestMoce();
            poslednjeBacene= current.BestMove.Karte;
            foreach(Karta card in poslednjeBacene)
            {
                if (isValid(card))
                {
                    topCard = card;
                }
                else
                {
                    throw new Exception("Invalid move");
                }
            }
            

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





        /*
        public static string handToString(List<Karta> hand)
        {
            string ret = "";
            foreach(Karta a in hand)
            {
                ret += "|" + a.Boja + " " + a.Broj;
            }
            return ret;
        }
        */

        
    }
}
