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
    public partial class Final_Form : Form
    {
        // FIELDS //////////////////////////////////////////////////
        private clsUser _user;
        private SoundPlayer _music;

        // PROPERTIES //////////////////////////////////////////////
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        public SoundPlayer Music
        {
            get { return _music; }
            set { _music = value; }
        }

        public Final_Form()
        {
            InitializeComponent();
        }

        public void DetermineDisplay()
        {
            string rank;
            rank = User.DetermineRank();
            if (User.Side == "good")
            {
                switch (rank) 
                {
                    case "Halfling":
                        topPictureBox.Image = (Image)Properties.Resources.HalflingsTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.HalflingsBottom;
                        messageLabel.Text += " (but you could do better)";
                        Music = new SoundPlayer("goodvictory.wav");
                        rankingLabel.Text = rank;
                        Music.Play();
                        break;
                    case "Dwarf":
                        topPictureBox.Image = (Image)Properties.Resources.GimliHappy;
                        bottomPictureBox.Image = (Image)Properties.Resources.GimliDrunk;
                        rankingLabel.Text = rank;
                        messageLabel.Text += " (but you could do better)";
                        Music = new SoundPlayer("goodvictory1.wav");
                        Music.Play();
                        break;
                    case "Man of the West":
                        topPictureBox.Image = (Image)Properties.Resources.MenOfTheWestTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.MenOfTheWestBottom;
                        rankingLabel.Text = rank;
                        Music = new SoundPlayer("goodvictoryalt.wav");
                        Music.Play();
                        break;
                    case "Elf":
                        topPictureBox.Image = (Image)Properties.Resources.ElfTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.ElfBottom;
                        rankingLabel.Text = rank;
                        Music = new SoundPlayer("goodvictory3.wav");
                        Music.Play();
                        break;
                    case "Wizard":
                        topPictureBox.Image = (Image)Properties.Resources.Gandalf;
                        bottomPictureBox.Image = (Image)Properties.Resources.WizardBottom;
                        rankingLabel.Text = rank;
                        Music = new SoundPlayer("taking_the_hobbits_to_Isengard.wav");
                        Music.Play();
                        break;
                }
            }

            if(User.Side == "evil")
            {
                switch (rank)
                {
                    case "Goblin-rat":
                        topPictureBox.Image = (Image)Properties.Resources.GoblinTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.GoblinBottom;
                        rankingLabel.Text =rank;
                        messageLabel.Text += " (but not really)";
                        Music =  new SoundPlayer("EvilEnd3.wav");
                        Music.Play();
                        break;
                    case "Orc-maggot":
                        topPictureBox.Image = (Image)Properties.Resources.OrcTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.OrcBottom;
                        rankingLabel.Text = rank;
                        messageLabel.Text += " (but not really)";
                        Music = new SoundPlayer("EvilEnd3.wav");
                        Music.Play();
                        break;
                    case "Uruk-scum":
                        topPictureBox.Image = (Image)Properties.Resources.UrukTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.UrukBottom;
                        rankingLabel.Text = rank;
                        Music = new SoundPlayer("EvilVictory2.wav");
                        Music.Play();
                        break;
                    case "Ringwraith":
                        topPictureBox.Image = (Image)Properties.Resources.RingwraithTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.RingwraithBottom;
                        rankingLabel.Text = rank;
                        Music = new SoundPlayer("EvilVictory3.wav");
                        Music.Play();
                        break;
                    case "Dark Lord":
                        topPictureBox.Image = (Image)Properties.Resources.DarkLordTop;
                        bottomPictureBox.Image = (Image)Properties.Resources.DarkLordBottom;
                        rankingLabel.Text = rank;
                        Music = new SoundPlayer("evilvictory3.wav");
                        Music.Play();
                        break;
                }
            }
        }

        private void Results_Form_Load(object sender, EventArgs e)
        {
            double score = this.User.CalculateScore();
            scoreLabel.Text = score.ToString();
            double scorePercent = (score / 30.0) * 100.0;
            percentCorrectLabel.Text = scorePercent.ToString("n1");
            if (User.Ranking == "Goblin-rat")
                messageLabel.Text += " (but not really)";
            else if(User.Ranking == "Halfling")
                messageLabel.Text = " (but you could do better)";
            DetermineDisplay();

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the Results form.
            Results_Form results = new Results_Form();
            results.User = _user;
            // Display the form.
            results.ShowDialog();
        }
    }
}
