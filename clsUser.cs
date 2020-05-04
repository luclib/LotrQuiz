using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_Quiz
{
    public class clsUser
    {
        /*
         * The clsUser Class represents a hypothetical quiz taker and, as such, contains two arrays
         * of length 30 as properties, one to record the user's answers and the other containing 
         * the correct answers drawn from an answer key stored in a Microsoft Access database file.
         * 
         * The clsUser class will also contain five bool properties corresponding to the 
         * five different sections (or subforms) of the quiz, each of which will be used as flag variables
         * whereby a value of "true" indicates that a user has completed a section of the quiz.
         * 
         * Numerical properties of the clsUser class include two int variables, one to track the user's progress
         * and display it in a progress bar on each section subform, the other to record the form number of the user.
         * In this case, the form number is equal to the question number in that each subform will display a single 
         * question at a time with the exception of section iv, which includes forms with multiple questions/answers.
         * In addition, the Score property will hold the score of the user.
         * 
         * Finally, the clsUser class also contains two string properties, Side and Ranking. Upon launching the
         * program, the user will be prompted to choose a side, either "good" or "evil" which will later
         * determine which ranking system the program will use and assign.
         */

        // FIELDS
        private string[] _userAnswers;      // Stores the user's answers
        private string[] _correctAnswers;   // Stores the correct answers from the answer key.
        private bool _sectionI;             // Records the completion of the Multiple Choice section.
        private bool _sectionII;            // Records the completion of the True or False section
        private bool _sectionIII;           // Records the completion of the Check Box question.
        private bool _sectionIV;            // Records completion of the Multiple-Answer section.
        private bool _sectionV;             // Records completion of the Short Answer section
        private int _progress;              // Records progress of the quiz to fill up the Progress Bar.
        private int _formNumber;            // Records the form number of the quiz.
        private string _side;               // Records which side the player chose to play on.
        private string _ranking;            // Records the user's rank based on his score.
        private int _score;                 // Records the user's number of correct answers.

        //--------------------------------------------
        //  CONSTRUCTOR
        //
        // By default, the constructor will have two empty string arrays and all of the section flag 
        // variables set to false.
        public clsUser()
        {
            _userAnswers = new string[30];
            _correctAnswers = new string[30]{ "South Africa", "John Ronald Reuel", "Roman Catholicism",
                "The Battle of the Somme (1916)", "Oxford", "True", "False",
                "True", "True", "False", "dwarves", "3", "7", "9", "1",
                "rule", "find", "bring", "bind", "1973", "111", "Smeagol",
                "fat", "Isengard", "walk", "precious", "eagles", "prey",
                "Morgoth", "Sauron"};
            _sectionI = false;
            _sectionII = false;
            _sectionIII = false;
            _sectionIV = false;
            _sectionV = false;
            _progress = 0;
            _formNumber = 1;
            _side = "";
            _ranking = "";
            _score = 0;
        }

        // ---------------------------------------------
        // PROPERTIES
        public string[] UserAnswers
        {
            get { return _userAnswers; }
            set { _userAnswers = value; }
        }

        public bool SectionI
        {
            get { return _sectionI; }
            set { _sectionI = value; }
        }

        public bool SectionII
        {
            get { return _sectionII; }
            set { _sectionII = value; }
        }

        public bool SectionIII
        {
            get { return _sectionIII; }
            set { _sectionIII = value; }
        }

        public bool SectionIV
        {
            get { return _sectionIV; }
            set { _sectionIV = value; }
        }

        public bool SectionV
        {
            get { return _sectionV; }
            set { _sectionV = value; }
        }

        public int Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }

        public int FormNumber
        {
            get { return _formNumber; }
            set { _formNumber = value; }
        }

        public string Side
        {
            get { return _side; }
            set { _side = value; }
        }

        public string Ranking
        {
            get { return _ranking; }
            set { _ranking = value; }
        }

        public string[] CorrectAnswers
        {
            get { return _correctAnswers; }
            set { _correctAnswers = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        // ---------------------------------------------
        //  METHODS
        //
        // The CalculateScore method compares the user's answers with the correct answers
        // drawn from the answer key in order to calculate the user's quiz score by recording
        // how many of the user's answers match those of the answer key. The resulting score
        // is return as a double variable.
        public double CalculateScore()
        {
           _score = 0;      // to hold quiz score
            for (int count = 0; count < _userAnswers.Length; count++)
            {
                if (_userAnswers[count] == _correctAnswers[count])
                {
                    _score++;
                }
            }
            return _score;
        }
        
        
        // The DetermineRank method and returns a string denoting the user's rank by looking
        // first at the User's Side and then score.
        public string DetermineRank()
        {
            string rank = "";
            switch (_side)
            {
                case "evil":
                    if (_score >= 0 && _score <= 6)
                    {
                        rank = "Goblin-rat";
                    }
                    if (_score > 6 && _score <= 12)
                    {
                        rank = "Orc-maggot";
                    }
                    if (_score > 12 && _score <= 18)
                    {
                        rank = "Uruk-scum";
                    }
                    if (_score > 18 && _score <= 24)
                    {
                        rank = "Ringwraith";
                    }
                    if (_score > 24 && _score <= 30)
                    {
                        rank = "Dark Lord";
                    }
                    break;

                case "good":
                    if (_score >= 0 && _score <= 6)
                    {
                        rank = "Halfling";
                    }
                    if (_score > 6 && _score <= 12)
                    {
                        rank = "Dwarf";
                    }
                    if (_score > 12 && _score <= 18)
                    {
                        rank = "Man of the West";
                    }
                    if (_score > 18 && _score <= 24)
                    {
                        rank = "Elf";
                    }
                    if (_score > 24 && _score <= 30)
                    {
                        rank = "Wizard";
                    }
                    break;
            }
            return rank;
        }
    }
}
