using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   
    public List<GameObject>items= new List<GameObject>();
    public List<InventorySlot>slots = new List<InventorySlot>();
    public GameObject iconPrefab= null;

    internal void AddItem(GameObject go)
    {
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.isEmpty = false;
                go.transform.SetParent(slot.transform);
                go.GetComponent<DragDrop>().SetSlot(slot);
                items.Add(go);
                break;
            }
        }
    }

    void Awake()
    {
        
        //for(int i =0;i<slots.Count;i++)
        //{

        //    slots[i].Init(iconPrefab, i ,true);

        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
