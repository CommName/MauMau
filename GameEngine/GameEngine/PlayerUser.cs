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
        public PlayerUser(IIgra player)
        {
            bot = player;
        }
        #endregion
        public void manualPlay(int cardNumber, TipPoteza moveType, Boja suit)
        {
            BestMove.Karte.Clear();
            BestMove.Tip = moveType;
            BestMove.NovaBoja = suit;
            if ((moveType & TipPoteza.BacaKartu) == TipPoteza.BacaKartu)
            { 
                BestMove.Karte.Add(hand[cardNumber]);
                hand.RemoveAt(cardNumber);

            }

        }

        #region interfejs
        public void findBestMove()
        {
            if (bot != null)
            {
                bot.BeginBestMove();
                Thread.Sleep(1000);
                bot.EndBestMove();
                BestMove = bot.BestMove;
                if ((BestMove.Tip & TipPoteza.BacaKartu) == TipPoteza.BacaKartu)
                {
                    foreach (Karta k in BestMove.Karte)
                    {
                        if (!this.Hand.Exists(x => x.Boja == k.Boja && x.Broj == k.Broj))
                        {
                            throw new Exception("Nemas tu kartu " + k.Broj + k.Boja.ToString());
                        }
                        hand.Remove(k);
                    }
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
            hand = new List<Karta>(karte);
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

  

    }
}
