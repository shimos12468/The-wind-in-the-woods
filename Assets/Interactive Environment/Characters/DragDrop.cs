using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{

    public Transform parentAfterDrag;
    InteractableSpriteVisualizer parentItem;
    InventorySlot slot;

    public void  SetItem(InteractableSpriteVisualizer go)
    {
        parentItem= go;
        GetComponent<Image>().sprite = parentItem.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    public void SetSlot(InventorySlot g)
    {
       slot= g;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(GameObject.FindGameObjectWithTag("UI Menu").transform);
        transform.SetAsLastSibling();
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position =Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        GetComponent<Image>().raycastTarget = true;
        var hits = new List<RaycastResult>();
        foreach(var i in hits)
        {
            print(i.gameObject.name);
        }
         Vector3 pos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.CircleCastAll(pos, 0.2f, Vector2.zero);
        foreach (var i in hit)
        {
            print(i.collider.name);
            if(i.collider.name== parentItem.targetName)
            {

                if (i.collider.GetComponent<PlantBehaviour>())
                {
                    i.collider.gameObject.name ="plant1";
                }
                DropItem();
                break;
            }

        }
        
        transform.SetParent(parentAfterDrag);
    }

    private void DropItem()
    {
        parentItem.gameObject.SetActive(false);
        
        parentItem.OnDrop?.Invoke();
        slot.isEmpty = true;
        //parentItem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject.FindAnyObjectByType<Inventory>().items.Remove(gameObject);
        GameObject.FindAnyObjectByType<PlayerInventoryHandler>().Items.Remove(parentItem.gameObject);
        Destroy(gameObject);

    }
}
