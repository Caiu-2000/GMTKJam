using UnityEngine;

public class Inventory
{
    int logs = 0;
    int gold = 0;
    public void AddLogs(int amount)
    {
        Debug.Log("Se agrego un tronco");
        logs += amount;
    }
    public void RemoveLogs(int amount)
    {
        logs -= amount;
    }
    public void AddGold(int amount)
    {
        Debug.Log("Se agrego un tronco");
        gold += amount;
    }
    public void RemoveGold(int amount)
    {
        gold -= amount;
    }
    public int GetLogs()
    {
        return logs;
    }
    public int GetGold() { return gold; }
}
