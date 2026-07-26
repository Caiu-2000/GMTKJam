using System.Collections;
using UnityEngine;

public class GoingToFireplace : State
{
    public override void StartState()
    {
        StartCoroutine(TravelToFireplace());
    }


    private IEnumerator TravelToFireplace()
    {
        _controlledEntity._animator.SetTrigger("Elevate");
        yield return new WaitForSeconds(2.0f);
        _controlledEntity.transform.position = GeneralHandler.Campfire.transform.position;
        _controlledEntity._animator.SetTrigger("Descend");


    }
}
