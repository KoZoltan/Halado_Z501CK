using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace TankShooter_Z501CK
{
    internal class Bullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;
        public string tagOfBullet = "bullet";

        public int speed = 20;
        private PictureBox bullet = new PictureBox();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();

        public void makeBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = tagOfBullet;
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);
            if (bullet.Left < 10 || bullet.Top < 10 || bullet.Left > 1000|| bullet.Top > 600)
            { form.Controls.Remove(bullet); }

                bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimeEvent);
            bulletTimer.Start();

        }
        private void BulletTimeEvent(object sender, EventArgs e)
        {
            switch (direction)
            {
                case "Left":
                    bullet.Left -= speed;
                    break;
                case "Right":
                    bullet.Left += speed;
                    break;
                case "Up":
                    bullet.Top -= speed;
                    break;
                case "Down":
                    bullet.Top += speed;
                    break;
            }

            if (bullet.Left < 10 || bullet.Top < 10 || bullet.Left > 1000 || bullet.Top > 600)
            {

                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
               

            }
        }
    }
}
