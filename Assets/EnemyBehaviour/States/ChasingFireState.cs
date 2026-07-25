using UnityEngine;

public class ChasingFireState : ChasingState
{

    public override void StartState()
    {
        
        base.StartState();
        
    }
    public override void UpdateState()
    {
        ChargeState.objective = GeneralHandler.Campfire.transform;
        ParentMachine._movement.Move(ParentMachine._ai.DirectionTowards(GeneralHandler.Campfire.transform.position));

        if (Vector3.Distance(this.transform.position, GeneralHandler.Campfire.transform.position) < RangeForAttack)
        {
            if (!ChargeState.ChargeInCD)
            {
                ParentMachine.ChangeState(ChargeState);
            }
        }
    }
}
