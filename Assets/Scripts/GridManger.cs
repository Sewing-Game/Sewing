using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManger : MonoBehaviour
{
    public GameObject pixelObject;
    public int gridSize = 100;
    public List<GameObject> pixels;

    public Color currentColor = Color.black;
    void Start()
    {
        spawnGrid();
    }
    void spawnGrid()
    {
        pixels = new List<GameObject>();
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                //픽셀 생성 함수
                GameObject obj = Instantiate(pixelObject, new Vector3(i, j, 0), Quaternion.identity, transform);
                pixels.Add(obj);
            }
        }
    }
    // Paint Holder안 paint button들에게 적용할 onClick 함수
    public void SetPencilColor(Image thisColor)
    {
        currentColor = thisColor.color;
    }

    public Color GetCurrentColor()
    {
        return currentColor;
    }
   
}