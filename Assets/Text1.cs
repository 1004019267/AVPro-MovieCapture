/**
 *Copyright(C) 2019 by #COMPANY#
 *All rights reserved.
 *FileName:     #SCRIPTFULLNAME#
 *Author:       #AUTHOR#
 *Version:      #VERSION#
 *UnityVersion：#UNITYVERSION#
 *Date:         #DATE#
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text1 : MonoBehaviour
{

    CaptureContro contro;
    public Button btn;
    public Button btn1;
    public Button btn2;
    public Text text;
    // Use this for initialization
    void Start()
    {
        contro = GetComponent<CaptureContro>();
        btn.onClick.AddListener(() =>
        {
            if (!contro.IsPaused())
            {
                contro.StartCapture();
            }
            else
            {
                contro.ResumeCapture();
            }
        });
        btn1.onClick.AddListener(() => contro.StopCapture());
        btn2.onClick.AddListener(() => contro.PauseCapture());

    }

    // Update is called once per frame
    void Update()
    {
        text.text = contro.GetDuaration();
    }
}
