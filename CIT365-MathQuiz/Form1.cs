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

        private void answer_Enter(object sender, EventArgs e)
        {
            // Selects all input text on 'entering' a numericUpDown menu
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If the user got the answer right:
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            if (timeLeft > 0)
            {
                // Update timer:
                timeLeft--;
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

        // Compares the answers the user input to the actual answers
        // returns true or false depending on the comparison
        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }
    }
}
