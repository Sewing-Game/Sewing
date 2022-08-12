using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManger : MonoBehaviour
{
    public GameObject pixelObject;
    public GameObject GridLineObject;
    public int gridSize = 40;
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
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                //�ȼ� ���� �Լ�
                //pixels.Add(Instantiate(pixelObject, new Vector3(j, -i, 0), Quaternion.identity, transform));
                Instantiate(pixelObject, new Vector3(j, i, 0), Quaternion.identity, transform);
            }
        }
        float initXPos = -0.5f;
        for (int i = 0; i < (gridSize + 1); i++)
        {
            Instantiate(GridLineObject, new Vector3(initXPos + i, 19.5f, -1), Quaternion.identity, transform);
            Instantiate(GridLineObject, new Vector3(19.5f, initXPos + i, -1), Quaternion.Euler(0,0,90), transform);
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
        for (int  i = 0;  i <(gridSize * gridSize);  i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void IsSymmetric()
    {
        //symmetric ���� ��ȯ ��ư
        symmetric = (symmetric == false) ? true : false;
    }

    public void MakeColorArray(int x, int y)
    {
        if(symmetric)
        {
            int symmetricPosX = gridSize - 1 - x;
            colorArray[symmetricPosX][y] = currentColor;
            int childOrder = (y * gridSize) + symmetricPosX;
            transform.GetChild(childOrder).GetComponent<SpriteRenderer>().color = currentColor;
        }
        colorArray[x][y] = currentColor;
        transform.GetChild((y*gridSize)+x).GetComponent<SpriteRenderer>().color = currentColor;
    }
}