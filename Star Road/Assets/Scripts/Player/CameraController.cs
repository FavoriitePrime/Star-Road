using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController
{
    private readonly Transform _transform;
    private readonly PlayerMovementInput _playerInput;
    private readonly OrientationController _orientationController;
    public CameraController(ref Transform transform, ref PlayerMovementInput playerMovementInput, ref OrientationController controller) 
    {  
        _transform = transform; 
        _playerInput = playerMovementInput;
        _orientationController = controller;
    }
    public void Enable()
    {
        _playerInput.Actions.Orientation.started += ChangeCameraOrientation;
    }
    public void Disable()
    {
        _playerInput.Actions.Orientation.started  -= ChangeCameraOrientation;
    }

    private void ChangeCameraOrientation(InputAction.CallbackContext context)
    {
        _transform.rotation = _orientationController.Direction switch
        {
            Directions.Right => Quaternion.Euler(0f, 0f, 90f),
            Directions.Up => Quaternion.Euler(0f, 0f, 180f),
            Directions.Left => Quaternion.Euler(0f, 0f, 270),
            Directions.Down => Quaternion.Euler(0f, 0f, 0),
            _ => Quaternion.Euler(0f, 0f, 0),
        };
    }
}