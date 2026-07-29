using System;
using UnityEngine;

public class BossProgressManager : MonoBehaviour
{
    public static BossProgressManager Instance { get; private set; }
    [SerializeField] float bossTargetTime = 600f;
    [SerializeField] float minTargetTime = 60f;
    float elapsedTime;
    bool bossSpawned;
    public float Progress01 => Mathf.Clamp01(elapsedTime / bossTargetTime);
    public float RemainingTime => Mathf.Max(0f, bossTargetTime - elapsedTime);
    public event Action<float> OnProgressChanged;
    public event Action OnBossSpawn;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossSpawned) return;
        elapsedTime += Time.deltaTime;
        OnProgressChanged?.Invoke(Progress01);
        if (elapsedTime >= bossTargetTime) TriggerBossSpawn();
    }
    public void SpeedUpBoss(float seconds)
    {
        if (bossSpawned) return;
        bossTargetTime = MathF.Max(minTargetTime, bossTargetTime-seconds);
        OnProgressChanged?.Invoke(Progress01);
    }
    public void SpeeUpBossByPercent(float percent)
    {
        SpeedUpBoss(bossTargetTime * percent);
    }
    void TriggerBossSpawn()
    {
        bossSpawned = true;
        OnBossSpawn?.Invoke();
    }    
}
