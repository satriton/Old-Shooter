using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        timerText.text = getTimeRemaining();
    }

    private string getTimeRemaining()
    {
        float time = SC_EnnemieManager.gameTime;

        var minute = (int)time/60;
        var second = (int)time % 60;

        return string.Format("{0:00}:{1:00}", minute, second);
    }
}
