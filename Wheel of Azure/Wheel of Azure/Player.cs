﻿using System;

namespace Wheel_of_Azure
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int TotalScore { get; set; }

        public Player(string n)
        {
            Name = n;
            Score = 0;
            TotalScore = 0;
        }

        public void AddCurrentScore(int i)
        {
            Score += i;
        }

        public void ResetCurrentAndTotalScores()
        {
            int curr = Score;
            Score = 0;
            TotalScore += curr;
        }
    }
}
