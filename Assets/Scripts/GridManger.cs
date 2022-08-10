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
        SpawnGrid();
    }
    void SpawnGrid()
    {
        pixels = new List<GameObject>();
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                //�ȼ� ���� �Լ�
                pixels.Add(Instantiate(pixelObject, new Vector3(i, j, 0), Quaternion.identity, transform));
            }
        }
    }
    // Paint Holder�� paint button�鿡�� ������ onClick �Լ�
    public void HandleColorClick(Image thisColor)
    {
        currentColor = thisColor.color;
    }

    public Color GetCurrentColor()
    {
        return currentColor;
    }
   
}