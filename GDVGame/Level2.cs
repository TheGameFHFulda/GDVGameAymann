using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDVGame
{
    public partial class Level2 : Form
    {
        bool right;
        bool left;
        bool jump;
        int G = 25;
        int Force;
        int index = 0;

        public Level2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;

            //GIF replay
            if (right == true && index % 15 == 0)
            {
                player.Image = Image.FromFile("walk_r.gif");
            }
            if (left == true && index % 15 == 0)
            {
                player.Image = Image.FromFile("walk_l.gif");
            }

            // Side Collision
            SideCollision(block1);
            SideCollision(block2);
            SideCollision(block3);
            SideCollision(block4);
            SideCollision(block5);
            SideCollision(block6);
            SideCollision(block7);
            SideCollision(block8);
            SideCollision(block9);
            SideCollision(block10);
            SideCollision(block11);
            SideCollision(block12);
            SideCollision(block13);
            SideCollision(block14);
            SideCollision(block15);
            SideCollision(block16);
            SideCollision(block17);
            SideCollision(block18);
            SideCollision(block19);
            SideCollision(block20);
            SideCollision(block21);
            SideCollision(block22);
            SideCollision(block23);

            // Controles
            SideScroll(block1);
            SideScroll(block2);
            SideScroll(block3);
            SideScroll(block4);
            SideScroll(block5);
            SideScroll(block6);
            SideScroll(block7);
            SideScroll(block8);
            SideScroll(block9);
            SideScroll(block10);
            SideScroll(block11);
            SideScroll(block12);
            SideScroll(block13);
            SideScroll(block14);
            SideScroll(block15);
            SideScroll(block16);
            SideScroll(block17);
            SideScroll(block18);
            SideScroll(block19);
            SideScroll(block20);
            SideScroll(block21);
            SideScroll(block22);
            SideScroll(block23);


            if (jump == true)
            {
                //Falling (after jump)
                player.Top -= Force;
                Force -= 1;
            }
            if (player.Top + player.Height >= Block21.Height)
            {
                player.Top = Block21.Height - player.Height; //Stop falling at bottom
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand.png");
                }
                jump = false;
                
            }
            else
            {
                player.Top += 5; //falling
            }

            //Top Collision
            TopCollision(block1);
            TopCollision(block2);
            TopCollision(block3);
            TopCollision(block4);
            TopCollision(block5);
            TopCollision(block6);
            TopCollision(block7);
            TopCollision(block8);
            TopCollision(block9);
            TopCollision(block10);
            TopCollision(block11);
            TopCollision(block12);
            TopCollision(block13);
            TopCollision(block14);
            TopCollision(block15);
            TopCollision(block16);
            TopCollision(block17);
            TopCollision(block18);
            TopCollision(block19);
            TopCollision(block20);
            TopCollision(block21);
            TopCollision(block22);
            TopCollision(block23);

            //Danger
            Danger(Wasser1);
            Danger(Wasser2);
            Danger(Wasser3);
            Danger(Wasser4);
            Danger(Wasser5);

            //HeadCollision
            HeadCollision(block1);
            HeadCollision(block2);
            HeadCollision(block3);
            HeadCollision(block4);
            HeadCollision(block5);
            HeadCollision(block6);
            HeadCollision(block7);
            HeadCollision(block8);
            HeadCollision(block9);
            HeadCollision(block10);
            HeadCollision(block11);
            HeadCollision(block12);
            HeadCollision(block13);
            HeadCollision(block14);
            HeadCollision(block15);
            HeadCollision(block16);
            HeadCollision(block17);
            HeadCollision(block18);
            HeadCollision(block18);
            HeadCollision(block19);
            HeadCollision(block20);
            HeadCollision(block21);
            HeadCollision(block22);
            HeadCollision(block23);

        }

        // Side Collision
        private void SideCollision(PictureBox block)
        {
            if (player.Right > block.Left - 4 && player.Left < block.Right - player.Width && player.Top < block.Bottom && player.Bottom > block.Top)
            {
                right = false;
            }
            if (player.Left < block.Right + 4 && player.Right > block.Left + player.Width && player.Top < block.Bottom  && player.Bottom > block.Top)
            {
                left = false;
            }
        }

        // Controles
        private void SideScroll(PictureBox block)
        {
            if (right == true) { block.Left -= 5; }
            if (left == true) { block.Left += 5; }
        }

        //Top Collision
        private void TopCollision(PictureBox block)
        {
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height -2;
            }
        }

        //Falling 2
        private void Falling2(PictureBox block)
        {
            if (!(player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width) && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = true;
            }
        }

        //Head Collision
        private void HeadCollision(PictureBox block)
        {
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top - block.Bottom <= 10 && player.Top - block.Top > -10)
            {
                Force = -1;
            }
        }

        //Danger
        private void Danger(PictureBox block)
        {
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height;
                player.Top = 140; block2.Left = 23; block1.Left = 23; block3.Left = 131; block4.Left = 206; block5.Left = 267; block6.Left = 337; block7.Left = 331; block8.Left = 438; block9.Left = 535; block10.Left = 606;
                block11.Left = 683; block12.Left = 454; block13.Left = 535; block14.Left = 621; block15.Left = 775; block16.Left = 846; block17.Left = 929; block18.Left = 892; Block19.Left = 500; Block20.Left = 1037;
                Block21.Left = 1443; Block22.Left = 1185; pictureBox3.Left =1072;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Escape) { this.Close(); } //Exit

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                    player.Image = Image.FromFile("jump.png");
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("stand.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
                player.Image = Image.FromFile("stand.png");
            }

        }
        
    }
}
