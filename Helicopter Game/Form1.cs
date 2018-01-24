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

        }
    }
}
