using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSky : MonoBehaviour
{
    public Light dayLight;
    public Material dayMat;
    public Material nightMat;
    private TimeManager tm;
    // [Range(0,300)]
    // public float exposure = 0.89f;
    public Text TimeTxt;
    private float x;
    
    void Start(){
        tm = FindObjectOfType<TimeManager>();
    }
    // Update is called once per frame
    void Update()
    {
        TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",tm.Year,tm.Month,tm.Day,tm.Hour,tm.Min);
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*0.5f);
    }

    private void OnGUI()
    {
        x = 360-((tm.Hour*3600 + tm.Min*60 +tm.Sec)/240);  //tm.Year* + tm.Month + 
        float y=dayLight.transform.rotation.y;
        float z=dayLight.transform.rotation.z;
        dayLight.transform.rotation = Quaternion.Euler(x,y,z);
        if(5<tm.Hour&&tm.Hour<19){//UnityEngine.GUI.Button(new Rect(5,5,80,20),"Day")){
            RenderSettings.skybox = dayMat;
        }
        else{
            RenderSettings.skybox = nightMat;
        }
    }
}

