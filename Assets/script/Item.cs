using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Categories category;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;
    private int cnt = 0;

    public string getItemName(){
        return itemName;
    }

    public Categories getCategory(){
        return category;
    }

    public Sprite getItemImage(){
        return itemImage;
    } 

    public int getCnt(){
        return cnt;
    }

    public void PlusCNT(){
        cnt+=1;
    }

}
