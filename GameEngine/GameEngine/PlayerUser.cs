using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;
using System.Threading;
namespace GameEngine
{
    public class PlayerUser
    {
        

        #region atributi
        protected List<Karta> hand;
        public IMove BestMove { get; set; }
        public List<Karta> Hand { get { return hand; } }
        // public bool playtime { get; set; }
        public PlayerUser nextPlayer { get; set; }
        public PlayerUser previousPlayer { get; set; }
        public string name { get; set; }

        public IIgra bot;
        #endregion

        #region construcotrs
        public PlayerUser()
        {
            //   playtime = false;
            hand = new List<Karta>();
            BestMove = new BestMove();
            bot = null;
            //*
        }
        public PlayerUser(bool autoPlayer) : this()
        {
            if (autoPlayer)
            {
                bot = new _16114.Gilgamesh();
            }
        }
        #endregion
        public void manualPlay(int rdBrojKarte, TipPoteza tip, Boja boja)
        {
            BestMove.Karte.Clear();
            BestMove.Tip = tip;
            BestMove.NovaBoja = boja;
            if (tip == TipPoteza.BacaKartu)
            { 
                BestMove.Karte.Add(hand[rdBrojKarte]);
                hand.RemoveAt(rdBrojKarte);

            }

        }

        #region interfejs
        public void findBestMoce()
        {
            if (bot != null)
            {
                bot.BeginBestMove();
                Thread.Sleep(1000);
                bot.EndBestMove();
                Thread.Sleep(500);
                BestMove = bot.BestMove;
                foreach(Karta k in BestMove.Karte)
                {
                    hand.Remove(k);
                }
            }

            return;
        }


        public void Bacenekarte(List<Karta> karte, Boja boja, int BrojKarataProtivnika)
        {
            if (bot != null)
            {
                bot.Bacenekarte(karte, boja, BrojKarataProtivnika);
            }
           /* if (karte != null)
            {
                Console.WriteLine(boja.ToString() + BrojKarataProtivnika.ToString());
                foreach (Karta k in karte)
                {
                    Console.Write(k.Broj + k.Boja);
                }
            } */
            return;
        }

        public void KupioKarte(List<Karta> karte)
        {
            hand.AddRange(karte);
            if (bot!=null){
                bot.KupioKarte(karte);
            }
        }

        public void Reset()
        {
            hand = new List<Karta>();
            if (bot != null)
            {
                bot.Reset();
            }
        }

        public void SetRuka(List<Karta> karte)
        {
            hand = karte;
            if (bot != null)
            {
                bot.SetRuka(karte);
            }
        }

        #endregion

        public override string ToString()
        {
            string ret = "hand: ";
            foreach(Karta karta in hand)
            {
                ret += "|" +karta.Broj + " "+karta.Boja+"|";
            }

            return name +ret;
        }


        //posebna klasa koja broji karte i dostavlja mi validne poteze
        //kopi konstruktor za karte koje imam (stablo klasa)
        //kopi konstruktor za protivnikove karte koji vraca valid moves
        //klasa stablo koja ima child validne poteze
        //posebna funkcija koja uzima ceo niz karata i razvrstava ih
        //retko posednuta matrica

        //igranje protiv keca i 8 
        //igranje portiv 7 T
        //igranje protiv 2/3

    }
}
