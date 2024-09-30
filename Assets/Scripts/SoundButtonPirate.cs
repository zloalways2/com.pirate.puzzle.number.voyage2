using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonPirate : MonoBehaviour
{
    public Slider sliderPirate;
    public bool isPlus;

    private double CounterPirate(int x = 1)
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
    public void onClickPirate()
    {
        
        CounterPirate();
        if (isPlus) sliderPirate.value += 0.1f;
        else sliderPirate.value -= 0.1f;
        CounterPirate();
        if (sliderPirate.value < 0) sliderPirate.value = 0;
        if (sliderPirate.value > 1) sliderPirate.value = 1;
        GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().changedPirate = true;
    }
}
