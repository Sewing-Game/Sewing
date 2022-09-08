using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static bool invectoryActivated = true;  // Whether enabled inventory

    [SerializeField]
    private GameObject go_InventoryBase; // the background of Slots 
    [SerializeField] 
    private GameObject go_SlotsParent;  //the Parent Object of Slots
    [SerializeField]
    private List<Slot> slots = new List<Slot>(); 
    [SerializeField]
    private Font m_font;

    void Start()
    {
    }

    void Update()
    {
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
        //Checking Slots List for avoiding add the same slot, just modify count
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].getItemCategory() == _item.getCategory())
            {
                slots[i].SetSlotCount(1); //count+=1 and show the text view
                return;
            }
        }
        //the slot is not in slot list, Add the slot to the list.
        GameObject s = new GameObject();
        s.AddComponent<Slot>();
        s.AddComponent<Image>();
        s.transform.parent = go_SlotsParent.transform; 
        GameObject t = new GameObject();
        t.AddComponent<Text>();
        t.transform.parent = s.transform;

        Slot slot = s.GetComponent<Slot>();
        Image slotImg = s.GetComponent<Image>();

        slot.AddItem(_item,slotImg,m_font); 
        slots.Add(slot);
    }

}