using System;
using UnityEngine;

public class PlayerRaycaster 
{
    private readonly float _distance;
    private readonly Transform _transform;
    private readonly LayerMask _mask;
    public PlayerRaycaster(ref Transform transform, ref float distance, ref LayerMask layerMask)
    {
        _transform = transform;
        _distance = distance;
        _mask = layerMask;
    }
    
    public RaycastHit2D GroundCheck(Directions direction)
    {
        return direction switch
        {
            Directions.Up => Physics2D.Raycast(_transform.position, Vector2.up, _distance, _mask),
            Directions.Down => Physics2D.Raycast(_transform.position, Vector2.down, _distance, _mask),
            Directions.Left => Physics2D.Raycast(_transform.position, Vector2.left, _distance, _mask),
            Directions.Right => Physics2D.Raycast(_transform.position, Vector2.right, _distance, _mask),
            _ => throw new ArgumentException("Не задано направление"),
        };
    }
}