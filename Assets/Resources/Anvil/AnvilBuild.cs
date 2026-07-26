using UnityEngine;
using UnityEngine.InputSystem;

public class AnvilBuild : MonoBehaviour
{
    [SerializeField] GameObject thisObject;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] GameObject panel;
    // Update is called once per frame
    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if(Keyboard.current.tKey.wasPressedThisFrame && player.inventory.GetGold() >= 5)
        {
            player.inventory.RemoveGold(5);
            objectToSpawn.SetActive(true);
            thisObject.SetActive(false);
            panel.SetActive(false);
        }
        if (Keyboard.current.numpad9Key.wasPressedThisFrame)
        {
            player.inventory.AddGold(5);
            player.inventory.AddLootOjo(5);
            player.inventory.AddLootEspectro(5);
        }
    }
}
