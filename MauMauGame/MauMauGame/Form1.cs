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

namespace MauMauGame
{
    public partial class GameView : Form, View
    {
        protected Controller controller;
        List<PictureBox> hand;

        protected static Bitmap[] karteSlike = { new Bitmap(Karte.KaroA), new Bitmap(Karte.Karo2),new Bitmap(Karte.Karo3), new Bitmap(Karte.Karo4), new Bitmap(Karte.Karo5), new Bitmap(Karte.Karo6), new Bitmap(Karte.Karo7), new Bitmap(Karte.Karo8), new Bitmap(Karte.Karo9), new Bitmap(Karte.Karo10), new Bitmap(Karte.KaroJ), new Bitmap(Karte.KaroQ), new Bitmap(Karte.KaroK)
                                                ,new Bitmap(Karte.PikA), new Bitmap(Karte.Pik2), new Bitmap(Karte.Pik3), new Bitmap(Karte.Pik4), new Bitmap(Karte.Pik5), new Bitmap(Karte.Pik6), new Bitmap(Karte.Pik7), new Bitmap(Karte.Pik8), new Bitmap(Karte.Pik9), new Bitmap(Karte.Pik10), new Bitmap(Karte.PikJ), new Bitmap(Karte.PikQ), new Bitmap(Karte.PikK)
                                                ,new Bitmap(Karte.HerzA), new Bitmap(Karte.Herz2), new Bitmap(Karte.Herz3), new Bitmap(Karte.Herz4), new Bitmap(Karte.Herz5), new Bitmap(Karte.Herz6), new Bitmap(Karte.Herz7), new Bitmap(Karte.Herz8), new Bitmap(Karte.Herz9), new Bitmap(Karte.Herz10), new Bitmap(Karte.HerzJ), new Bitmap(Karte.HerzQ), new Bitmap(Karte.HerzK)
                                                ,new Bitmap(Karte.TrefA), new Bitmap(Karte.Tref2), new Bitmap(Karte.Tref3), new Bitmap(Karte.Tref4), new Bitmap(Karte.Tref5), new Bitmap(Karte.Tref6), new Bitmap(Karte.Tref7), new Bitmap(Karte.Tref8), new Bitmap(Karte.Tref9), new Bitmap(Karte.Tref10), new Bitmap(Karte.TrefJ), new Bitmap(Karte.TrefQ), new Bitmap(Karte.TrefK) };




        public GameView()
        {
            InitializeComponent();
            hand = new List<PictureBox>();
            controller = new Controller(this);
        }

        public void updateEnemyHand(int karte)
        {
            enemyHand.Text = karte.ToString();
        }

        public void updateTalon(Karta k, Boja b)
        {
            
            imageFaceCard.Image = karteSlike[indexKarte(k)];
        }

        public void updateYourHand(List<Karta> k)
        {
            //yourHand.Controls.Clear();
            
            foreach(Karta karta in k)
            {
                PictureBox pom = new PictureBox();
                pom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pom.Image=karteSlike[indexKarte(karta)];
               
                pom.Height = 80;
                pom.Width = 50;
                hand.Add(pom);
                

               
                yourHand.Controls.Add(pom);
                //yourHand.Controls.Add(test);
            }
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
    }
}
