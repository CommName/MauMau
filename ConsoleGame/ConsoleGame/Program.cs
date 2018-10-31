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
            {
               Console.WriteLine(Engine.handToString(game.player1));
               Console.WriteLine(Engine.handToString(game.player2));





            }


        }
    }
}
