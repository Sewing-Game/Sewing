using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static bool invectoryActivated = true;  // Whether enabled inventory

    public GameObject go_InventoryBase; // the background of Slots 
    public GameObject go_SlotsParent;  //the Parent Object of Slots
    public const int MAX_COUNT = 3; //the max number of Inventory view
    public Button left;
    public Button right;

    private int page=0;
    private int slotCount;
    private InventorySlot[] slots;
    private List<Item> items = new List<Item>(); 
    private List<Item> showitems = new List<Item>(); 

    void Start()
    {  
        slots = go_SlotsParent.GetComponentsInChildren<InventorySlot>();
    }
    
    public void Remove(){
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].ClearSlot();
            slots[i].gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        ShowPage(page);
    }

    public void TryOpenInventory()
    {
        invectoryActivated = !invectoryActivated;

        if (invectoryActivated)
            OpenInventory();
        else
            CloseInventory();

    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AddSlot(Item _item)
    {   
        //Checking Slots List for avoiding add the same slot, then just modify count
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].getCategory() == _item.getCategory())
            {
                items[i].AddCount(); //count+=1 and show the text view
                return;
            }
        }

        items.Add(_item);
        showitems.Add(_item);

        if(showitems.Count>MAX_COUNT){
            page+=1;
            Debug.Log("MAX_COUNT"+page+"/"+items.Count);
            ShowButton(true);
            showitems.Clear();
        }
    }

    public void ShowButton(bool p){
        if(p){
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
        }
        else{
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
        }
    }

    public void ShowPage(int pg){
        Remove();
        for (int i = pg*MAX_COUNT; i < (pg*MAX_COUNT)+MAX_COUNT; i++)
        {
            if(i<items.Count){
                int k = i%3;
                slots[k].gameObject.SetActive(true);
                slots[k].AddItem(items[i]);
            }
        }
    }

    public void ShowPrevPage(){
        page-=1;
    }

    public void ShowNextPage(){
        page+=1;
    }

}
