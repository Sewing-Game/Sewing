using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //Assign thie field in Inspector window
    [SerializeField] private Categories category;
    [SerializeField] private string Clothkind = "None";
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private int cnt=1;

    public string getItemName(){
        return itemName;
    }

    public Categories getCategory(){
        return category;
    }

    public Sprite getItemImage(){
        return itemImage;
    } 

    public int getCNT(){
        return cnt;
    }

    public void AddCount(){
        cnt+=1;
    }

    public string getKind(){
        return Clothkind;
    }

}
