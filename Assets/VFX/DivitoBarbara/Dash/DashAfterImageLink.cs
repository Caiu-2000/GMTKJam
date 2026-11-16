using UnityEngine;

public class DashAfterImageLink : MonoBehaviour
{
    [SerializeField] private DashCOmponnent dash;
    [SerializeField] private AfterImageSpawner spawner;

    private void OnEnable()
    {
        dash.OnDashed += spawner.BeginSpawning;
        dash.OnDashFinished += spawner.EndSpawning;
    }

    private void OnDisable()
    {
        dash.OnDashed -= spawner.BeginSpawning;
        dash.OnDashFinished -= spawner.EndSpawning;
    }
}