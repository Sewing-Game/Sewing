using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSky : MonoBehaviour
{
    private TimeManager tm;
    public Text TimeTxt;
    private bool isNight;
    private float x;
    
    void Start(){
        tm = FindObjectOfType<TimeManager>();
    }

    void Update()
    {
        TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",tm.Year,tm.Month,tm.Day,tm.Hour,tm.Min);
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*0.3f);
    }

    private void OnGUI()
    {
        x = ((tm.Hour*3600 + tm.Min*60 +tm.Sec)/86400);
        float y=transform.rotation.y;
        float z=transform.rotation.z;
        transform.rotation = Quaternion.Euler(x*360.0f + 270.0f,y,z);
        if (transform.eulerAngles.x >= 170) // night when x angle>=170
            isNight = true;
        else if (transform.eulerAngles.x <= 10)  // day when x angle<=10
            isNight = false;
    }
}
