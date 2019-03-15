using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIG.AV.Karte;
using System.Threading;

namespace MauMauGame
{
    public partial class GameView : Form, View
    {
        protected Controller controller;
        List<PictureBox> hand;

        protected static Bitmap[] karteSlike = { new Bitmap(Karte.KaroA), new Bitmap(Karte.Karo2),new Bitmap(Karte.Karo3), new Bitmap(Karte.Karo4), new Bitmap(Karte.Karo5), new Bitmap(Karte.Karo6), new Bitmap(Karte.Karo7), new Bitmap(Karte.Karo8), new Bitmap(Karte.Karo9), new Bitmap(Karte.Karo10), new Bitmap(Karte.KaroJ), new Bitmap(Karte.KaroQ), new Bitmap(Karte.KaroK)
                                                ,new Bitmap(Karte.PikA), new Bitmap(Karte.Pik2), new Bitmap(Karte.Pik3), new Bitmap(Karte.Pik4), new Bitmap(Karte.Pik5), new Bitmap(Karte.Pik6), new Bitmap(Karte.Pik7), new Bitmap(Karte.Pik8), new Bitmap(Karte.Pik9), new Bitmap(Karte.Pik10), new Bitmap(Karte.PikJ), new Bitmap(Karte.PikQ), new Bitmap(Karte.PikK)
                                                ,new Bitmap(Karte.HerzA), new Bitmap(Karte.Herz2), new Bitmap(Karte.Herz3), new Bitmap(Karte.Herz4), new Bitmap(Karte.Herz5), new Bitmap(Karte.Herz6), new Bitmap(Karte.Herz7), new Bitmap(Karte.Herz8), new Bitmap(Karte.Herz9), new Bitmap(Karte.Herz10), new Bitmap(Karte.HerzJ), new Bitmap(Karte.HerzQ), new Bitmap(Karte.HerzK)
                                                ,new Bitmap(Karte.TrefA), new Bitmap(Karte.Tref2), new Bitmap(Karte.Tref3), new Bitmap(Karte.Tref4), new Bitmap(Karte.Tref5), new Bitmap(Karte.Tref6), new Bitmap(Karte.Tref7), new Bitmap(Karte.Tref8), new Bitmap(Karte.Tref9), new Bitmap(Karte.Tref10), new Bitmap(Karte.TrefJ), new Bitmap(Karte.TrefQ), new Bitmap(Karte.TrefK)
                                                ,new Bitmap(Karte.BackGround) };

        protected static Bitmap[] bacenekarteSlike = { new Bitmap(BaceneKarte.KaroA), new Bitmap(BaceneKarte.Karo2),new Bitmap(BaceneKarte.Karo3), new Bitmap(BaceneKarte.Karo4), new Bitmap(BaceneKarte.Karo5), new Bitmap(BaceneKarte.Karo6), new Bitmap(BaceneKarte.Karo7), new Bitmap(BaceneKarte.Karo8), new Bitmap(BaceneKarte.Karo9), new Bitmap(BaceneKarte.Karo10), new Bitmap(BaceneKarte.KaroJ), new Bitmap(BaceneKarte.KaroQ), new Bitmap(BaceneKarte.KaroK)
                                                ,new Bitmap(BaceneKarte.PikA), new Bitmap(BaceneKarte.Pik2), new Bitmap(BaceneKarte.Pik3), new Bitmap(BaceneKarte.Pik4), new Bitmap(BaceneKarte.Pik5), new Bitmap(BaceneKarte.Pik6), new Bitmap(BaceneKarte.Pik7), new Bitmap(BaceneKarte.Pik8), new Bitmap(BaceneKarte.Pik9), new Bitmap(BaceneKarte.Pik10), new Bitmap(BaceneKarte.PikJ), new Bitmap(BaceneKarte.PikQ), new Bitmap(BaceneKarte.PikK)
                                                ,new Bitmap(BaceneKarte.HerzA), new Bitmap(BaceneKarte.Herz2), new Bitmap(BaceneKarte.Herz3), new Bitmap(BaceneKarte.Herz4), new Bitmap(BaceneKarte.Herz5), new Bitmap(BaceneKarte.Herz6), new Bitmap(BaceneKarte.Herz7), new Bitmap(BaceneKarte.Herz8), new Bitmap(BaceneKarte.Herz9), new Bitmap(BaceneKarte.Herz10), new Bitmap(BaceneKarte.HerzJ), new Bitmap(BaceneKarte.HerzQ), new Bitmap(BaceneKarte.HerzK)
                                                ,new Bitmap(BaceneKarte.TrefA), new Bitmap(BaceneKarte.Tref2), new Bitmap(BaceneKarte.Tref3), new Bitmap(BaceneKarte.Tref4), new Bitmap(BaceneKarte.Tref5), new Bitmap(BaceneKarte.Tref6), new Bitmap(BaceneKarte.Tref7), new Bitmap(BaceneKarte.Tref8), new Bitmap(BaceneKarte.Tref9), new Bitmap(BaceneKarte.Tref10), new Bitmap(BaceneKarte.TrefJ), new Bitmap(BaceneKarte.TrefQ), new Bitmap(BaceneKarte.TrefK)
                                                ,new Bitmap(BaceneKarte.BackGround) };


