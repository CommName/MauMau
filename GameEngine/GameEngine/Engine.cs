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

        //talon
        public Karta topCard { get; set; }
        public Boja boja { get; set; }
        protected int kazna;
        protected bool kupioKartu;
        protected bool promena;
        protected List<Karta> poslednjeBacene;

        public PlayerUser player1 { get; set; } 
        public PlayerUser player2 { get; set; }

        public PlayerUser current { get; set; }


        public Engine() {
            deck = new Spil(true);

            player1 = new PlayerUser(true);
            player2 = new PlayerUser(true);

            player1.nextPlayer = player2;
            player1.previousPlayer = player2;
            player2.nextPlayer = player1;
            player2.previousPlayer = player1;


            topCard = deck.Karte[0];
            poslednjeBacene = new List<Karta>();
            poslednjeBacene.Add(topCard);
            deck.Karte.RemoveAt(0);
            boja = Boja.Unknown;
            kazna = 0;
            kupioKartu = false;
            promena = true;

            //Dealibg cards
            for(int i = 0; i < 2; i++)
            {

                player1.KupioKarte(deck.Karte.GetRange(0, 3));
                deck.Karte.RemoveRange(0, 3);
                player2.KupioKarte(deck.Karte.GetRange(0, 3));
                deck.Karte.RemoveRange(0, 3);
            }
            //player1.Bacenekarte(poslednjeBacene, Boja.Unknown, 6);
            //player2.Bacenekarte(poslednjeBacene, Boja.Unknown, 6);
            //poslednjeBacene.Clear();
            current = player1;

        }

        public bool Game()
        {
            //bug kraj poteza kupio kartu
           
            if (gameOver())
                return false;

            bool bacioKartu = false;
            if (promena)
            {
                current.Bacenekarte(poslednjeBacene, boja, current.previousPlayer.Hand.Count);
                poslednjeBacene = null;
                promena = false;
            }
             current.findBestMoce();
                
            //kupi kartu
            if (((int)current.BestMove.Tip & (int)TipPoteza.KupiKartu) != 0)
            {
                if (kupioKartu)
                {
                    throw new Exception("Vec je kupljena karta");
                }
                kupioKartu = true;
                current.KupioKarte(kupi(1));
            }
            //kaznene karte
            if (((int)current.BestMove.Tip & (int)TipPoteza.KupiKazneneKarte) != 0)
            {
                if (kazna == 0)
                {
                    throw new Exception("Nije potrebno kupiti kaznenu kartu");
                }
                current.KupioKarte(kupi(kazna));
                kazna = 0;
            }
            //baci kartu
            if (((int)current.BestMove.Tip & (int)TipPoteza.BacaKartu) != 0)
            {
                poslednjeBacene = new List<Karta>();
                if (current.BestMove.Karte.Count == 0)
                {
                    throw new Exception("Nije selektovana karta");
                }
                for (int i = 0; i < current.BestMove.Karte.Count; i++)
                {
                    if (isValid(current.BestMove.Karte[i]))
                    {
                        bacioKartu = true;
                        kupioKartu = false; 
                        poslednjeBacene.Add(current.BestMove.Karte[i]);
                        topCard = current.BestMove.Karte[i];
                        //7
                        if (topCard.Broj == "7")
                        {
                            kazna += 2;
                        }
                        else if (kazna != 0)
                        {
                            throw new Exception("Nije kupio kaznene karte");
                        }
                        //2 tref
                        if (topCard.Boja == Boja.Tref && topCard.Broj == "2")
                        {
                            current.previousPlayer.KupioKarte(kupi(4));
                        }
                        //J
                        if (topCard.Broj == "J")
                        {
                            boja = current.BestMove.NovaBoja;
                            if(boja == Boja.Unknown)
                            {
                                throw new Exception("Boja nije setovana");
                            }

                        }
                        else
                        {
                            boja = Boja.Unknown;
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid move");
                    }                    

                }
                if(topCard.Broj != "A") //A
                
                {
                    if(topCard.Broj == "8")
                    {
                        //8 skippped
                        current = current.nextPlayer.nextPlayer;
                    }
                    else
                    {
                        current = current.nextPlayer;
                        promena = true;
                    }
                }

            }
            //Kraj poteza
            if(((int)current.BestMove.Tip & (int)TipPoteza.KrajPoteza) != 0)
            {
                if(kupioKartu || bacioKartu)
                {
                    if (!bacioKartu)
                    {
                        current = current.nextPlayer;
                        kupioKartu = false;
                    }
                    return true;
                }
                else
                {
                    throw new Exception("Ne moze da zavrsi potez");
                }
            }
           
        return true;
        }


            public List<Karta> kupi(int i)
            {
                List<Karta> ret = new List<Karta>() ;
                for(int j = 0; j < i; j++)
                {
                    if (deck.Karte.Count == 0)
                        throw new Exception("Nema vise karata");
                    ret.Add(deck.Karte[0]);
                    deck.Karte.RemoveAt(0);
                }
                return ret;
            }


            //is it a valid move
            protected bool isValid(Karta card)
            {
            
                if ((card.Broj == "J") || (card.Boja == topCard.Boja) || (card.Broj == topCard.Broj)|| (boja==card.Boja))
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
                if (topCard.Broj!="A"&&(player1.Hand.Count == 0 || player1.Hand.Count == 0)&&kazna==0)
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
