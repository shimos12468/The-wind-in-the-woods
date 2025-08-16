using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour ,IDropHandler
{

    GameObject iconprefab;
    public bool isEmpty = true;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDrop item = dropped.GetComponent<DragDrop>();
        item.parentAfterDrag = transform;

    }

    internal void Init(GameObject iconPrefab, int i, bool v)
    {
        throw new NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
