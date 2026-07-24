using System.Collections;
using UnityEngine;

public class ChargeAttack : State
{
    [SerializeField] float SpeedMultiplier;
    [SerializeField] float chargeDuration;
    [SerializeField] float CastDuration;
    [SerializeField] float ChargeCD;
    public bool ChargeInCD = false;


    private float OldSpeed;
    public override void StartState()
    {
        OldSpeed = ParentMachine._movement.Speed;
        ChargeInCD = true;
        StartCoroutine(chargeSecuence());
    }

    private IEnumerator chargeSecuence()
    {
        // TRIGUEREAR ANIMACION
        print("Esperando");
        ParentMachine._movement.Move(new Vector2(0,0));
        yield return new WaitForSeconds(chargeDuration);
        print("Termino la espera");
        ParentMachine._movement.Speed *= SpeedMultiplier ;
        float elapsedTime = 0;
        Vector3 ChargeDirection = ParentMachine._ai.DirectionTowards(GeneralHandler.player.transform.position);
        while (elapsedTime < CastDuration)
        {
            ParentMachine._movement.Move(ChargeDirection);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        ParentMachine._movement.Speed = OldSpeed;
        ParentMachine.ChangeState(DefaultNextState);
    }
    public override void StopState()
    {
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(ChargeCD);
        ChargeInCD = false ;
    }
}
