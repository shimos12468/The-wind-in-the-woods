using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputForwarder : MonoBehaviour
{
    private PlayerMovementController _movementController;
    private PlayerPickupController _pickupController;
    private PlayerInventoryHandler _inventorHandler;

    private PlayerInputActions _inputActions;
    private InputActionMap _playerActionMap;

    private InputAction _move;
    private InputAction _interact;
    private InputAction _toggleInventory;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _playerActionMap = _inputActions.Player;

        _move = _playerActionMap.FindAction("Move");
        _interact = _playerActionMap.FindAction("Interact");
        _toggleInventory = _playerActionMap.FindAction("Toggle Inventory");

        _movementController = GetComponent<PlayerMovementController>();
        _pickupController = GetComponent<PlayerPickupController>();
        _inventorHandler = GetComponent<PlayerInventoryHandler>();
    }

    private void OnEnable()
    {
        _playerActionMap.Enable();

        _move.performed += _movementController.OnMovePerform;
        _move.canceled += _movementController.OnMoveCancel;

        _interact.performed += _pickupController.OnInteract;

        _toggleInventory.performed += _inventorHandler.OnToggleInventory;
    }

    private void OnDisable()
    {
        _move.performed -= _movementController.OnMovePerform;
        _move.canceled -= _movementController.OnMoveCancel;

        _interact.performed -= _pickupController.OnInteract;

        _toggleInventory.performed += _inventorHandler.OnToggleInventory;

        _playerActionMap?.Disable();
    }
}
