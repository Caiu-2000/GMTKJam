using UnityEngine;
using System.Collections.Generic;
public static class EnemyTracker
{
    static readonly List<Enemy> active = new();
    public static void Register(Enemy enemy) => active.Add(enemy);
    public static void Unregister(Enemy enemy) => active.Remove(enemy);
    public static void KillAll()
    {
        for (int i = active.Count - 1; i >= 0; i--)
        {
            active[i].Die();
        }
    }
}
