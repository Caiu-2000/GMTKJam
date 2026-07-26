using UnityEngine;

public class SpecialChase : ChasingState
{
    public override void UpdateState()
    {

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
