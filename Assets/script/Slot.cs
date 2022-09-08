using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Item item; // 획득한 아이템
    [SerializeField] private int itemCount; // 획득한 아이템의 개수
    //[SerializeField] private Image itemImage;  // 아이템의 이미지
    private Text cnt;

    public Categories getItemCategory(){
        return item.getCategory();
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, Image slotImg,Font m_font,int _count=1)
    {
        item = _item;
        itemCount = _count; //_item.getCnt();
        slotImg.sprite = _item.getItemImage();  
        cnt = gameObject.GetComponentsInChildren<Text>()[0];
        cnt.color = Color.black;
        cnt.font = m_font;
        cnt.fontSize = 20;
        if(itemCount>1)
        {
            cnt.text = itemCount.ToString();
        }
    }

    // 해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        cnt.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 해당 슬롯 하나 삭제
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        gameObject.GetComponent<Image>().sprite = null;

        cnt.text = "0";
    }
}
