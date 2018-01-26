using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helicopter_Game
{
    public partial class Form1 : Form
    {

        // Global Variables
        bool goup; //boolean that allows the player to go up
        bool godown; //boolean that allows the player to go down
        bool shot = false; // boolean that determines if the player has shot ammo
        int score = 0; // holds the score
        int speed = 8; // holds the speed of obstacles
        Random rand = new Random(); // random generator
        int playerSpeed = 7; // speed of the helicopter
        int index; // integer used for changing the aliens

        public Form1()
        {
            InitializeComponent();
        }

        // logic for controlling the key being pressed down
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // player presses the Up Key so it changes goup to true
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                // player presses the Down Key so it changes go down to true
                godown = true;
            }
            if (e.KeyCode == Keys.Space && shot == false)
            {
                // if the player presses space and shot is false, we turn shot to true
                makeBullet();
                shot = true;
            }
        }

        // logic for controlling the key up button
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // player presses the Up Key so it changes goup to false
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                // player presses the Down Key so it changes go down to false
                godown = false;
            }
            if (shot == true)
            {
                // if the shot is true, we will turn it to false so they have to press to shoot again
                shot = false;
            }
        }

        // logic for the game timer
        private void gametick(object sender, EventArgs e)
        {
            // Moving the first pillar to the left part of the screen
            pillar1.Left -= speed;
            // Moving the second pillar to the left part of the screen
            pillar2.Left -= speed;
            // Moving the UFO to the left part of the screen
            ufo.Left -= speed;
            // Showing the score
            label1.Text = "Score: " + score;

            // If up is true, deduct from the top location and allow to move up
            if (goup)
            {
                player.Top -= playerSpeed;
            }

            // If down is true, deduct from the bottom location and allow to move down
            if(godown)
            {
                player.Top += playerSpeed;
            }

            // If the pillar goes off the left, it is replaced on the right side
            if(pillar1.Left < -150)
            {
                pillar1.Left = 900;
            }

            // If the pillar goes off the left, it is replaced on the right side
            if (pillar2.Left < -150)
            {
                pillar2.Left = 1000;
            }

            // Logic that checks if you hit the UFO's or Pillars
            if(ufo.Left < -5 || 
                player.Bounds.IntersectsWith(ufo.Bounds) ||
                player.Bounds.IntersectsWith(pillar1.Bounds) ||
                player.Bounds.IntersectsWith(pillar2.Bounds)
                )
            {
                // Game timer will stop if you and show you the final message with your score
                gameTimer.Stop();
                MessageBox.Show("You failed the mission soldier, you Killed " + score + " Ufo's");
            }

            // Logic for the controls
            foreach(Control X in this.Controls)
            {
                // Logic for displaying the bullets and how they move to the right of the screen
                if(X is PictureBox && X.Tag == "bullet")
                {
                    X.Left += 15;
                    if(X.Left > 900)
                    {
                        // Once its left the view of the form, dispose of the bullet
                        this.Controls.Remove(X);
                        X.Dispose();
                    }

                    // Logic for what occurs when the bullet hits a UFO and incrementing your score, creating new targets
                    if(X.Bounds.IntersectsWith(ufo.Bounds))
                    {
                        score += 1;
                        this.Controls.Remove(X);
                        X.Dispose();
                        ufo.Left = 1000;
                        ufo.Top = rand.Next(5, 330) - ufo.Height;
                        changeUFO();
                    }
                }
            }
        }

        // function used to change the UFO's placement in the game
        private void changeUFO()
        {
            index += 1; // increase the index by 1

            if (index > 3)
            {
                // if the index is greater than 3, set it back to 1
                index = 1;
            }

            // logic how the aliens switch images. Uses the index to alternate pics.
            switch(index)
            {
                case 1: 
                    ufo.Image = Properties.Resources.alien1;
                    break;
                case 2:
                    ufo.Image = Properties.Resources.alien2;
                    break;
                case 3:
                    ufo.Image = Properties.Resources.alien3;
                    break;
            }
        }

        // function used to generate the bullets
        private void makeBullet()
        {
            // New picture box class
            PictureBox bullet = new PictureBox();

            // Color of the bullet
            bullet.BackColor = System.Drawing.Color.DarkOrange;

            // Height of the bullet in pixels
            bullet.Height = 5;

            // Width of the bullet in pixels
            bullet.Left = player.Left + player.Width;

            // Placing the bullet in front of the player
            bullet.Top = player.Top + player.Height / 2;

            // Placing the bullet in the middle height of the player
            bullet.Tag = "bullet";

            // Adds the picture box bullet to the scene
            this.Controls.Add(bullet);
        }
    }
}
