using System.Collections;
using UnityEngine;

public class GoingToFireplace : State
{
    public override void StartState()
    {
        print("Se llamo a este estdo");
        IsPausable = false;
        StartCoroutine(TravelToFireplace());
    }


    private IEnumerator TravelToFireplace()
    {
        ParentMachine._movement.Move(new Vector2(0, 0));
        _controlledEntity._animator.SetTrigger("Elevate");
        ParentMachine._movement.Move(Vector2.zero);
        yield return new WaitForSeconds(2.0f);
        Vector3 pos = GeneralHandler.Campfire.transform.position;
        _controlledEntity.transform.position = new Vector3(pos.x , 2 , pos.z);


        _controlledEntity._animator.SetTrigger("Descend");
        yield return new WaitForSeconds(2.0f);
        ParentMachine.ChangeState(DefaultNextState);

    }
}
