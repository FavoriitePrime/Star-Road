using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement 
{
    private Directions _direction = Directions.Down;
    private readonly float _speed;
    private readonly float _jumpForce;
    private readonly float _gravityForce;
    private readonly Rigidbody2D _rigidbody;
    private readonly PlayerMovementInput _playerInput;
    private readonly PlayerRaycaster _playerRaycaster;


    public PlayerMovement(ref Rigidbody2D rb, ref PlayerMovementInput playerMovementInput, 
        ref PlayerRaycaster playerRaycaster, ref float speed, ref float jumpForce, ref float gravityForce)
    {
        _rigidbody = rb;
        _playerInput = playerMovementInput;
        _speed = speed;
        _jumpForce = jumpForce;
        _gravityForce = gravityForce;
        _playerRaycaster = playerRaycaster;
    }

    public void Enable()
    {
        _playerInput.EnableInput();
        _playerInput.Actions.Jump.started += Jump;
        _playerInput.Actions.Orientation.started += ChangeMoveOrientation;
    }

    public void Disable()
    {
        _playerInput.DisableInput();
        _playerInput.Actions.Jump.started -= Jump;
        _playerInput.Actions.Orientation.started -= ChangeMoveOrientation;
    }

    public void Move()
    {
        switch (_direction)
        {
            case Directions.Down:
                _rigidbody.linearVelocityX = (_playerInput.MoveInput * _speed);
                break;
            case Directions.Up:
                _rigidbody.linearVelocityX = (_playerInput.MoveInput * _speed);
                break;
            case Directions.Left:
                _rigidbody.linearVelocityY = (_playerInput.MoveInput * -_speed);
                break;
            case Directions.Right:
                _rigidbody.linearVelocityY = (_playerInput.MoveInput * _speed);
                break;
        }
    }

    private void ChangeMoveOrientation(InputAction.CallbackContext context)
    {
        GetMoveOrientation(_playerInput.OrientationInput);
        Physics2D.gravity = context.ReadValue<Vector2>() * _gravityForce;
    }

    private void GetMoveOrientation(Vector2 input)
    {
        if (input == Vector2.up) _direction = Directions.Up;
        else if (input == Vector2.down) _direction = Directions.Down;
        else if (input == Vector2.left) _direction=  Directions.Left;
        else if (input == Vector2.right) _direction =  Directions.Right;
        else _direction = Directions.Down;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_playerRaycaster.groundCheck(_direction))
        {
            switch (_direction)
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