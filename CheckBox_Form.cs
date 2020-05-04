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
    public partial class CheckBox_Form : Form
    {

        // FIELD    
        private clsUser _user = new clsUser();

        // CONSTRUCTOR
        public CheckBox_Form()
        {
            InitializeComponent();
        }

        // PROPERTIES
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        /*
         * The RecordAnswer verifies if all of the 13 correct check boxes
         * are selected. If yes, it returns a string called "dwarves", if
         * not, it returns a string called "goblins". This string will then
         * later be transcribed unto the main array recording the user's answer
         * for question 11.
         */
        public string RecordAnswer()
        {
            string answer = "goblins";

            if(thorinCheckBox.Checked &&
                balinCheckBox.Checked &&
                dwalinCheckBox.Checked &&
                oinCheckBox.Checked &&
                gloinCheckBox.Checked &&
                bifurCheckBox.Checked &&
                bofurCheckBox.Checked &&
                bomburCheckBox.Checked &&
                kiliCheckBox.Checked &&
                filiCheckBox.Checked &&
                oriCheckBox.Checked &&
                doriCheckBox.Checked &&
                noriCheckBox.Checked)
            {
                answer = "dwarves";
            }

            return answer;
        }

        private void CheckBox_Form_Load(object sender, EventArgs e)
        {
            pictureBox.Image = (Image)Properties.Resources.ThorinsCompany;
            progressBar.Value = User.Progress;
            progressBar.Visible = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            int index = User.FormNumber - 1;
            // Record the user's answer.
            User.UserAnswers[index] = RecordAnswer();
            // Set the SectionIII indicator to true.
            User.SectionIII = true;
            // Increment its FormNumber.
            User.FormNumber++;
            User.Progress += 3;
            progressBar.Increment(User.Progress);
            DialogResult = DialogResult.Abort;
        }


        private void previousButton_Click(object sender, EventArgs e)
        {
            int index = User.FormNumber - 1;
            // Record the user's answer.
            User.UserAnswers[index] = RecordAnswer();
            // Decrement the FormNumber
            User.FormNumber--;

            User.Progress -= 3;
            progressBar.Increment(-3);

            // Make sure sections II & III indicators are set to false.
            User.SectionII = false;
            User.SectionIII = false;
            DialogResult = DialogResult.Abort;
        }
    }
}
