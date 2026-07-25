
using UnityEngine;

public class CampFireDetector : MonoBehaviour
{

    [SerializeField] float DamageToCampfire = 5.0f;
    [SerializeField] GameObject Parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<campfireFlicker>(out campfireFlicker campfire))
        {
            campfire.RemoveFuel(DamageToCampfire);
            Destroy(Parent);
        }
    }
}
