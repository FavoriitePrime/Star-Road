using UnityEngine;
using static PlayerInputActions;

public class PlayerMovementInput
{
    public PlayerActions Actions;

    public PlayerMovementInput()
    {
        Actions = new PlayerInputActions().Player;
    }

    public void EnableInput()
    {
        Actions.Enable();
    }

    public void DisableInput()
    {
        Actions.Disable();
    }

    public float MoveInput
    {
        get  { return Actions.Move.ReadValue<Vector2>().x; }
    }

    public Vector2 OrientationInput
    {
        get { return Actions.Orientation.ReadValue<Vector2>(); }
    }

    public bool Jump
    {
        get { return Actions.Jump.ReadValue<bool>(); }
    }
}
