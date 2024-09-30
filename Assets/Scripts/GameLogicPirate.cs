using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicPirate : MonoBehaviour
{
    public CellPirate currentEmptyPirate;
    public Sprite sprite1Pirate;
    public Sprite sprite2Pirate;
    public Sprite sprite3Pirate;
    public Sprite sprite4Pirate;
    public Sprite sprite5Pirate;
    public Sprite sprite6Pirate;
    public Sprite sprite7Pirate;
    public Sprite sprite8Pirate;
    public Sprite sprite9Pirate;
    bool checkPirate = false;

    public System.Random rPirate = new System.Random();
    List<Sprite> spritesPirate;
    public Text levelTextPirate;


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

    public void InitGamePirate(int diffPirate)
    {

        levelTextPirate.text = "Level " + diffPirate;
        GetComponent<TimerScriptPirate>().RefreshTimerPirate();

        checkPirate = false;
        spritesPirate = new List<Sprite>
        {
            sprite1Pirate,
            sprite2Pirate,
            sprite3Pirate,
            sprite4Pirate,
            sprite5Pirate,
            sprite6Pirate,
            sprite7Pirate,
            sprite8Pirate,
            sprite9Pirate
        };

        for(int iPirate = 1; iPirate < 10; iPirate++)
        {
            GameObject.Find("GameCellPirate" + iPirate.ToString()).GetComponent<CellPirate>().currentSpritePirate = RandomSpritePirate();
            GameObject.Find("GameCellPirate" + iPirate.ToString()).GetComponent<CellPirate>().checkPositionPirate();
            if (GameObject.Find("GameCellPirate" + iPirate.ToString()).GetComponent<CellPirate>().currentSpritePirate == sprite9Pirate)
                currentEmptyPirate = GameObject.Find("GameCellPirate" + iPirate.ToString()).GetComponent<CellPirate>();
        }


    }

    public bool checkAllPositionsPirate()
    {
        
        int countPirate = 0;

        for (int iPirate = 1; iPirate < 10; iPirate++)
        {        
           if(GameObject.Find("GameCellPirate" + iPirate.ToString()).GetComponent<CellPirate>().checkPositionPirate())
            {
                countPirate++;
            }
        }

        if(countPirate == 9) checkPirate = true;

        return checkPirate;
    }


    public Sprite RandomSpritePirate()
    {
        Sprite tempSpritePirate;
        int rIntPirate = rPirate.Next(0, spritesPirate.Count);
        tempSpritePirate = spritesPirate[rIntPirate];
        spritesPirate.RemoveAt(rIntPirate);
            
        return tempSpritePirate;
    }

     void Update()
    {
        if(checkPirate)
        {
            CounterPirate();
            checkPirate = false;
            GetComponent<JumpCanvasPirate>().JumpPirate("winPirate");
        }
    }

}
