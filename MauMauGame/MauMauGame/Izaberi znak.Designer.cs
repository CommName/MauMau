namespace MauMauGame
{
    partial class izaber_znak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(izaber_znak));
            this.label1 = new System.Windows.Forms.Label();
            this.hertz = new System.Windows.Forms.PictureBox();
            this.pik = new System.Windows.Forms.PictureBox();
            this.tref = new System.Windows.Forms.PictureBox();
            this.karo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hertz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tref)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.karo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // hertz
            // 
            resources.ApplyResources(this.hertz, "hertz");
            this.hertz.BackColor = System.Drawing.SystemColors.Control;
            this.hertz.Image = global::MauMauGame.Ostalo.herz;
            this.hertz.Name = "hertz";
            this.hertz.TabStop = false;
            this.hertz.Click += new System.EventHandler(this.hertz_Click);
            // 
            // pik
            // 
            resources.ApplyResources(this.pik, "pik");
            this.pik.BackColor = System.Drawing.SystemColors.Control;
            this.pik.Image = global::MauMauGame.Ostalo.pik;
            this.pik.Name = "pik";
            this.pik.TabStop = false;
            this.pik.Click += new System.EventHandler(this.pik_Click);
            // 
            // tref
            // 
            resources.ApplyResources(this.tref, "tref");
            this.tref.Image = global::MauMauGame.Ostalo.tref;
            this.tref.Name = "tref";
            this.tref.TabStop = false;
            this.tref.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // karo
            // 
            resources.ApplyResources(this.karo, "karo");
            this.karo.Image = global::MauMauGame.Ostalo.karo;
            this.karo.Name = "karo";
            this.karo.TabStop = false;
            this.karo.Click += new System.EventHandler(this.karo_Click);
            // 
            // izaber_znak
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hertz);
            this.Controls.Add(this.pik);
            this.Controls.Add(this.tref);
            this.Controls.Add(this.karo);
            this.Name = "izaber_znak";
            ((System.ComponentModel.ISupportInitialize)(this.hertz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tref)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.karo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox karo;
        private System.Windows.Forms.PictureBox tref;
        private System.Windows.Forms.PictureBox pik;
        private System.Windows.Forms.PictureBox hertz;
        private System.Windows.Forms.Label label1;
    }
}