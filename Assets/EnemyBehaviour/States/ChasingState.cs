using UnityEngine;

public class ChasingState : State
{
    [SerializeField] protected float RangeForAttack = 1.0f;

    [SerializeField] protected ChargeAttack ChargeState;
   
    [SerializeField] protected AttackMeleState Attack;
    [SerializeField] private bool ChaseFire;

    public override void StartState()
    {
        base.StartState();
        
    
    }
    public override void UpdateState()
    {
        if (ChargeState != null)
        {
            if (ChargeState.objective == null) { 
                ChargeState.objective = GeneralHandler.player.transform;
            
            }

            
        }
    
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
