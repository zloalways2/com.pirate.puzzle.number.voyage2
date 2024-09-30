using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundsPirate : MonoBehaviour
{
    public Sprite onPirate;
    public Sprite offPirate;
    public bool isSoundPirate;
    public bool isOnPirate=true;

    private float CounterPirate(int x = 2)
    {
        float aPirate = 0;
        for (int i = 0; i < 3; i++)
        {
            aPirate += Time.time;
        }
        return aPirate - x;
    }
    public void onClickPirate()
    {
        isOnPirate=!isOnPirate;
        CounterPirate();
        if (isSoundPirate) GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().soundIsOnPirate = isOnPirate;
        else GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().musicIsOnPirate = isOnPirate;
        GameObject.Find("MainCameraPirate").GetComponent<SoundManagerPirate>().changedPirate = true;
        if (isOnPirate) GetComponent<Image>().sprite = onPirate;
        else GetComponent<Image>().sprite = offPirate;



    }
}
