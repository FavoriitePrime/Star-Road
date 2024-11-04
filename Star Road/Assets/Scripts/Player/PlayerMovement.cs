using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpStrength;
    private Vector2 _velocity;
    private Directions _direction;
    private Rigidbody2D Rigidbody;
    private PlayerMovementInput _playerInput;
    private PlayerRaycaster _playerRaycaster;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerMovementInput
        {
            Actions = new PlayerInputActions()
        };
    }

    private void OnEnable()
    {
        _playerInput.EnableInput();
        _playerInput.Actions.Player.Jump.started += HorizontalVelocity;
        _playerInput.Actions.Player.Move.performed += VerticialVelocity;
    }

    private void OnDisable()
    {
        _playerInput.DisableInput();
        _playerInput.Actions.Player.Jump.started -= HorizontalVelocity;
        _playerInput.Actions.Player.Move.performed -= VerticialVelocity;
    }

    void Update()
    {
        GravityForce();
        Rigidbody.AddForce(_velocity);
        Debug.Log(_velocity);
    }

    private void VerticialVelocity(InputAction.CallbackContext context)
    {
        _velocity.x = (_playerInput.MoveDirection * MoveSpeed);
    }

    private void HorizontalVelocity(InputAction.CallbackContext context)
    {
        _velocity.y += JumpStrength;
    }

    private void GravityForce()
    {
        
        _velocity += (Vector2)Physics.gravity * Time.deltaTime;
    }
}