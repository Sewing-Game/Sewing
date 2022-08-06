using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

// Custom serializable class
[Serializable]
public class Date
{
    public int year;
    public int month;
    public int day;
    public int hour;
    public int min;
    public float sec;
    public bool weekday = false;
    public bool weekend = false;
}

public class TimeManager : MonoBehaviour
{
    private int monthByYear = 12;
    private int monthlyDate = 30;  

    private long daySecond => 24 * 60 * 60;  //하루간의 총 초
    private long monthSecond =>  monthlyDate * daySecond; //한 달간의 총 초
    private long yearSecond => monthByYear * monthSecond; //1년간의 총 초
    private int inityear=102;
    private int initmonth=4;
    private int initday=1;
    public float speed = 1.2f;
    public Text TimeTxt;
    public float _totalTime;
    public Date date;
    
    // [Serializable]
    // public class DateTime
    // {
    //     public int year;
    //     public int day;
    //     public int month;
    // }

    private void Start()
    {
        Time.timeScale = speed;
    }

    // Update is called once per frame
    void Update()
    {
        _totalTime += Time.deltaTime * speed;//Time.timeScale;
        TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",(int)date.year,(int)date.month,(int)date.day,(int)date.hour,(int)date.min);
        double t = _totalTime;
        date.year = inityear+(int)(t / yearSecond);
        t %= yearSecond;
        date.month = initmonth+(int)(t / monthSecond);
        t %= monthSecond;
        date.day = initday+(int)(t / daySecond);
        if(date.day%7<6){
                date.weekend=false;
                date.weekday=true;
        }
        if(date.day%7>5 || date.day%7==0){
                date.weekend=true;
                date.weekday=false;
        }
        t %= daySecond;
        date.hour = (int)(t / 3600);
        t %= 3600;
        date.min = (int)(t / 60);
        t %= 60;
        date.sec = (float)t;
    }
}
