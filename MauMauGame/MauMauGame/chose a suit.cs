using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MauMauGame
{
    public partial class chose_suit : Form
    {
        public TIG.AV.Karte.Boja boja { get; set; }
        public chose_suit()
        {
            InitializeComponent();
            DialogResult= DialogResult.Cancel;
            boja = TIG.AV.Karte.Boja.Unknown;
        }

        private void pik_Click(object sender, EventArgs e)
        {
            boja = TIG.AV.Karte.Boja.Pik;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void hertz_Click(object sender, EventArgs e)
        {
            boja = TIG.AV.Karte.Boja.Herz;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void karo_Click(object sender, EventArgs e)
        {
            boja = TIG.AV.Karte.Boja.Karo;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            boja = TIG.AV.Karte.Boja.Tref;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
