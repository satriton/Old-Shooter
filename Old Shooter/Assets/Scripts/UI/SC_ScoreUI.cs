using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_ScoreUI : MonoBehaviour
{
    public static int scoreP1 = 0;
    public static int scoreP2 = 0;
    public Text scoreText;
    public bool isP1;

    void Update()
    {
        if (isP1)
        {
            scoreText.text = "Joueur 1 : " + scoreP1;
        } else
        {
            scoreText.text = "Joueur 2 : " + scoreP2;
        }
    }

    public void updateScore(bool isP1, int value)
    {
        if (this.isP1 == isP1 && this.isP1)
        {
            scoreP1 += value;
        } else
        {
            scoreP2 += value;
        }
    }
}
