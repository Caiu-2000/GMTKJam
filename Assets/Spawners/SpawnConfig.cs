using UnityEngine;

[CreateAssetMenu(fileName = "SpawnConfig", menuName = "Scriptable Objects/SpawnConfig")]
public class SpawnConfig : ScriptableObject
{
    public float baseSpawnInterval = 3f;
    public AnimationCurve spawnRateMultiplier = AnimationCurve.Linear(0, 1, 1, 5);
    public GameObject[] enemyPrefabs;
}
