using UnityEngine;

public class DeathState : State
{
    public override void StartState()
    {
        ParentMachine._movement.Move(new Vector2(0, 0));
        Destroy(gameObject , 3.0f);
    }
}
