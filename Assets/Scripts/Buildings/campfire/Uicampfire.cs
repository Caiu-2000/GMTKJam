using UnityEngine;
using UnityEngine.InputSystem;

public class Uicampfire : MonoBehaviour
{
    [SerializeField]campfireFlicker campfire;
    [SerializeField] GameObject torch;
    [SerializeField] GameObject panel;
    
    // Update is called once per frame
    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            if (campfire.currentTier == 0 && player.inventory.GetLogs() >= 5)
            {
                campfire.Upgrade();
                player.inventory.RemoveLogs(5);
            }
            else if (campfire.currentTier == 1 && player.inventory.GetLogs() >= 20)
            {
                campfire.Upgrade();
                player.inventory.RemoveLogs(20);
            }
            panel.SetActive(false);
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (player.inventory.GetLogs() >= 1)
            {
                campfire.AddFuel(30);
                player.inventory.RemoveLogs(1);
            }
            panel.SetActive(false);
        }
        if (Keyboard.current.tKey.wasPressedThisFrame && torch.activeSelf == false)
        {
            if (player.inventory.GetLogs() >= 1)
            {
                player.inventory.RemoveLogs(1);
                torch.SetActive(true);
            }
            panel.SetActive(false);
        }
    }
}
