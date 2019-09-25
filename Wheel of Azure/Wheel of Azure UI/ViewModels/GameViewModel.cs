using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheel_of_Azure;

namespace Wheel_of_Azure_UI.ViewModels
{
    public class GameViewModel: Screen
    {
        PhraseBoard myBoard = new PhraseBoard("hello");

        private string _phraseText;

        public string PhraseText
        {
            get { return _phraseText; }
            set
            {
                _phraseText = value;
                NotifyOfPropertyChange(() => PhraseText);
            }
        }

        private string _guessedLetter;

        public string GuessedLetter 
        {
            get { return _guessedLetter; }
            set { _guessedLetter = value; }
        }


        public GameViewModel()
        {
            Debug.WriteLine(myBoard.GetBoardString());
            PhraseText = myBoard.GetBoardString();
        }

        public void SubmitGuess()
        {
            Debug.WriteLine(GuessedLetter);
            myBoard.MakeGuess(1, char.Parse(GuessedLetter));
            PhraseText = myBoard.GetBoardString();
        }
    }
}
