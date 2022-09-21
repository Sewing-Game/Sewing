using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private int itemCount; // acquired item's number
    private Image slotImg;
    private string itemName="None";
    private Text cnt;
    private Font m_font;
    private Categories category;


    void Start(){
        m_font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        slotImg = transform.Find("item_Icon").gameObject.GetComponent<Image>();
        cnt = transform.Find("item_count").gameObject.GetComponent<Text>();
    }

    public Categories getItemCategory(){
        return category;
    }

    // Update the number of this slot 
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        cnt.text = itemCount.ToString();
        
        if (itemCount <= 0)
            ClearSlot();
    }

    public void AddItem(Item _item)
    {
        itemName = _item.getItemName();
        itemCount = _item.getCNT();
        category = _item.getCategory();
        slotImg.sprite = _item.getItemImage();
        cnt.color = Color.black;
        cnt.font = m_font;
        cnt.fontSize = 20;
        if(itemCount>1)
        {
            cnt.text = itemCount.ToString();
        }
    }

    public void ClearSlot(){
        itemCount=0;
        cnt.text ="";
        slotImg.sprite = null;
        category=Categories.None;
    }

    void OnMouseEnter() {
        Debug.Log(itemName);
    }
}
