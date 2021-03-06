﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;


namespace _16114
{
    public class Board
    {
        public IMove talon { get; set; }
        public bool yourTurn { get; set; }
        public List<Karta> hand { get; set; }
        public int enemyHand { get; set; }
        public CardCounter counter;

        public List<IMove> moves()
            {

                if (yourTurn)
                {
                    return getMoves(hand);
                }
                else
                {
                    return getMoves(counter.valid(talon.Karte.Last(), talon.NovaBoja, enemyHand));
                }
            } 


        public bool penalty { get; set; }
        public bool cardDrawn { get; set; }

        public Board()
        {
            hand = new List<Karta>();
            penalty = false;
            cardDrawn = false;

        }
        public Board(IMove lastMove, bool turn, List<Karta> yourHand, int enemy, CardCounter used,bool kaznene) : this()
        {
            lock (Gilgamesh._locker)
            {
                counter = new CardCounter(used);
                talon = lastMove;

                hand = new List<Karta>(yourHand);
                /*
                if (yourHand != null && yourHand.Count > 0)
                {
                    hand.AddRange(yourHand);
                }*/
                enemyHand = enemy;
                counter.remove(lastMove.Karte);
                yourTurn = turn;

                if (lastMove.Tip == TipPoteza.BacaKartu && lastMove.Karte.Count > 0 && (lastMove.Karte.Last().Broj == "7" || (lastMove.Karte.Last().Broj == "2" && lastMove.Karte.Last().Boja == Boja.Tref)) && !kaznene)
                {
                    penalty = true;
                }
            }
        }
        public Board(Board board, IMove move) : this()
        {
            counter = new CardCounter(board.counter);
            talon = move;
            enemyHand = board.enemyHand;
            this.hand = new List<Karta>(board.hand);
            if (board.yourTurn)
            {
                foreach (Karta k in move.Karte)
                {
                    hand.Remove(k);
                }
                
            }
            else
            {
                foreach (Karta k in move.Karte)
                {
                    counter.remove(k);
                }
                enemyHand--;
            }
            if (move.Tip == TipPoteza.BacaKartu && move.Karte.Last().Broj == "7")
            {
                penalty = true;
            }
            else
            {
                penalty = false;
            }
            if (move.Tip==TipPoteza.BacaKartu&&( move.Karte.Last().Broj == "A" || move.Karte.Last().Broj == "8"))
            {
                yourTurn = board.yourTurn;
            }
            else
            {
                yourTurn = !board.yourTurn;
            }
        }
      
        protected List<IMove> getMoves(List<Karta> fromHand)
        {
            bool J = false; //J 2 puta
            List<IMove> ret = new List<IMove>();
            if (penalty)
            {
                if (talon.Karte.Last().Broj == "7")
                {
                    foreach (Karta karta in fromHand)
                    {
                        if (karta.Broj == "7")
                        {
                            Move temp = new Move();
                            temp.setKarta(karta);
                            ret.Add(temp);
                        }
                    }
                }
                ret.Add(new Move() { Tip = TipPoteza.KupiKazneneKarte });
            }
            else
            {
                foreach (Karta card in fromHand)
                {
                    if (!J && card.Broj == "J")
                    {
                        J = true;
                        for (int i = 1; i < 5; i++)
                        {
                            Move temp = new Move();
                            temp.setKarta(card);
                            temp.NovaBoja = (Boja)i;
                            temp.Tip = TipPoteza.BacaKartu | TipPoteza.PromeniBoju;
                            ret.Add(temp);
                        }
                    }
                    else
                    {
                        if (isValid(card))
                        {
                            if (card.Broj == "A")
                            {
                                List<Karta> jedinice = new List<Karta>();
                                jedinice.Add(card);

                                combinationsA(jedinice, fromHand, ref ret);
                            }
                            else
                            {
                                
                                Move temp = new Move();
                                temp.setKarta(card);
                                ret.Add(temp);
                                
                            }
                        }
                    }
                }
                if (ret.Count == 0) { 
                if (cardDrawn)
                {
                    ret.Add(new Move() { Tip = TipPoteza.KrajPoteza });
                }
                else
                {
                    ret.Add(new Move() { Tip = TipPoteza.KupiKartu, Karte = new List<Karta>( talon.Karte )});
                }
                }
            }
            return ret;
        }

