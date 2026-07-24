using UnityEngine;

public class ChasingState : State
{
    [SerializeField] float RangeForAttack = 3.0f;

    public override void UpdateState()
    {
        ParentMachine._movement.Move(ParentMachine._ai.DirectionTowards(GeneralHandler.player.transform.position));
    }
}
