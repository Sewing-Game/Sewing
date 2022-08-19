using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class baseGridManger : MonoBehaviour
{
    //public PixelColor pixelObject;
    public GameObject board;

    public int gridSize = 40;
    
    private Color[][] colorArray;
    public string filePath;
    //texture 씌울 오브젝트
    public GameObject square;

    private GridManger drawing;
    private float score;
    public float loss;

    void Start()
    {
        setLabelImage(filePath);
        drawing = board.GetComponent<GridManger>();
    }

    void Update(){
        loss = similarity();
    }

    float abs(float x){
        if(x<0) x*=-1;
        return x;
    }

    float similarity(){
        for (int i = 0; i < gridSize; i++){
            for (int j = 0; j < gridSize; j++){
                Color l = colorArray[i][j];
                Color ct = drawing.getColor(i,j);
                Color diff = l-ct;
                score+=(abs(diff.r+diff.g+diff.b));
            }
        }
        return Mathf.Sqrt(Mathf.Pow(score,2));
    }

    Texture2D resizing(Texture2D source,int gridSize){

        //Resize to 40X40
        Texture2D result = new Texture2D(gridSize, gridSize, source.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = (1.0f / (float)gridSize);
        float incY = (1.0f / (float)gridSize);

        for (int px = 0; px < rpixels.Length; px++)
        {
            rpixels[px] = source.GetPixelBilinear(incX * ((float)px % gridSize), incY * ((float)Mathf.Floor(px / gridSize)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        //print("Size is " + result.width + " by " + result.height);
        return result;
    }

    void setLabelImage(string filePath)
    {
        Texture2D tex = new Texture2D(gridSize, gridSize);
        byte[] bytes = File.ReadAllBytes(filePath);
        tex.LoadImage(bytes);

        Texture2D result = resizing(tex,gridSize);

        //Color[] label = tex.GetPixels(0,0,gridSize,gridSize);
        square.GetComponent<Renderer>().material.mainTexture = tex;
        //create pixel sprite renderer
        colorArray = new Color[gridSize][];
        for (int i = 0; i < gridSize; i++)
        {
            colorArray[i] = new Color[gridSize];
            for (int j = 0; j < gridSize; j++)
            {
                var x = i;
                var y = j;
                // Debug.Log(i+""+j);
                Color c = result.GetPixel(i,j);
                // Debug.Log(c);
                // Debug.Log(Color.black);
                colorArray[i][j] = c;
            }
        }
    }

    public Color getColor(int x,int y){
        return colorArray[x][y];
    }
}