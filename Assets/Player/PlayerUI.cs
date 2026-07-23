using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI treeText;
    Player player;
    private void Start()
    {
        player = GeneralHandler.Instance.GetPlayer();
    }
    void Update()
    {
        player = GeneralHandler.Instance.GetPlayer();
        treeText.text = $"{player.inventory.GetLogs()}";
    }
}
