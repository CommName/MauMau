using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using System.Windows.Forms;

namespace MauMauGame
{
    public class Controller
    {
        View pogled;
        Engine game;
        PlayerUser igrac;
        int yourPoints, enemyPoints;

        public Controller(View view)
        {
            pogled = view;
            newGame();
        }
        public void newGame()
        {
            yourPoints = 0;
            enemyPoints = 0;
            newRound();

        }
        protected void newRound()
        {
            
            game = new Engine(1);
            if (game.player1.bot == null)
            {
                igrac = game.player1;
            }
            else
            {
                igrac = game.player2;
            }

            updateView();
            playEnemyTurn();
            flags();
        }


        public void updateView()
        {
            pogled.updateTalon(game.topCard,game.suit);
            pogled.updateYourHand(igrac.Hand);
            pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
            pogled.updatePoints(yourPoints, enemyPoints);
        }
        protected void gameover()
        {
            int player=0, bot=0;
            if (igrac.Hand.Count == 0)
            {
                bool J = game.topCard.Broj == "J";
                player += J?-40:-20;
                foreach(TIG.AV.Karte.Karta k in igrac.nextPlayer.Hand)
                {
                    bot += J?Engine.vrednostKarte(k)*2:Engine.vrednostKarte(k);
                }
            }
            else if (igrac.nextPlayer.Hand.Count == 0)
            {
                bool J = game.topCard.Broj == "J";
                bot += J ? -40 : -20;
                foreach (TIG.AV.Karte.Karta k in igrac.Hand)
                {
                    player += J ? Engine.vrednostKarte(k) * 2 : Engine.vrednostKarte(k);
                }
            }
            else
            {
                foreach (TIG.AV.Karte.Karta k in igrac.nextPlayer.Hand)
                {
                    bot += Engine.vrednostKarte(k);
                }

                foreach (TIG.AV.Karte.Karta k in igrac.Hand)
                {
                    player += Engine.vrednostKarte(k);
                }
            }
            yourPoints += player;
            enemyPoints += bot;
            pogled.endOfRound(player, bot);
            pogled.updatePoints(yourPoints, enemyPoints);
            if (yourPoints < 100 && enemyPoints < 100)
            {
                newRound();
            }
            else
            {
                if (yourPoints < 100)
                {
                    MessageBox.Show("Congratulations, you won", "Winner");
                }
                else
                {
                    MessageBox.Show("You lost, better luck next time", "Loser");
                }
            }
        }
        protected void flags()
        {
            pogled.penalty(game.isPenaltyActive);
            pogled.drawCards(game.canDrawCards);
        }
        protected void playYourturn()
        {
            if (game.current.bot == null&&!game.Game())
            {
                pogled.updateYourHand(igrac.Hand);
                pogled.updateTalon(game.topCard, game.suit);
                gameover();
                return;
            }

            pogled.updateYourHand(igrac.Hand);
            pogled.updateTalon(game.topCard, game.suit);
            if (game.gameOver())
            {
                gameover();
            }
            else
            {
                playEnemyTurn();
            }
            flags();
        }
        protected void playEnemyTurn()
        {
            if(game.current.bot != null)
            {
                pogled.yourTurn(false);
            }
            while (game.current.bot != null)
            {
                if (game.Game())
                {
                    pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
                    pogled.updateTalon(game.topCard, game.suit);
                }
                else
                {
                    pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
                    pogled.updateTalon(game.topCard, game.suit);
                    gameover();
                    return;
                }

            }
            pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
            pogled.updateTalon(game.topCard, game.suit);
            if (game.gameOver())
            {
                gameover();
            }
            pogled.yourTurn(true);

        }

        public int draw()
        {
            if (game.isPenaltyActive)
            {
                igrac.manualPlay(0, TIG.AV.Karte.TipPoteza.KupiKazneneKarte, TIG.AV.Karte.Boja.Unknown);
                playYourturn();
                return 0;
            }
            else if (game.canDrawCards)
            {
                igrac.manualPlay(0, TIG.AV.Karte.TipPoteza.KupiKartu, TIG.AV.Karte.Boja.Unknown);
                playYourturn();
                return 1;
            }
            else
            {
                igrac.manualPlay(0, TIG.AV.Karte.TipPoteza.KrajPoteza, TIG.AV.Karte.Boja.Unknown);
                playYourturn();
                return 2;
            }
            return -1;
        }
        public bool playCard(int i)
        {
            if (game.isValid(igrac.Hand[i]))
            {
                if (game.isPenaltyActive)
                {
                    if (game.topCard.Broj == "2")
                    {
                        MessageBox.Show("You have to buy penalty cards first!");
                        return false;
                    }
                    if (!(game.topCard.Broj == "7" && igrac.Hand[i].Broj == "7"))
                    { 
                        MessageBox.Show("You have to buy penalty cards first!");
                        return false;
                    }
                }
                if (igrac.Hand[i].Broj == "J")
                {
                    chose_suit znak = new chose_suit();
                    znak.Location = Cursor.Position;
                    if (znak.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        igrac.manualPlay(i, TIG.AV.Karte.TipPoteza.BacaKartu | TIG.AV.Karte.TipPoteza.PromeniBoju, znak.boja);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    igrac.manualPlay(i, TIG.AV.Karte.TipPoteza.BacaKartu, TIG.AV.Karte.Boja.Unknown);
                }
                playYourturn();
                return true;
            }
            return false;
        }

    }
}
