using UnityEngine;

public class Treekiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Tree>(out Tree tree)) { Destroy(tree.gameObject); }
    }
}
