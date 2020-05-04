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
    public partial class AutoFail : Form
    {
        public AutoFail()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void AutoFail_Load(object sender, EventArgs e)
        {
            // Suspend layout of the control.
            gameOverLabel.SuspendLayout();
            // Suspend the layout of the picture box.
            pictureBox.SuspendLayout();
            // Suspend of the form.
            SuspendLayout();
            // Set the back color to transparent.
            gameOverLabel.BackColor = Color.Transparent;

            // Resume the layout of the control by setting the 
            // argument to false.
            gameOverLabel.ResumeLayout(false);
            // Resume layout of the form by setting the argument to false.
            ResumeLayout(false);
            // Resume layout of the picture box.
            pictureBox.ResumeLayout(false);

            // Enable timer
            timer.Enabled = true;
            timer.Interval = 10850;
            timer2.Enabled = true;
            timer2.Interval = 12000;

            this.pictureBox.Image = (Image)Properties.Resources.GimliOver;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameOverLabel.Visible = !gameOverLabel.Visible;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gameOverLabel.Visible = !gameOverLabel.Visible;
            timer.Interval += 150;
        }
    }
}
