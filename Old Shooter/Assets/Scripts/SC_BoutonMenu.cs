using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_BoutonMenu : MonoBehaviour, IShootable
{
    public string sceneToLoad;

    public void DoAction()
    {

    }

    public void GetShoot(SC_Player scplayer)
    {
        if (sceneToLoad.Equals("Quit"))
        {
            Application.Quit();
        } else if (sceneToLoad.Equals("Resume"))
        {
            SC_Player.Pause();
        } else
        {
            Time.timeScale = 1;
            SC_Player.isGame = false;
            SceneManager.LoadScene(sceneToLoad);
        }



    }

    public void Move(List<Vector2> listOfPointPath)
    {

    }

    public void OnSpawn()
    {

    }
}
