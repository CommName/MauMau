namespace MauMauGame
{
    partial class Form1
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
            this.group_hand_user = new System.Windows.Forms.GroupBox();
            this.draw = new System.Windows.Forms.Button();
            this.imageFaceCard = new System.Windows.Forms.PictureBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.hand_my_label = new System.Windows.Forms.Label();
            this.hand_enemy_label = new System.Windows.Forms.Label();
            this.face_card_label = new System.Windows.Forms.Label();
            this.group_hand_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).BeginInit();
            this.SuspendLayout();
            // 
            // group_hand_user
            // 
            this.group_hand_user.Controls.Add(this.hand_my_label);
            this.group_hand_user.Location = new System.Drawing.Point(12, 325);
            this.group_hand_user.Name = "group_hand_user";
            this.group_hand_user.Size = new System.Drawing.Size(579, 113);
            this.group_hand_user.TabIndex = 0;
            this.group_hand_user.TabStop = false;
            this.group_hand_user.Text = "My Hand";
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(68, 59);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(188, 229);
            this.draw.TabIndex = 1;
            this.draw.Text = "button1";
            this.draw.UseVisualStyleBackColor = true;
            // 
            // imageFaceCard
            // 
            this.imageFaceCard.Location = new System.Drawing.Point(301, 59);
            this.imageFaceCard.Name = "imageFaceCard";
            this.imageFaceCard.Size = new System.Drawing.Size(206, 229);
            this.imageFaceCard.TabIndex = 2;
            this.imageFaceCard.TabStop = false;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(516, 296);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(75, 23);
            this.draw_button.TabIndex = 3;
            this.draw_button.Text = "Draw";
            this.draw_button.UseVisualStyleBackColor = true;
            // 
            // hand_my_label
            // 
            this.hand_my_label.AutoSize = true;
            this.hand_my_label.Location = new System.Drawing.Point(117, 47);
            this.hand_my_label.Name = "hand_my_label";
            this.hand_my_label.Size = new System.Drawing.Size(35, 13);
            this.hand_my_label.TabIndex = 0;
            this.hand_my_label.Text = "label1";
            // 
            // hand_enemy_label
            // 
            this.hand_enemy_label.AutoSize = true;
            this.hand_enemy_label.Location = new System.Drawing.Point(98, 23);
            this.hand_enemy_label.Name = "hand_enemy_label";
            this.hand_enemy_label.Size = new System.Drawing.Size(35, 13);
            this.hand_enemy_label.TabIndex = 4;
            this.hand_enemy_label.Text = "label1";
            // 
            // face_card_label
            // 
            this.face_card_label.AutoSize = true;
            this.face_card_label.Location = new System.Drawing.Point(342, 40);
            this.face_card_label.Name = "face_card_label";
            this.face_card_label.Size = new System.Drawing.Size(35, 13);
            this.face_card_label.TabIndex = 5;
            this.face_card_label.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 450);
            this.Controls.Add(this.face_card_label);
            this.Controls.Add(this.hand_enemy_label);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.imageFaceCard);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.group_hand_user);
            this.Name = "Form1";
            this.Text = "Form1";
            this.group_hand_user.ResumeLayout(false);
            this.group_hand_user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageFaceCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox group_hand_user;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.PictureBox imageFaceCard;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.Label hand_my_label;
        private System.Windows.Forms.Label hand_enemy_label;
        private System.Windows.Forms.Label face_card_label;
    }
}

