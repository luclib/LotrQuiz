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
    public partial class MC_Form : Form
    {

        private clsUser _user = new clsUser();

        // Property
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        // Constructor.
        public MC_Form()
        {
            InitializeComponent();
        }

        // Load Event
        private void MC_EntryForm_Load(object sender, EventArgs e)
        {
            loadQuestion(User.FormNumber);
            progressBar.Value = User.Progress;
            progressBar.Visible  = true;
        }

        // METHODS
        // The loadQ methods set the instructionLabel and the radioButton
        // to the approriate question form depending on the question number.
        private void loadQuestion(int questionNumber)
         {
            switch (questionNumber)
            {
                case 1:
                    instructionLabel.Text = questionNumber.ToString() + ". In which modern-day country was J.R.R. Tolkien born?";
                    radioButton1.Text = "Australia";
                    radioButton2.Text = "India";
                    radioButton3.Text = "South Africa";
                    radioButton4.Text = "Great Britain";
                    pictureBox.Image = (Image)Properties.Resources.tolkien;
                    break;
                case 2:
                    instructionLabel.Text = questionNumber.ToString() + ". The initials 'J.R.R.' stand for:";
                    radioButton1.Text = "Joel Richard Ronald";
                    radioButton2.Text = "John Ronald Reuel";
                    radioButton3.Text = "Jack Rupert Royce";
                    radioButton4.Text = "Jonathan Rhys Ruben";
                    pictureBox.Image = (Image)Properties.Resources.JRRTolkien;
                    break;
                case 3:
                    instructionLabel.Text = questionNumber.ToString() + ". To what religion did Tolkien and his mother convert to" +
                    " when he was just 8 years of age?";
                    radioButton1.Text = "Anglicanism";
                    radioButton2.Text = "Greek Orthodoxy";
                    radioButton3.Text = "Roman Catholicism";
                    radioButton4.Text = "Lutheranism";
                    pictureBox.Image = (Image)Properties.Resources.TolkienFamily;
                    break;
                case 4:
                    instructionLabel.Text = questionNumber.ToString() + ". Which famous military engagement did Tolkien take part in?";
                    radioButton1.Text = "The South West Africa Campaign (1914-1915)";
                    radioButton2.Text = "The Battle of Charlevoix (1914)";
                    radioButton3.Text = "The Gallipoli Campaign (1915-1916)";
                    radioButton4.Text = "The Battle of the Somme (1916)";
                    pictureBox.Image = (Image)Properties.Resources.BattleSomme;
                    break;
                case 5:
                    instructionLabel.Text = questionNumber.ToString() + ". Tolkien was a professor at which of the following prestigious" +
                    " English universities?";
                    radioButton1.Text = "Oxford";
                    radioButton2.Text = "Cambridge";
                    radioButton3.Text = "London";
                    radioButton4.Text = "Kent";
                    pictureBox.Image = (Image)Properties.Resources.Oxford;
                    previousButton.Visible = true;
                    break;
            }
        }


        //The RecordAnswer method will assign the answer listed on the Radio Button that was selected
        //by the user and assign it to the corresponding entry of the string array.
        private void RecordAnswer(int questionNumber)
        {
            // The int 'number' will represent the position of the answers array
            // and thus has to be equal to the question number minus 1 as the count
            // always starts first at 0.
            int count = questionNumber - 1;
            if (radioButton1.Checked)
            {
                _user.UserAnswers[count] = radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                _user.UserAnswers[count] = radioButton2.Text;
            }
            if (radioButton3.Checked)
            {
                _user.UserAnswers[count] = radioButton3.Text;
            }
            if (radioButton4.Checked)
            {
                _user.UserAnswers[count] = radioButton4.Text;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            RecordAnswer(User.FormNumber);
            User.FormNumber++;
            User.Progress += 3;
            progressBar.Increment(3);
            while (User.FormNumber > 1)
            {
                previousButton.Visible = true;
                break;
            }
            if (User.FormNumber > 5)
            {
               User.SectionI = true;

                // Close the form.
               DialogResult = DialogResult.Abort;
            }
            else
            {
                loadQuestion(User.FormNumber);
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            RecordAnswer(User.FormNumber);
            User.FormNumber--;
            User.Progress -= 3;
            progressBar.Increment(-3);
            if (User.FormNumber == 1)
            {
                previousButton.Visible = false;
            }
            loadQuestion(User.FormNumber);
        }
    }
}
