using UnityEngine;

public class SkeletorGano : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        print("Hola"+other.name);
        if(other.TryGetComponent<Tree>(out Tree tree))
            Destroy(tree.gameObject);
    }
}
