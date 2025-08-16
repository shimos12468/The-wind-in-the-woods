using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private static readonly int IsRight = Animator.StringToHash("IsRight");
    private static readonly int IsLeft = Animator.StringToHash("IsLeft");
    private static readonly int IsBack = Animator.StringToHash("IsBack");
    private static readonly int IsFront = Animator.StringToHash("IsFront");
    private static readonly int BlendX = Animator.StringToHash("Blend_X");
    private static readonly int BlendY = Animator.StringToHash("Blend_Y");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private Animator _animationController;
    [SerializeField] private Vector2 _moveDirection = Vector2.zero;
    private PlayerMovementController _playerMovementController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animationController = GetComponent<Animator>();
        _playerMovementController = this.GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = _playerMovementController.MovementDirection;
        _animationController.SetFloat(BlendX, _moveDirection.x);
        _animationController.SetFloat(BlendY, _moveDirection.y);
        _animationController.SetBool(IsMoving, _playerMovementController.IsMoving);
    }
}
