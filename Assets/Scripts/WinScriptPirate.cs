using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptPirate : MonoBehaviour
{
  
    public Text ScoreTxtPirate;

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

    public void WinScreenPirate()
    {
        ScoreTxtPirate.text = GameObject.Find("LevelTextPirate").GetComponent<Text>().text;

        CounterPirate();
    }

}
