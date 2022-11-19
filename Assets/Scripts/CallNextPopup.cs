using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CallNextPopup : MonoBehaviour
{
    int count = 0;


    public void setActivateColorPopup()
    {
        Debug.Log(count);
        if (count == 0)
        {
            PopupSystem.instance.popup = GameObject.Find("TargetPopupSystem").transform.Find("popup2").gameObject;
            OnClickMyButton();
            count += 1;
        }
        else if (count == 1)
        {
            PopupSystem.instance.popup = GameObject.Find("TargetPopupSystem").transform.Find("popup3").gameObject;
            OnClickMyButton();
            count += 1;
        }
        else if (count == 2)
        {
            GameObject.Find("TutorialCanvas").SetActive(false);
        }
    }

    public void OnClickMyButton()
    {
        PopupSystem.instance.OpenPopup(
            () => { Debug.Log("okay"); },
            () => { Debug.Log("noooooo"); });
    }
}
