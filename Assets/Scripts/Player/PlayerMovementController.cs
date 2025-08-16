using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputForwarder))]
[RequireComponent(typeof(Rigidbody2D))]

// A rigidbody based movement system that is extremely basic.
public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection =  Vector2.zero;
    public Vector3 MovementDirection => _moveDirection;

    [SerializeField] [Range(0, 5)] private float _accelRate;
    [SerializeField] [Range(-5, 0)] private float _stopRate;
    [SerializeField] private float _maxSpeed;
    private bool _isMoving = false;
    public bool IsMoving => _isMoving;
    private float _currentSpeed;
 

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _currentSpeed += _isMoving ? _accelRate : _stopRate;
        _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _maxSpeed);

        _rb.linearVelocity = _moveDirection * _currentSpeed;
    }

    public void OnMovePerform(InputAction.CallbackContext ctx)
    {
        _moveDirection = ctx.ReadValue<Vector2>();
        _isMoving = true;
    }

    public void OnMoveCancel(InputAction.CallbackContext ctx) => _isMoving = false;
}
