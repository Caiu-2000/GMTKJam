using UnityEngine;

public class BossHitEffect : MonoBehaviour
{
    [SerializeField] private GameObject bloodPrefab;  // the empty parent with both particle systems
    [SerializeField] private float lifetime = 1f;

    public void PlayHit(Vector3 hitPoint, Vector3 attackerPosition)
    {
        bool goRight = hitPoint.x >= attackerPosition.x;
        Quaternion rotation = goRight ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f);

        GameObject blood = Instantiate(bloodPrefab, hitPoint, rotation);

        foreach (var flipper in blood.GetComponentsInChildren<FlipOnLeft>())
            flipper.SetFlipped(!goRight);

        Destroy(blood, lifetime);
    }
}