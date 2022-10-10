using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private const int monthByYear = 12;
    private const int monthlyDate = 30;  

    private const long daySecond = 24 * 60 * 60;  //Total seconds of a day
    private const long monthSecond =  monthlyDate * daySecond; //Total seconds of a month
    private const long yearSecond = monthByYear * monthSecond; //Total seconds of a year
    public int inityear=102;
    public int initmonth=4;
    public int initday=1;
    public float speed = 96f;
    private int year=0;
    private int month=0;
    private int day=0;
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
        date = new NemoDate();
    }

    void Update()
    {
        _totalTime += Time.deltaTime * Time.timeScale;
        float t = _totalTime;
        year = (int)(t / yearSecond);
        date.year = inityear + year;
        t %= yearSecond;
        month = (int)(t / monthSecond);
        date.month = initmonth + month;
        t %= monthSecond;
        day = (int)(t / daySecond);
        date.day = initday + day;
        t %= daySecond;
        date.hour = (int)(t / 3600);
        t %= 3600;
        date.min = (int)(t / 60);
        t %= 60;
        date.sec = t;
    }
}
