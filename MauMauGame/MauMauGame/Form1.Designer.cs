namespace MauMauGame
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
            this.imageFaceCard = new System.Windows.Forms.PictureBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.yourHand = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyHandlabel = new System.Windows.Forms.Label();
            this.enemyHand = new System.Windows.Forms.FlowLayoutPanel();
            this.draw = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.enemyHand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.draw)).BeginInit();
            this.SuspendLayout();
            // 
            // imageFaceCard
            // 
            this.imageFaceCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageFaceCard.BackColor = System.Drawing.SystemColors.Control;
            this.imageFaceCard.Location = new System.Drawing.Point(137, 183);
            this.imageFaceCard.Name = "imageFaceCard";
            this.imageFaceCard.Size = new System.Drawing.Size(170, 194);
            this.imageFaceCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageFaceCard.TabIndex = 2;
            this.imageFaceCard.TabStop = false;
            // 
            // draw_button
            // 
            this.draw_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.draw_button.Location = new System.Drawing.Point(507, 354);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(75, 23);
            this.draw_button.TabIndex = 3;
            this.draw_button.Text = "Draw";
            this.draw_button.UseVisualStyleBackColor = true;
            // 
            // yourHand
            // 
            this.yourHand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yourHand.AutoScroll = true;
            this.yourHand.Location = new System.Drawing.Point(137, 418);
            this.yourHand.MaximumSize = new System.Drawing.Size(350, 100);
            this.yourHand.MinimumSize = new System.Drawing.Size(350, 100);
            this.yourHand.Name = "yourHand";
            this.yourHand.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.yourHand.Size = new System.Drawing.Size(350, 100);
            this.yourHand.TabIndex = 6;
            this.yourHand.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.scoreToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // scoreToolStripMenuItem
            // 
            this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            this.scoreToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.scoreToolStripMenuItem.Text = "Score";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // enemyHandlabel
            // 
            this.enemyHandlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyHandlabel.AutoSize = true;
            this.enemyHandlabel.Location = new System.Drawing.Point(3, 0);
            this.enemyHandlabel.Name = "enemyHandlabel";
            this.enemyHandlabel.Size = new System.Drawing.Size(35, 13);
            this.enemyHandlabel.TabIndex = 8;
            this.enemyHandlabel.Text = "label1";
            // 
            // enemyHand
            // 
            this.enemyHand.Controls.Add(this.enemyHandlabel);
            this.enemyHand.Location = new System.Drawing.Point(137, 27);
            this.enemyHand.MaximumSize = new System.Drawing.Size(350, 100);
            this.enemyHand.MinimumSize = new System.Drawing.Size(350, 100);
            this.enemyHand.Name = "enemyHand";
            this.enemyHand.Size = new System.Drawing.Size(350, 100);
            this.enemyHand.TabIndex = 9;
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(319, 183);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(168, 194);
            this.draw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draw.TabIndex = 10;
            this.draw.TabStop = false;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 530);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.enemyHand);
            this.Controls.Add(this.yourHand);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.imageFaceCard);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(640, 100000);
            this.Name = "GameView";
            this.Text = "Mau Mau";
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.enemyHand.ResumeLayout(false);
            this.enemyHand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox imageFaceCard;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.FlowLayoutPanel yourHand;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Label enemyHandlabel;
        private System.Windows.Forms.FlowLayoutPanel enemyHand;
        private System.Windows.Forms.PictureBox draw;
    }
}

