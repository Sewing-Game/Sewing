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
        //줄 수 초기화
        colorArray = new Color[gridSize][];
        for (int i = 0; i <gridSize; i ++)
        {
            //칸 수 초기화
            colorArray[i] = new Color[gridSize];
            //Array.Fill은 1D array만 채울 수 있음.
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
                //픽셀 생성 함수
                //pixels.Add(Instantiate(pixelObject, new Vector3(j, -i, 0), Quaternion.identity, transform));
                pixels.Add(Instantiate(pixelObject, new Vector3(j, i, 0), Quaternion.identity, transform));
            }
        }
    }
    // Paint Holder안 paint button들에게 적용할 onClick 함수
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
        //symmetric 여부 전환 버튼
        symmetric = (symmetric == false) ? true : false;
    }

    public Color MakeColorArray(int x, int y)
    {
        colorArray[x][y] = currentColor;
        return colorArray[x][y];
    }
}