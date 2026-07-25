using System.Collections;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    private bool IsReady = false;
    [SerializeField] private float BuffDuration = 3.0f;


    private bool Islinked = false;
    private void Start()
    {
        GeneralHandler.DamageBuff = this;
    }
    public void Unlock()
    {
        if (Islinked) return;
        IsReady = true;
        GeneralHandler.player.input.OnBuffPressed += ActivateBuff;
        Islinked = true;
    }

    public void ActivateBuff()
    {
        if (IsReady) StartCoroutine(UpgradeTimer());
    }




    private IEnumerator UpgradeTimer()
    {
        IsReady = false;
        GeneralHandler.DamageBuffed = true;
        yield return new WaitForSeconds(BuffDuration);
        GeneralHandler.DamageBuffed = false;
        yield return new WaitForSeconds(10.0f);
        IsReady = true ;
    }
}
