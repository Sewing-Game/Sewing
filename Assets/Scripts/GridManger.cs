using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManger : MonoBehaviour
{
    public PixelColor pixelObject;
    public GameObject GridLineObject;

    public int gridSize = 40;
    public Color currentColor = Color.black;
    public bool symmetric = false;

    private PixelColor[][] colorArray;

    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {

        //create pixel sprite renderer
        colorArray = new PixelColor[gridSize][];
        for (int i = 0; i < gridSize; i++)
        {
            colorArray[i] = new PixelColor[gridSize];
            for (int j = 0; j < gridSize; j++)
            {
                //�ȼ� �ν��Ͻ��� ����� colorArray[i][j]��°�� ������Ʈ�� �Ҵ���.
                colorArray[i][j]=Instantiate(pixelObject, new Vector3(j, i, 0), Quaternion.identity, transform);
            }
        }
        //create pixel grid renderer
        float initXPos = -0.5f;
        for (int i = 0; i < (gridSize + 1); i++)
        {   
            //���� ���� �׸��� ���� ����
            Instantiate(GridLineObject, new Vector3(initXPos + i, 19.5f, -1), Quaternion.identity, transform);
            Instantiate(GridLineObject, new Vector3(19.5f, initXPos + i, -1), Quaternion.Euler(0,0,90), transform);
        }
    }
    // Paint Holder�� paint button�鿡�� ������ onClick �Լ�
    public void HandleColorClick(Image thisColor)
    {
        currentColor = thisColor.color;
    }

    
    public void ClearGrid()
    {
        foreach (var pixels in colorArray)
        {
           foreach (var pixel in pixels)
           {
                pixel.Color = Color.white;
           }
        }


    }
   
    public void ToggleSymmetric()
    {
        //symmetric ���� ��ȯ ��ư
        symmetric = !symmetric ;
    }

    public void MakeColorArray(int x, int y)
    {
        if(symmetric)
        {
            int symmetricPosX = gridSize - 1 - x;
            colorArray[symmetricPosX][y].Color = currentColor;
        }
        colorArray[x][y].Color = currentColor;
    }
}

///
/// GridManager : ȭ�鿡 �׸��� ����. �ȷ�Ʈ�κ��� ������ �÷��� �޾ƿ�(= currentColor)
///  - SpawnGrid()�� ȣ���� �Ǹ� pixelObject�� �ν��Ͻ��� �����԰� ���ÿ� colorArray[][]�� ������Ʈ�� �Ҵ��Ͽ� �����Ŵ.
///  - HandleColorClick method�� �ȷ�Ʈ ��ư���� onClick event handler�� ����.
///  - �߰����� : ����Ʈ ��
///