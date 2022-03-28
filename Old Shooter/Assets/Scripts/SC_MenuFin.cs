using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_MenuFin : MonoBehaviour
{
    public AudioSource[] source;
    public Text victoryText;
    public Text scoreP1;
    public Text scoreP2;


    void Start()
    {
        audioVictoire();

        if (SC_ScoreUI.scoreP1 > SC_ScoreUI.scoreP2)
            victoryText.text = "Player 1 wins !";
        else
            victoryText.text = "Player 2 wins !";


        scoreP1.text = "Player 1 score\n" + SC_ScoreUI.scoreP1;
        scoreP2.text = "Player 2 score\n" + SC_ScoreUI.scoreP2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void audioVictoire()
    {
        for (int i = 0; i < source.Length; i++)
        {
            source[i].Play();
        }
    }
}