        protected static Bitmap[] znakSlika = { null, new Bitmap(Ostalo.karo), new Bitmap(Ostalo.pik), new Bitmap(Ostalo.herz), new Bitmap(Ostalo.tref) };

        protected static Bitmap[] flegovi = { new Bitmap(Ostalo.kartaKupljenaActive), new Bitmap(Ostalo.kartaKupljena), new Bitmap(Ostalo.kaznaActive), new Bitmap(Ostalo.kazna), new Bitmap(Ostalo.yourTurnA),new Bitmap(Ostalo.yourTurn) };

        public GameView()
        {
            //Initialize components
            InitializeComponent();
            imageFaceCard.BackColor = Color.Transparent;
            yourHand.BackColor = Color.Transparent;
            enemyHand.BackColor = Color.Transparent;
            BackgroundImage = Ostalo.background;
            draw.Image = bacenekarteSlike[52];
            draw.BackColor = Color.Transparent;
            znak.BackColor = Color.Transparent;
            kaznaFleg.BackColor = Color.Transparent;
            kupiFleg.BackColor = Color.Transparent;
            turnFleg.BackColor = Color.Transparent;
            this.Refresh();

            hand = new List<PictureBox>();
            disableInput();
            controller = new Controller(this);
            enableInput();
        }


        public void updateEnemyHand(int karte)
        {
            enemyHand.Controls.Clear();
            for(int i = 0; i < karte; i++) 
            {
                PictureBox pom = new PictureBox();
                pom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pom.Image = karteSlike[52];

                pom.Height = 80;
                pom.Width = 50;
                enemyHand.Controls.Add(pom);
                
            }
            enemyHand.Refresh();
        }

        public void updateTalon(Karta k, Boja b)
        {
                imageFaceCard.Image = bacenekarteSlike[indexKarte(k)];
                znak.Image = znakSlika[(int)b];

            imageFaceCard.Refresh();
            znak.Refresh();
        }

        public void updateYourHand(List<Karta> k)
        {
                yourHand.Controls.Clear();
                hand.Clear();

                foreach (Karta karta in k)
                {
                    PictureBox pom = new PictureBox();
                    pom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pom.Image = karteSlike[indexKarte(karta)];

                    pom.Height = 80;
                    pom.Width = 50;
                    pom.Click += playCard;
                    hand.Add(pom);

                    yourHand.Controls.Add(pom);
                }


            yourHand.Refresh();
        }

