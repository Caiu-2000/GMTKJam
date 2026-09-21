using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform bossSpawnPoint;
    [SerializeField] Transform bossSpawnPointDebug;
    [SerializeField] GameObject BossCircleVFX;
    [SerializeField] float spawnTimer = 2f;
    GameObject bossDebug;
    bool bossSpawning = false;

    void Start()
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
        if (bossSpawning) return;
        StartCoroutine(SpawnCircle());
    }
    void SpawnBossDebug()
    {
        if (bossSpawning) return;
        StartCoroutine(SpawnCircleDebug());
    }
    private void Update()
    {
        if(Keyboard.current.numpad7Key.wasPressedThisFrame)
        {
            SpawnBossDebug();
        }
        if(Keyboard.current.numpad8Key.wasPressedThisFrame)
        {
            Destroy(bossDebug);
        }
    }
    IEnumerator SpawnCircleDebug()
    {
        bossSpawning = true;
        var  circleSpawner = Instantiate(BossCircleVFX, bossSpawnPointDebug.position, bossSpawnPoint.rotation);
        yield return new WaitForSeconds(spawnTimer);
        Destroy(circleSpawner);
        bossDebug = Instantiate(bossPrefab, bossSpawnPointDebug.position, bossSpawnPoint.rotation);
        bossSpawning = false;
    }
    IEnumerator SpawnCircle()
    {
        bossSpawning = true;
        var circleSpawner = Instantiate(BossCircleVFX, bossSpawnPoint.position, bossSpawnPoint.rotation);
        yield return new WaitForSeconds(spawnTimer);
        Destroy(circleSpawner);
        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
        bossSpawning = false;
    }
}
