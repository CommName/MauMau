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
        protected Boja novaBoja;
        protected CardCounter remainingCards;
        protected int brojKarataEnemy;

        public IMove BestMove { get; set; }

        public Gilgamesh()
        {
            Reset();
        }

        


        public void Bacenekarte(List<Karta> karte, Boja boja, int BrojKarataProtivnika)
        {
            talon = karte.Last();
            remainingCards.remove(karte);
            novaBoja = boja;
            brojKarataEnemy = BrojKarataProtivnika;
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
            remainingCards.remove(karte);
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
            hand.AddRange(karte);
            remainingCards.remove(karte);
        }

        //kradja iteracia sa bacene karte
    }
}
