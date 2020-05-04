using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOTR_Quiz
{
    public partial class ShortAnswer_Form : Form
    {
        public ShortAnswer_Form()
        {
            InitializeComponent();
        }

        // FIELD
        private clsUser _user;

        // Properties
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        // Methods
        //
        // The RecordAnswer method will store the input entered into
        // the textbox to its appropriate position at the answer array.
        private void RecordAnswer(int questionNumber)
        {
            int index = questionNumber - 1;
            User.UserAnswers[index] = answerTextBox.Text.Trim();
        }

        private void LoadQuestion(int questionNumber)
        {
            switch (questionNumber)
            {
                case 20:
                    questionLabel.Text =  questionNumber + ". Using the numbers listed in the poem," +
                        " in what year did J.R.R. Tolkien die? (Hint: Tolkien was born " +
                        "in 1896).";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.RingsOfPower;
                    break;
                case 21:
                    questionLabel.Text = questionNumber + ". What age did Bilbo celebrate in the opening of " +
                        "'The Lord of the Rings'?";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.BilboBirthday;
                    break;
                case 22:
                    questionLabel.Text = questionNumber + ". What was Gollum's original name? (Hint: it rhymes " +
                        "with 'eagle'.";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.Smeagol;
                    break;
                case 23:
                    questionLabel.Text = questionNumber + ". Stupid ___ hobbit!";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.FatHobbit;
                    break;
                case 24:
                    questionLabel.Text = questionNumber + ". They're taking the hobbits to _______!";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.TakingTheHobbits;
                    break;
                case 25:
                    questionLabel.Text = questionNumber + ". One does not simply ____ into Mordor.";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.Boromir;
                    break;
                case 26:
                    questionLabel.Text = questionNumber + ". It's mine, my own, my ________.";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.MyPrecious;
                    break;
                case 27:
                    questionLabel.Text = questionNumber + ". Do not come between a Nazgûl and its ____.";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.WitchKing;
                    break;
                case 28:
                    questionLabel.Text = questionNumber + ". The _____ are coming!";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.TheEaglesAreComing;
                    break;
                case 29:
                    questionLabel.Text = questionNumber + ". A Balrog of _______.";
                    // Load relevant image.
                    pictureBox.Image = (Image)Properties.Resources.BalrogOfMorgoth;
                    break;
                case 30:
                    questionLabel.Text = questionNumber + ". Who is the Lord of the Rings?";
                    // Load the relevant image.
                    pictureBox.Image = (Image)Properties.Resources.Who;
                    break;
            }
        }

        // Load Event Click Handler.
        private void ShortAnswer_Form_Load(object sender, EventArgs e)
        {
            LoadQuestion(User.FormNumber);
            progressBar.Value = User.Progress;
            progressBar.Visible = true;
        }

        // The nextButton Click handler will load the next question
        // while recording the answers for the current question.
        private void nextButton_Click(object sender, EventArgs e)
        {
            while(User.FormNumber < 31)
            {
                RecordAnswer(User.FormNumber);
                break;
            }
            User.FormNumber++;     // Increment the UserAnswers.FormNumberer
            User.Progress += 3;
            progressBar.Increment(3);
            if(User.FormNumber == 31)
            {
                // Set the section V marker to true
                User.SectionV = true;
                DialogResult = DialogResult.Abort;
            }
            else
            {
                // Clear the answer text box
                answerTextBox.Clear(); 
                // Reset the focus
                answerTextBox.Focus(); 
                // Load the next question
                LoadQuestion(User.FormNumber);   
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            RecordAnswer(User.FormNumber);
            User.FormNumber--;
            User.Progress -= 3;
            progressBar.Increment(-3);

            if(User.FormNumber < 20)
            {

                // Set the section IV marker to false
                User.SectionIV = false;
                // Set the section V marker to false
                User.SectionV = false;
                // Reset the form number to that of the last section
                User.FormNumber = 13;
                // Close the form.
                DialogResult = DialogResult.Abort;
            }
            else
            {
                answerTextBox.Clear();  // Clear the answer text box
                answerTextBox.Focus();  // Reset the focus
                LoadQuestion(User.FormNumber);
            }
        }
    }
}
