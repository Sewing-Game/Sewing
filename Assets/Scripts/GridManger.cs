using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class GridManger : MonoBehaviour
{
    public PixelColor pixelObject;
    //public GameObject GridLineObject;

    public int gridSize = 40;
    public Color currentColor = Color.black;
    public bool symmetric = false;
    public bool selectedPaintTool = false;
    
    
    private PixelColor[][] colorArray;
    private static readonly int[,] paintVisitPath = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
    private bool[,] visit;
    private float gap = 0.7f;

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
                //Creates a pixel instance and assigns an object to the colorArray[i][j]th.
                var x = i;
                var y = j;
                colorArray[i][j]=Instantiate(pixelObject, new Vector3(6.6f+gap*i, 4.5f+gap*j, 0), Quaternion.identity, this.transform);
                colorArray[i][j].OnClick.AddListener((item) =>
                {
                    if (symmetric)
                    {
                        int symmetricPosX = gridSize - 1 - x;
                        colorArray[symmetricPosX][y].Color = currentColor;
                    }
                    if (selectedPaintTool)
                    {
                        Color nowColor = colorArray[x][y].Color;
                        BFS(x, y, nowColor);
                    }
                    colorArray[x][y].Color = currentColor;
                });
            }
        }
        //create pixel grid renderer
        //float initXPos = -0.5f;
        //for (int i = 0; i < (gridSize + 1); i++)
        //{   
        //    Create Horizontal, Vertical Grid Lines
        //    Instantiate(GridLineObject, new Vector3(initXPos + i, 19.5f, -1), Quaternion.identity, transform);
        //    Instantiate(GridLineObject, new Vector3(19.5f, initXPos + i, -1), Quaternion.Euler(0,0,90), transform);
        //}
    }
    // OnClick function to apply to paint buttons in Paint Holder
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
        //switch whether symmetric is present button
        symmetric = !symmetric ;
    }

    public void HandlePaintToolClick()
    {
        selectedPaintTool = !selectedPaintTool;
        if (selectedPaintTool) 
        {
            symmetric = false;
        } 
        Debug.Log(selectedPaintTool);
    }
    

    public void BFS(int x, int y, Color targetColor)
    {
        visit = new bool[gridSize, gridSize];
        var queue = new Queue<(int,int)>();

        visit[x, y] = true;
        queue.Enqueue((x, y));

        while (queue.Any() == true)
        {
            (int a,int b) = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int dx = a + paintVisitPath[i, 0];
                int dy = b + paintVisitPath[i, 1];
                if ((dx >= gridSize || dy >= gridSize || dx < 0 || dy < 0) || visit[dx,dy]==true)
                {
                    continue;
                }
                if (visit[dx,dy] == false && colorArray[dx][dy].Color == targetColor)
                {
                    queue.Enqueue((dx, dy));
                    visit[dx, dy] = true;
                    colorArray[dx][dy].Color = currentColor;
                }
            }
        }
    }

    //<temp> create cloth object and material code
    public void SaveColorArrayAsImage()
    {
        Texture2D texture = new Texture2D(gridSize, gridSize);
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                texture.SetPixel(i, j, colorArray[i][j].Color);
            }
        }
        System.Random r = new System.Random();
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "";
        texture.Apply();

        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = new Vector3(30, 30, 0);
        //cube.GetComponent<Renderer>().material.mainTexture = texture;
        int rand = r.Next();
        File.WriteAllBytes(dirPath + "/" + rand + ".png", bytes);
    }
}

///
/// GridManager : Create grid on screen; get color to change from palette (= currentColor)
///  - When SpawnGrid() is called, Create an instance of pixelObject and assign the object to colorArray[][] at the same time.
///  - et the HandleColorClick method to onClick event handler for each palette button
///