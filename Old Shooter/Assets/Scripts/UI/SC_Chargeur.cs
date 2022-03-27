using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Chargeur : MonoBehaviour
{
    public bool isP1;

    public int nbBalle;
    public int nbBalleMax = 7;

    [SerializeField] private Image[] imageArray;
    [SerializeField] private Sprite Balle;
    [SerializeField] private Sprite BalleEmpty;


    void Update()
    {
        updateChargeur();
    }

    private void updateChargeur()
    {
        for (int i = 0; i < imageArray.Length; i++)
        {
            if (nbBalle > nbBalleMax)
                nbBalle = nbBalleMax;

            if (i < nbBalle)
            {
                imageArray[i].sprite = Balle;
            }
            else
            {
                imageArray[i].sprite = BalleEmpty;
            }

            if(i < nbBalleMax)
            {
                imageArray[i].enabled = true;
            }
            else
            {
                imageArray[i].enabled = false;
            }
        } 
    }

    public void TriggerReloadEvent(bool isP1)
    {
        if (isP1 == this.isP1)
        {
            nbBalle = nbBalleMax;
        }
    }

    public void TriggerFireEvent(bool isP1)
    {
        if (isP1 == this.isP1)
        {
            nbBalle -= 1;
        }
    }
}
