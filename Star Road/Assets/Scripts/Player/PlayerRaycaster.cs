using System;
using UnityEngine;

public class PlayerRaycaster 
{
    private Ray2D _rayUp;
    private Ray2D _rayDown;
    private Ray2D _rayLeft;
    private Ray2D _rayRight;
    private readonly float _distance;
    public PlayerRaycaster(Vector2 startPosition, float distance)
    {
        _rayUp = new Ray2D(startPosition, Vector2.up);
        _rayDown = new Ray2D(startPosition, Vector2.down);
        _rayLeft = new Ray2D(startPosition, Vector2.left);
        _rayRight = new Ray2D(startPosition, Vector2.right);
        _distance = distance;
    }
    
    public RaycastHit2D RayCast(Directions direction)
    {
        return direction switch
        {
            Directions.Up => Physics2D.Raycast(_rayUp.origin, _rayUp.direction, _distance),
            Directions.Down => Physics2D.Raycast(_rayDown.origin, _rayDown.direction, _distance),
            Directions.Left => Physics2D.Raycast(_rayLeft.origin, _rayLeft.direction, _distance),
            Directions.Right => Physics2D.Raycast(_rayRight.origin, _rayRight.direction, _distance),
            _ => throw new ArgumentException("Не задано направление"),
        };
    }
}