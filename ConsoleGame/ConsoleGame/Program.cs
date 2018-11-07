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

            do
            {
                Console.WriteLine(game.current);
                Console.WriteLine("Tip poteza: BacaKartu, ")


            } while (game.Game());


        }
    }
}
