using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelManage : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sRend;
    int x;
    int y;
    private void Start()
    {
        sRend = GetComponent<SpriteRenderer>();

    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 pos = sRend.transform.position;
            x = (int)pos.x;
            y = (int)pos.y;
            transform.parent.GetComponent<GridManger>().MakeColorArray(x,y);
        }
    }

}
