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
            playEnemyTurn();
        }

        protected void updateView()
        {
            pogled.updateTalon(game.topCard,game.boja);
            pogled.updateYourHand(igrac.Hand);
            pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
        }

        protected void playYourturn()
        {
            if (game.Game())
            {

            }
            pogled.updateYourHand(igrac.Hand);
            pogled.updateTalon(game.topCard, game.boja);
            playEnemyTurn();
        }
        protected void playEnemyTurn()
        {
            while (game.Game() && game.current != igrac)
            {
                pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
                pogled.updateTalon(game.topCard, game.boja);
            }
        }

        public void draw()
        {
            if (game.kupiKaznene)
            {
                igrac.manualPlay(0, TIG.AV.Karte.TipPoteza.KupiKazneneKarte, TIG.AV.Karte.Boja.Unknown);
            }
            else if (game.KupiKartu)
            {
                igrac.manualPlay(0, TIG.AV.Karte.TipPoteza.KupiKartu, TIG.AV.Karte.Boja.Unknown);
            }
        }

    }
}
