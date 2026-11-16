using System.Collections;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    [SerializeField] float Cooldown = 10.0f;
    public event System.Action<float> OnCooldownStarted;
    public event System.Action OnReady;
    public bool IsReady = false;
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
        OnReady?.Invoke();
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
        OnCooldownStarted?.Invoke(Cooldown);
        yield return new WaitForSeconds(Cooldown);
        IsReady = true ;
        OnReady?.Invoke();
    }
}
