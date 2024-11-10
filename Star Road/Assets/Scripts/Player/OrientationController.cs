using UnityEngine;
using UnityEngine.InputSystem;

public class OrientationController
{
    private Directions _direction = Directions.Down;
    public Directions Direction => _direction;
    private readonly PlayerMovementInput _playerInput;
    public OrientationController(ref PlayerMovementInput playerInput)
    {
        _playerInput = playerInput;
    }
    public void Enable()
    {
        _playerInput.Actions.Orientation.started += GetMoveOrientation;
    }
    public void Disable()
    {
        _playerInput.Actions.Orientation.started -= GetMoveOrientation;
    }
    private void GetMoveOrientation(InputAction.CallbackContext input)
    {
        if (_direction == Directions.Down)
        {
            if (input.ReadValue<Vector2>() == Vector2.up) _direction = Directions.Up;
            else if (input.ReadValue<Vector2>() == Vector2.down) _direction = Directions.Down;
            else if (input.ReadValue<Vector2>() == Vector2.left) _direction = Directions.Left;
            else if (input.ReadValue<Vector2>() == Vector2.right) _direction = Directions.Right;
            else _direction = Directions.Down;
        }
        else if (_direction == Directions.Left)
        {
            if (input.ReadValue<Vector2>() == Vector2.up) _direction = Directions.Right;
            else if (input.ReadValue<Vector2>() == Vector2.down) _direction = Directions.Left;
            else if (input.ReadValue<Vector2>() == Vector2.left) _direction = Directions.Up;
            else if (input.ReadValue<Vector2>() == Vector2.right) _direction = Directions.Down;
            else _direction = Directions.Left;
        }
        else if (_direction == Directions.Up)
        {
            if (input.ReadValue<Vector2>() == Vector2.up) _direction = Directions.Down;
            else if (input.ReadValue<Vector2>() == Vector2.down) _direction = Directions.Up;
            else if (input.ReadValue<Vector2>() == Vector2.left) _direction = Directions.Right;
            else if (input.ReadValue<Vector2>() == Vector2.right) _direction = Directions.Left;
            else _direction = Directions.Up;
        }
        else if (_direction == Directions.Right)
        {
            if (input.ReadValue<Vector2>() == Vector2.up) _direction = Directions.Left;
            else if (input.ReadValue<Vector2>() == Vector2.down) _direction = Directions.Right;
            else if (input.ReadValue<Vector2>() == Vector2.left) _direction = Directions.Down;
            else if (input.ReadValue<Vector2>() == Vector2.right) _direction = Directions.Up;
            else _direction = Directions.Right;
        }
    }
}