using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasPirate : MonoBehaviour
{

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


    public void JumpPirate(string destinationPirate)
    {
        CounterPirate();
        GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().PlayClickPirate();
        GameObject.Find("MainCameraPirate").GetComponent<CanvasHolderPirate>().MovePirate(destinationPirate,false);
    }

    public void JumpPirateGame(int difPirate)
    {
        CounterPirate();
        GameObject.Find("MainCameraPirate").GetComponent<CanvasHolderPirate>().MovePirate("gamePirate", false,difPirate);
    }


    public void JumpBackPirate()
    {
        GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().PlayClickPirate();
        CounterPirate();
        GameObject.Find("MainCameraPirate").GetComponent<CanvasHolderPirate>().MoveBackPirate();
       
    }

    public void ClosePirate()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        CounterPirate();
        activity.Call<bool>("moveTaskToBack", true);
    }
}
