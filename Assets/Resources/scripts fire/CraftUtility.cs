using UnityEngine;

public static class CraftUtility
{
    public static bool CanAfford(CraftOptionData option)
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        foreach (var cost in option.costs)
        {
            if (player.inventory.GetAmount(cost.type) < cost.amount)
                return false;
        }
        return true;
    }
}