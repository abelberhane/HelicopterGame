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
            
        }

        // logic for controlling the key up button
        private void keyisup(object sender, KeyEventArgs e)
        {

        }

        // logic for the game timer
        private void gametick(object sender, EventArgs e)
        {

        }

        // function used to change the UFO's placement in the game
        private void changeUFO()
        {

        }

        // function used to generate the bullets
        private void makeBullet()
        {

        }
    }
}
