using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace _16114
{
    public class Move : IMove
    {
        public TipPoteza Tip { get; set; }
        public List<Karta> Karte { get; set; }
        public Boja NovaBoja { get; set; }
        public int Dubina { get; set; }
        public int Value { get; set; }

        public Move()
        {
            Karte = new List<Karta>();
            NovaBoja = Boja.Unknown;
            Tip = TipPoteza.KupiKartu;
            Dubina = 0;
        }
        public Move(IMove mv,int d,int v)
        {
            Karte = new List<Karta>(mv.Karte);
            NovaBoja = mv.NovaBoja;
            Tip = mv.Tip;
            Dubina = d;
        }
        public Move(Karta k, Boja nova)
        {
            Karte= new List<Karta>();
            Karte.Add(k);
            NovaBoja = nova;
            Tip = TipPoteza.BacaKartu;

        }
        public Move(Move m)
        {
            Tip = m.Tip;
            NovaBoja = m.NovaBoja;
            Karte = new List<Karta>();
            Karte.AddRange(m.Karte);
        }

        public void setKarta(Karta  karta)
        {
            Karte.Clear();
            Karte.Add(karta);
            Tip = TipPoteza.BacaKartu;
        }

        public void apendMove(IMove move)
        {
            if (Karte.Last().Broj == "A")
            {
                Karte.AddRange(move.Karte);
                if (move.Karte.Last().Broj == "J")
                {
                    NovaBoja = move.NovaBoja;
                }
            }

            return;
        }

    }
}
