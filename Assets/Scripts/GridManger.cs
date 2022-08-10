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
                //�ȼ� ���� �Լ�
                GameObject obj = Instantiate(pixelObject, new Vector3(i, j, 0), Quaternion.identity, transform);
                pixels.Add(obj);
            }
        }
    }
    // Paint Holder�� paint button�鿡�� ������ onClick �Լ�
    public void SetPencilColor(Image thisColor)
    {
        currentColor = thisColor.color;
    }

    public Color GetCurrentColor()
    {
        return currentColor;
    }
   
}