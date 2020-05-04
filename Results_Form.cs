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
    public partial class Results_Form : Form
    {

        // Field
        private clsUser _user;

        // Constructor
        public Results_Form()
        {
            InitializeComponent();
        }


        // Propertie(s)
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        //Methods
        private void PrintAnswers()
        {
            for (int i = 0; i < this.User.CorrectAnswers.Length; i++)
            {
                int questionNumber = i + 1;
                // Add an entry to the Correct Answer's List Box
                correctListBox.Items.Add(questionNumber +". " + this.User.CorrectAnswers[i]);
                if (this.User.UserAnswers[i] != this.User.CorrectAnswers[i])
                {
                    userListBox.Items.Add(questionNumber + ". " + this.User.UserAnswers[i]);
                    xListBox.Items.Add("X");
                }
                else
                {
                    userListBox.Items.Add(questionNumber + ". " + this.User.UserAnswers[i]);
                    xListBox.Items.Add("");
                }
            }
        }


        // Load event handler
        private void Results_Form_Load(object sender, EventArgs e)
        {
            PrintAnswers();

        }

        private void correctListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = correctListBox.SelectedIndex;
            userListBox.SelectedIndex = index;
            xListBox.SelectedIndex = index;
        }

        private void userListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = userListBox.SelectedIndex;
            correctListBox.SelectedIndex = index;
            xListBox.SelectedIndex = index;
        }

        private void xListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = xListBox.SelectedIndex;
            correctListBox.SelectedIndex = index;
            userListBox.SelectedIndex = index;
        }
    }
}
