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
    public partial class MultiAnswer_Form : Form
    {
        // string variables to hold parts of the poem used in the question
        // that will help save time typing repeated lines in code.
        string ring = "One Ring to                   them all ,";
        string end = "And in the darkness                 them!";

        // Field
        private clsUser _user = new clsUser();


        // CONSTRUCTOR
        public MultiAnswer_Form()
        {
            InitializeComponent();
        }

        // PROPERTY 
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

 // LoadForm12 method loads the form that contains questions 12-15.
        private void LoadForm12()
        {
            // Display the first set of Labels
            firstLabel1.Text = "rings for the Elven-kings under the sky,";
            firstLabel1.Visible = true;
            firstLabel2.Text = "for the Dwarf-lords in their halls of stone,";
            firstLabel2.Visible = true;
            firstLabel3.Text = "for Mortal Men doomed to die,";
            firstLabel3.Visible = true;
            firstLabel4.Text = "for the Dark Lord on his dark throne.";
            firstLabel4.Visible = true;
            label5.Text = "In the Land of Mordor where the Shadows lie.";
            label5.Visible = true;
            // Display the first set of TextBoxes
            firstTextBox1.Visible = true;
            firstTextBox2.Visible = true;
            firstTextBox3.Visible = true;
            firstTextBox4.Visible = true;
            // List the question numbers 12-15.
            questionLabel1.Text = "12.";
            questionLabel2.Text = "13.";
            questionLabel3.Text = "14.";
            questionLabel4.Text = "15.";

            // Hide the second set of Labels.
            secondLabel1.Visible = false;
            secondLabel2.Visible = false;
            secondLabel3.Visible = false;
            secondLabel4.Visible = false;
            // Hide the second set of Text Boxes.
            secondTextBox1.Visible = false;
            secondTextBox2.Visible = false;
            secondTextBox3.Visible = false;
            secondTextBox4.Visible = false;

            // Set the focus to the first text box.
            firstTextBox1.Focus();
        }

        // The LoadForm13 method loads the form that contains questions 16-19
        private void LoadForm13()
        {
            // Hide the first set of labels
            firstLabel1.Visible = false;
            firstLabel2.Visible = false;
            firstLabel3.Visible = false;
            firstLabel4.Visible = false;
            // Hide the first set of Text Boxes
            firstTextBox1.Visible = false;
            firstTextBox2.Visible = false;
            firstTextBox3.Visible = false;
            firstTextBox4.Visible = false;


            // Add text to the the second set of Labels;
            secondLabel1.Text = ring;
            secondLabel2.Text = "One Ring to                     them,";
            secondLabel3.Text = "One ring to                 them all,";
            secondLabel4.Text = end;
            // Display the second set of Labels
            secondLabel1.Visible = true;
            secondLabel2.Visible = true;
            secondLabel3.Visible = true;
            secondLabel4.Visible = true;
            // Display the second set of Text Boxes
            secondTextBox1.Visible = true;
            secondTextBox2.Visible = true;
            secondTextBox3.Visible = true;
            secondTextBox4.Visible = true;
            // List the question numbers 16-19.
            questionLabel1.Text = "16.";
            questionLabel2.Text = "17.";
            questionLabel3.Text = "18.";
            questionLabel4.Text = "19.";

            // Set the focus to the first textbox
            secondTextBox1.Focus();
        }

        // The LoadQuestion method will load the appropriate form for a given question.
        public void LoadQuestion(int questionNumber)
        {
            if(questionNumber == 12)
            {
                LoadForm12();
            }
                 
            else if(questionNumber ==13)
            {
                LoadForm13();
            }
        }

       

        // The RecordAnswer method will take the input entered into the answer text boxes
        // and transcribe them into the MultiAnswer Form's array to represent the user's 
        // answers for those set of questions.
        public void RecordAnswer(int questionNumber)
        {
            if (questionNumber == 12)
            {
                for (int count = 11; count < 15 ; count++)
                {
                    if (count == 11)
                    {
                        User.UserAnswers[count] = firstTextBox1.Text.Trim();
                    }
                    if (count == 12)
                    {
                        User.UserAnswers[count] = firstTextBox2.Text.Trim();
                    }
                    if (count == 13)
                    {
                        User.UserAnswers[count] = firstTextBox3.Text.Trim();
                    }
                    if (count == 14)
                    {
                        User.UserAnswers[count] = firstTextBox4.Text.Trim();
                    }
                }
            }
            else if (questionNumber == 13)
            {
                for (int count = 15; count < 19; count++)
                {
                    if (count == 15)
                    {
                        User.UserAnswers[count] = secondTextBox1.Text.Trim().ToLower();
                    }
                    if (count == 16)
                    {
                        User.UserAnswers[count] = secondTextBox2.Text.Trim().ToLower();
                    }
                    if (count == 17)
                    {
                        User.UserAnswers[count] = secondTextBox3.Text.Trim().ToLower();
                    }
                    if (count == 18)
                    {
                        User.UserAnswers[count] = secondTextBox4.Text.Trim().ToLower();
                    }
                }
            }
        }

        private void MultiAnswer_Form_Load(object sender, EventArgs e)
        {
            pictureBox.Image = (Image)Properties.Resources.SauronOneRing;
            LoadQuestion(User.FormNumber);
            progressBar.Value = User.Progress;
            progressBar.Visible = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
            {
            // Upon clicking the "Next" button the user effectively submits
            // his answer for that question, that is, his responses are transcribed
            // onto the MultiAnswer_Form's array so that it can be then transferred
            // onto the Main Form's array as the user's final answers.
            RecordAnswer(User.FormNumber);
            // Increment the UserAnswers.FormNumber variable by one.
            User.FormNumber++;
            User.Progress += 17;
            progressBar.Increment(17);
            if (User.FormNumber > 13)
            {
                User.SectionIV = true;
                // Set the FormNumber property to 20 corresponding to the next question.
                User.FormNumber = 20;
                DialogResult = DialogResult.Abort;
            }
            else
            {
                LoadQuestion(User.FormNumber);    // Load the questions of the next form.
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            RecordAnswer(User.FormNumber);
            // Decrement the UserAnswers.FormNumberer variable by one.
            User.FormNumber--;;
            User.Progress -= 17;
            progressBar.Increment(-17);
            if (User.FormNumber < 12)
            {
                // Set the progress bar value back to zero
                progressBar.Value = 0;

                // Set the Section III indicator to false;
                User.SectionIII = false;
                // Set the Section IV form to false
                User.SectionIV = false;
                DialogResult = DialogResult.Abort;
            }
            else
            {
                // Load the questions of the previous form.
                LoadQuestion(User.FormNumber);
            }  
        }
    }
}
