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
        // Subtraction random numbers:
        int minuend, subtrahend;
        // Multiplication random numbers:
        int multiplicand, multiplier;
        // Division random numbers:
        int dividend, divisor;
        // Countdown:
        int timeLeft;

        public Form1()
        {
            InitializeComponent();

            // Today's date applied to a label
            dateLabel.Text = DateTime.Now.ToString("d MMMM yyyy");
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

        // An event method that should make sounds but doesn't...
        private void Answer_Correct_Alert(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                switch (answerBox.Name)
                {
                    case "sum":
                        if (addend1 + addend2 == sum.Value)
                            System.Media.SystemSounds.Beep.Play();
                        break;
                    case "difference":
                        if (minuend - subtrahend == difference.Value)
                            System.Media.SystemSounds.Beep.Play();
                        break;
                    case "product":
                        if (multiplicand * multiplier == product.Value)
                            System.Media.SystemSounds.Beep.Play();
                        break;
                    case "quotient":
                        if (dividend / divisor == quotient.Value)
                            System.Media.SystemSounds.Beep.Play();
                        break;
                    default:
                        break;
                }
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
                if (timeLeft < 6)
                    timeLabel.BackColor = Color.Red;
            }
            else
            {
                // Time ran out!:
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
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

            // Subtraction problem:
            // Randomizing numbers:
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            // Updating Labels:
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            // Setting default:
            difference.Value = 0;

            // Multiplication problem:
            // Randomizing numbers:
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            // Labeling:
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            // Default:
            product.Value = 0;

            // Division problem:
            // Randomizing:
            divisor = randomizer.Next(2, 11);
            int tempQuotient = randomizer.Next(2, 11);
            dividend = divisor * tempQuotient;
            // Labeling:
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            // Default:
            quotient.Value = 0;

            // Timer:
            // Time limit:
            timeLeft = 30;
            // Setting time label:
            timeLabel.Text = "30 seconds";
            timeLabel.BackColor = Color.Transparent;
            // Start timer:
            timer1.Start();
        }

        // Compares the answers the user input to the actual answers
        // returns true or false depending on the comparison
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) &&
                (minuend - subtrahend == difference.Value) &&
                (multiplicand * multiplier == product.Value) &&
                (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
    }
}
