using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;
using System.Threading;

namespace _16114
{
    
    public class Gilgamesh : TIG.AV.Karte.IIgra
    {
        protected List<Karta> hand;
        protected Karta talon;
        protected Boja novaBoja;
        protected CardCounter remainingCards;
        protected int brojKarataEnemy;
        protected bool kupioKaznene;
        protected bool kupio;

        public IMove BestMove { get; set; }

        public Gilgamesh()
        {
            Reset();
        }

        protected static Dictionary<ulong, Move> tabela = new Dictionary<ulong, Move>();


        public void Bacenekarte(List<Karta> karte, Boja boja, int BrojKarataProtivnika)
        {

            if (karte != null && karte.Count > 0)
            {
                talon = karte.Last();
                remainingCards.remove(karte);
            }
            novaBoja = boja;
            brojKarataEnemy = BrojKarataProtivnika;
            BestMove = new Move();
            kupio = false;
            if (karte != null && karte.Count > 0)
                kupioKaznene = false;
            else
            {
                kupioKaznene = true;
            }
        }
        bool stop;
        public static readonly object _locker = new object();
        private bool checkStop()
        {
            bool ret;
            lock (_locker)
            {
                ret = stop;
            }
            return ret;
        }
        protected int alpaBeta(int depth, bool yourTurn, Board node, int alpa, int beta, out IMove best)
        {
            //promeni alph beta
            //za child napravi kombinaciju

            if (checkStop())
            {
                best = null;
                return 0;
            }
            List<IMove> child = node.moves();
            if (depth == 0 || child.Count < 1 || node.hand.Count==0||node.enemyHand<0)
            {

                best = new Move { Tip = TipPoteza.KupiKartu };

                return node.evaluation();
            }
            if (node.talon.Tip == TipPoteza.KupiKartu || node.talon.Tip == TipPoteza.KupiKazneneKarte || node.talon.Tip == TipPoteza.KrajPoteza)
            {
                best = node.talon;
                return node.evaluation();
            }
            int v;
            best = child.First();
            if (yourTurn)
            {
                v = int.MaxValue;
                foreach (IMove i in child)
                {
                    if (checkStop())
                    {
                        best = null;
                        return 0;
                    }
                    int pom;
                    if ((i.Tip & TipPoteza.KupiKartu) == TipPoteza.KupiKartu || (i.Tip & TipPoteza.KupiKazneneKarte) == TipPoteza.KupiKazneneKarte)
                    {
                        pom = node.evaluation();
                    }
                    else {
                        bool turn = false;
                        if (i.Karte.Last().Broj == "A" || i.Karte.Last().Broj == "8")
                        {
                            turn = true;
                        }
                        IMove bb;
                        pom = alpaBeta(depth - 1, turn, new Board(node, i), alpa, beta, out bb);
                        if (checkStop())
                        {
                            best = null;
                            return 0;
                        }
                        if (turn)
                        {
                            pom -= 5;
                        }
                        if((i.Tip&TipPoteza.BacaKartu)==TipPoteza.BacaKartu && i.Karte.Last().Broj == "A"&&(bb.Tip&TipPoteza.BacaKartu)==TipPoteza.BacaKartu)
                        {
                            i.Karte.AddRange(bb.Karte);
                            i.NovaBoja = bb.NovaBoja;
                            i.Tip = i.Tip | bb.Tip;
                        }
                    }
                    
                    if (v > pom)
                    {
                        v = pom;
                        best = i;
                        if (alpa > v)
                        {
                            alpa = v;
                            if (beta >= alpa)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                v = int.MinValue;
                foreach (IMove i in child)
                {
                    if (checkStop())
                    {
                        best = null;
                        return 0;
                    }
                    int pom;
                    if ((i.Tip & TipPoteza.KupiKartu) == TipPoteza.KupiKartu || (i.Tip & TipPoteza.KupiKazneneKarte) == TipPoteza.KupiKazneneKarte)
                    {
                        IMove bb;
                        IMove kupi = new Move();
                        kupi.Karte = node.talon.Karte;
                        kupi.NovaBoja = i.NovaBoja;
                        kupi.Tip = TipPoteza.BacaKartu;
                        node.enemyHand++;
                        pom = alpaBeta(depth - 1, !yourTurn, new Board(node,kupi ), alpa, beta, out bb);
                        node.enemyHand--;
                        pom -= 10;
                    }
                    else
                    {
                        IMove bb;
                        pom = alpaBeta(depth - 1, !yourTurn, new Board(node, i), alpa, beta, out bb);
                    }
                    if (v < pom)
                    {
                        v = pom;
                        best = i;
                        if (beta < v)
                        {
                            beta = v;
                            if (beta >= alpa)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            
            return v;
        }

      

        protected void alphaBetaBestMove()
        {
            Move trenutni = new Move(talon, novaBoja);
            Board trenutnoStanje = new Board(trenutni, true, hand, brojKarataEnemy, remainingCards, kupioKaznene);
            Move history;

            if (tabela.TryGetValue(trenutnoStanje.key(),out history))
            {
                BestMove = history;
            }

            for (int i = 1; i < Int32.MaxValue; i++)
            {

                int alpha = int.MinValue;
                int beta = int.MaxValue;
                IMove best = new Move() ;
                int value = alpaBeta(i, true, trenutnoStanje, alpha,  beta, out best);

                if (checkStop())
                {
                    break;
                }
                lock (_locker)
                {
                    BestMove.Karte = best.Karte;
                    BestMove.NovaBoja = best.NovaBoja;
                    BestMove.Tip = best.Tip;
                    if (kupio)
                    {
                        if ((BestMove.Tip & TipPoteza.KupiKartu) == TipPoteza.KupiKartu)
                        {
                            BestMove.Tip = BestMove.Tip ^ (TipPoteza.KupiKartu);
                            BestMove.Tip = BestMove.Tip | TipPoteza.KrajPoteza;
                        }
                    }
                    if ((BestMove.Tip & TipPoteza.BacaKartu) == TipPoteza.BacaKartu && BestMove.Karte.Last().Broj != "A")
                    {
                        BestMove.Tip = BestMove.Tip | TipPoteza.KrajPoteza;
                    }
                    if(!(((BestMove.Tip & TipPoteza.KupiKazneneKarte )== TipPoteza.KupiKazneneKarte)|| ((BestMove.Tip & TipPoteza.KupiKartu) == TipPoteza.KupiKartu)) && (hand.Count-BestMove.Karte.Count) ==1)
                    {
                        BestMove.Tip = TipPoteza.Poslednja | BestMove.Tip;
                    }
                }
                Move upis;

                if (tabela.TryGetValue(trenutnoStanje.key(), out upis))
                {
                    if (upis.Dubina < i)
                    {
                        upis = new Move(best,i);
                    }
                }

            }

            lock (_locker)
            {
                if (BestMove.Tip == TipPoteza.KupiKazneneKarte)
                {
                    kupioKaznene = true;
                }
                else
                {
                    if ((BestMove.Tip & TipPoteza.KupiKartu) != TipPoteza.KupiKartu)
                    {
                        kupioKaznene = false;

                    }
                }
                
                if ((BestMove.Tip & TipPoteza.KupiKartu) == TipPoteza.KupiKartu)
                {
                    kupio = true;
                }
                else
                {
                    kupio = false;
                }
                if ((BestMove.Tip & TipPoteza.BacaKartu) == TipPoteza.BacaKartu)
                {
                    foreach (Karta k in BestMove.Karte)
                    {
                        if (k != null)
                        {
                            hand.Remove(k);
                            talon = BestMove.Karte.Last();
                            novaBoja = BestMove.NovaBoja;
                        }
                    }
                }
            }
        }

        public void BeginBestMove()
        {
            stop = false;
            Thread alphaBeta = new Thread(alphaBetaBestMove);
            alphaBeta.Priority = ThreadPriority.Highest;
            alphaBeta.Start();
          
            
        }

        public void EndBestMove()
        {
            lock (_locker)
            {
                stop = true;
            }
        }

        public void KupioKarte(List<Karta> karte)
        {
            if (karte != null && karte.Count > 0)
            {
                hand.AddRange(karte);
                remainingCards.remove(karte);
            }
        }

        public void Reset()
        {
            hand = new List<Karta>();
            remainingCards = new CardCounter();
            remainingCards.hand = hand;
            kupio = false;
            kupioKaznene = false;
            return;
        }

        public void SetRuka(List<Karta> karte)
        {
            hand = new List<Karta>();
            hand.AddRange(karte);
            remainingCards.remove(karte);
        }
        
    }
}
