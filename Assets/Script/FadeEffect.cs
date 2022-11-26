using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private Image cg;
    public float FadeTime = 2f;

    private Coroutine fadeCor;

    private void Awake()
    {
        cg = gameObject.GetComponent<Image>();
    }

       private void OnEnable()
    {
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        if (fadeCor != null)
        {
            StopAllCoroutines();
            fadeCor = null;
        }
        fadeCor = StartCoroutine(FadeIn());

    }

    public void StartFadeOut()
    {
        if (fadeCor != null)
        {
            StopAllCoroutines();
            fadeCor = null;
        }
        fadeCor = StartCoroutine(FadeOut());

    }

    //alpha 1->0
    public IEnumerator FadeIn()          
    {
        Color color = cg.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / FadeTime;
            cg.color = color;
            yield return null;
        }
    }
    
    public IEnumerator FadeOut()
    {
        Color color = cg.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / FadeTime;
            cg.color = color;
            yield return null;
        }
    }
}