using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : Singleton<Score>
{
    public TextMeshProUGUI scoreText;
    private int score;

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
