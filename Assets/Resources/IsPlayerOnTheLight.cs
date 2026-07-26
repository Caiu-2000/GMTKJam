using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IsPlayerOnTheLight : MonoBehaviour
{
    [SerializeField]Player player;
    [SerializeField] List<Light> activeLights = new List<Light>();
    bool isPlayerInRange = false;
    bool damageCd = false;

    void Start()
    {
        GeneralHandler.Instance.AddLightAreaChecker(this);
    }
    void Update()
    {
        player = GeneralHandler.Instance.GetPlayer();
        if (activeLights.Count == 0) return;
        foreach (Light light in activeLights)
        {
            if (Vector3.Distance(player.transform.position, light.transform.position) <= light.range/2 && light.enabled)
            {
                isPlayerInRange = true;
                break;
            }
            else
                isPlayerInRange = false;
        }
        if (isPlayerInRange == false && damageCd == false)
        {
            Debug.Log("Test");
            StartCoroutine(TakeDamage());

        }

    }
    public void AddLight(Light lightToAdd)
    {
        activeLights.Add(lightToAdd);
    }
    public void RemoveLight(Light lightToRemove)
    {
        activeLights.Remove(lightToRemove);
    }
    IEnumerator TakeDamage()
    {
        Hitt test = new Hitt();
        damageCd = true;
        player.applyDamage(5f, test);
        yield return new WaitForSeconds(1.5f);
        damageCd = false;
    }
}