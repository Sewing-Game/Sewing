using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CallNextPopup : MonoBehaviour
{
    int count = 0;


    public void setActivatePopup()
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
            GameObject.Find("Grid Holder").GetComponent<GridManger>().EnableTrue();
            PopupSystem.instance.popup = GameObject.Find("PopupCanvas").transform.Find("PopupSystem").transform.Find("CreateCheckPopup").gameObject;
        }
    }

    public void OnClickMyButton()
    {
        PopupSystem.instance.OpenPopup(
            () => { },
            () => { });
    }
}
