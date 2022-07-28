using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelManage : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sRend;
    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();

    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        {
            sRend.color = transform.parent.GetComponent<GridManger>().GetCurrentColor();
        }
    }

}
