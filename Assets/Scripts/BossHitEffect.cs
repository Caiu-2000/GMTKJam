using UnityEngine;

public class BossHitEffect : MonoBehaviour
{
    [SerializeField] private GameObject bloodPrefab; 
    [SerializeField] private float lifetime = 1f;
    public void PlayHit(Vector3 hitPoint, Vector3 hitDirection)
    {
        Quaternion rotation = hitDirection.sqrMagnitude > 0.001f
            ? Quaternion.LookRotation(hitDirection)
            : Quaternion.identity;

        GameObject blood = Instantiate(bloodPrefab, hitPoint, rotation);
        Destroy(blood, lifetime);
    }
}