using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCreateButton : MonoBehaviour
{
    public void OnClickMyButton()
    {
        //GameObject.Find("Grid Holder").GetComponent<GridManger>().EnableFalse();
        PopupSystem.instance.OpenPopup(
            () => 
            { 
                Debug.Log("okay"); 
            },
            () => 
            { 
                GameObject.Find("Grid Holder").GetComponent<GridManger>().EnableTrue(); 
            });
    }
}
