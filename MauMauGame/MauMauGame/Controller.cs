using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;


namespace MauMauGame
{
    public class Controller
    {
        View pogled;
        Engine game;
        PlayerUser igrac;

        public Controller(View view)
        {
            pogled = view;
            game = new Engine(1);
            if (game.player1.bot != null)
            {
                igrac = game.player1;
            }
            else
            {
                igrac = game.player2;
            }

            updateView();
        }

        void updateView()
        {
            pogled.updateTalon(game.topCard,game.boja);
            pogled.updateYourHand(igrac.Hand);
            pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
        }

    }
}
