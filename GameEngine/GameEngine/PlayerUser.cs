using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;
namespace GameEngine
{
    public class PlayerUser
    {

        #region atributi
        protected List<Karta> hand;
        public IMove BestMove { get; set; }
        public List<Karta> Hand { get; }
        // public bool playtime { get; set; }
        public PlayerUser nextPlayer { get; set; }
        public PlayerUser previousPlayer { get; set; }
        public string name { get; set; }
        #endregion

        #region construcotrs
        public PlayerUser()
        {
            //   playtime = false;
            hand = new List<Karta>();
            //IMOVE

        }
        #endregion
        public void manualPlay(int rdBrojKarte, TipPoteza tip, Boja boja)
        {
            BestMove.Karte.Clear();
            BestMove.Karte.Add(hand[rdBrojKarte]);
            hand.RemoveAt(rdBrojKarte);
            BestMove.Tip = tip;
            BestMove.NovaBoja = boja;

        }

        #region interfejs
        public void findBestMoce()
        {
            return;
        }


        public void Bacenekarte(List<Karta> karte)
        {
            throw new NotImplementedException();
        }

        public void KupioKarte(List<Karta> karte)
        {
            hand.AddRange(karte);
        }

        public void Reset()
        {
            hand = new List<Karta>();
        }

        public void SetRuka(List<Karta> karte)
        {
            hand = karte;
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
