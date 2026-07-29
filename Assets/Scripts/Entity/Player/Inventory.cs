using UnityEngine;
public enum ResourceType
{
    Logs,
    Gold,
    LootEspectro,
    LootOjo
}
public class Inventory
{
    int logs = 0;
    int gold = 0;
    int mobDropEspectro = 0;
    int mobDropOjo = 0;
    #region logs
    public void AddLogs(int amount)
    {
        Debug.Log("Se agrego un tronco");
        logs += amount;
    }
    public void RemoveLogs(int amount)
    {
        logs -= amount;
    }
    public int GetLogs()
    {
        return logs;
    }
    #endregion
    #region gold
    public void AddGold(int amount)
    {
        Debug.Log("Se agrego un tronco");
        gold += amount;
    }
    public void RemoveGold(int amount)
    {
        gold -= amount;
    }
    
    public int GetGold() { return gold; }
    #endregion
    #region Espectro
    public void AddLootEspectro(int amount)
    {
        Debug.Log("Se agrego un tronco");
        mobDropEspectro += amount;
    }
    public void RemoveLootEspectro(int amount)
    {
        mobDropEspectro -= amount;
    }

    public int GetLootEspectro() { return mobDropEspectro; }
    #endregion
    #region Ojo
    public void AddLootOjo(int amount)
    {
        Debug.Log("Se agrego un tronco");
        mobDropOjo += amount;
    }
    public void RemoveLootOjo(int amount)
    {
        mobDropOjo -= amount;
    }

    public int GetLootOjo() { return mobDropOjo; }
    #endregion
    public int GetAmount(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Logs: return logs;
            case ResourceType.Gold: return gold;
            case ResourceType.LootEspectro: return mobDropEspectro;
            case ResourceType.LootOjo: return mobDropOjo;
            default: return 0;
        }
    }
}
