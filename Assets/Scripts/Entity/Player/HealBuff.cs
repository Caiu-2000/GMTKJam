using System.Collections;
using UnityEngine;

public class HealBuff : MonoBehaviour
{
    [SerializeField] float Cooldown = 20.0f;
    public event System.Action<float> OnCooldownStarted;
    public event System.Action OnReady;
    public bool IsReady = false;
   
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
        OnReady?.Invoke();
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
        OnCooldownStarted?.Invoke(Cooldown);
        yield return new WaitForSeconds(Cooldown);
        IsReady = true;
        OnReady?.Invoke();
    }
}
