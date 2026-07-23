using UnityEngine;

public class ItemFromFloor : MonoBehaviour
{
    [SerializeField] private ToolObject ObjectData; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().ChangeWeapon(ObjectData.tool);
            Destroy(this.gameObject);
        }
    }
}
