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

    private const float nightFogDensity = 0.1f; // Fog density during the night
    private float dayFogDensity; // Fog density during the daytime
    private const float fogDensityCalc = 0.2f; // ratio for FogDensity
    private float currentFogDensity; 
    
    void Start(){
        tm = FindObjectOfType<TimeManager>();
        dayFogDensity = RenderSettings.fogDensity;
    }

    void Update()
    {
        TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",tm.Year,tm.Month,tm.Day,tm.Hour,tm.Min);
        TimeTxt.color = Color.red;
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
        else if (transform.eulerAngles.x <= 10)  // daytime when x angle<=10
            isNight = false;

        if (isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityCalc * x;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCalc * x;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
    }
}
