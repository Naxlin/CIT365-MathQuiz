using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIT365_MathQuiz
{
    public partial class Form1 : Form
    {
        // Variables:
        // Creating random number generator:
        Random randomizer = new Random();
        // Addition random numbers:
        int addend1, addend2;
        // Countdown:
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Update timer:
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // Time ran out!:
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        // Will start the game when the start quiz button is pressed
        // this includes the creation of random numbers and the timer
        public void StartTheQuiz()
        {
            // Addition problem:
            // Randomizing numbers:
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            // Updating the labels accordingly:
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            // Setting Sum default:
            sum.Value = 0;

            // Timer:
            // Time limit:
            timeLeft = 30;
            // Setting time label:
            timeLabel.Text = "30 seconds";
            // Start timer:
            timer1.Start();
        }
    }
}
