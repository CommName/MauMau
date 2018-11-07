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
        static void Main(string[] args)
        {


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
                    Console.WriteLine(game.current);
                    Console.WriteLine(game.topCard.Boja + " " + game.topCard.Broj + " " + game.boja);

                    Console.WriteLine("Tip poteza: Kupi kartu (1),Kupi kaznenu kartu(2),Promeni boju (8), Baca kartu(16), Kraj Poteza(512) ");
                    TIG.AV.Karte.TipPoteza tip = (TIG.AV.Karte.TipPoteza)Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Redni broj karte za bacanje ");
                    int karta = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Boja: unknown (0), Karo(1),Pik(2),Herz(3),Tref(4)");
                    TIG.AV.Karte.Boja boja = (TIG.AV.Karte.Boja)Int32.Parse(Console.ReadLine());

                    game.current.manualPlay(karta, tip, boja);



                } while (game.Game());
            }
            catch(Exception e)
            {
               Console.WriteLine(e.Message);
            }


        }
    }
}
