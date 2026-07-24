using System.Collections;
using UnityEngine;

public class ChargeAttack : State
{
    [SerializeField] float SpeedMultiplier;
    [SerializeField] float chargeDuration;
    [SerializeField] float CastDuration;

    private float OldSpeed;
    public override void StartState()
    {
        OldSpeed = ParentMachine._movement.Speed;
        StartCoroutine(chargeSecuence());
    }

    private IEnumerator chargeSecuence()
    {
        // TRIGUEREAR ANIMACION
        yield return new WaitForSeconds(chargeDuration);
        ParentMachine._movement.Speed *= SpeedMultiplier ;
        float elapsedTime = 0;
        while (elapsedTime < chargeDuration)
        {
            ParentMachine._movement.Move(ParentMachine._ai.DirectionTowards(GeneralHandler.player.transform.position));
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        ParentMachine._movement.Speed = OldSpeed;
        ParentMachine.ChangeState(DefaultNextState);
    }
}
