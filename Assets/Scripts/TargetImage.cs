using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TargetImage : MonoBehaviour
{
    // Start is called before the first frame update
    private float _equalRate;
    private int count;
    public Sprite target;
    private Color[] targetColors;
    private Color[] UsersColors;

    public float EualRate
    {
        get => _equalRate;

    }

    public void TextureFromSprite(Sprite sprite)
    {   
        int x = Mathf.FloorToInt(sprite.textureRect.x);
        int y = Mathf.FloorToInt(sprite.textureRect.y);
        int width = Mathf.FloorToInt(sprite.textureRect.width);
        int height = Mathf.FloorToInt(sprite.texture.height);

        targetColors = sprite.texture.GetPixels(x, y, width, height);

        Texture2D newtx = new Texture2D(width, height);
        newtx.SetPixels(targetColors);
    }

    public void CalEqualRate(Texture2D tx)
    {
        count = 0;
        TextureFromSprite(target);
        UsersColors = tx.GetPixels(0);
        for (int i = 0; i < targetColors.Length; i++)
        {
            if (targetColors[i] == UsersColors[i]) count += 1;
        }

        _equalRate = (count) / 1600f * 100f;
    }
}
