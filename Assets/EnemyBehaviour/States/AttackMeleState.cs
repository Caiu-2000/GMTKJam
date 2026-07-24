using System.Collections;

using UnityEngine;

public class AttackMeleState : State
{

    [SerializeField] float chargeDuration;
  
    [SerializeField] float ChargeCD;
    public bool ChargeInCD = false;


    private float OldSpeed;
    public override void StartState()
    {
        ChargeInCD = true;
        StartCoroutine(chargeSecuence());
    }

    private IEnumerator chargeSecuence()
    {
        // TRIGUEREAR ANIMACION
    
        ParentMachine._movement.Move(new Vector2(0, 0));
        yield return new WaitForSeconds(chargeDuration);
        ParentMachine.CallAttack(GeneralHandler.player.transform.position);
        yield return new WaitForSeconds(0.2f);
        ParentMachine.ChangeState(DefaultNextState);
    }
    public override void StopState()
    {
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(ChargeCD);
        ChargeInCD = false;
    }


}
