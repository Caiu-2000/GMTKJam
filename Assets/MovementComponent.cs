

using System;

using UnityEngine;


[System.Serializable]
public class MovementComponent 
{
    [SerializeField] public Rigidbody _RB;
    [SerializeField] private Entity _parentEntity;
    [SerializeField]
    public float Speed = 3.0f;

    public Vector2 LastDirection;
    public MovementComponent (Rigidbody rb , Entity parent, float newSpeed = 10)
    {
        _RB = rb;
        _parentEntity = parent;
        Speed = newSpeed;
    }

    public void Move(Vector2 moveDir)
    {
        LastDirection = moveDir;
        _RB.linearVelocity = new Vector3(moveDir.x , 0 , moveDir.y)  * Speed;
    }
}
