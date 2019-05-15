using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_by_Paneq
{
    public partial class Form1 : Form
    {

        public int speed_left = 4;   // predkosc kuli
        public int speed_top = 4;
        public int point = 0; // punkty :D


        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide(); // Hide the cursor

            this.FormBorderStyle = FormBorderStyle.None; // usuwamy ramki
            this.TopMost = true;                  // wyciaga formsa
            this.Bounds = Screen.PrimaryScreen.Bounds;   // Pełny ekran

            racket.Top = playground.Bottom - (playground.Bottom / 10); // pozycja rakiety

            koniecgry.Left = (playground.Width / 2) - (koniecgry.Width / 2);
            koniecgry.Top = (playground.Height / 2) - (koniecgry.Height / 2);
            koniecgry.Visible = false; 
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            racket.Left = Cursor.Position.X - (racket.Width / 2); // ustawiamy pozycje rakiety wzgledem kursora 

            ball.Left += speed_left; // poruszanie piłki
            ball.Top += speed_top;


            if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) // kolizje
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top; // zmiana kierunku 
                point += 1;

                punkty.Text = point.ToString();

            }

            if (ball.Left <= playground.Left)
            {

                speed_left = -speed_left; 
            }
            if(ball.Right >= playground.Right)
            {

                speed_left = -speed_left;
            }
            if(ball.Top <= playground.Top)
            {
                speed_top = -speed_top;

            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false; // piłka wyszła koniec gry
                koniecgry.Visible = true; // koniec gry wyswietlnie napisu 
            }




        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } //esc do wyjscia
            if (e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                point = 0;
                punkty.Text = "0";
                timer1.Enabled = true;
                koniecgry.Visible = false;
            }


        }

        private void ball_Click(object sender, EventArgs e)
        {

        }

        private void punkty_Click(object sender, EventArgs e)
        {

        }
    }
}
