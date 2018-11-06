using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;
namespace GameEngine
{
    public class PlayerUser : TIG.AV.Karte.IIgra 
    {

        #region atributi
        protected List<Karta> hand;
        public IMove BestMove { get; set; }

       // public bool playtime { get; set; }
        public PlayerUser nextPlayer { get; set; }
        public PlayerUser previousPlayer { get; set; }

        #endregion

        #region construcotrs
        public PlayerUser()
        {
         //   playtime = false;
            
        }
        #endregion


        #region interfejs
        public void findBestMoce()
        {
            return;
        }


        public void Bacenekarte(List<Karta> karte)
        {
            throw new NotImplementedException();
        }

        public void BeginBestMove()
        {
            throw new NotImplementedException();
        }

        public void EndBestMove()
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

            return ret;
        }
    }
}
