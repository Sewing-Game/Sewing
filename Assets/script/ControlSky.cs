using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSky : MonoBehaviour
{
    public Material dayMat;
    public Material nightMat;
    public GameObject dayLight;
    public GameObject nightLight;
    public GameObject time;
    public TimeManager tm;
    public Color dayFog;
    public Color nightFog;
    public float exposure = 0.89f;
    public Text TimeTxt;
    float x;
    
    void Start(){
        tm = time.GetComponent<TimeManager>();
    }
    // Update is called once per frame
    void Update()
    {
        TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",(int)tm.date.year,(int)tm.date.month,(int)tm.date.day,(int)tm.date.hour,(int)tm.date.min);
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*0.5f);
    }

    private void OnGUI()
    {
        //UnityEngine.GUI.Lable(new Rect(5,5,80,20),time);
        //Debug.Log(timeTxt.GetComponent<TimeManager>().min);
        if(tm.date.hour==0){
            RenderSettings.skybox.SetFloat("_Exposure",exposure);
        }
        if(5<tm.date.hour&&tm.date.hour<19){//UnityEngine.GUI.Button(new Rect(5,5,80,20),"Day")){
            RenderSettings.skybox = dayMat;
            RenderSettings.fogColor = dayFog;
            dayLight.SetActive(true);
            x += Time.deltaTime ;
            dayLight.transform.rotation = Quaternion.Euler(x,0,0);
            nightLight.SetActive(false);
            if(tm.date.hour>16){
                exposure-=(float)0.000001;
                RenderSettings.skybox.SetFloat ("_Exposure",exposure);
            }
        }
        else{//UnityEngine.GUI.Button(new Rect(5,35,80,20),"Night")){
            RenderSettings.skybox = nightMat;
            RenderSettings.fogColor = nightFog;
            dayLight.SetActive(false);
            nightLight.SetActive(true);
            x += Time.deltaTime; //* 10;
            nightLight.transform.rotation = Quaternion.Euler(x,0,0);
            // var nrot = nightLight.transform.rotation;
            // nrot.x += Time.deltaTime * 10;
            // transform.rotation = nrot;
        }
    }
}

