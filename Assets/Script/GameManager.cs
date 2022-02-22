using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string playTime { get; private set; }

    private float timeSec;
    private float timeMin;

    private void Update()
    {
        timeCalc();
        playTime = timeMin.ToString("00") + ":" + timeSec.ToString("00");
    }
    private void timeCalc()
    {
        timeSec += Time.deltaTime;
        if(timeSec >= 59.5f)
        {
            timeSec = 0f;
            timeMin += 1f;
        }
    }

}