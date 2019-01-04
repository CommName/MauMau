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
            this.draw = new System.Windows.Forms.Button();
            this.imageFaceCard = new System.Windows.Forms.PictureBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.yourHand = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyHand = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // draw
            // 
            this.draw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.draw.Location = new System.Drawing.Point(96, 148);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(188, 229);
            this.draw.TabIndex = 1;
            this.draw.Text = "button1";
            this.draw.UseVisualStyleBackColor = true;
            // 
            // imageFaceCard
            // 
            this.imageFaceCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageFaceCard.Location = new System.Drawing.Point(313, 148);
            this.imageFaceCard.Name = "imageFaceCard";
            this.imageFaceCard.Size = new System.Drawing.Size(206, 229);
            this.imageFaceCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageFaceCard.TabIndex = 2;
            this.imageFaceCard.TabStop = false;
            // 
            // draw_button
            // 
            this.draw_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.draw_button.Location = new System.Drawing.Point(541, 376);
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
            // enemyHand
            // 
            this.enemyHand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyHand.AutoSize = true;
            this.enemyHand.Location = new System.Drawing.Point(21, 183);
            this.enemyHand.Name = "enemyHand";
            this.enemyHand.Size = new System.Drawing.Size(35, 13);
            this.enemyHand.TabIndex = 8;
            this.enemyHand.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(137, 27);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(350, 100);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(350, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 100);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 530);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.enemyHand);
            this.Controls.Add(this.yourHand);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.imageFaceCard);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(640, 100000);
            this.Name = "GameView";
            this.Text = "Mau Mau";
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.PictureBox imageFaceCard;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.FlowLayoutPanel yourHand;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Label enemyHand;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

