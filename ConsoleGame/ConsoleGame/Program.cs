using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using TIG.AV.Karte;

namespace ConsoleGame
{

    class Program
    {
        static void igra() {

            GameEngine.Engine game = new GameEngine.Engine();

            //while (!game.gameOver())
            game.player1.name = "player 1";
            game.player2.name = "player 2";

            Console.WriteLine(game.player1);
            Console.WriteLine(game.player2);

            try
            {
                do
                {

                    Console.WriteLine(game.topCard.Boja + " " + game.topCard.Broj + " " + game.boja);
                    Console.WriteLine(game.current);

                    /*Console.WriteLine("Tip poteza: Kupi kartu (1),Kupi kaznenu kartu(2),Promeni boju (8), Baca kartu(16), Kraj Poteza(512) ");
                    TIG.AV.Karte.TipPoteza tip = (TIG.AV.Karte.TipPoteza)Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Redni broj karte za bacanje ");
                    int karta = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Boja: unknown (0), Karo(1),Pik(2),Herz(3),Tref(4)");
                    TIG.AV.Karte.Boja boja = (TIG.AV.Karte.Boja)Int32.Parse(Console.ReadLine());
                    
                    game.current.manualPlay(karta, tip, boja);
                    */


                } while (game.Game());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void specCase()
        {
            PlayerUser bot = new PlayerUser(true);

            //Prethodne karte
            Console.WriteLine("Broj prethodnih karata");
            int broj = Int32.Parse(Console.ReadLine().ToString());
            Console.WriteLine("Upisite prethodne karte");
            List<Karta> ruka = new List<Karta>();
            for (int i = 0; i < broj; i++)
            {
                Karta karta = new Karta();
                karta.Boja = (TIG.AV.Karte.Boja)(Console.Read()-'0');
                Console.Read();
                karta.Broj = Console.ReadLine().ToString();
                ruka.Add(karta);
            }
            bot.Bacenekarte(ruka, Boja.Unknown, 5);
            //Trenutno karte
            Console.WriteLine("Unesite broj trenutnih karata");
            ruka.Clear();
            broj = Int32.Parse(Console.ReadLine().ToString());
            for(int i = 0; i < broj; i++)
            {
                Karta karta = new Karta();
                karta.Boja = (TIG.AV.Karte.Boja)(Console.Read() -'0') ;
                Console.Read();
                karta.Broj = Console.ReadLine().ToString();
                ruka.Add(karta);
            }
            bot.SetRuka(ruka);
            //Talon
            Console.WriteLine("Talon");

            Karta k = new Karta();
            k.Boja = (TIG.AV.Karte.Boja)(Console.Read()-'0');
            Console.Read();
            k.Broj = Console.ReadLine().ToString();
            ruka.Clear();
            ruka.Add(k);
            Console.WriteLine("Broj karata protivnika");
            int br = Int32.Parse(Console.ReadLine());
            bot.Bacenekarte(ruka, Boja.Unknown, br);

            Console.WriteLine(bot.ToString());
            Console.WriteLine(k.Boja + " " + k.Broj);
            bot.findBestMoce();

            Console.Write(bot.BestMove.NovaBoja.ToString() + " " + bot.BestMove.Tip.ToString());
            foreach (Karta p in bot.BestMove.Karte)
            {
                Console.Write(p.Boja.ToString() + " " + p.Broj + "| ");
            }


        }


        static void Main(string[] args)
        {

            
            //igra();
            specCase();

        }
    }
}
