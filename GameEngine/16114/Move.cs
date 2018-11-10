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

        public Move()
        {
            Karte = new List<Karta>();
            NovaBoja = Boja.Unknown;
            Tip = TipPoteza.KupiKartu;
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
