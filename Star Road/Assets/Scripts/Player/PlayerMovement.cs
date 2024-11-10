using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement 
{
    private readonly OrientationController _orientationController;
    private readonly float _speed;
    private readonly float _jumpForce;
    private readonly float _gravityForce;
    private readonly Rigidbody2D _rigidbody;
    private readonly PlayerMovementInput _playerInput;
    private readonly PlayerRaycaster _playerRaycaster;


    public PlayerMovement(ref Rigidbody2D rb, ref PlayerMovementInput playerMovementInput, 
        ref PlayerRaycaster playerRaycaster, ref float speed, ref float jumpForce, ref float gravityForce, ref OrientationController controller)
    {
        _rigidbody = rb;
        _playerInput = playerMovementInput;
        _speed = speed;
        _jumpForce = jumpForce;
        _gravityForce = gravityForce;
        _playerRaycaster = playerRaycaster;
        _orientationController = controller;
    }

    public void Enable()
    {
        _playerInput.EnableInput();
        _playerInput.Actions.Jump.started += Jump;
    }

    public void Disable()
    {
        _playerInput.DisableInput();
        _playerInput.Actions.Jump.started -= Jump;
    }

    public void Move()
    {
        ChangeGravity();
        switch (_orientationController.Direction)
        {
            case Directions.Down:
                _rigidbody.linearVelocityX = (_playerInput.MoveInput * _speed);
                break;
            case Directions.Up:
                _rigidbody.linearVelocityX = (_playerInput.MoveInput * -_speed);
                break;
            case Directions.Left:
                _rigidbody.linearVelocityY = (_playerInput.MoveInput * -_speed);
                break;
            case Directions.Right:
                _rigidbody.linearVelocityY = (_playerInput.MoveInput * _speed);
                break;
        }
    }

    private void ChangeGravity()
    {
        switch (_orientationController.Direction)
        {
            case Directions.Down:
                Physics2D.gravity = Vector2.down * _gravityForce;
                break;
            case Directions.Up:
                Physics2D.gravity = Vector2.up * _gravityForce;
                break;
            case Directions.Left:
                Physics2D.gravity = Vector2.left * _gravityForce;
                break;
            case Directions.Right:
                Physics2D.gravity = Vector2.right * _gravityForce;
                break;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_playerRaycaster.GroundCheck(_orientationController.Direction))
        {
            switch (_orientationController.Direction)
            {
                case Directions.Down:
                    _rigidbody.linearVelocityY = _jumpForce;
                    break;
                case Directions.Up:
                    _rigidbody.linearVelocityY = -_jumpForce;
                    break;
                case Directions.Left:
                    _rigidbody.linearVelocityX = _jumpForce;
                    break;
                case Directions.Right:
                    _rigidbody.linearVelocityX = -_jumpForce;
                    break;
            }
        }
    }
}