        private void playCard(object sender, EventArgs e)
        {
            bool pom = endTurn.Visible;
            disableInput();
            if(!controller.playCard(hand.IndexOf(sender as PictureBox)))
            {
                endTurn.Visible = pom;
            }
            enableInput();
        }

        protected void disableInput()
        {
            
            foreach (PictureBox a in hand)
            {
                a.Enabled = false;
                a.Refresh();
            }
            draw.Enabled = false;
            draw.Refresh();
            endTurn.Visible = false;
            yourHand.UseWaitCursor = true;
            yourHand.Refresh();

        }
        protected void enableInput()
        {
            foreach (PictureBox a in hand)
            {
                a.Enabled = true;
                a.Refresh();
            }
            draw.Enabled = true;
            draw.Refresh();
            turnFleg.Image = flegovi[4];
            turnFleg.Refresh();
            tvojPotez.SetToolTip(turnFleg, "It's your turn");

            yourHand.UseWaitCursor = false;
        }

        static protected int indexKarte(Karta k)
        {
            int pom = 0;
            pom += ((int)k.Boja - 1) * 13;
            switch (k.Broj)
            {
                case "A": pom += 0; break;
                case "2": pom += 1; break;
                case "3": pom += 2; break;
                case "4": pom += 3; break;
                case "5": pom += 4; break;
                case "6": pom += 5; break;
                case "7": pom += 6; break;
                case "8": pom += 7; break;
                case "9": pom += 8; break;
                case "10": pom += 9; break;
                case "J": pom += 10; break;
                case "Q": pom += 11; break;
                case "K": pom += 12; break;
            }
            return pom;
        }

        private void draw_Click(object sender, EventArgs e)
        {

            disableInput();
            if (controller.draw() == 1)
            {
                endTurn.Visible = true;
            }
            enableInput();
        }

        public void updatePoints(int your, int enemy)
        {
            playerPoints.Text = your.ToString();
            enemyPoints.Text = enemy.ToString();
            playerPoints.Refresh();
            enemyPoints.Refresh();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disableInput();
            controller.newGame();
            enableInput();
        }

        public void endOfRound(int tvoj, int protivnik)
        {
            krajRundeTvoj.Text = tvoj.ToString();
            krajrundeProtivnikovi.Text = protivnik.ToString();

            krajRundeTvoj.Visible = true;
            krajrundeProtivnikovi.Visible = true;
            krajRundeTvoj.Refresh();
            krajrundeProtivnikovi.Refresh();

            Thread.Sleep(2500);

            krajRundeTvoj.Visible = false;
            krajrundeProtivnikovi.Visible = false;
            krajRundeTvoj.Refresh();
            krajrundeProtivnikovi.Refresh();

        }

        private void endTurn_Click(object sender, EventArgs e)
        {
            disableInput();
            controller.draw();
            enableInput();
        }

        public void penalty(bool k)
        {
            if (k)
            {
                kaznaFleg.Image = flegovi[2];
                kazneneKarte.SetToolTip(kaznaFleg, "You need to draw penalty cards");
            }
            else
            {
                kaznaFleg.Image = flegovi[3];
                kazneneKarte.SetToolTip(kaznaFleg, "There is no penalty active");
            }
            kaznaFleg.Refresh();
        }

        public void drawCards(bool k)
        {
            if (k)
            {
                kupiFleg.Image = flegovi[0];
                kupiKartu.SetToolTip(kupiFleg, "You can draw a card");
            }
            else
            {
                kupiFleg.Image = flegovi[1];
                kupiKartu.SetToolTip(kupiFleg, "You already drew a card");
            }
            kaznaFleg.Refresh();
        }

        public void yourTurn(bool t)
        {
            if (t)
            {
                turnFleg.Image = flegovi[4];
                tvojPotez.SetToolTip(turnFleg, "It's your turn");
                
            }
            else
            {
                turnFleg.Image = flegovi[5];
                tvojPotez.SetToolTip(turnFleg, "It's not your turn, please wait!");
            }
            turnFleg.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
