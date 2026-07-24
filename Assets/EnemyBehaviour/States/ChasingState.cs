using UnityEngine;

public class ChasingState : State
{
    [SerializeField] float RangeForAttack = 1.0f;

    [SerializeField] private ChargeAttack ChargeState;
   
    [SerializeField] private AttackMeleState Attack;

    public override void UpdateState()
    {
        ParentMachine._movement.Move(ParentMachine._ai.DirectionTowards(GeneralHandler.player.transform.position));

        if (Vector3.Distance(this.transform.position, GeneralHandler.player.transform.position) < RangeForAttack)
        {
            if (!ChargeState.ChargeInCD)
            {
                ParentMachine.ChangeState(ChargeState);
            }
            else if (!Attack.ChargeInCD)
            {
                ParentMachine.ChangeState(Attack);
            }
        }
    
    
    }
}
