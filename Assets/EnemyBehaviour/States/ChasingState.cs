using UnityEngine;

public class ChasingState : State
{
    [SerializeField] protected float RangeForAttack = 1.0f;

    [SerializeField] protected ChargeAttack ChargeState;
   
    [SerializeField] private AttackMeleState Attack;
    [SerializeField] private bool ChaseFire;

    public override void StartState()
    {
        base.StartState();
        ChargeState.objective = GeneralHandler.player.transform;
    }
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
