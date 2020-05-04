using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LOTR_Quiz
{
    public partial class ChooseSide_Form : Form
    {
        // Field
        private clsUser _user;

        // Properties
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        // Constructor
        public ChooseSide_Form()
        {
            InitializeComponent();
        }
       

        private void badPictureBox_Click(object sender, EventArgs e)
        {
            // Assing the user's side.
            _user.Side = "evil";
            this.DialogResult = DialogResult.Abort;
        }

        private void goodPictureBox_Click(object sender, EventArgs e)
        {
            _user.Side = "good";
            this.DialogResult = DialogResult.Abort;
        }

        private void ChooseSide_Form_Load(object sender, EventArgs e)
        {
            goodPictureBox.Image = (Image)Properties.Resources.Gondor;
            badPictureBox.Image = (Image)Properties.Resources.Mordor;
        }
    }
}
