using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private const int monthByYear = 12;
    private const int monthlyDate = 30;  

    private const long daySecond = 24 * 60 * 60;  //total seconds of a day
    private const long monthSecond =  monthlyDate * daySecond; //total seconds of a month
    private const long yearSecond = monthByYear * monthSecond; //total seconds of a year
    public int inityear=102;
    public int initmonth=4;
    public int initday=1;
    public float speed = 96f;
<<<<<<< HEAD

=======
    private int tmp=0;
    private int year=0;
    private int month=0;
    private int day=0;
>>>>>>> bcaa3b562e2a102383be36c2f9fd26b345ccd1c1
    private float _totalTime;
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
        date = new NemoDate(inityear,initmonth,initday);
    }

    void Update()
    {
        _totalTime += Time.deltaTime * Time.timeScale;
        float t = _totalTime;
        tmp = year;
        year = (int)(t / yearSecond);
        if (tmp!=year) date.year+=1;
        t %= yearSecond;
        tmp = month;
        month = (int)(t / monthSecond);
        if (tmp!=month) date.month+=1;
        t %= monthSecond;
        tmp = day;
        day = (int)(t / daySecond);
        if (tmp!=day) date.day+=1;
        t %= daySecond;
        date.hour = (int)(t / 3600);
        t %= 3600;
        date.min = (int)(t / 60);
        t %= 60;
        date.sec = t;
    }
}
