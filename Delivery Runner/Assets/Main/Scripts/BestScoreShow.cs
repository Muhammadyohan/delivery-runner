using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreShow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int highestScore;

    void Start ()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highestScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highestScore = 0;
        }
        scoreText.text = highestScore.ToString();
    }
}
