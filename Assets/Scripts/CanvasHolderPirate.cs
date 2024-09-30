using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderPirate : MonoBehaviour
{
    public Canvas loadingCanvasPirate;
    public Canvas menuCanvasPirate;
    public Canvas settingsCanvasPirate;
    public Canvas gameCanvasPirate;
    public Canvas winCanvasPirate;
    public Canvas loseCanvasPirate;
    public Canvas difChoiceCanvasPirate;


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


    public bool activePirate = true;

    Timer tPirate;

    public Stack<string> currentStackPirate;


    void Start()
    {    
        menuCanvasPirate.enabled = false; 
        settingsCanvasPirate.enabled = false;
         CounterPirate();
        gameCanvasPirate.enabled = false;
        winCanvasPirate.enabled = false;
        difChoiceCanvasPirate.enabled = false;
         CounterPirate();
        loseCanvasPirate.enabled = false;
        currentStackPirate = new Stack<string>();
        currentStackPirate.Push("menuPirate");

        HideTimerPirate();
    }

 
    public void EndLoadPirate()
    {
        CounterPirate();
        loadingCanvasPirate.enabled = false;
        menuCanvasPirate.enabled = true;
    }




    public void HideTimerPirate()
    {
        tPirate = new Timer(1500);
        tPirate.AutoReset = false;
        CounterPirate();
        tPirate.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tPirate.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
             CounterPirate();
            EndLoadPirate();
        }
        finally
        {
             CounterPirate();
            tPirate.Enabled = false;
        }
    }

    public void MoveBackPirate()
    {
        currentStackPirate.Pop();
         CounterPirate();
        MovePirate(currentStackPirate.Peek(), true);
    }
    public void MovePirate(string destinationPirate, bool backmovePirate = false, int difPirate =0)
    {

        menuCanvasPirate.enabled = false;
        settingsCanvasPirate.enabled = false;
         CounterPirate();
        gameCanvasPirate.enabled = false;
        loseCanvasPirate.enabled = false;
        winCanvasPirate.enabled = false;
        difChoiceCanvasPirate.enabled = false;

        if (destinationPirate == "winPirate")
        {
           
            winCanvasPirate.enabled = true;
            winCanvasPirate.GetComponent<WinScriptPirate>().WinScreenPirate();
            backmovePirate = true;
        }

        if (destinationPirate == "losePirate")
        {
           
            loseCanvasPirate.enabled = true;
            loseCanvasPirate.GetComponent<WinScriptPirate>().WinScreenPirate();
            backmovePirate = true;
        }


         CounterPirate();

        if (destinationPirate == "menuPirate")
        {
            menuCanvasPirate.enabled = true;
            activePirate = false;
        }
        else if (destinationPirate == "settingsPirate")
        {
            settingsCanvasPirate.enabled = true;
        }
        else if (destinationPirate == "levelsPirate")
        {
            difChoiceCanvasPirate.enabled = true;
        }
        else if (destinationPirate == "gamePirate")
        {
             CounterPirate();
            gameCanvasPirate.enabled = true;
            if (!backmovePirate) gameCanvasPirate.GetComponent<GameLogicPirate>().InitGamePirate(difPirate);
        }
      
        if (!backmovePirate) { currentStackPirate.Push(destinationPirate); }
         CounterPirate();
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackPirate.Count == 1)
                    {
                         CounterPirate();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackPirate();
                    }

                }
            }
            catch (Exception ePirate)
            {

            }
        }
    }


}
