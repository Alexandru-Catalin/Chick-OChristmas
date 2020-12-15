using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0f;
    private float deathScore = 0f;
    public Text scoreText, death;
    public int difficultyLevel = 1;
    public int maxDifficultyLevel = 100;
    public int scoreToNextLevel = 10;

    void Update()
    {
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime * difficultyLevel;
        deathScore += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
        death.text = ((int)deathScore).ToString();
    }

    public void LevelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficultyLevel++;
    }
}
