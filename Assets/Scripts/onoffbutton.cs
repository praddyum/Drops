using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class onoffbutton : MonoBehaviour
{
    DatabaseReference reference;
    AudioSource audioclip;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        audioclip=GetComponent<AudioSource>();
    }

    //Button Logic
    private int switchState = 1;
    public GameObject switchBtn;
    public GameObject watercan;


    public void OnSwitchButtonClicked()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
        switchState = Math.Sign(-switchBtn.transform.localPosition.x);
        Debug.Log(switchState);
        if (switchState == 1)
        {
            pushnoti(1);
            watercan.SetActive(true);
            audioclip.Play();

        }
        else if (switchState == -1)
        {
            pushnoti(0);
            watercan.SetActive(false);
          
        }
    }

    void pushnoti(int a)
    {
        reference.Child("plant").Child("mstatus").SetValueAsync(a);
    }
}
