﻿namespace MauMauGame
{
    partial class GameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.yourHand = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyHand = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerPoints = new System.Windows.Forms.Label();
            this.enemyPoints = new System.Windows.Forms.Label();
            this.znak = new System.Windows.Forms.PictureBox();
            this.draw = new System.Windows.Forms.PictureBox();
            this.imageFaceCard = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.znak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.draw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).BeginInit();
            this.SuspendLayout();
            // 
            // yourHand
            // 
            this.yourHand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yourHand.AutoScroll = true;
            this.yourHand.Location = new System.Drawing.Point(164, 394);
            this.yourHand.MaximumSize = new System.Drawing.Size(350, 100);
            this.yourHand.MinimumSize = new System.Drawing.Size(350, 105);
            this.yourHand.Name = "yourHand";
            this.yourHand.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.yourHand.Size = new System.Drawing.Size(350, 105);
            this.yourHand.TabIndex = 6;
            this.yourHand.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // enemyHand
            // 
            this.enemyHand.Location = new System.Drawing.Point(164, 28);
            this.enemyHand.MaximumSize = new System.Drawing.Size(350, 100);
            this.enemyHand.MinimumSize = new System.Drawing.Size(350, 100);
            this.enemyHand.Name = "enemyHand";
            this.enemyHand.Size = new System.Drawing.Size(350, 100);
            this.enemyHand.TabIndex = 9;
            this.enemyHand.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tvoj poeni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Protivnikovi poeni";
            // 
            // playerPoints
            // 
            this.playerPoints.AutoSize = true;
            this.playerPoints.BackColor = System.Drawing.Color.Transparent;
            this.playerPoints.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerPoints.ForeColor = System.Drawing.Color.White;
            this.playerPoints.Location = new System.Drawing.Point(1, 45);
            this.playerPoints.Name = "playerPoints";
            this.playerPoints.Size = new System.Drawing.Size(38, 16);
            this.playerPoints.TabIndex = 14;
            this.playerPoints.Text = "label3";
            // 
            // enemyPoints
            // 
            this.enemyPoints.AutoSize = true;
            this.enemyPoints.BackColor = System.Drawing.Color.Transparent;
            this.enemyPoints.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyPoints.ForeColor = System.Drawing.Color.White;
            this.enemyPoints.Location = new System.Drawing.Point(60, 45);
            this.enemyPoints.Name = "enemyPoints";
            this.enemyPoints.Size = new System.Drawing.Size(38, 16);
            this.enemyPoints.TabIndex = 15;
            this.enemyPoints.Text = "label4";
            // 
            // znak
            // 
            this.znak.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.znak.Location = new System.Drawing.Point(118, 293);
            this.znak.Name = "znak";
            this.znak.Size = new System.Drawing.Size(40, 40);
            this.znak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.znak.TabIndex = 11;
            this.znak.TabStop = false;
            // 
            // draw
            // 
            this.draw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.draw.Location = new System.Drawing.Point(346, 167);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(168, 194);
            this.draw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draw.TabIndex = 10;
            this.draw.TabStop = false;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // imageFaceCard
            // 
            this.imageFaceCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageFaceCard.BackColor = System.Drawing.SystemColors.Control;
            this.imageFaceCard.Location = new System.Drawing.Point(164, 167);
            this.imageFaceCard.Name = "imageFaceCard";
            this.imageFaceCard.Size = new System.Drawing.Size(170, 194);
            this.imageFaceCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageFaceCard.TabIndex = 2;
            this.imageFaceCard.TabStop = false;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(644, 511);
            this.Controls.Add(this.enemyPoints);
            this.Controls.Add(this.playerPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.znak);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.enemyHand);
            this.Controls.Add(this.yourHand);
            this.Controls.Add(this.imageFaceCard);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(660, 550);
            this.MinimumSize = new System.Drawing.Size(660, 550);
            this.Name = "GameView";
            this.Text = "Mau Mau";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.znak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.draw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox imageFaceCard;
        private System.Windows.Forms.FlowLayoutPanel yourHand;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel enemyHand;
        private System.Windows.Forms.PictureBox draw;
        private System.Windows.Forms.PictureBox znak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label playerPoints;
        private System.Windows.Forms.Label enemyPoints;
    }
}

