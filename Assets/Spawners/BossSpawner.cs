using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform bossSpawnPoint;
    void OnEnable()
    {
        BossProgressManager.Instance.OnBossSpawn += SpawnBoss;
    }
    void OnDisable()
    {
        if (BossProgressManager.Instance != null)
            BossProgressManager.Instance.OnBossSpawn -= SpawnBoss;
    }
    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
    }
}
