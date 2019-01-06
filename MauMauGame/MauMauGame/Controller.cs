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
            novaIgra();
        }
        public void novaIgra()
        {
            yourPoints = 0;
            enemyPoints = 0;
            novaRunda();

        }
        protected void novaRunda()
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
        }


        protected void updateView()
        {
            pogled.updateTalon(game.topCard,game.boja);
            pogled.updateYourHand(igrac.Hand);
            pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
            pogled.updatePoints(yourPoints, enemyPoints);
        }
        protected void gameover()
        {
            if (igrac.Hand.Count == 0)
            {
                bool J = game.topCard.Broj == "J";
                yourPoints += J?-40:-20;
                foreach(TIG.AV.Karte.Karta k in igrac.nextPlayer.Hand)
                {
                    enemyPoints += J?Engine.vrednostKarte(k)*2:Engine.vrednostKarte(k);
                }
            }
            else if (igrac.nextPlayer.Hand.Count == 0)
            {
                bool J = game.topCard.Broj == "J";
                enemyPoints += J ? -40 : -20;
                foreach (TIG.AV.Karte.Karta k in igrac.Hand)
                {
                    yourPoints += J ? Engine.vrednostKarte(k) * 2 : Engine.vrednostKarte(k);
                }
            }
            pogled.updatePoints(yourPoints, enemyPoints);
            if (yourPoints < 100 && enemyPoints < 100)
            {
                novaRunda();
            }
            else
            {
                if (yourPoints < 100)
                {
                    MessageBox.Show("Cestitam pobedili ste", "POBEDNIK");
                }
                else
                {
                    MessageBox.Show("Izgubili ste", "");
                }
            }
        }

        protected void playYourturn()
        {
            if (game.current.bot == null&&!game.Game())
            {
                gameover();
            }

            pogled.updateYourHand(igrac.Hand);
            pogled.updateTalon(game.topCard, game.boja);
            if (game.gameOver())
            {
                gameover();
            }
            else
            {
                playEnemyTurn();
            }
        }
        protected void playEnemyTurn()
        {

            while (game.current.bot != null&& game.Game())
            {
               
                    pogled.updateEnemyHand(igrac.nextPlayer.Hand.Count);
                    pogled.updateTalon(game.topCard, game.boja);

            }
            if (game.gameOver())
            {
                gameover();
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
            else
            {
                igrac.manualPlay(0, TIG.AV.Karte.TipPoteza.KrajPoteza, TIG.AV.Karte.Boja.Unknown);
            }
            playYourturn();
        }
        public void playCard(int i)
        {
            if (game.isValid(igrac.Hand[i]))
            {
                if (game.kupiKaznene)
                {
                    if (game.topCard.Broj == "2")
                    {
                        MessageBox.Show("Potrebno je kupiti kaznene karte!");
                        return;
                    }
                    if (!(game.topCard.Broj == "7" && igrac.Hand[i].Broj == "7"))
                    { 
                        MessageBox.Show("Potrebno je kupiti kaznene karte!");
                        return;
                    }
                }
                if (igrac.Hand[i].Broj == "J")
                {
                    izaber_znak znak = new izaber_znak();
                    if (znak.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        igrac.manualPlay(i, TIG.AV.Karte.TipPoteza.BacaKartu | TIG.AV.Karte.TipPoteza.PromeniBoju, znak.boja);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    igrac.manualPlay(i, TIG.AV.Karte.TipPoteza.BacaKartu, TIG.AV.Karte.Boja.Unknown);
                }
                playYourturn();
            }
        }

    }
}
