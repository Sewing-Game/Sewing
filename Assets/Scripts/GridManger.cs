using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManger : MonoBehaviour
{
    public GameObject pixelObject;
    public int gridSize = 40;
    public List<GameObject> pixels;
    public Color currentColor = Color.black;
    public bool symmetric = false;

    private Color[][] colorArray;
    void Start()
    {
        //�� �� �ʱ�ȭ
        colorArray = new Color[gridSize][];
        for (int i = 0; i <gridSize; i ++)
        {
            //ĭ �� �ʱ�ȭ
            colorArray[i] = new Color[gridSize];
            //Array.Fill�� 1D array�� ä�� �� ����.
            Array.Fill(colorArray[i], Color.white);
        }
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
                //pixels.Add(Instantiate(pixelObject, new Vector3(j, -i, 0), Quaternion.identity, transform));
                pixels.Add(Instantiate(pixelObject, new Vector3(j, i, 0), Quaternion.identity, transform));
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
    
    public void ClearGrid()
    {
        int numOfChild = this.transform.childCount;
        for (int  i = 0;  i <numOfChild;  i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void IsSymmetric()
    {
        //symmetric ���� ��ȯ ��ư
        symmetric = (symmetric == false) ? true : false;
    }

    public Color MakeColorArray(int x, int y)
    {
        colorArray[x][y] = currentColor;
        return colorArray[x][y];
    }
}