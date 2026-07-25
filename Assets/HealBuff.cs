using System.Collections;
using UnityEngine;

public class HealBuff : MonoBehaviour
{

    private bool IsReady = false;
    [SerializeField] private float BuffDuration = 3.0f;
    [SerializeField] float Healtick = 1;

    private bool Islinked = false;
    private void Start()
    {
        GeneralHandler.Heatlbuff = this;
    }
    public void Unlock()
    {
        IsReady = true;
        print("Se desbloqueo heal");
        GeneralHandler.player.input.OnHealPressed += ActivateBuff;
        Islinked = true;
    }

    public void ActivateBuff()
    {
        print("SE llamo la habilidad");
        if (IsReady) StartCoroutine(UpgradeTimer());
    }




    private IEnumerator UpgradeTimer()
    {
        IsReady = false;
      
        GeneralHandler.player.Heal(Healtick * 10);
        yield return new WaitForSeconds(20.0f);
        IsReady = true;
    }
}
