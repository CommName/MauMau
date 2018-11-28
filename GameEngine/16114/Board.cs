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

        public List<IMove> moves { get
            {

                if (yourTurn)
                {
                    return getMoves(hand);
                }
                else
                {
                    return getMoves(counter.valid(talon.Karte.Last(), talon.NovaBoja, enemyHand));
                }
            } }


        public bool kazna { get; set; }
        public bool kupio { get; set; }

        public Board()
        {
            hand = new List<Karta>();
            kazna = false;
            kupio = false;

        }
        public Board(IMove lastMove, bool turn, List<Karta> yourHand, int enemy, CardCounter used,bool kaznene) : this()
        {
            lock (Gilgamesh._locker)
            {
                counter = new CardCounter(used);
                talon = lastMove;
                if (yourHand != null && yourHand.Count > 0)
                {
                    hand.AddRange(yourHand);
                }
                enemyHand = enemy;
                counter.remove(lastMove.Karte);
                yourTurn = turn;

                if (lastMove.Tip == TipPoteza.BacaKartu && lastMove.Karte.Count > 0 && (lastMove.Karte.Last().Broj == "7" || (lastMove.Karte.Last().Broj == "2" && lastMove.Karte.Last().Boja == Boja.Tref)) && !kaznene)
                {
                    kazna = true;
                }
            }
        }
        public Board(Board board, IMove move) : this()
        {
            counter = new CardCounter(board.counter);
            talon = move;
            enemyHand = board.enemyHand;
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
                kazna = true;
            }
            else
            {
                kazna = false;
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
            if (kazna)
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
                foreach (Karta karta in fromHand)
                {
                    if (!J && karta.Broj == "J")
                    {
                        J = true;
                        for (int i = 1; i < 5; i++)
                        {
                            Move temp = new Move();
                            temp.setKarta(karta);
                            temp.NovaBoja = (Boja)i;
                            temp.Tip = TipPoteza.BacaKartu | TipPoteza.PromeniBoju;
                            ret.Add(temp);
                        }
                    }
                    else
                    {
                        if (isValid(karta))
                        {
                            if (karta.Broj == "A")
                            {
                                List<Karta> jedinice = new List<Karta>();
                                jedinice.Add(karta);

                                kombinacijeA(jedinice, fromHand, ref ret);
                            }
                            else
                            {
                                
                                Move temp = new Move();
                                temp.setKarta(karta);
                                ret.Add(temp);
                                
                            }
                        }
                    }
                }

                if (kupio)
                {
                    ret.Add(new Move() { Tip = TipPoteza.KrajPoteza });
                }
                else
                {
                    ret.Add(new Move() { Tip = TipPoteza.KupiKartu, Karte = new List<Karta>( talon.Karte )});
                }
            }
            return ret;
        }

        protected void kombinacijeA(List<Karta> kec, List<Karta> hand, ref List<IMove> moves)
        {
            bool J = false; //J 2 puta
            List<Karta> localHand = new List<Karta>();
            localHand.AddRange(hand);
            foreach (Karta k in kec)
            {
                localHand.Remove(k);
            }
            foreach (Karta k in localHand)
            {
                if (isValid(kec.Last(), k))
                {
                    if (k.Broj != "A")
                    {
                        
                        if (!J && k.Broj == "J")
                        {
                            J = true;

                            for (int i = 1; i < 5; i++)
                            {
                                Move temp = new Move();
                                temp.Karte.AddRange(kec);
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
                            temp.Karte.AddRange(kec);
                            temp.Karte.Add(k);
                            moves.Add(temp);
                        }
                    }
                    else
                    {
                        List<Karta> pom = new List<Karta>();
                        pom.AddRange(kec);
                        pom.Add(k);
                        kombinacijeA(pom, hand, ref moves);
                    }
                }

            }
            Move kraj = new Move();
            kraj.Karte.AddRange(kec);
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
            
            int evaluacija = 0;
            if (hand.Count == 0)
            {
                if (talon.Karte.Count != 0)
                {
                    if (talon.Karte.Last().Broj == "A")
                    {
                        evaluacija = -200;
                    }
                    else
                    {
                        evaluacija = -400;
                    }
                }
            }
            else {
                foreach (Karta k in hand)
                {
                    evaluacija += cardPoints(k);
                }
            }
            // avrage card is 8 points
            evaluacija -= 8 * enemyHand;

            evaluacija -= getMoves(hand).Count * 8;

            if(enemyHand ==0 || hand.Count == 0)
            {
                if (talon.Karte.Count != 0)
                {
                    if (talon.Karte.Last().Broj == "J")
                    {
                        evaluacija *= 2;
                        //shift 2
                    }
                }
            }

            return evaluacija;
        }

        public static int cardPoints(Karta karta)
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
                case "J": return 10;
                case "Q": return 10;
                case "K": return 10;
                default: return 8;
            }
        }
    }
}
