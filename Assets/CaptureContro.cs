
using RenderHeads.Media.AVProMovieCapture;
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

public class CaptureContro : MonoBehaviour
{
    CaptureBase movieCapture;
    // Use this for initialization
    void Awake()
    {

        movieCapture = GetComponent<CaptureFromCamera>();
        //启动Microsoft H.264解码编辑器     
        movieCapture._useMediaFoundationH264 = true;
        SetCaptureMode(false);     
        SetDefinition(CaptureBase.DownScale.Original);
        SetResolution(CaptureBase.Resolution.SD_800x600);
        SetFrameRate(CaptureBase.FrameRate.Thirty);
        SetSavePath("DownVideo", "123", "mp4");
      
    }

    /// <summary>
    /// 开始录像
    /// </summary>
    public void StartCapture()
    {
        movieCapture.StartCapture();
    }

    /// <summary>
    /// 重新开始录像(配套暂停)开始无效 无法重启
    /// </summary>
    public void ResumeCapture()
    {
        movieCapture.ResumeCapture();        
    }

    /// <summary>
    /// 暂停录像
    /// </summary>
    public void PauseCapture()
    {
        movieCapture.PauseCapture();
    }

    /// <summary>
    /// 结束录像
    /// </summary>
    public void StopCapture()
    {
        movieCapture.StopCapture();
    }

    /// <summary>
    /// 是否暂停
    /// </summary>
    /// <returns></returns>
    public bool IsPaused()
    {
       return movieCapture.IsPaused();
    }

    
    /// <summary>
    /// 删除已经录制的片段
    /// </summary>
    public void CancelCapture()
    {
        movieCapture.CancelCapture();
    }
    /// <summary>
    /// 设置分辨率
    /// </summary>
    /// <param name="type"></param>
    public void SetResolution(CaptureBase.Resolution type)
    {
        movieCapture._renderResolution = type;
    }

    /// <summary>
    /// 设置清晰度 每一等级清晰度是之前的一半
    /// </summary>
    public void SetDefinition(CaptureBase.DownScale type)
    {
        movieCapture._downScale = type;
    }
    /// <summary>
    /// 设置帧率
    /// </summary>
    /// <param name="type"></param>
    public void SetFrameRate(CaptureBase.FrameRate type)
    {
        movieCapture._frameRate = type;
    }

    /// <summary>
    /// 设置捕获模式 对自己电脑有信心可以true
    /// </summary>
    /// <param name="isRealTime"></param>
    public void SetCaptureMode(bool isRealTime)
    {
        movieCapture._isRealTime = isRealTime;
    }

    /// <summary>
    /// 获取FPS
    /// </summary>
    /// <returns></returns>
    public float GetFPS()
    {
        return movieCapture.FPS;
    }

    /// <summary>
    /// 设置存放位置 SteamingAsset下面 
    /// 生成文件为名字-时间-长度-分辨率
    /// </summary>
    /// <param name="path"></param>
    /// <param name="name"></param>
    /// <param name="format"></param>
    public void SetSavePath(string path, string name, string format)
    {
        movieCapture._outputFolderPath = Application.streamingAssetsPath + "/" + path;
        movieCapture._autoFilenamePrefix = name;
        movieCapture._autoFilenameExtension = format;
    }

    /// <summary>
    /// 获取当前录制持续时间
    /// </summary>
    /// <returns></returns>
    public string GetDuaration()
    {
        float _lastEncodedSeconds;
        if (!movieCapture._isRealTime)
        {
            _lastEncodedSeconds = (uint)Mathf.FloorToInt((float)movieCapture.NumEncodedFrames / (float)movieCapture._frameRate);
        }
        else
        {
            _lastEncodedSeconds = movieCapture.TotalEncodedSeconds;
        }
        float _lastEncodedMinutes = _lastEncodedSeconds / 60;
        _lastEncodedSeconds = _lastEncodedSeconds % 60;
        float _lastEncodedFrame = movieCapture.NumEncodedFrames % (uint)movieCapture._frameRate;

        string duaration = _lastEncodedMinutes.ToString("00") + ":" + _lastEncodedSeconds.ToString("00") + "." + _lastEncodedFrame.ToString("000");
        return duaration;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(movieCapture.GetProgress());
    }
}
