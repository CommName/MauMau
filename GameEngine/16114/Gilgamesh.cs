﻿using System;
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
        protected bool kupioKaznene;
        protected bool kupio;

        public IMove BestMove { get; set; }

        public Gilgamesh()
        {
            Reset();
        }

        


        public void Bacenekarte(List<Karta> karte, Boja boja, int BrojKarataProtivnika)
        {
            if (karte != null)
            {
                talon = karte.Last();
                remainingCards.remove(karte);
            }
            novaBoja = boja;
            brojKarataEnemy = BrojKarataProtivnika;
            BestMove = new Move();
        }


        protected int alpaBeta(int depth,bool yourTurn,Board node,ref int alpa,ref int beta,out IMove best)
        {
            List<IMove> child = node.moves;
            if(depth==0|| child.Count < 1)
            {
                
                best = new Move { Tip = TipPoteza.KrajPoteza };
                
                return node.evaluation();
            }
            int v;
            best = child.First();
            if (yourTurn)
            {
                v = int.MaxValue;
                foreach(IMove i in child)
                {
                    int pom;
                    if ((i.Tip & TipPoteza.KupiKartu) == TipPoteza.KupiKartu || (i.Tip & TipPoteza.KupiKazneneKarte)==TipPoteza.KupiKazneneKarte)
                    {
                        pom = node.evaluation();
                    }
                    else {
                        bool turn = false;
                        if (i.Karte.First().Broj == "A" || i.Karte.First().Broj == "8")
                        {
                            turn = true;
                        }
                        IMove bb;
                        pom= alpaBeta(depth - 1, turn, new Board(node, i), ref alpa, ref beta,out bb);
                    }
                    if (v > pom)
                    {
                        v = pom;
                        best = i;
                        if (alpa > v)
                        {
                            alpa = v;
                            if (beta <= alpa)
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
                foreach(IMove i in child)
                {
                    IMove bb;
                    int pom = alpaBeta(depth - 1, !yourTurn, new Board(node, i), ref alpa, ref beta, out bb);
                    if (v < pom)
                    {
                        v = pom;
                        best = i;
                        if (beta < v)
                        {
                            beta = v;
                            if (beta <= alpa)
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
            int alpha = int.MinValue;
            int beta = int.MaxValue;
            IMove best;
            alpaBeta(1, true, new Board(new Move(talon, novaBoja), true, hand, brojKarataEnemy, remainingCards,kupioKaznene), ref alpha, ref beta, out best);
            BestMove.Karte = best.Karte;
            BestMove.NovaBoja = best.NovaBoja;
            BestMove.Tip = best.Tip;
            if(BestMove.Tip == TipPoteza.KupiKazneneKarte)
            {
                kupioKaznene = true;
            }
            else
            {
                kupioKaznene = false;
            }
            if (kupio)
            {
                if (BestMove.Tip == TipPoteza.KupiKartu)
                    BestMove.Tip = TipPoteza.KrajPoteza;
            }
            if (BestMove.Tip == TipPoteza.KupiKartu)
            {
                kupio = true;
            }
            else
            {
                kupio = false;
            }
            

            foreach (Karta k in BestMove.Karte)
            {
                hand.Remove(k);
                talon = k;
            }
        }

        public void BeginBestMove()
        {
            alphaBetaBestMove();
        }

        public void EndBestMove()
        {
            
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
            hand.AddRange(karte);
            remainingCards.remove(karte);
        }

        //kradja iteracia sa bacene karte
    }
}
