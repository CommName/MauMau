using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16114
{
    public class Gilgamesh : TIG.AV.Karte.IIgra
    {
        protected List<Karta> hand;
        protected Karta talon;

        CardCounter remainingCards;


        public Gilgamesh()
        {
            Reset();
        }

        

        public IMove BestMove { get; set; }

        public void Bacenekarte(List<Karta> karte, Boja boja, int BrojKarataProtivnika)
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
            throw new NotImplementedException();
        }

        public void Reset()
        {
            hand = new List<Karta>();
            remainingCards = new CardCounter();
            remainingCards.hand = hand;
            return;
        }

        public void SetRuka(List<Karta> karte)
        {
            throw new NotImplementedException();
        }

        //kradja iteracia sa bacene karte
    }
}
