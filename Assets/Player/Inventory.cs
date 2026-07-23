using UnityEngine;

public class Inventory
{
    int logs = 0;
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
}
