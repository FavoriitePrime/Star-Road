using UnityEngine;

public class PlayerMovementInput
{
    public PlayerInputActions Actions;
  
    public void EnableInput()
    {
        Actions.Player.Enable();
    }

    public void DisableInput()
    {
        Actions.Player.Disable();
    }

    public float MoveDirection
    {
        get  { return Actions.Player.Move.ReadValue<Vector2>().x; }
    }

    public bool Jump
    {
        get { return Actions.Player.Jump.ReadValue<bool>(); }
    }
}
