using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace GameEngine
{
    public class BestMove : TIG.AV.Karte.IMove
    {
        public TipPoteza Tip { get; set; }
        public List<Karta> Karte { get; set; }
        public Boja NovaBoja { get; set; }

        public BestMove()
        {
            Karte = new List<Karta>();
        }

    }
}