        protected void combinationsA(List<Karta> A, List<Karta> hand, ref List<IMove> moves)
        {
            bool J = false; //J 2 puta
            List<Karta> localHand = new List<Karta>();
            localHand.AddRange(hand);
            foreach (Karta k in A)
            {
                localHand.Remove(k);
            }
            foreach (Karta k in localHand)
            {
                if (isValid(A.Last(), k))
                {
                    if (k.Broj != "A")
                    {
                        
                        if (!J && k.Broj == "J")
                        {
                            J = true;

                            for (int i = 1; i < 5; i++)
                            {
                                Move temp = new Move();
                                temp.Karte.AddRange(A);
                                temp.Karte.Add(k);
                                temp.NovaBoja = (Boja)i;
                                temp.Tip = TipPoteza.BacaKartu | TipPoteza.PromeniBoju;
                                moves.Add(temp);
                            }
                        }
                        else
                        {
                            Move temp = new Move();
                            temp.Tip = TipPoteza.BacaKartu;
                            temp.Karte.AddRange(A);
                            temp.Karte.Add(k);
                            moves.Add(temp);
                        }
                    }
                    else
                    {
                        List<Karta> pom = new List<Karta>();
                        pom.AddRange(A);
                        pom.Add(k);
                        combinationsA(pom, hand, ref moves);
                    }
                }

            }
            Move kraj = new Move();
            kraj.Karte.AddRange(A);
            kraj.Tip = TipPoteza.BacaKartu;
            moves.Add(kraj);

        }

        protected bool isValid(Karta talon,Karta karta)
        {

            if ((karta.Broj == "J") || ((karta.Boja == talon.Boja) || (talon.Broj == karta.Broj)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool isValid(Karta karta)
        {

            if ((karta.Broj != "J") && ((talon.NovaBoja == Boja.Unknown && karta.Boja == talon.Karte.Last().Boja) || (talon.Karte.Last().Broj == karta.Broj) || (talon.NovaBoja == karta.Boja)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public int evaluation()
        {
            
            int evulationValue = 0;
            if (hand.Count == 0)
            {
                if (talon.Karte.Count != 0)
                {
                    if (talon.Karte.Last().Broj == "A")
                    {
                        evulationValue = -200;
                    }
                    else
                    {
                        evulationValue = -400;
                    }
                }
            }
            else {
                foreach (Karta k in hand)
                {
                    evulationValue += cardPoints(k);
                }
            }

            if (enemyHand == 0)
            {
                evulationValue += 100;
            }
            // avrage card is 8 points
            //evaluacija -= 8 * enemyHand;

            evulationValue -= getMoves(hand).Count;

            if(enemyHand ==0 || hand.Count == 0)
            {
                if (talon.Karte.Count != 0)
                {
                    if (talon.Karte.Last().Broj == "J")
                    {
                        evulationValue *= 2;
                        //shift 2
                    }
                }
            }

            return evulationValue;
        }

        public ulong key()
        {
            ulong ret = 0;
            ret += counter.key()*10000000000;

            foreach(Karta k in hand)
            {
                ret += CardCounter.brojToNumber(k.Broj)*100*((uint)Math.Pow(100 ,((uint)((int)k.Boja))));
            }
            if (penalty)
            {
                ret+=10000000000000000000;
            }
            return ret;
        }

        public int cardPoints(Karta karta)
        {
            switch (karta.Broj)
            {
                case "A": return 13;
                case "2": if (karta.Boja == Boja.Tref) return 10; else return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 10;
                case "8": return 12;
                case "9": return 9;
                case "10": return 10;
                case "J": if (enemyHand > 3) return 1; else return 25;
                case "Q": return 10;
                case "K": return 10;
                default: return 8;
            }
        }
    }
}
