using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public const int monthByYear = 12;
    public const int monthlyDate = 30;  

    public const long daySecond = 24 * 60 * 60;  //하루간의 총 초
    public const long monthSecond =  monthlyDate * daySecond; //한 달간의 총 초
    public const long yearSecond = monthByYear * monthSecond; //1년간의 총 초
    private int inityear=102;
    private int initmonth=4;
    private int initday=1;
    //[Range(1,300)]
    public float speed = 96f;

    public float _totalTime;
    private NemoDate date;
    public int Year => date.year;
    public int Month => date.month;
    public int Day => date.day;
    public int Hour => date.hour;
    public int Min => date.min;
    public float Sec => date.sec;
    
    private void Start()
    {
        Time.timeScale = speed;
        date = new NemoDate();
    }

    void Update()
    {
        _totalTime += Time.deltaTime * Time.timeScale *speed;
        float t = _totalTime;
        date.year = (int)(t / yearSecond);
        t %= yearSecond;
        date.month = (int)(t / monthSecond);
        t %= monthSecond;
        date.day = (int)(t / daySecond);
        t %= daySecond;
        date.hour = (int)(t / 3600);
        t %= 3600;
        date.min = (int)(t / 60);
        t %= 60;
        date.sec = t;
    }
}
