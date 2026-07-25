using System.Collections;
using UnityEngine;

public class ChargeAttack : State
{
    [SerializeField] float SpeedMultiplier;
    [SerializeField] float chargeDuration;
    [SerializeField] float CastDuration;
    [SerializeField] float ChargeCD;
    public bool ChargeInCD = false;

    public Transform objective;

    private float OldSpeed;
    public override void StartState()
    {
        OldSpeed = ParentMachine._movement.Speed;
        ChargeInCD = true;
        StartCoroutine(chargeSecuence());
    }

    protected virtual IEnumerator chargeSecuence()
    {
        // TRIGUEREAR ANIMACION
        print("Esperando");
        ParentMachine._movement.Move(new Vector2(0,0));
        float elapsedTime = 0;
        Vector3 scapeDir = ParentMachine._ai.DirectionTowards(objective.position) * -1;
        ParentMachine._movement.Speed = 0.5f;

        while (true) 
        { 
            elapsedTime += Time.deltaTime;
            ParentMachine._movement.Move(scapeDir);
            if (elapsedTime >= chargeDuration)
            {
                break;
            }
            yield return null;
        
        }
        ParentMachine._movement.Speed = OldSpeed;
        print("Termino la espera");
        ParentMachine._movement.Speed *= SpeedMultiplier * 2 ;
        elapsedTime = 0;
        Vector3 ChargeDirection = ParentMachine._ai.DirectionTowards(objective.position);
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
