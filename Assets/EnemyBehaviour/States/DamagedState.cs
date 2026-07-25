using System.Collections;
using UnityEngine;

public class DamagedState : State
{
    private Hitt _hittData;
    public State Paused;



    public Vector3 debug1;
    public Vector3 debug2;
    public Vector3 debug3;



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

            debug1 = GM.OppositeDirection(_hittData.AttackFrom, this.transform.position);
            debug2 = _hittData.AttackFrom;
            debug3 = this.transform.position;


            if (elapsedTime > 0.1f) break;

            yield return null;
        }

        ParentMachine.ChangeState(Paused);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(debug1, 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(debug2, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(debug3, 0.5f);
    }

}
