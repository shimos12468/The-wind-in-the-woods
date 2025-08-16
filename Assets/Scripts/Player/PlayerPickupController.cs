using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputForwarder))]

// Will determine what happens when the player picks up an item.
// To pick up an item, the player must be within the item's trigger, and the player must hold the Interact button.
public class PlayerPickupController : MonoBehaviour
{
    public bool _canPickUp;
    public GameObject _pickup;
    private PlayerInventoryHandler _inventoryHandler;

    private void Start()
    {
        _inventoryHandler = GetComponent<PlayerInventoryHandler>();
    }

    public void OnInteract(InputAction.CallbackContext _)
    {
        ////Debug.Log("OnInteract fired");
        
        //if (!_canPickUp || _pickup == null)
        //{
        //    Debug.Log("Nothing to pick up");
        //    return;
        //}
        
        //Debug.Log("Interacting with: "  + gameObject.name);
        //_inventoryHandler.AddToInventory(_pickup);
        //_pickup.GetComponent<InteractableSpriteVisualizer>().OnPickup?.Invoke();
        //_pickup.SetActive(false);
        //_canPickUp = false;
        //_pickup = null;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Item")) return;
        
        Debug.Log("Inside item's radius");
        _canPickUp = true;
        _pickup = other.gameObject;
        Debug.Log("canPickUp is: " +  _canPickUp + " and the pickup is: " + _pickup.name);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Item")) return;

        Debug.Log("Walked out of item's radius");
        _canPickUp = false;
        _pickup = null;
        Debug.Log("canPickUp is: " + _canPickUp + " and the pickup is: " + _pickup);
    }
}
