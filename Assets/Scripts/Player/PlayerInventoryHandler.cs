using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventoryHandler : MonoBehaviour
{
    private Canvas _inventoryCanvas;
    private GridLayoutGroup _inventoryLayoutGroup;

    public bool ShouldShowInventory { get; set; }
    private bool dummySlotExists = false;

    public GameObject ItemPanel => _itemPanelPrefab;
    [SerializeField] private GameObject _itemPanelPrefab;


    public List<GameObject> Items => _items; 
    [Header("INVENTORY")]
    [SerializeField] private List<GameObject> _items;

    private void Start()
    {
        _inventoryCanvas = GameObject.FindGameObjectWithTag("UI Menu").GetComponent<Canvas>();
        _inventoryCanvas.enabled = false;

        _inventoryLayoutGroup = _inventoryCanvas.GetComponentInChildren<GridLayoutGroup>();
    }

    public void OnToggleInventory(InputAction.CallbackContext _)
    {
        ShouldShowInventory = !ShouldShowInventory;
        _inventoryCanvas.enabled = ShouldShowInventory;
        if(ShouldShowInventory) VerifyPanelsMoreThanZero();
    }

    public void AddToInventory(GameObject go) //Adds gameobject 'go' to the inventory and instantiates a sprite under a newly instantiated panel
    {
        _items.Add(go);

//        GameObject newPanel = Instantiate(_itemPanelPrefab, _inventoryLayoutGroup.transform, true);
  //      newPanel.name = go.name + "_Inventory";

        //Image newPanelIcon = GetChildComponentLinq<Image>(newPanel);
    //    SpriteRenderer goSr = go.GetComponentInChildren<SpriteRenderer>();
      //  newPanelIcon.sprite = goSr.sprite;
        //newPanelIcon.color = goSr.color;

       // VerifyPanelsMoreThanZero();
    }

    public void RemoveFromInventory(GameObject go)
    {
        _items.Remove(go);
        //TODO with Destroy() method
        //edit: Maybe not needed to remove from inventory in the scope of this game?
        VerifyPanelsMoreThanZero();
    }

    private void VerifyPanelsMoreThanZero()
    {
        int childCount = _inventoryLayoutGroup.transform.childCount;
        if (childCount < 1)
        {
            GameObject emptyPanel = Instantiate(_itemPanelPrefab, _inventoryLayoutGroup.transform, true);
            GetChildComponentLinq<Image>(emptyPanel).enabled = false;
            dummySlotExists = true;
        }
        else if (childCount > 1 && dummySlotExists)
        {
            Destroy(_inventoryLayoutGroup.transform.GetChild(0).gameObject);
            dummySlotExists = false;
        }
    }

    private T GetChildComponentLinq<T>(GameObject go) where T : Component
    {
        return go.GetComponentsInChildren<T>().FirstOrDefault(c => c.gameObject != go.gameObject);
    }
}
