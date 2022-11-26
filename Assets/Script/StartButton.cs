using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : FadeManager
{
    public Sprite clicked;
    private Image img;

    public void load(){
        Invoke("loadScene",fadeTime);
    }

    private void loadScene(){
        SceneManager.LoadScene("CartoonScene");
    }

    public void Clicked(){
        img = GetComponent<Image>();
        img.sprite = clicked;
    }
}
