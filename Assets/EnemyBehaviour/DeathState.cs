using UnityEngine;

public class DeathState : State
{
    public override void StartState()
    {
        Destroy(gameObject , 3.0f);
    }
}
