using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_ScoreUI : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public bool isP1;

    void Update()
    {
        if (isP1)
        {
            scoreText.text = "Joueur 1 : " + score;
        } else
        {
            scoreText.text = "Joueur 2 : " + score;
        }
    }

    public void updateScore(bool isP1, int value)
    {
        if (this.isP1 == isP1)
            score += value;
    }
}
