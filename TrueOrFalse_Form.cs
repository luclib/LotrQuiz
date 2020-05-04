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
    public partial class TrueOrFalse_Form : Form
    {
        // PROPERTIES
        private clsUser _user = new clsUser();

        // CONSTRUCTOR
        public TrueOrFalse_Form()
        {
            InitializeComponent();
        }

        // PROPERTY
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        private void TrueOrFalse_Form_Load(object sender, EventArgs e)
        {
            // Load the question
            LoadQuestion(User.FormNumber);
            // Fill up the progress bar
            progressBar.Value = User.Progress;
            progressBar.Visible = true;
        }

        private void LoadQuestion(int questionNumber)
        {
            switch (questionNumber)
            {
                case 6:
                    questionLabel.Text = questionNumber + ". Tolkien wrote the opening line of his novel " +
                    "The Hobbit while grading one of his student's exams.";
                    pictureBox.Image = (Image)Properties.Resources.TolkienStudy;
                    break;

                case 7:
                    questionLabel.Text = questionNumber + ". Tolkien wrote 'The Hobbit' as a prequel to the highly" +
                        " successful 'The Lord of the Rings' novel.";
                    pictureBox.Image = (Image)Properties.Resources.TheHobbitCover;
                    break;
                case 8:
                    questionLabel.Text = questionNumber + ". An alternative name for the region of Wilderland, in " +
                        "which most of the action in 'The Hobbit' takes place, is Rhovanion.";
                    pictureBox.Image = (Image)Properties.Resources.Wilderland;
                    break;
                case 9:
                    questionLabel.Text = questionNumber + ". The protagonist of 'The Hobbit', Bilbo Baggins, is the uncle " +
                        "of Frodo Baggins, the protagonist of 'The Lord of the Rings'.";
                    pictureBox.Image = (Image)Properties.Resources.Baggins;
                    break;
                case 10:
                    questionLabel.Text = questionNumber + ". The movie trilogie of 'The Hobbit' is far superior to its " +
                        "predecessor 'The Lord of the Rings.'";
                    pictureBox.Image = (Image)Properties.Resources.HobbitvsLord;
                    break;
            }
        }

        // The CheckCompletion methods indicates whether any of the Radio Buttons are selected or not.
        private bool Checked()
        {
            bool check = false;
            if(trueRadioButton.Checked || falseRadiobutton.Checked)
            {
                check = true;
            }
            return check;
        }

        // The RecordAnswer method will store the input entered into
        // the textbox to its appropriate position at the answer array.
        private void RecordAnswer(int questionNumber)
        {
            int index = questionNumber - 1;
            if (trueRadioButton.Checked == true)
            {
                _user.UserAnswers[index] = "True";
            }
            else if (falseRadiobutton.Checked == true)
            {
                _user.UserAnswers[index] = "False";
            }
   
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!Checked())
            {
                // Display message
                MessageBox.Show("You must select one of the Radio Buttons to continue");
            }
            else
            {
                RecordAnswer(User.FormNumber);
                User.FormNumber++;
                progressBar.Increment(3);
                User.Progress += 3;
                if (User.FormNumber > 10)
                {
                    User.SectionII = true;
                    DialogResult = DialogResult.Abort;
                } 
                else
                {
                    LoadQuestion(User.FormNumber);
                }
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (!Checked())
            {
                // Display message
                MessageBox.Show("You must select one of the Radio Buttons to continue");
            }
            else
            {
                RecordAnswer(User.FormNumber);
                User.FormNumber--;
                User.Progress -= 3;
                progressBar.Increment(-3);

                // If the user goes past question 6, the True or False form will 
                // close and the SectionII property will be set to false.
                if (User.FormNumber < 6)
                {
                    User.SectionI = false;
                    // Set the progress bar value back to zero
                    progressBar.Value = 0;

                    DialogResult = DialogResult.Abort;
                }
                else
                {
                    LoadQuestion(User.FormNumber);
                }
            }
        }

    }
}
