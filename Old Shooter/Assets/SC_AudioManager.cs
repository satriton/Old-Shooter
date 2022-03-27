using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource[] douilleSound;
    [SerializeField] public AudioSource reloadSound;
    [SerializeField] public AudioSource fireSound;


    public void playFireSound()
    {
        fireSound.Play();

        int indiceSound = (int)Random.Range(0f, douilleSound.Length);
        douilleSound[indiceSound].PlayDelayed(0.4f);
    }

    public void playReloadSound()
    {

        reloadSound.Play();
    }
}
