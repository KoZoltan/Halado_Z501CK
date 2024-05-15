namespace TankShooter_Z501CK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            player1 = new PictureBox();
            player2 = new PictureBox();
            player1_score = new Label();
            player2_score = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            RandomBulletTimer = new System.Windows.Forms.Timer(components);
            GameOverText = new Label();
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            SuspendLayout();
            // 
            // player1
            // 
            player1.BackColor = Color.Transparent;
            player1.Image = Properties.Resources.up2;
            player1.Location = new Point(401, 229);
            player1.Name = "player1";
            player1.Size = new Size(90, 57);
            player1.SizeMode = PictureBoxSizeMode.StretchImage;
            player1.TabIndex = 0;
            player1.TabStop = false;
            player1.Tag = "player1";
            // 
            // player2
            // 
            player2.BackColor = Color.Transparent;
            player2.Image = Properties.Resources.down;
            player2.Location = new Point(401, 82);
            player2.Name = "player2";
            player2.Size = new Size(90, 59);
            player2.SizeMode = PictureBoxSizeMode.StretchImage;
            player2.TabIndex = 1;
            player2.TabStop = false;
            player2.Tag = "player2";
            // 
            // player1_score
            // 
            player1_score.AutoSize = true;
            player1_score.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            player1_score.Location = new Point(0, -1);
            player1_score.Name = "player1_score";
            player1_score.Size = new Size(131, 29);
            player1_score.TabIndex = 2;
            player1_score.Text = "player1:0";
            // 
            // player2_score
            // 
            player2_score.AutoSize = true;
            player2_score.Font = new Font("Showcard Gothic", 13.8F);
            player2_score.Location = new Point(851, -1);
            player2_score.Name = "player2_score";
            player2_score.Size = new Size(132, 29);
            player2_score.TabIndex = 3;
            player2_score.Text = "player2:0";
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimer_Tick;
            // 
            // RandomBulletTimer
            // 
            RandomBulletTimer.Enabled = true;
            RandomBulletTimer.Interval = 10000;
            RandomBulletTimer.Tick += RandomBulletTimer_Tick;
            // 
            // GameOverText
            // 
            GameOverText.AutoSize = true;
            GameOverText.BackColor = SystemColors.Control;
            GameOverText.Location = new Point(310, 182);
            GameOverText.Name = "GameOverText";
            GameOverText.Size = new Size(0, 20);
            GameOverText.TabIndex = 4;
            GameOverText.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(982, 553);
            Controls.Add(GameOverText);
            Controls.Add(player2_score);
            Controls.Add(player1_score);
            Controls.Add(player2);
            Controls.Add(player1);
            MaximumSize = new Size(1000, 600);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ((System.ComponentModel.ISupportInitialize)player2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox player1;
        private PictureBox player2;
        private Label player1_score;
        private Label player2_score;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer RandomBulletTimer;
        private Label GameOverText;
    }
}
