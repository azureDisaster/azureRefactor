﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Wheel_of_Azure;
using Xunit;
using System.Diagnostics;
using Moq;

namespace UnitTests
{
    public class TestGame
    {
        [Theory]
        [InlineData("abc", "1; Diane; bad;1;x;1;bad;b; 1;b;a; 2;abc;;", 1000, 6400)]
        [InlineData("blues clues", "1; Diane; 1;b; 2;blues clues;;", 100, 5100)]
        [InlineData("dog", "1; Diane; 2;cat; 2;dog;;", 100, 5000)]
        [InlineData("cat", "1; Diane; 1; 2;cat;;", Wheel.LoseATurn, 5000)]
        [InlineData("abc", "2; Diane; Wolf; 1;c; 1;x; 1;z; 2;abc;;", 100, 5100)]
        [InlineData("abc", "a; 4; ; ; ; ; 2;x; 2;x; 2;x; 2;x; 2; abc;;", 100, 5000)]
        public void TestGameStart_PlayerOneWins(string phrase, string consoleInput, int fixedWheelAmount, int expected)
        {
            // Redirect the console input to a string, ';' is used to separate line inputs
            var stringBuilder = new StringBuilder();
            foreach (var str in consoleInput.Split(';') )
            {
                stringBuilder.AppendLine(str.Trim());
            }
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);

            // setup the mock ICategorizedPhrases so the phrase is our test value
            var mock = new Mock<ICategorizedPhrases>();
            mock.Setup(x => x.category).Returns("Test");
            mock.Setup(x => x.GetPhrase("Test")).Returns(phrase);

            // Instantiate a new Game object, overwrite the wheel with our fixed amount
            var game = new Game(mock.Object)
            {
                wheel = new Wheel(new int[] { fixedWheelAmount })
            };

            // Start the game
            game.Start();

            // Examine the state of the player's score to see if the game ran correctly
            //int expected = fixedWheelAmount*lettersGuessedCorrectly + PhraseBoard.PointsEarnedForSolving;
            int actual = game.players[0].TurnScore;
            Assert.Equal(expected, actual);
        }



        [Fact(Skip = "randomized phrases, will add test later") ]
        public void TestProgramMain_OnePlayer()
        {
            // This is just to get code coverage on our main program :)
            Program.Main(new string[] {"abc", "1\r\nDiane\r\n2\r\nabc\r\n\r\n" });
        }
    }
}
