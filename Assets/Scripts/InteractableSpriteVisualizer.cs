using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]

// Handles displaying Item info boxes.
// These should appear whenever the player is within the item's trigger.
public class InteractableSpriteVisualizer : MonoBehaviour
{
    // A parent object containing all "UI" elements to display.
    [SerializeField] private GameObject uiParent;
    [SerializeField] public UnityEvent OnPickup;
    [SerializeField] public UnityEvent OnDrop;
    [SerializeField] public GameObject icon;
    [SerializeField] public GameObject canvas;
    [SerializeField] public string targetName;
    void Start()
    {
        uiParent.SetActive(false);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);

        var go =Instantiate(icon,canvas.transform);
        go.transform.SetAsLastSibling();
        go.GetComponent<DragDrop>().SetItem(this);
        go.name= gameObject.name;
        canvas.GetComponent<Inventory>().AddItem(go);
        go.transform.position = Input.mousePosition;

        FindAnyObjectByType<PlayerInventoryHandler>().AddToInventory(gameObject);
        OnPickup?.Invoke();
        
        FindAnyObjectByType<PlayerPickupController>()._canPickUp= false;
        FindAnyObjectByType<PlayerPickupController>()._pickup = null;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiParent.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiParent.SetActive(false);
        }
    }
}
