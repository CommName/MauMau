using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16114
{
    class Gilgamesh : TIG.AV.Karte.IIgra
    {
        protected List<Karta> hand;
        protected Karta talon;


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

            return;
        }

        public void SetRuka(List<Karta> karte)
        {
            throw new NotImplementedException();
        }
    }
}
