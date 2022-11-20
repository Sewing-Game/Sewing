using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetImage : MonoBehaviour
{
    // Start is called before the first frame update
    private float equalRate;
    private int count;
    public Sprite target;
    private Texture2D targetTexture;

    public float getRate()
    {
        return equalRate;

    }

    void Start()
    {
        targetTexture = TextureFromSprite(target);
        count = 0;
    }


    public Texture2D  TextureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }

    public void CalEqualRate(Texture2D tx)
    {
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                if (tx.GetPixel(i,j) != targetTexture.GetPixel(i,j))
                {
                    count += 1;
                }
            }
        }

        equalRate = ((160-count) / 160f) * 100f;
        Debug.Log(equalRate);
    }
}
