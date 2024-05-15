using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TankShooter_Z501CK
{

    public delegate void GameOverEventHandler(object sender, EventArgs e);
    public partial class Form1 : Form
    {
        public event GameOverEventHandler GameOverEvent;



        string player1Facing = "Up";
        string player2Facing = "Down";
        bool w, a, s, d, space, up, down, right, left, num0, gameOver;
        int PlayerSpeed = 10;
        int RandomBullet = 1;
        Random randNum = new Random();
        int player1score = 0;
        int player2score = 0;
        bool canShoot = true;
        int maxbullet = 100;
        int bulletNumber = 0;



        public Form1()
        {
            InitializeComponent();
            GameOverEvent += GameOverEventHandler;

        }

        /////Timers/////
        private void RandomBulletTimer_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < RandomBullet; i++)
            {

                spawnRandomBullet();


            }


            if (RandomBullet < 10)
            {
                RandomBullet++;
            }



        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            removeBullet();
            player1Move();
            player2Move();
            killPlayer1();
            killPlayer2();
            
            GameOver();

        }

        ///// Move Player/////
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    w = true;
                    player1Facing = "Up";

                    player1.Image = Properties.Resources.up2;
                    break;
                case Keys.A:
                    a = true;
                    player1Facing = "Left";
                    player1.Image = Properties.Resources.left2;
                    break;
                case Keys.S:
                    s = true;
                    player1Facing = "Down";
                    player1.Image = Properties.Resources.down2;
                    break;
                case Keys.D:
                    d = true;
                    player1Facing = "Right";
                    player1.Image = Properties.Resources.right2;
                    break;
                case Keys.Space:
                    space = true;

                    break;
                case Keys.Up:
                    up = true;
                    player2Facing = "Up";
                    player2.Image = Properties.Resources.up;
                    break;
                case Keys.Down:
                    down = true;
                    player2Facing = "Down";
                    player2.Image = Properties.Resources.down;
                    break;
                case Keys.Left:
                    left = true;
                    player2Facing = "Left";
                    player2.Image = Properties.Resources.left;
                    break;
                case Keys.Right:
                    right = true;
                    player2Facing = "Right";
                    player2.Image = Properties.Resources.right;
                    break;
                case Keys.NumPad0:
                    num0 = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    w = false;
                    break;
                case Keys.A:
                    a = false;
                    break;
                case Keys.S:
                    s = false;
                    break;
                case Keys.D:
                    d = false;
                    break;
                case Keys.Space:
                    Shooting1(player1Facing);
                    break;
                case Keys.Up:
                    up = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
                case Keys.NumPad0:
                    Shooting2(player2Facing);
                    break;
            }

        }

        private void player1Move()
        {
            if (a == true && player1.Left > 0)
            {
                player1.Left -= PlayerSpeed;
            }
            else if (d == true && player1.Left + player1.Width < this.ClientSize.Width)
            {
                player1.Left += PlayerSpeed;
            }
            else if (w == true && player1.Top > 0)
            {
                player1.Top -= PlayerSpeed;
            }
            else if (s == true && player1.Top + player1.Height < this.ClientSize.Height)
            {
                player1.Top += PlayerSpeed;
            }

        }
        private void player2Move()
        {
            if (left == true && player2.Left > 0)
            {
                player2.Left -= PlayerSpeed;
            }
            else if (right == true && player2.Left + player2.Width < this.ClientSize.Width)
            {
                player2.Left += PlayerSpeed;
            }
            else if (up == true && player2.Top > 0)
            {
                player2.Top -= PlayerSpeed;
            }
            else if (down == true && player2.Top + player2.Height < this.ClientSize.Height)
            {
                player2.Top += PlayerSpeed;
            }

        }

        /////Shooting/////
        private void Shooting1(string direction)
        {
            if (canShoot && bulletNumber<maxbullet)
            {
                bulletNumber++;
                Bullet shootBullet = new Bullet();
                shootBullet.direction = direction;
                shootBullet.tagOfBullet = "Bullet1";
                shootBullet.bulletLeft = player1.Left + (player1.Width / 2);
                shootBullet.bulletTop = player1.Top + (player1.Height / 2);
                shootBullet.makeBullet(this);
            }

        }
        private void Shooting2(string direction)
        {
            if (canShoot && bulletNumber < maxbullet)
            {
                bulletNumber++;
                Bullet shootBullet = new Bullet();
                shootBullet.direction = direction;
                shootBullet.tagOfBullet = "Bullet2";
                shootBullet.bulletLeft = player2.Left + (player2.Width / 2 + 1);
                shootBullet.bulletTop = player2.Top + (player2.Height / 2 + 1);
                shootBullet.makeBullet(this);

            }
        }


        /////After hit/////
        private void Restart()
        {


            Random randposx = new Random();
            Random randposy = new Random();



            player2.Left = randposx.Next(100, 800); 
            player2.Top = randposy.Next(30, 500); 
            player1.Top = randposy.Next(30, 500); 
            player1.Left = randposx.Next(100, 800); 
            if(player1.Left == player2.Left)
            {
                player1.Top = randposy.Next(30, 500);
                player1.Left = randposx.Next(100, 800);
            }


        }
 
        private void removeBullet()
        {
            foreach(Control x in this.Controls)
            {
                if((x is PictureBox && (string)x.Tag == "bullet") || (x is PictureBox && (string)x.Tag == "Bullet2") || (x is PictureBox && (string)x.Tag == "Bullet1"))
                {
                    if(x.Left == 0 || x.Top == 0 || x.Left == 1000  || x.Top == 600)
                    {
                        bulletNumber--;
                        this.Controls.Remove(x);
                    }
                    
                }

                
            }
        }
        private void killPlayer1()
        {
            foreach (Control x in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "player1") || (j is PictureBox && (string)j.Tag == "Bullet2" && x is PictureBox && (string)x.Tag == "player1"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            bulletNumber=0;
                            canShoot = false;
                            this.Controls.Remove(j);
                            this.Controls.Remove(x);
                            ((PictureBox)j).Dispose();
                            ((PictureBox)x).Visible = false;
                            player2score++;
                            player2_score.Text = "Player2:" + player2score.ToString();
                            Thread.Sleep(1000); // Sleep for 1 seconds
                            ((PictureBox)x).Visible = true;
                            Restart();
                            this.Controls.Add(x);
                            canShoot = true;
                        }
                    }
                }
            }


        }

        private void killPlayer2()
        {
            foreach (Control x in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "player2") || (j is PictureBox && (string)j.Tag == "Bullet1" && x is PictureBox && (string)x.Tag == "player2"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            bulletNumber = 0; ;
                            canShoot = false;
                            this.Controls.Remove(j);
                            this.Controls.Remove(x);
                            ((PictureBox)j).Dispose();
                            ((PictureBox)x).Visible = false;
                            player1score++;
                            player1_score.Text = "Player1:" + player1score.ToString();
                            Thread.Sleep(1000); // Sleep for 1 seconds
                            ((PictureBox)x).Visible = true;
                            Restart();
                            this.Controls.Add(x);
                            canShoot = true;

                        }
                    }
                }
            }


        }


        /////Random Bullets/////
        private void spawnRandomBullet()
        {
            String rbdir = "";
            int rbDirection = randNum.Next(0, 3);
            int rbPosition;
            Bullet rb = new Bullet();
            rb.speed = 5;
            switch (rbDirection)
            {
                case 0:
                    rbdir = "Up";
                    rbPosition = randNum.Next(10, 990);
                    rb.direction = rbdir;
                    rb.bulletTop = 600;
                    rb.bulletLeft = rbPosition;
                    rb.makeBullet(this);
                    break;
                case 1:
                    rbdir = "Left";
                    rbPosition = randNum.Next(10, 590);
                    rb.direction = rbdir;
                    rb.bulletTop = rbPosition;
                    rb.bulletLeft = 1000;
                    rb.makeBullet(this);
                    break;
                case 2:
                    rbdir = "Right";
                    rbPosition = randNum.Next(10, 590);
                    rb.direction = rbdir;
                    rb.bulletTop = rbPosition;
                    rb.bulletLeft = 0;
                    rb.makeBullet(this);
                    break;
                case 3:
                    rbdir = "Down";
                    rbPosition = randNum.Next(10, 990);
                    rb.direction = rbdir;
                    rb.bulletTop = 0;
                    rb.bulletLeft = rbPosition;
                    rb.makeBullet(this);
                    break;
            }
        }


        /////Total Game Over/////
        private void GameOver()
        {
            GameOverText.Visible = false;

            if (player1score == 10)
            {

                GameOverText.Text = "Player1 win";
                GameOverText.Visible = true;
                RandomBulletTimer.Stop();
                GameTimer.Stop();
                OnGameOver();



            }
            if (player2score == 10)
            {
                GameOverText.Text = "Player2 win";
                GameOverText.Visible = true;
                RandomBulletTimer.Stop();
                GameTimer.Stop();
                OnGameOver();

            }

        }

        protected virtual void OnGameOver()
        {
            GameOverEvent?.Invoke(this, EventArgs.Empty);
        }

        // Event handler for the GameOverEvent event
        private void GameOverEventHandler(object sender, EventArgs e)
        {
            string message = "";
            // Handle the game over event here
            if (player1score == 10)
            {
                 message = "Player1 wins! Do you want a rematch?";
            }
            if (player2score == 10)
            {
                message = "Player2 wins! Do you want a rematch?";
            }
            // string message = "Do you want a rematch?";
            string title = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                
                player1score = 0;
                player1_score.Text = "Player1:" + player1score.ToString();
                player2score = 0;
                player2_score.Text = "Player2:" + player2score.ToString();
                Restart();
                GameTimer.Start();
                RandomBulletTimer.Start();
                RandomBullet = 1;
            }
            else
            {
                this.Close();
                Application.Exit();
            }
        }

    }
}
    





