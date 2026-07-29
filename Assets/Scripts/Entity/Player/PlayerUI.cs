using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI treeText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI spectreText;
    [SerializeField] TextMeshProUGUI eyeText;
    Player player;
    private void Start()
    {
        player = GeneralHandler.Instance.GetPlayer();
    }
    void Update()
    {
        player = GeneralHandler.Instance.GetPlayer();
        treeText.text = $"{player.inventory.GetLogs()}";
        goldText.text = $"{player.inventory.GetGold()}";
        spectreText.text = $"{player.inventory.GetLootEspectro()}";
        eyeText.text = $"{player.inventory.GetLootOjo()}";
    }
}
