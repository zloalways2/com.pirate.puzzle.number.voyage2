using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerPirate : MonoBehaviour
{
    public AudioSource themePirate;
    public AudioSource pingPirate;
    public AudioSource clickPirate;

    public bool soundIsOnPirate = true;
    public bool musicIsOnPirate = true;

    public float soundLevelPirate = 0.7f;
    public float musicLevelPirate = 0.7f;
    public bool changedPirate = false;

    public Slider musicSliderPirate;
    public Slider soundSliderPirate;


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


    void Start()
    {
       
        themePirate.Play();
        CounterPirate();
    }

    public void PlayPingPirate()
    {
        CounterPirate();
        pingPirate.Play();
    }

    public void PlayClickPirate()
    {
        CounterPirate();
        clickPirate.Play();
        CounterPirate();
    }



    void Update()
    {
        CounterPirate();
        if (changedPirate)
        {
            soundLevelPirate = soundSliderPirate.value;
            musicLevelPirate = musicSliderPirate.value;
           

            pingPirate.volume = soundLevelPirate;
            clickPirate.volume = soundLevelPirate;
            themePirate.volume = musicLevelPirate;
            
            changedPirate = false;
        }
        

     if(!themePirate.isPlaying)
        {
            CounterPirate();
            themePirate.Play();
        }
    }


}
