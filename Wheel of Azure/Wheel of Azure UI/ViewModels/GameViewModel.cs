using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wheel_of_Azure;

namespace Wheel_of_Azure_UI.ViewModels
{
    public class GameViewModel: Screen
    {
        PhraseBoard myBoard = new PhraseBoard("azure");
        Player playerOne;
        Wheel wheel = new Wheel();
        int wheelAmount;
        System.Media.SoundPlayer themeSound;
        System.Media.SoundPlayer winSound;
        bool bankrupt = false;

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
            set {
                _guessedLetter = value;
                NotifyOfPropertyChange(() => GuessedLetter);
            }
        }

        private string _scoreText;

        public string ScoreText
        {
            get { return _scoreText; }
            set {
                _scoreText = value;
                NotifyOfPropertyChange(() => ScoreText);
            }
        }

        private string _wheelText;

        public string WheelText
        {
            get { return _wheelText; }
            set
            {
                _wheelText = value;
                NotifyOfPropertyChange(() => WheelText);
            }
        }

        private bool _guessButtonEnabled;

        public bool GuessButtonEnabled
        {
            get { return _guessButtonEnabled; }
            set
            {
                _guessButtonEnabled = value;
                NotifyOfPropertyChange(() => GuessButtonEnabled);
            }
        }

        private bool _spinButtonEnabled;

        public bool SpinButtonEnabled
        {
            get { return _spinButtonEnabled; }
            set
            {
                _spinButtonEnabled = value;
                NotifyOfPropertyChange(() => SpinButtonEnabled);
            }
        }



        public GameViewModel()
        {
            Debug.WriteLine(myBoard.GetBoardString());
            PhraseText = myBoard.GetBoardString();
            playerOne = new Player("Player One");
            WheelText = "Wheel: ";
            ScoreText = $"Score: ${playerOne.TurnScore} ";
            GuessButtonEnabled = false;
            SpinButtonEnabled = true;
            themeSound =
                new System.Media.SoundPlayer(@"C:\Users\v-deree\Projects\azureRefactor\Wheel of Azure\Wheel of Azure UI\Sounds\theme.wav");
            winSound =
               new System.Media.SoundPlayer(@"C:\Users\v-deree\Projects\azureRefactor\Wheel of Azure\Wheel of Azure UI\Sounds\win.wav");
            themeSound.Play();
        }
        public void SubmitGuess()
        {
            Debug.WriteLine(GuessedLetter);
            int pointsEarned = 0;
            try
            {
                pointsEarned = myBoard.MakeGuess(wheelAmount, char.Parse(GuessedLetter));
            } catch (Exception e)
            {
                string msgText = "Please enter a guess";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show(msgText, "Wheel of Azure", button);
            }

            if(pointsEarned > 0)
            {
                playerOne.AddCurrentScore(pointsEarned);
            } 
            PhraseText = myBoard.GetBoardString();
            ScoreText = $"Score: ${playerOne.TurnScore} ";
            GuessedLetter = "";
            GuessButtonEnabled = false;
            SpinButtonEnabled = true;
            if(myBoard.IsGameOver())
            {
                WheelText = "You win!!!!";
                winSound.Play();
                GuessButtonEnabled = false;
                SpinButtonEnabled = false;
            }
        }

        public void HandleSpinClick()
        {
            Spin(playerOne);
            if(!bankrupt)
            {
                GuessButtonEnabled = true;
                SpinButtonEnabled = false;
            }
            
        }

        public void Spin(Player player)
        {
            wheelAmount = wheel.WheelSpin();

            if(wheelAmount > 0)
            {
                bankrupt = false;
                WheelText = $"Wheel: ${wheelAmount}";
            } else
            {
                WheelText = $"Wheel: BANKRUPTCY";
                playerOne.AddCurrentScore(-1 * playerOne.TurnScore);
                ScoreText = $"Score: ${playerOne.TurnScore} ";
                bankrupt = true;
            }  
        }
    }
}
