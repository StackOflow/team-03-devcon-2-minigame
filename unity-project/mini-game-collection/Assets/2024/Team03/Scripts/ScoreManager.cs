using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace MiniGameCollection.Games2024.Team03
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI p1ScoreText;
        public int p1Score = 0;
        public TextMeshProUGUI p2ScoreText;
        public int p2Score = 0;

        private void Start()
        {
            // Update the score UI at the start of the game
            UpdateScoreUI();
        }

        // Method to increase the score by a certain amount (called when player earns points)
        public void AddP1Score(int points)
        {
            p1Score += points;
            UpdateScoreUI();
        }
        // Method to increase the score by a certain amount (called when player earns points)
        public void AddP2Score(int points)
        {
            p2Score += points;
            UpdateScoreUI();
        }
        public void ReduceP1Score(int punish)
        {
            p1Score -= punish;
            UpdateScoreUI();
        }
        // Method to increase the score by a certain amount (called when player earns points)
        public void ReduceP2Score(int punish)
        {
            p2Score -= punish;
            UpdateScoreUI();
        }

        // Method to reset the score, for example when restarting the game
        public void ResetScore()
        {
            p1Score = 0;
            p2Score = 0;
            UpdateScoreUI();
        }

        // Method to update the score UI text
        private void UpdateScoreUI()
        {
            // Ensure there's a UI Text component to display the score
            if (p1ScoreText != null)
            {
                p1ScoreText.text = p1Score.ToString();
            }
            if (p2ScoreText != null)
            {
                p2ScoreText.text = p2Score.ToString();
            }
        }
    }
}
