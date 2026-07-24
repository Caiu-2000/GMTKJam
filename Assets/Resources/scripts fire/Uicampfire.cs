using UnityEngine;
using UnityEngine.InputSystem;

public class Uicampfire : MonoBehaviour
{
    [SerializeField]campfireFlicker campfire;
    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            campfire.Upgrade();
        }
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            if (player.inventory.GetLogs() >= 1)
            {
                campfire.AddFuel(30);
                player.inventory.RemoveLogs(1);
            }
        }
    }
}
