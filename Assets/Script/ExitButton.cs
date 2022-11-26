using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : FadeManager
{
    public Sprite clicked;
    private Image img;

    public void Clicked(){
        img = GetComponent<Image>();
        img.sprite = clicked;
    }
}
