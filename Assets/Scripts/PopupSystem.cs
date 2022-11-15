using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour
{

    public GameObject popup;
    Animator anim;

    Action onClickOkay, onClickCancel;

    //Singleton Pattern
    public static PopupSystem instance { get; private set; }


    private void Awake()
    {
        instance = this;
        anim = popup.GetComponent<Animator>();
    }


    public void OpenPopup (Action onClickOkay, Action onClickCancel)
    {
        this.onClickOkay = onClickOkay;
        this.onClickCancel = onClickCancel;
        popup.SetActive(true);
    }

    public void OnClickOkay()
    {
        if(onClickOkay != null)
        {
            onClickOkay();
        }
        ClosePopup();
        popup.SetActive(false);
    }

    public void OnClickCancel()
    {
        if(onClickCancel != null)
        {
            onClickCancel();
        }
        ClosePopup();
        popup.SetActive(false);
    }

    void ClosePopup()
    {
        anim.SetTrigger("close");
        
    }

}
