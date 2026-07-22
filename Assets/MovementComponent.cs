using UnityEngine;

[System.Serializable]
public class MovementComponent 
{
    [SerializeField] private Rigidbody _RB;
    public float Speed = 3.0f;

    public void Move(Vector2 moveDir)
    {
        _RB.linearVelocity = moveDir * Time.deltaTime * Speed;
    }
}
