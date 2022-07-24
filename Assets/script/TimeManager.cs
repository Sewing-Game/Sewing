using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float sec;
    public bool weekday;
    public bool weekend;
    public int year=102;
    public int month=4;
    public int day=1;
    public int min;
    public int hour;
    public Text TimeTxt;
    public string time;
    public float speed =(float)1.2;
    public float exposure = (float)0.89;

    // Update is called once per frame
    void Update()
    {
            sec += Time.deltaTime * speed;
            //Debug.Log(sec);
            //sec*=speed;
            TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",(int)year,(int)month,(int)day,(int)hour,(int)min);
            if((int)month>12){
                year+=1;
                month=0;
            }
            if(day%7<6){
                weekend=false;
                weekday=true;
            }
            if(day%7>5 || day%7==0){
                weekend=true;
                weekday=false;
            }
            if((int)day>30){
                month+=1;
                day=0;
            }
            if((int)hour>23){
                day+=1;
                hour=0;
            }
            if((int)sec>59){
                sec=0;
                min+=1;//(float)1.6;
            }
            if((int)min>59){
                min=0;
                hour+=1;//(float)1.6;
            }
    }
}
