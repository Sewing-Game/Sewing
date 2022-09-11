using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSky : MonoBehaviour
{
    [SerializeField]
    private Light dayLight;
    [SerializeField]
    private Material dayMat;
    private TimeManager tm;
    [SerializeField]
    private Text TimeTxt;
    private float x;
    
    void Start(){
        tm = FindObjectOfType<TimeManager>();
    }

    void Update()
    {
        TimeTxt.text = string.Format("{0}Y {1}M {2}D {3:D2}H:{4:D2}M",tm.Year,tm.Month,tm.Day,tm.Hour,tm.Min);
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*0.5f);
    }

    private void OnGUI()
    {
        x = (360-(tm.Hour*3600 + tm.Min*60 +tm.Sec)/240); 
        float y=dayLight.transform.rotation.y;
        float z=dayLight.transform.rotation.z;
        dayLight.transform.rotation = Quaternion.Euler(x,y,z);
        RenderSettings.skybox = dayMat;
    }
}
