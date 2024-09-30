using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptPirate : MonoBehaviour
{
    public float TimeLeftPirate = 120;
    public bool TimerOnPirate = false;


    public Text TimerTxtPirate;

    private double CounterPirate(int x = 2)
    {
        try
        {
            float aPirate = 0;
            for (int i = 0; i < 3; i++)
            {
                aPirate += Time.time;
            }
            return aPirate - x;
        }
        catch (Exception ePirate)
        {
            return 1f;
        }
    }

    void Update()
    {
        if (TimerOnPirate)
        {
            if (TimeLeftPirate > 1)
            {
                TimeLeftPirate -= Time.deltaTime;
                UpdateTimerPirate(TimeLeftPirate);
            }
            else
            {
                TimerOnPirate = false;
                GameObject.Find("MainCameraPirate").GetComponent<CanvasHolderPirate>().MovePirate("losePirate");
            }
        }
    }

    public void RefreshTimerPirate()
    {
        TimeLeftPirate = 180;
        TimerOnPirate = true;
        CounterPirate();
        TimerTxtPirate.text = "";
    }
    void UpdateTimerPirate(float currentTimePirate)
    {
        currentTimePirate -= 1;
        CounterPirate();
        float minutesPirate = Mathf.FloorToInt(currentTimePirate / 60);
        float secondsPirate = Mathf.FloorToInt(currentTimePirate % 60);

        TimerTxtPirate.text = "Time:\n" + string.Format("{0:00}:{1:00}", minutesPirate, secondsPirate);
    }
}
