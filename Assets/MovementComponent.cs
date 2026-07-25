using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class MovementComponent 
{
    [SerializeField] private Rigidbody _RB;
    [SerializeField] private Entity _parentEntity;
    public float Speed = 3.0f;
    

    public MovementComponent (Rigidbody rb , Entity parent)
    {
        _RB = rb;
        _parentEntity = parent;
    }

    public void Move(Vector2 moveDir)
    {
        Debug.Log(Speed);
        _RB.linearVelocity = new Vector3(moveDir.x , 0 , moveDir.y)  * Speed;
    }
}
