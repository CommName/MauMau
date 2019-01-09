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

        public bool KupiKartu { get { return !kupioKartu; } }
        public bool kupiKaznene { get { return kazna!=0; } }


        public PlayerUser player1 { get; set; } 
        public PlayerUser player2 { get; set; }

        public PlayerUser current { get; set; }


        public Engine(int numOfBots) {
            deck = new Spil(true);
            if(numOfBots == 0)
            {
                player1 = new PlayerUser(false);
                player2 = new PlayerUser(false);
            }
            else if (numOfBots == 1)
            {
                 Random random = new Random();
                if (random.Next() % 2 == 0)
                {
                    player1 = new PlayerUser(false);
                    player2 = new PlayerUser(true);
                }
                else
                {
                    player1 = new PlayerUser(true);
                    player2 = new PlayerUser(false);
                }
            }
            else
                if (numOfBots == 2)
            {
                player1 = new PlayerUser(new _16114.Gilgamesh());
                player2 = new PlayerUser(new _16114.Gilgamesh());
            }
            else throw new Exception("Neispravan broj igraca");
            

            player1.nextPlayer = player2;
            player1.previousPlayer = player2;
            player2.nextPlayer = player1;
            player2.previousPlayer = player1;


            topCard = deck.Karte[0];
            poslednjeBacene = new List<Karta>();
            deck.Karte.RemoveAt(0);
            //Da ne pocninje partiju sa kaznenim kartama
            if (topCard.Broj == "7" || (topCard.Broj == "2" && topCard.Boja == Boja.Tref))
            {
                int index = 0;
                while (deck.Karte[index].Broj=="7"||(deck.Karte[index].Broj=="2"&&deck.Karte[index].Boja==Boja.Tref))
                {
                    index++;
                }
                Karta pom = topCard;
                topCard = deck.Karte[index];
                deck.Karte[index] = pom;
            }
            poslednjeBacene.Add(topCard);
            player1.Bacenekarte(poslednjeBacene, Boja.Unknown, 6);
            player2.Bacenekarte(poslednjeBacene, Boja.Unknown, 6);
            boja = Boja.Unknown;
            kazna = 0;
            kupioKartu = false;
            promena = true;

            //Dealibg cards
                player1.SetRuka(deck.Karte.GetRange(0, 6));
                deck.Karte.RemoveRange(0, 6);
                player2.SetRuka(deck.Karte.GetRange(0, 6));
                deck.Karte.RemoveRange(0,6 );
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
                
            
            //kaznene karte
            if (((int)current.BestMove.Tip & (int)TipPoteza.KupiKazneneKarte) != 0)
            {
                if (kazna == 0)
                {
                    throw new Exception("Nije potrebno kupiti kaznenu kartu");
                }
                //Popraviti ovo da  vrati false
                if(deck.Karte.Count< kazna)
                {
                    return false;
                }
                current.KupioKarte(kupi(kazna)); 
                kazna = 0;
            }
            //kupi kartu
            if (((int)current.BestMove.Tip & (int)TipPoteza.KupiKartu) != 0)
            {
                if (kupioKartu)
                {
                    throw new Exception("Vec je kupljena karta");
                }
                kupioKartu = true;
                if (deck.Karte.Count != 0)
                {
                    current.KupioKarte(kupi(1));
                }
                else
                {
                    return false;
                }

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
                            kazna = 4;
                        }
                        //J
                        if (topCard.Broj == "J")
                        {
                            if ((current.BestMove.Tip & TipPoteza.PromeniBoju) != TipPoteza.PromeniBoju)
                            {
                                throw new Exception("Pogresan tip za J");
                            }
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
                        /*
                        Console.Write(current.BestMove.Tip.ToString());
                        foreach (Karta k in current.BestMove.Karte)
                        {
                            Console.Write(k.Broj +" "+k.Boja.ToString());
                        }
                        */
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
            if (!promena)
            {
                if (((int)current.BestMove.Tip & (int)TipPoteza.KrajPoteza) != 0)
                {

                    if (kupioKartu || bacioKartu)
                    {
                        if (!bacioKartu)
                        {
                            current = current.nextPlayer;
                            promena = true;
                            kupioKartu = false;
                        }
                        return true;
                    }
                    else
                    {
                        throw new Exception("Ne moze da zavrsi potez");
                    }
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
            public bool isValid(Karta card)
            {

                if((card.Broj == "J") || (card.Boja == topCard.Boja && boja == Boja.Unknown) || (card.Broj == topCard.Broj) || (boja == card.Boja))
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
                if ((topCard.Broj!="A")&&(player1.Hand.Count == 0 || player2.Hand.Count == 0)&&(kazna==0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public static int vrednostKarte(Karta k)
            {
            switch (k.Broj)
            {
                case "A": return 13;
                case "2": if (k.Boja == Boja.Tref) return 10; else return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 10;
                case "8": return 12;
                case "9": return 9;
                case "10": return 10;
                case "J": return 25;
                case "Q": return 10;
                case "K": return 10;
                default: return 8;
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
