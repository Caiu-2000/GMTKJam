using UnityEngine;
using UnityEngine.InputSystem;

public class AltarUI : MonoBehaviour
{
    Player player;
    int nextUpgrade = 0;
    int maxUpgrade = 3;
    bool resourcesCheck = false;
    [SerializeField] campfireFlicker campfire;
    [SerializeField] Altar altarScript;

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GeneralHandler.Instance.GetPlayer();
        resourcesCheck = CheckResources(nextUpgrade);
        if (Keyboard.current.tKey.wasPressedThisFrame && nextUpgrade < maxUpgrade && resourcesCheck)
        {
            if (nextUpgrade == 0)
            {
                GeneralHandler.Instance.TurnDashOn();
                player.inventory.RemoveGold(10);
                altarScript.OnUpgradeSuccess();
            }
            else if (nextUpgrade == 1)
            {
                GeneralHandler.Instance.ImprovedBasics();
                player.inventory.RemoveGold(15);
                player.inventory.RemoveLootOjo(5);
                altarScript.OnUpgradeSuccess();
            }
            else if (nextUpgrade == 2)
            {
                GeneralHandler.Instance.TurnOnReneration();
                player.inventory.RemoveGold(25);
                player.inventory.RemoveLootOjo(10);
                altarScript.OnUpgradeSuccess();
            }
            nextUpgrade++;
            gameObject.SetActive(false);
        }
        else if (nextUpgrade >= maxUpgrade)
            gameObject.SetActive(false);
    }
    bool CheckResources(int level)
    {
        if (level == 0)
        {
            if (player.inventory.GetGold() >= 10) return true;
            else return false;
        }
        else if (level == 1)
        {
            if (player.inventory.GetGold() >= 15 && player.inventory.GetLootOjo() >= 5 && campfire.currentTier >= 1) return true;
            else return false;
        }
        else if (level == 2)
        {
            if (player.inventory.GetGold() >= 25 && player.inventory.GetLootOjo() >= 10) return true;
            else return false;
        }
        return false;
    }
}
