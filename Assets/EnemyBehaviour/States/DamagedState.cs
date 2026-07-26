using System.Collections;
using UnityEngine;

public class DamagedState : State
{
    private Hitt _hittData;
    public State Paused;




    public void HittData(Hitt hitt , State paused)
    {
        _hittData = hitt;
        Paused = paused;
    }


    public override void StartState()
    {
        StartCoroutine(Knockback());
    }

    private IEnumerator Knockback()
    {
        float elapsedTime = 0;

        while (true)
        {
            elapsedTime += Time.deltaTime;
          
            ParentMachine._movement.Move(GM.OppositeDirection(_hittData.AttackFrom , this.transform.position) * 3.0f);



            if (elapsedTime > 0.1f) break;

            yield return null;
        }

        ParentMachine.ChangeState(Paused);

    }



}
