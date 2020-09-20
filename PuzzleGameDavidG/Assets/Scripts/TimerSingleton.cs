using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSingleton : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int timer;

    public static TimerSingleton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);        
        }
    }

    public void addTimer()
    {
        timer++;
    }
}
