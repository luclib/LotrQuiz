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

    /*
     * Application is a quiz simulation based on material
     * drawn from the Lord of the Rings mythology and the 
     * life of its author: J.R.R. Tolkien.
     * 
     * The quiz itself will have 5 sections, each with its corresponding 
     * Windows form:
     * - Section I will contain five multiple choice questions concerning
     *       J.R.R. Tolkien;
     * - Section II will contain five True or False questions
     *      concerning the story of The Hobbit;
     * - Section III will contain a question with check boxes whereby the 
     *      user will be prompted to select all the correct answers from a set of
     *       options;
     * - Section IV will contain eight questions divided between two forms, 
     *      each form containing four questions, whereby the user will have to
     *       enter the correct answers in the TextBoxes provided;
     * - Section V will consist of a single Windows Form per question whereby
     *       the user will fill in the blank of a given statement via a Text Box.
     */

    public partial class MainForm : Form
    {
        // All of the forms in the application will have an instance of the clsUser class
        // so that the answers recorded in the subform can be transferred directly to those 
        // of the  MainForm, as the answer arrays of each will be referencing the original array
        // found in the MainForm as opposed to a copy of it.

        // Fields
        private clsUser _user = new clsUser();

        // Property
        public clsUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        //Define and initialize a music file to hold the music to be played at the beginning of the program until the user
        // has selected his side.
        SoundPlayer menuMusic = new SoundPlayer("MainMenu.wav");


        public MainForm()
        {
            InitializeComponent();
        }



        // The LOAD EVENT CLICK HANDLER will automatically populate the _correctAnswers array
        // with the answers from our Microsoft Acces Database file named "Answer Key"
        private void MainForm_Load(object sender, EventArgs e)
        {

            // Play music file.
            menuMusic.Play();

            // Load the map of Middle-Earth.
            pictureBox.Image = (Image)Properties.Resources.MiddleEarth;
        }

        // The ResetQuiz function takes the _user instance and resets all of its properties back to the values
        // of its default constructor to have it ready for another user to play the quiz.
        private void ResetQuiz()
        {
            // The method will process the array and replace every one of its answers with a null entry just 
            // as a default constructor would be populated.
            for (int index = 0; index < _user.UserAnswers.Length; index++)
            {

                if (_user.UserAnswers[index] != null)
                {
                    _user.UserAnswers[index] = null;
                }
                // On the other hand, as soon as the method detects a null entry it will know that the previous 
                // user had stopped the quiz at this question, at which point the program will abort and proceed
                // to modifying the remaining User properties.
                else
                {
                    break;
                }
            }
            // Set the user's FormNumber back to 1.
            _user.FormNumber = 1;
            // Set the section flags equal to false;
            _user.SectionI = false;
            _user.SectionII = false;
            _user.SectionIII = false;
            _user.SectionIV = false;
            _user.SectionV = false;
            // Set the progress bar to zero
            _user.Progress = 0;
            //_user.AutoFail = false;
        }

        // The DetermineForm method uses a set of if-else statements to determine which form
        // must be open at one time. The method takes an int representing the question number 
        // as an argument and returns another int indicating which subform to display at a given
        // time
        public int DetermineForm(int questionNumber)
        {
            int form = 0;
            if (questionNumber >= 1 && questionNumber <= 5)
            {
                // Load form 1: multiple choice-section
                form = 1;

            }
            else if (questionNumber >= 6 && questionNumber <= 10)
            {
                // Load form 2: true or false section.
                form = 2;
            }
            else if (questionNumber == 11)
            {
                // Load form 3: the checkbox section.
                form = 3;
            }
            else if (questionNumber >= 12 && questionNumber <= 19)
            {
                // Load form 4: the multiple-answer section
                form = 4;
            }
            else if (questionNumber >= 20 && questionNumber <= 30)
            {
                // Load form 5: the single-answer section.
                form = 5;
            }
            return form;
        }

        // The CheckCompletion method simply checks if the user has completed all of the sections of
        // the quiz by verifying that all of the section flag variables are true, which could only 
        // happen if the user has gone through all the questions to the very end. If so, the method 
        // will return a value of true, else it returns a value of false.
        // 
        // This method became necessary as without it, the program could mistake an incomplete quiz with a 
        // a completed quiz.
        private bool CheckCompletion()
        {
            bool complete = false;
            if (_user.SectionI)
                if (_user.SectionII)
                    if (_user.SectionIII)
                        if (_user.SectionIV)
                            if (_user.SectionV)
                                complete = true;
            return complete;
        }

        // Upon starting up the program, a form will be displayed prompting the user to choose a side by
        // clicking one of the animated pictures. Once he/she has selected a picture, his answer will assigned 
        // to the Side property of the clsUser instance, which will later on determine which ranking system
        // to use: those of the forces of good, or those of evil.
        private void startButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the ChooseSide Form
            ChooseSide_Form choose = new ChooseSide_Form();
            // Assign the subform's user instance to that of the MainForm's.
            choose.User = _user;
            // Display the subform.
            choose.ShowDialog();

            // Once the user has selected his side, the subform will close, at which point the music file
            // will cease playing.
            if(choose.DialogResult == DialogResult.Abort)
            {
                menuMusic.Stop();
                // Now the program will create subforms for each of the quiz sections.
                // First for section I...
                MC_Form mc = new MC_Form();
                // Next, for section II...
                TrueOrFalse_Form tr = new TrueOrFalse_Form();
                // Then for section III..
                CheckBox_Form cBox = new CheckBox_Form();
                // Then for section IV...
                MultiAnswer_Form multi = new MultiAnswer_Form();
                // And finally for section V...
                ShortAnswer_Form shorty = new ShortAnswer_Form();

                // Now a while loop is used in conjuction with the DetermineForm method to display the 
                // appropriate subform in accordance with the user's formNumber (which, as a reminder, corresponds
                // to the question number the user find him or herself in, with the exception of section IV wherein
                // multiple questions are displayed in one form).
                //
                // As long quiz remains incomplete, the program will continuously display the subform according to
                // the user's FormNumber property.
                //
                // Naturally, the multiplce choice section will always be displayed first as the user starts with a 
                // FormNumber value of 1.
                while (!(_user.SectionI == true
                        && _user.SectionII == true
                        && _user.SectionIII == true
                        && _user.SectionIV == true
                        && _user.SectionV == true))
                {
                    int form = DetermineForm(_user.FormNumber);

                    if (form == 1)
                    {
                        // Set the subform's clsUser object to that of the main form.
                        mc.User = _user;
                        // Show the subform.
                        mc.ShowDialog();

                        // If the user closes the subform BEFORE completion, the DialogResult will be set to cancel,
                        // at which point, the subform will close and a message will be displayed indicating to the user
                        // that he/she has exited the quiz.
                        if (mc.DialogResult == DialogResult.Cancel)
                        {
                            // Display message.
                            MessageBox.Show("You have been exited from the quiz. Fly you fool!");
                            // Reset the clsUser's properties.
                            ResetQuiz();
                            // Re-play menu music.
                            menuMusic.Play();
                            // Exit the while loop.
                            break;
                        }
                        // On the other hand, if the user reaches the end of a section, the DialogResult is set to abort 
                        // which closes the section without activating the exit message.
                    }
                    // Section II differs from the other sections in that it contains a trap question (question 10), which,
                    // if the user answers incorrectly, he will be automatically exited from the quiz due to his/her bad taste
                    // and/or ignorance.
                    else if (form == 2)
                    {
                        // Set the subform's clsUser object to that of the main form.
                        tr.User = _user;
                        // Show the subform.
                        tr.ShowDialog();
                        // if the user closes the window, display the exit message and reset the clsUser's instance.
                        if (tr.DialogResult == DialogResult.Cancel)
                        {
                            // Display message.
                            MessageBox.Show("You have been exited from the quiz. Fly you fool!");
                            // Reset the clsUser's properties.
                            ResetQuiz();
                            // Re-play menu music.
                            menuMusic.Play();
                            // Exit the while loop.
                            break;
                        }
                        else if (_user.SectionII == true)
                        {
                            // Now check to see if he/she answered the trap question incorrectly
                            if (_user.UserAnswers[9] == "True")
                            {
                                // If so, close the form.
                                tr.Close();

                                // Create and display an instance of the AutoFail form which contains within it
                                // a message indicating to him/her what happened.
                                AutoFail fail = new AutoFail();
                                fail.ShowDialog();

                                // Once the user closes the AutoFail form, the quiz will end and the user's
                                // answers will be reset.
                                if (fail.DialogResult == DialogResult.Cancel)
                                {
                                    // Display message.
                                    MessageBox.Show("You have been exited from the quiz. Fly you fool!");
                                    // Reset the clsUser's properties.
                                    ResetQuiz();
                                    // Re-play menu music.
                                    menuMusic.Play();
                                    // Exit the while loop.
                                    break;
                                }
                            }
                        }
                    }
                    else if (form == 3)
                    {
                        // Set the subform's clsUser object to that of the main form.
                        cBox.User = _user;
                        // Show the form.
                        cBox.ShowDialog();
                        // if the user closes the window, display the exit message and reset the clsUser's instance.
                        if (cBox.DialogResult == DialogResult.Cancel)
                        {
                            // Display message.
                            MessageBox.Show("You have been exited from the quiz. Fly you fool!");
                            // Reset the clsUser's properties.
                            ResetQuiz();
                            // Re-play menu music.
                            menuMusic.Play();
                            // Exit the while loop.
                            break;
                        }
                    }
                    else if (form == 4)
                    {
                        // Set the subform's clsUser object to that of the main form.
                        multi.User = _user;
                        // Show the form.
                        multi.ShowDialog();
                        // if the user closes the window, display the exit message and reset the clsUser's instance.
                        if (multi.DialogResult == DialogResult.Cancel)
                        {
                            // Display message.
                            MessageBox.Show("You have been exited from the quiz. Fly you fool!");
                            // Reset the clsUser's properties.
                            ResetQuiz();
                            // Re-play menu music.
                            menuMusic.Play();
                            // Exit the while loop.
                            break;
                        }
                    }
                    else if (form == 5)
                    {
                        // Set the subform's clsUser object to that of the main form.
                        shorty.User = _user;
                        // Show the form.
                        shorty.ShowDialog();
                        // if the user closes the window, display the exit message and reset the clsUser's instance.
                        if (shorty.DialogResult == DialogResult.Cancel)
                        {
                            // Display message.
                            MessageBox.Show("You have been exited from the quiz. Fly you fool!");
                            // Reset the clsUser's properties.
                            ResetQuiz();
                            // Re-play menu music.
                            menuMusic.Play();
                            // Exit the while loop.
                            break;
                        }
                    }
                }
                // Now verify that all quiz sections are complete.
                if (CheckCompletion() == true)
                {
                    // ... if so, create an instance of the Final_form that contains the user's quiz score and ranking.
                    Final_Form result = new Final_Form();
                    // Set the subform's clsUser instance to that of the main form.
                    result.User = _user;
                    // Display the subform.
                    result.ShowDialog();
                    // Once the user has closed the subform, reset the quiz and close the music
                    if (result.DialogResult == DialogResult.Cancel)
                    {
                        // The result form contains within a SoundPlayer object has one of its properties.
                        // Once the form has been closed, the music will stop playing.
                        result.Music.Stop();
                        ResetQuiz();
                        // Replay the menu music.
                        menuMusic.Play();
                    }
                }
            }
            
        }

        // The EXIT BUTTON Click handler event simply exits the quiz.
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
