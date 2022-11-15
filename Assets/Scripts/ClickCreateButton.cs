using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCreateButton : MonoBehaviour
{
    public void OnClickMyButton()
    {
        PopupSystem.instance.OpenPopup(
            () => { Debug.Log("okay"); },
            () => { Debug.Log("noooooo"); });
    }
}
