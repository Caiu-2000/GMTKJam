using UnityEngine;

public class ChasingState : State
{
    public override void UpdateState()
    {
        ParentMachine._movement.Move(ParentMachine._ai.DirectionTowards(GeneralHandler.player.transform.position));
    }
}
