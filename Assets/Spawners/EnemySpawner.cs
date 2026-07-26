using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnConfig config;
    [SerializeField] Transform[] spawnPoints;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BossProgressManager.Instance.OnBossSpawn += HandleBossSpawn;
    }
    private void OnDisable()
    {
        if (BossProgressManager.Instance != null)
            BossProgressManager.Instance.OnBossSpawn -= HandleBossSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float progress = BossProgressManager.Instance.Progress01;
        float multiplier = config.spawnRateMultiplier.Evaluate(progress);
        float currentInterval = config.baseSpawnInterval / multiplier;
        if (timer >= currentInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        var prefab = config.enemyPrefabs[Random.Range(0, config.enemyPrefabs.Length)];
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(prefab, point.position, point.rotation);
    }
    void HandleBossSpawn()
    {
        enabled = false;
        EnemyTracker.KillAll();
    }
}
