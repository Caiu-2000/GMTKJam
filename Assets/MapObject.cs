using System.Collections;
using UnityEngine;

public class MapObject : MonoBehaviour , IHittable
{
    private bool CanBeHitted = true;
    public void Hitt(Hitt hitt)
    {
        if (!CanBeHitted) { return; }
        StartCoroutine(HittCd());
        print("Hay me pego  " + hitt.HittDamage);
    


    }

    private IEnumerator HittCd()
    {
        CanBeHitted = false;
        yield return new WaitForSeconds(0.2f);
        CanBeHitted = true ;
    }

}
