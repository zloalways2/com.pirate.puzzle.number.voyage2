using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellPirate : MonoBehaviour
{

    public Sprite correctSpritePirate;
    public Sprite currentSpritePirate;
    public int horPositionPirate;
    public int vertPositionPirate;
    public bool correctPirate = false;

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

    public void onClickPirate()
    {
      var tempPirate=GameObject.Find("GameCanvasPirate").GetComponent<GameLogicPirate>().currentEmptyPirate;
        if ((Mathf.Abs((horPositionPirate + vertPositionPirate) - (tempPirate.vertPositionPirate + tempPirate.horPositionPirate)) == 1)&&((vertPositionPirate == tempPirate.vertPositionPirate)||(horPositionPirate==tempPirate.horPositionPirate)))
        {
            var tempSpritePirate = tempPirate.currentSpritePirate;
            tempPirate.currentSpritePirate = currentSpritePirate;
            currentSpritePirate = tempSpritePirate;
            CounterPirate();
            GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().PlayPingPirate();
            GameObject.Find("GameCanvasPirate").GetComponent<GameLogicPirate>().currentEmptyPirate = this;
            GameObject.Find("GameCanvasPirate").GetComponent<GameLogicPirate>().checkAllPositionsPirate();
        }
    }

    public bool checkPositionPirate()
    {
        GetComponent<Image>().sprite=currentSpritePirate;
        if (currentSpritePirate == correctSpritePirate)
        {
            CounterPirate();
            correctPirate = true;
        }
        else correctPirate = false;
        return correctPirate;
    }

}
